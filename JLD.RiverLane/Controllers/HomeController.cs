using System.Web.Mvc;
using BaseClasses.Fixtures;
using JLD.RiverLane.Services.Home;

namespace JLD.RiverLane.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomeService service;

        public HomeController(IHomeService service)
        {
            Check.NotNull(service, nameof(service));
            this.service = service;
        }

        public ActionResult Index()
        {
            return View(service.Index.Get());
        }
    }
}