using System;
using System.Security.Cryptography;
using System.Text;

namespace Qitchen.Helpers
{
    public static class AuthHelper
    {
        private static string PASSWORD_SALT = "helloworld123";

        public static string GeneratePasswordHash(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(password + PASSWORD_SALT);
            var encodingBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodingBytes).Replace("-", "").ToLower();
		}

		private static string SESSION_SALT = "ASDAFASFAS";

		public static string GenerateSessionToken(string login)
		{
            // Generate random token salt.
            var rand = new Random();
            var bytes = new byte[32];
            rand.NextBytes(bytes);
            string rndSalt = Convert.ToBase64String(bytes);

            var strToken = rndSalt + login + SESSION_SALT;

            using (var md5 = new MD5CryptoServiceProvider())
			{
				var originalBytes = Encoding.Default.GetBytes(strToken);
				var encodingBytes = md5.ComputeHash(originalBytes);
				return BitConverter.ToString(encodingBytes).Replace("-", "").ToLower();
			}
		}
	}
}
