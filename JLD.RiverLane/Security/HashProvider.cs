using JLD.RiverLane.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace JLD.RiverLane.Security
{
    /// <summary>
    /// Contains code for converting a password to a hash and a salt
    /// </summary>
    public class HashProvider : IHashProvider
    {
        /// <summary>
        /// Returns a <see cref="HashSaltPair"/> containing a hash and the salt that was used to generate it
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>

        public HashSaltPair GenerateHashAndSalt(string plainTextString)
        {
            Check.NotNullOrEmpty(plainTextString, nameof(plainTextString));

            var saltBytes = GenerateSalt(32);
            var hashBytes = GenerateHashBytes(plainTextString, saltBytes);

            var hash = Convert.ToBase64String(hashBytes);
            var salt = Convert.ToBase64String(saltBytes);

            return new HashSaltPair(hash, salt);
        }

        protected virtual byte[] GenerateSalt(int saltSize)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[saltSize];
            rng.GetBytes(buff);
            return buff;
        }

        private static byte[] GenerateHashBytes(string plainTextString, byte[] saltBytes)
        {
            var algorithm = new SHA256Managed();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainTextString);
            var plainTextWithSaltBytes = AppendByteArrays(plainTextBytes, saltBytes);
            var hashBytes = algorithm.ComputeHash(plainTextWithSaltBytes);
            return hashBytes;
        }

        private static byte[] AppendByteArrays(byte[] byteArray1, byte[] byteArray2)
        {
            var byteArrayResult =
                    new byte[byteArray1.Length + byteArray2.Length];

            for (var i = 0; i < byteArray1.Length; i++)
                byteArrayResult[i] = byteArray1[i];
            for (var i = 0; i < byteArray2.Length; i++)
                byteArrayResult[byteArray1.Length + i] = byteArray2[i];

            return byteArrayResult;
        }        

        /// <summary>
        /// Returns a <see cref="HashSaltPair"/> of the given password generated using the given salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string GenerateHash(string plainTextString, string salt)
        {
            Check.NotNullOrEmpty(plainTextString, nameof(plainTextString));
            Check.NotNullOrEmpty(salt, nameof(salt));

            var saltBytes = Convert.FromBase64String(salt);
            var hashBytes = GenerateHashBytes(plainTextString, saltBytes);

            var hash = Convert.ToBase64String(hashBytes);

            return hash;
        }
    }
}