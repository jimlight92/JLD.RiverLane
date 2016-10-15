using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JLD.RiverLane.Infrastructure.Attributes
{
    public class AuthorizeRequestAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var loggedOn = httpContext.Session["loggedOn"];

            bool authorized = false;
            if (loggedOn == null || !bool.TryParse(loggedOn.ToString(), out authorized) || !authorized)
            {
                return false;
            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary 
                    {
                        { "action", "login" },
                        { "controller", "accounts" }
                    });
        }
    }
}