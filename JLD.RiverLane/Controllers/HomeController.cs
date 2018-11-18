using System.Web.Mvc;
using JLD.RiverLane.ViewModels.Home;

namespace JLD.RiverLane.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeIndexModel());
        }
    }
}