using JLD.RiverLane.Services.Accounts;
using JLD.RiverLane.ViewModels.Accounts;
using System.Web.Mvc;
using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using BaseClasses.Infrastructure.Attributes;
using BaseClasses.Security;

namespace JLD.RiverLane.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IAccountsService service;

        public AccountsController(IAccountsService service)
        {
            Check.NotNull(service, nameof(service));
            this.service = service;
        }

        public ActionResult Login(string returnUrl, bool? logOut)
        {
            if (returnUrl == "/")
            {
                return RedirectToAction("");
            }

            if (logOut.GetValueOrDefault())
            {
                ModelState.AddModelError("", "You have been successfully logged out.");
            }
            else if (!string.IsNullOrEmpty(returnUrl))
            {
                ModelState.AddModelError("", "You must sign in to access this page.");
            }

            var model = service.Index.Get();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var loginResult = service.Index.Post(model);

            if (loginResult != AuthenticationResult.Success)
            {
                ModelState.AddModelError("", loginResult.GetCustomAttribute<MessageAttribute>().Message);
                return View(model);
            }

            service.User.SignIn(model.Username);

            if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
            {
                return Redirect(Request["ReturnUrl"]);
            }
            else
            {
                return RedirectToAction("index", "dashboard");
            }
        }

        public ActionResult LogOut()
        {
            service.User.LogOut();
            return RedirectToAction("login", new { logOut = true });
        }
    }
}