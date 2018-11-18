using System.IO;
using System.Linq;
using System.Web;
using JLD.RiverLane.ViewModels.Shared;

namespace JLD.RiverLane.Services
{
    public class SlideshowResolver : ISlideshowResolver
    {
        public TModel Resolve<TModel>(TModel model, SlideshowGroupType group) where TModel : LayoutModel
        {
            model.Slides = Directory.GetFiles(HttpContext.Current.Server.MapPath($"~/Content/Images/{group}/"))
                .Select(file => new Slide()
                {
                    FileName = file,
                    SlideshowGroup = group
                })
                .ToArray();

            return model;
        }
    }
}