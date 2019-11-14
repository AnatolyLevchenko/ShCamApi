using System;
using System.Security.Cryptography;
using System.Text;
using static System.String;

namespace Api.Auth
{
    internal class EncryptionHelper
    {
        public static string CreateHash(byte[] data, string hashAlgorithm = "SHA1")
        {
            if (IsNullOrEmpty(hashAlgorithm))
                hashAlgorithm = "SHA1";


            var algorithm = HashAlgorithm.Create(hashAlgorithm);
            if (algorithm == null)
                throw new ArgumentException("Unrecognized hash name");

            var hashByteArray = algorithm.ComputeHash(data);
            return BitConverter.ToString(hashByteArray).Replace("-", "");
        }
        public static string CreateSaltKey(int size)
        {
            // Generate a cryptographic random number
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        public static string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1")
        {
            return CreateHash(Encoding.UTF8.GetBytes(Concat(password, saltkey)), passwordFormat);
        }
    }
}
