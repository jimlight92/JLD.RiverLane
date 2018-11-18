using JLD.RiverLane.ViewModels.Home;
using JLD.RiverLane.ViewModels.Shared;

namespace JLD.RiverLane.Services.Home
{
    public class HomeIndexService : IHomeIndexService
    {
        private readonly ISlideshowResolver slideshowResolver;

        public HomeIndexService(ISlideshowResolver slideshowResolver)
        {
            this.slideshowResolver = slideshowResolver;
        }

        public HomeIndexModel Get()
        {
            return slideshowResolver.Resolve(new HomeIndexModel(), SlideshowGroupType.Main);
        }
    }
}