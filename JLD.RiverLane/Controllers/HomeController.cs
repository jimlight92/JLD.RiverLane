using System.Threading.Tasks;
using System.Web.Mvc;
using BaseClasses.Fixtures;
using JLD.RiverLane.Actions;
using JLD.RiverLane.Actions.Queries;
using JLD.RiverLane.ViewModels.Home;

namespace JLD.RiverLane.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IQuery<HomeIndexModel> query;

        public HomeController(IQuery<HomeIndexModel> query)
        {
            Check.NotNull(query, nameof(query));
            this.query = query;
        }

        public async Task<ActionResult> Index()
        {
            var result = await query.ExecuteAsync(Unit.Default);

            return View(result);
        }
    }
}