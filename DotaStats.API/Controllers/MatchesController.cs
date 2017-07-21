using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotaStats.Core.Configuration;
using DotaStats.Model.Extensions;

namespace DotaStats.API.Controllers
{
    [RoutePrefix("api/matches")]
    public class MatchesController : BaseController
    {
        public MatchesController() { }
        public MatchesController(IServiceDependencies dependencies) : base(dependencies)  { }

        [HttpGet]
        [Route("{matchId}")]
        public IHttpActionResult GetByAccountAndHero(long matchId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/matches/{matchId}", "Getting Matches by Account/Hero");
                var match = Services.Matches.Get(matchId);
                DotaStatsApplication.Logger.LogTrace($"GET api/matches/{matchId}", $"Found {match.ToJson()} Matches");
                return Ok(match);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/matches/{matchId}", ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("account/{accountId}/hero/{heroId}")]
        public IHttpActionResult GetByAccountAndHero(long accountId, int heroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/matches/account{accountId}/hero/{heroId}", "Getting Matches by Account/Hero");
                var matches = Services.Matches.GetByAccountAndHero(accountId, heroId).ToList();
                DotaStatsApplication.Logger.LogTrace($"GET api/matches/account{accountId}/hero/{heroId}", $"Found {matches.Count()} Matches");
                return Ok(matches);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/matches/account{accountId}/hero/{heroId}", ex);
                return InternalServerError();
            }
        }
    }
}