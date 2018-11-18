using System;
using System.Web;
using System.Web.Mvc;

namespace JLD.RiverLane.Infrastructure.Attributes.Authorisation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class RiverLaneAuthoriseAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User is Security.RiverLanePrincipal;
        }
    }
}