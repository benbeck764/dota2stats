using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotaStats.Core.Configuration;

namespace DotaStats.API.Controllers
{
    [RoutePrefix("api/herorecords")]
    public class HeroRecordsController : BaseController
    {
        public HeroRecordsController() { }
        public HeroRecordsController(IServiceDependencies dependencies) : base(dependencies)  { }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllHeroRecords(long accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/herorecords/all/{accountId}", "Getting All Hero Records");
                var records = Services.Records.GetAll(accountId).OrderBy(r => r.Hero.LocalizedName).ToList();
                DotaStatsApplication.Logger.LogTrace($"GET api/herorecords/all/{accountId}", $"Found {records.Count} Records");
                return Ok(records);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/heroes/all/{accountId}", ex);
                return InternalServerError();
            }
        }
    }
}
