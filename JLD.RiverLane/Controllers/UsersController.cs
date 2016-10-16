using JLD.RiverLane.Models;
using JLD.RiverLane.Services.Users;
using System.Web.Mvc;

namespace JLD.RiverLane.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUsersService service;

        public UsersController(IUsersService service)
        {
            Check.NotNull(service, nameof(service));
            this.service = service;
        }

        public ActionResult Index()
        {
            var model = service.Index.Get();
            return View(model);
        }
    }
}