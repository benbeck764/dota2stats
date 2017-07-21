using DotaStats.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotaStats.Model;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
//using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace DotaStats.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly IRepositoryConnection _connection;
        private DocumentClient _client;
        private Database _database = null;
        private DocumentCollection _collection = null;
        //private readonly RetryStrategy _retryStrategy;
        private readonly Func<BaseModel, string> _documentWrapExpression = i => i.Id.ToString("D");

        private DocumentClient Client => _client ?? (_client = new DocumentClient(new Uri(_connection.EndPointUrl), _connection.AuthorizationKey));

        public Repository(IRepositoryConnection connection)
        {
            this._connection = connection;
            //this._retryStrategy = RetryStrategy.DefaultExponential;
            //this._retryStrategy.FastFirstRetry = true;
        }

        public async Task Delete(T item)
        {
            await EnsureInitialized();
            var itemId = item.Id.ToString("D");
            DocumentWrap<T> existing = null;

            var queryADone = false;
            while (!queryADone)
            {
                try
                {
                    existing = _client
                        //.AsReliable(_retryStrategy)
                        .CreateDocumentQuery<DocumentWrap<T>>(_collection.DocumentsLink, new FeedOptions { EnableCrossPartitionQuery = true })
                        .Where(i => i.Id == itemId).AsEnumerable().SingleOrDefault();
                    queryADone = true;
                }
                catch (DocumentClientException documentClientException)
                {
                    handleDocumentClientException(documentClientException);
                }
                catch (AggregateException aggregateException)
                {
                    handleAggregateException(aggregateException);
                }
            }


            var queryBDone = false;
            if (existing == null) { return; }
            while (!queryBDone)
            {
                try
                {
                    await _client
                        //.AsReliable(_retryStrategy)
                        .DeleteDocumentAsync(existing.SelfLink, new RequestOptions() { PartitionKey = new PartitionKey(existing.Id) });
                    queryBDone = true;
                }
                catch (DocumentClientException documentClientException)
                {
                    handleDocumentClientException(documentClientException);
                }
                catch (AggregateException aggregateException)
                {
                    handleAggregateException(aggregateException);
                }
            }
        }

        public void Dispose()
        {
            Client?.Dispose();
        }

        public IQueryable<T> Query()
        {
            EnsureInitialized().ConfigureAwait(false).GetAwaiter().GetResult();
            IQueryable<T> res = null;

            var queryDone = false;
            while (!queryDone)
            {
                try
                {
                    res = _client
                        //.AsReliable(_retryStrategy)
                        .CreateDocumentQuery<DocumentWrap<T>>(_collection.DocumentsLink, new FeedOptions { EnableCrossPartitionQuery = true })
                        .Where(d => d.Type == typeof(T).Name)
                        .Select(d => d.Document);
                    queryDone = true;
                    return res;
                }
                catch (DocumentClientException documentClientException)
                {
                    handleDocumentClientException(documentClientException);
                }
                catch (AggregateException aggregateException)
                {
                    handleAggregateException(aggregateException);
                }
            }
            return res;
        }

        public IEnumerable<T> Query(string query)
        {
            EnsureInitialized().ConfigureAwait(false).GetAwaiter().GetResult();
            IEnumerable<T> res = null;

            var queryDone = false;
            while (!queryDone)
            {
                try
                {
                    res = _client
                        //.AsReliable(_retryStrategy)
                        .CreateDocumentQuery<DocumentWrap<T>>(_collection.DocumentsLink, query, new FeedOptions { EnableCrossPartitionQuery = true })
                        .AsEnumerable()
                        .Select(d => d.Document);
                    queryDone = true;
                    return res;
                }
                catch (DocumentClientException documentClientException)
                {
                    handleDocumentClientException(documentClientException);
                }
                catch (AggregateException aggregateException)
                {
                    handleAggregateException(aggregateException);
                }
            }
            return res;
        }

        public IQueryable<TObjType> QueryAllByType<TObjType>()
        {
            EnsureInitialized().ConfigureAwait(false).GetAwaiter().GetResult();
            IQueryable<TObjType> res = null;

            var queryDone = false;
            while (!queryDone)
            {
                try
                {
                    res = _client
                        //.AsReliable(_retryStrategy)
                        .CreateDocumentQuery<DocumentWrap<TObjType>>(_collection.DocumentsLink, new FeedOptions { EnableCrossPartitionQuery = true })
                        .Where(d => d.Type == typeof(TObjType).Name)
                        .Select(d => d.Document);
                    queryDone = true;
                    return res;
                }
                catch (DocumentClientException documentClientException)
                {
                    handleDocumentClientException(documentClientException);
                }
                catch (AggregateException aggregateException)
                {
                    handleAggregateException(aggregateException);
                }
            }
            return res;
        }

        public async Task Upsert(T item)
        {
            await EnsureInitialized();

            var queryDone = false;
            while (!queryDone)
            {
                try
                {
                    await _client
                        .UpsertDocumentAsync(_collection.DocumentsLink, item.Wrap(_documentWrapExpression));
                    queryDone = true;
                }
                catch (DocumentClientException documentClientException)
                {
                    handleDocumentClientException(documentClientException);
                }
                catch (AggregateException aggregateException)
                {
                    handleAggregateException(aggregateException);
                }
            }
        }

        #region Repository Helpers

        private async Task EnsureInitialized()
        {
            if (_database == null)
            {
                _database = await ReadOrCreateDatabase();
            }

            if (_collection == null)
            {
                _collection = await ReadOrCreateCollection(_database.SelfLink);
            }
        }

        private async Task<Database> ReadOrCreateDatabase()
        {
            Database db = null;
            var queryDone = false;
            while (!queryDone)
            {
                try
                {
                    db = Client.CreateDatabaseQuery()
                        .Where(d => d.Id == _connection.Database)
                        .AsEnumerable()
                        .FirstOrDefault();
                    queryDone = true;
                }
                catch (DocumentClientException documentClientException)
                {
                    handleDocumentClientException(documentClientException);
                }
                catch (AggregateException aggregateException)
                {
                    handleAggregateException(aggregateException);
                }
            }


            if (db == null)
            {
                queryDone = false;
                while (!queryDone)
                {
                    try
                    {
                        db = await Client.CreateDatabaseAsync(new Database { Id = _connection.Database });
                        queryDone = true;
                    }
                    catch (DocumentClientException documentClientException)
                    {
                        handleDocumentClientException(documentClientException);
                    }
                    catch (AggregateException aggregateException)
                    {
                        handleAggregateException(aggregateException);
                    }
                }

            }

            return db;
        }

        private async Task<DocumentCollection> ReadOrCreateCollection(string databaseLink)
        {
            DocumentCollection col = null;
            var queryDone = false;

            while (!queryDone)
            {
                try
                {
                    col = Client.CreateDocumentCollectionQuery(databaseLink)
                        .Where(c => c.Id == _connection.Collection)
                        .AsEnumerable()
                        .FirstOrDefault();
                    queryDone = true;
                }
                catch (DocumentClientException documentClientException)
                {
                    handleDocumentClientException(documentClientException);
                }
                catch (AggregateException aggregateException)
                {
                    handleAggregateException(aggregateException);
                }
            }



            if (col == null)
            {
                var collectionSpec = new DocumentCollection { Id = _connection.Collection, PartitionKey = new PartitionKeyDefinition { Paths = new Collection<string> { "/id" } } };
                var requestOptions = new RequestOptions { OfferType = _connection.RepositorySize, ConsistencyLevel = ConsistencyLevel.Eventual };
                queryDone = false;

                while (!queryDone)
                {
                    try
                    {
                        col = await Client.CreateDocumentCollectionAsync(databaseLink, collectionSpec, requestOptions);
                        queryDone = true;
                    }
                    catch (DocumentClientException documentClientException)
                    {
                        handleDocumentClientException(documentClientException);
                    }
                    catch (AggregateException aggregateException)
                    {
                        handleAggregateException(aggregateException);
                    }
                }
            }
            return col;
        }

        private void handleDocumentClientException(DocumentClientException documentClientException)
        {
            var statusCode = (int)documentClientException.StatusCode;
            if (statusCode == 429 || statusCode == 503)
                Thread.Sleep(documentClientException.RetryAfter);
            else
                throw documentClientException;
        }

        private void handleAggregateException(AggregateException aggregateException)
        {
            if (aggregateException.InnerException.GetType() == typeof(DocumentClientException))
            {

                var docExcep = aggregateException.InnerException as DocumentClientException;
                var statusCode = (int)docExcep.StatusCode;
                if (statusCode == 429 || statusCode == 503)
                    Thread.Sleep(docExcep.RetryAfter);
                else
                    throw aggregateException;
            }
        }

#endregion
    }
}
