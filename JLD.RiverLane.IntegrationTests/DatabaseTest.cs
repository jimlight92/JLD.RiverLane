using AutoMapper;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.IntegrationTests.Fixtures;
using System;
using Xunit;

namespace JLD.RiverLane.IntegrationTests
{
    [Trait("Database Test", "Database Test")]
    public abstract class DatabaseTest : IDisposable
    {
        private readonly RiverLaneContext context;
        private readonly IMapper mapper;

        protected DatabaseTest()
        {
            context = new RiverLaneContext();

            var config = new MapperConfiguration(cfg => AutoMapperConfig.Configure(cfg));
            mapper = config.CreateMapper();

            deleter.DeleteAll(Context);
            seeder.Seed(Context);
        }

        protected RiverLaneContext Context
        {
            get { return context; }
        }

        protected IMapper Mapper
        {
            get { return mapper; }
        }

        private IDatabaseDeleter<RiverLaneContext> deleter
        {
            get { return new DatabaseDeleter(); }
        }

        private IDatabaseSeeder<RiverLaneContext> seeder
        {
            get { return new DatabaseSeeder(); }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
