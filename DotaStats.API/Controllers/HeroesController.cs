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
    [RoutePrefix("api/heroes")]
    public class HeroesController : BaseController
    {
        public HeroesController() { }
        public HeroesController(IServiceDependencies dependencies) : base(dependencies)  { }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllHeroes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(HandleModelStateValidation(this.ModelState));
            }
            try
            {
                DotaStatsApplication.Logger.LogTrace($"GET api/heroes/all", "Getting All Heroes");
                var heroes = Services.Heroes.GetAll().OrderBy(h => h.LocalizedName).ToList();
                DotaStatsApplication.Logger.LogTrace($"GET api/heroes/all", $"Found {heroes.Count} Heroes");
                return Ok(heroes);
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException($"GET api/heroes/all", ex);
                return InternalServerError();
            }
        }
    }
}
