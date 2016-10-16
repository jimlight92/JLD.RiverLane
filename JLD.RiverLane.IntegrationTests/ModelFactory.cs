using JLD.RiverLane.Models;

namespace JLD.RiverLane.IntegrationTests
{
    /// <summary>
    /// Contains code for building entities to use in database tests
    /// </summary>
    public class ModelFactory
    {
        /// <summary>
        /// Returns a valid user with the given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static UserAccount User(string username)
        {
            return new UserAccount(username, "any");
        }
    }
}
