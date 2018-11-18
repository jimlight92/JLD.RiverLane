using BaseClasses.Fixtures;

namespace JLD.RiverLane.Services.Home
{
    public class HomeService : IHomeService
    {
        public HomeService(IHomeIndexService index)
        {
            Check.NotNull(index, nameof(index));
            Index = index;
        }

        public IHomeIndexService Index { get; }
    }
}