using System;
using BaseClasses.Models;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.IntegrationTests
{
    /// <summary>
    /// Contains code for building entities to use in database tests
    /// </summary>
    public class ModelFactory
    {
        /// <summary>
        /// Returns a valid address
        /// </summary>
        /// <returns></returns>
        public static Address Address()
        {
            return new Address();
        }

        /// <summary>
        /// Returns a valid Settings entity
        /// </summary>
        /// <returns></returns>
        public static Settings Settings()
        {
            return new Settings("any", "any", Address());
        }

        /// <summary>
        /// Returns a valid user with the given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static UserAccount User(string username)
        {
            var user = new UserAccount(username);
            user.ChangePassword("password");
            return user;
        }
    }
}
