using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.IntegrationTests.Fixtures
{
    public class DatabaseSeeder : IDatabaseSeeder<RiverLaneContext>
    {
        public void Seed(RiverLaneContext context)
        {
            context.Set<Settings>().Add(ModelFactory.Settings());
        }
    }
}
