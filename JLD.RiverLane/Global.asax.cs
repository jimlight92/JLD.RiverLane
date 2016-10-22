using JLD.RiverLane.Security;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JLD.RiverLane
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest()
        {
            var tokenProvider = DependencyResolver.Current.GetService<ITokenProvider>();
            var principal = tokenProvider.GetUser();

            if (principal != null)
            {
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = HttpContext.Current.User;
            }
        }
    }
}
