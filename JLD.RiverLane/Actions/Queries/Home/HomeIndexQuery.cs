using System.Threading.Tasks;
using JLD.RiverLane.Services;
using JLD.RiverLane.ViewModels.Home;
using JLD.RiverLane.ViewModels.Shared;

namespace JLD.RiverLane.Actions.Queries.Home
{
    public class HomeIndexQuery : IQuery<HomeIndexModel>
    {
        private readonly ISlideshowResolver slideshowResolver;

        public HomeIndexQuery(ISlideshowResolver slideshowResolver)
        {
            this.slideshowResolver = slideshowResolver;
        }
        
        public Task<ResultWrapper<HomeIndexModel>> Execute(Unit model)
        {
            return Task.FromResult(new ResultWrapper<HomeIndexModel>(slideshowResolver.Resolve(new HomeIndexModel(), SlideshowGroupType.Main)));
        }
    }
}