using System.IO;
using System.Linq;
using System.Web;

namespace JLD.RiverLane.ViewModels.Shared
{
    public abstract class LayoutModel
    {
        protected LayoutModel(SlideshowGroupType group)
        {
            Slides = Directory.GetFiles(HttpContext.Current.Server.MapPath($"~/Content/Images/{group}/"))
                .Select(file => new Slide()
                {
                    FileName = file,
                    SlideshowGroup = group
                })
                .ToArray();
        }

        public Slide[] Slides { get; set; }
    }
}