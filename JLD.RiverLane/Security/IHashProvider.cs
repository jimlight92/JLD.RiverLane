namespace JLD.RiverLane.Security
{
    /// <summary>
    /// Contains code for converting a password to a hash and a salt
    /// </summary>
    public interface IHashProvider
    {
        /// <summary>
        /// Returns a <see cref="HashSaltPair"/> containing a hash and the salt that was used to generate it
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        HashSaltPair GenerateHashAndSalt(string data);

        /// <summary>
        /// Returns a <see cref="HashSaltPair"/> of the given password generated using the given salt
        /// </summary>
        /// <param name="data"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        string GenerateHash(string data, string salt);
    }
}