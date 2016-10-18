using JLD.RiverLane.Models;
using JLD.RiverLane.Models.Enums;
using JLD.RiverLane.Services.Settings;
using JLD.RiverLane.ViewModels.Settings;
using System.Web.Mvc;

namespace JLD.RiverLane.Controllers
{
    public class SettingsController : BaseController
    {
        private readonly ISettingsService service;

        public SettingsController(ISettingsService service)
        {
            Check.NotNull(service, nameof(service));
            this.service = service;
        }

        public ActionResult Edit()
        {
            var model = service.Edit.Get();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SettingsEditModel model)
        {
            if (!ModelState.IsValid)
            {
                model = service.Edit.Get(model);
            }

            service.Edit.Post(model);

            RaiseAlert(AlertType.Success, "Changes successfully saved.");
            return RedirectToAction("Edit");
        }
    }
}