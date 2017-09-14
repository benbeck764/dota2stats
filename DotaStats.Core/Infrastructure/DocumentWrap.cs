using System;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace DotaStats.Core.Infrastructure
{
    public class DocumentWrap<T> : Document
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Document")]
        public T Document { get; set; }
    }

    public static class DocumentWrapExtensions
    {
        public static DocumentWrap<T> Wrap<T>(this T obj, Func<T, string> selectId)
        {
            if (ReferenceEquals(obj, null)) return null;

            return new DocumentWrap<T>()
            {
                Id = selectId(obj),
                Document = obj,
                Type = obj.GetType().Name
            };
        }

        public static T Unwrap<T>(this DocumentWrap<T> document)
        {
            if (document != null)
                return document.Document;

            return default(T);
        }
    }
}
