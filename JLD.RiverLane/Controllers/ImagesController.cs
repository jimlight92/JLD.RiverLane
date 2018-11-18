using System.IO;
using System.Web.Mvc;

namespace JLD.RiverLane.Controllers
{
    public class ImagesController : BaseController
    {
        public ActionResult Download(string filename, string folder)
        {
            var dir = Server.MapPath($"/Content/Images/{folder}/");
            var path = Path.Combine(dir, filename);
            var img = new FileInfo(path);

            if (img.Exists)
            {
                return File(System.IO.File.ReadAllBytes(path), "image/jpg");
            }

            return HttpNotFound();
        }
    }
}