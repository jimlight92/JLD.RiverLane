using JLD.RiverLane.Infrastructure.Attributes;
using JLD.RiverLane.Models.Enums;
using System.ComponentModel;
using System.Web.Mvc;

namespace JLD.RiverLane.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Returns a JSON response that redirects to a specified action.
        /// </summary>
        /// <param name="actionName">The action to redirect to.</param>
        protected JsonResult JsonRedirect(string actionName)
        {
            return Json(new { url = Url.Action(actionName), success = true });
        }

        /// <summary>
        /// Returns a JSON response that redirects to a specified action with a specified route values
        /// </summary>
        /// <param name="actionName">The action to redirect to.</param>
        protected JsonResult JsonRedirect(string actionName, object routeValues)
        {
            return Json(new { url = Url.Action(actionName, routeValues), success = true });
        }

        /// <summary>
        /// Raise a one-time alert of the specified type with the specified message
        /// </summary>
        /// <param name="alertType">The type of alert</param>
        /// <param name="message">The message to display</param>
        protected void RaiseAlert(AlertType alertType, string message)
        {
            var style = alertType.GetAttribute<DescriptionAttribute>().Description;
            var glyphicon = alertType.GetAttribute<GlyphiconAttribute>().Glyphicon;

            TempData["style"] = style;
            TempData["message"] = message;
            TempData["icon"] = $"glyphicon glyphicon-{glyphicon}";
        }
    }
}