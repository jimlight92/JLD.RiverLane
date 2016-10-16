using JLD.RiverLane.Models;

namespace JLD.RiverLane.Security
{
    public class HashSaltPair
    {
        /// <summary>
        /// A container for a hash and the salt that was used to generate it
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="salt"></param>
        public HashSaltPair(string hash, string salt)
        {
            Check.NotNullOrEmpty(hash, nameof(hash));
            Check.NotNullOrEmpty(salt, nameof(salt));

            Hash = hash;
            Salt = salt;
        }

        public string Hash { get; }

        public string Salt { get; }
    }
}