using JLD.RiverLane.ViewModels.Shared;

namespace JLD.RiverLane.Services
{
    public interface ISlideshowResolver
    {
        TModel Resolve<TModel>(TModel model, SlideshowGroupType group) where TModel : LayoutModel;
    }
}