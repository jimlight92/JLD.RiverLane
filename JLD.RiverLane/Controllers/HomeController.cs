using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;
using System.Web.Mvc;

namespace JLD.RiverLane.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}