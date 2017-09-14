using System;
using System.Web.Http;
using DotaStats.Core.Configuration;
using DotaStats.Model.Extensions;

namespace DotaStats.API.Controllers
{
    [RoutePrefix("api/statistics")]
    public class StatisticsController : BaseController
    {
        public StatisticsController() { }
        public StatisticsController(IServiceDependencies dependencies) : base(dependencies)  { }

        [HttpGet]
        [Route("kda")]
        public IHttpActionResult GetKDA(long accountId, int heroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/statistics/kda/accountId/{accountId}/heroId/{heroId}", "Getting KDA");
                var kda = Services.Statistics.GetKDA(accountId, heroId);
                DotaStatsApplication.Logger.LogTrace($"GET api/heroes/kda/accountId/{accountId}/heroId/{heroId}", $"Found KDA: {kda.ToJson()}");
                return Ok(kda);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/heroes/kda/accountId/{accountId}/heroId/{heroId}", ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("winrate")]
        public IHttpActionResult GetWinRate(long accountId, int heroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/statistics/winrate/accountId/{accountId}/heroId/{heroId}", "Getting WinRate");
                var winRate = Services.Statistics.GetWinRate(accountId, heroId);
                DotaStatsApplication.Logger.LogTrace($"GET api/heroes/winrate/accountId/{accountId}/heroId/{heroId}", $"Found WinRate: {winRate.ToJson()}");
                return Ok(winRate);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/heroes/winrate/accountId/{accountId}/heroId/{heroId}", ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("mostused")]
        public IHttpActionResult GetMostUsedItems(long accountId, int heroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/statistics/winrate/mostused/{accountId}/heroId/{heroId}", "Getting MostUsedItems");
                var mostUsedItems = Services.Statistics.GetMostUsedItems(accountId, heroId);
                DotaStatsApplication.Logger.LogTrace($"GET api/heroes/winrate/mostused/{accountId}/heroId/{heroId}", $"Found MostUsedItems: {mostUsedItems.ToJson()}");
                return Ok(mostUsedItems);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/heroes/winrate/mostused/{accountId}/heroId/{heroId}", ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("matches")]
        public IHttpActionResult GetMatchDetails(long accountId, int heroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/statistics/winrate/matches/{accountId}/heroId/{heroId}", "Getting MatchDetails");
                var matchDetails = Services.Statistics.GetMatchDetails(accountId, heroId);
                DotaStatsApplication.Logger.LogTrace($"GET api/heroes/winrate/matches/{accountId}/heroId/{heroId}", $"Found MatchDetails: {matchDetails.ToJson()}");
                return Ok(matchDetails);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/heroes/winrate/matches/{accountId}/heroId/{heroId}", ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("permin")]
        public IHttpActionResult GetPerMin(long accountId, int heroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/statistics/winrate/permin/{accountId}/heroId/{heroId}", "Getting XPM/GPM");
                var perMin = Services.Statistics.GetPerMin(accountId, heroId);
                DotaStatsApplication.Logger.LogTrace($"GET api/heroes/winrate/permin/{accountId}/heroId/{heroId}", $"Found XPM/GPM: {perMin.ToJson()}");
                return Ok(perMin);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/heroes/winrate/permin/{accountId}/heroId/{heroId}", ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("lhdeny")]
        public IHttpActionResult GetLastHitsAndDenies(long accountId, int heroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/statistics/winrate/permin/{accountId}/heroId/{heroId}", "Getting LastHitsAndDenies");
                var perMin = Services.Statistics.GetLastHitsAndDenies(accountId, heroId);
                DotaStatsApplication.Logger.LogTrace($"GET api/heroes/winrate/permin/{accountId}/heroId/{heroId}", $"Found LastHitsAndDenies: {perMin.ToJson()}");
                return Ok(perMin);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/heroes/winrate/permin/{accountId}/heroId/{heroId}", ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("bestversus")]
        public IHttpActionResult GetBestVersus(long accountId, int heroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/statistics/winrate/permin/{accountId}/heroId/{heroId}", "Getting BestVersus");
                var bv = Services.Statistics.GetBestVersus(accountId, heroId);
                DotaStatsApplication.Logger.LogTrace($"GET api/heroes/winrate/permin/{accountId}/heroId/{heroId}", $"Found LastHitsAndDenies: {bv.ToJson()}");
                return Ok(bv);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/heroes/winrate/permin/{accountId}/heroId/{heroId}", ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("worstversus")]
        public IHttpActionResult GetWorstVersus(long accountId, int heroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/statistics/worstversus/{accountId}/heroId/{heroId}", "Getting WorstVersus");
                var wv = Services.Statistics.GetWorstVersus(accountId, heroId);
                DotaStatsApplication.Logger.LogTrace($"GET api/statistics/worstversus/{accountId}/heroId/{heroId}", $"Found LastHitsAndDenies: {wv.ToJson()}");
                return Ok(wv);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/statistics/worstversus/{accountId}/heroId/{heroId}", ex);
                return InternalServerError();
            }
        }
    }
}
