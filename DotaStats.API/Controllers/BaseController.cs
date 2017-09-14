using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using DotaStats.Core.Configuration;
using DotaStats.Services;

namespace DotaStats.API.Controllers
{
    [EnableCors(origins: "http://localhost:57111", headers: "*", methods: "GET,POST,PUT,DELETE,OPTIONS")]
    public class BaseController : ApiController
    {
        private IServices _services;

        public IServices Services => _services ?? (_services = ServiceFactory.Create(DotaStatsApplication.Environment.ServiceDependencies));

        public BaseController() { }

        public BaseController(IServiceDependencies dependencies)
        {
            this._services = ServiceFactory.Create(dependencies);
        }

        protected string HandleModelStateValidation(ModelStateDictionary modelState)
        {
            return "Invalid Model State. " + modelState.Values.Aggregate("", (current1, val) => val.Errors.Aggregate(current1, (current, error) =>
                       current + ("Error Message: " + error?.ErrorMessage + ", " + "Exception Message: " + error?.Exception?.Message + "/n")));
        }
    }
}
