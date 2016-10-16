using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;
using System.Web.Mvc;

namespace JLD.RiverLane.Controllers
{
    public class HomeController : BaseController
    {
        private readonly RiverLaneContext context;

        public HomeController(RiverLaneContext context)
        {
            Check.NotNull(context, nameof(context));
            this.context = context;
        }

        public ActionResult Index()
        {
            var user = new UserAccount("jimbo", "password");
            context.Users.Add(user);
            context.SaveChanges();

            var userAgain = context.Users.Find(user.Id);
            var passwordMatch = userAgain.PasswordIsMatch("password");

            userAgain.ChangePassword("another");

            passwordMatch = userAgain.PasswordIsMatch("password");
            passwordMatch = userAgain.PasswordIsMatch("another");

            return View();
        }
    }
}