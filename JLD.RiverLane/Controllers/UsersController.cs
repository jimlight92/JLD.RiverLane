using JLD.RiverLane.Models;
using JLD.RiverLane.Services.Users;
using JLD.RiverLane.ViewModels.Users;
using System.Web.Mvc;
using BaseClasses.Fixtures;
using BaseClasses.Helpers;

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

        public ActionResult Create()
        {
            var model = service.Create.Get();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                model = service.Create.Get(model);
                return View(model);
            }

            service.Create.Post(model);

            return RedirectToAction("index");
        }
    }
}