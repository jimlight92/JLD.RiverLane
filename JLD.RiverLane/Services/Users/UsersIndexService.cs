using System.Collections.Generic;
using JLD.RiverLane.ViewModels.Users;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Models;
using AutoMapper;

namespace JLD.RiverLane.Services.Users
{
    public class UsersIndexService : IUsersIndexService
    {
        private readonly RiverLaneContext context;
        private readonly IMapper mapper;

        public UsersIndexService(RiverLaneContext context, IMapper mapper)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNull(mapper, nameof(mapper));

            this.context = context;
            this.mapper = mapper;
        }

        public UsersIndexModel Get()
        {
            var model = new UsersIndexModel();
            model.Users = mapper.Map<IEnumerable<UserModel>>(context.Users);

            return model;
        }
    }
}