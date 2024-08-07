using System.Security.Cryptography;
using System.Text;

namespace Spoleto.Delivery.Helpers
{
    public static class CryptoHelper
    {
        private static readonly SHA256 _cryptoProvider = SHA256.Create();
        private static readonly string _password = GetPassword();
        private static readonly object _lockObject = new();

        /// <summary>
        /// Decrypts string.
        /// </summary>
        /// <param name="string">The encoded string.</param>
        /// <returns>The decoded string.</returns>
        public static string? DecryptString(string? @string)
        {
            if (@string == null)
                return null;

            if (_password == null)
                throw new ArgumentNullException(nameof(_password));

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(@string);
            var passwordBytes = Encoding.UTF8.GetBytes(_password);
            lock (_lockObject)
            {
                passwordBytes = _cryptoProvider.ComputeHash(passwordBytes);
            }

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

            var result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        /// <summary>
        /// Encrypts string.
        /// </summary>
        /// <param name="string">The origin string.</param>
        /// <returns>The encoded string.</returns>
        public static string? EncryptString(string? @string)
        {
            if (@string == null)
                return null;

            if (_password == null)
                throw new ArgumentNullException(nameof(_password));

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(@string);
            var passwordBytes = Encoding.UTF8.GetBytes(_password);

            lock (_lockObject)
            {
                // Hash the password with SHA256
                passwordBytes = _cryptoProvider.ComputeHash(passwordBytes);
            }

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

            var result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        private static byte[] GetSalt()
        {
            return [18, 02, 7, 8, 8, 2, 2, 4];
        }

        private static byte[] Decrypt(byte[] encryptedBytes, byte[] passwordBytes)
        {
            byte[]? decryptedBytes = null;

            var saltBytes = GetSalt();

            // Create an Aes object
            // with the specified key and IV.
            using (var aesAlg = Aes.Create())
            {
                aesAlg.KeySize = 256;
                aesAlg.BlockSize = 128;

                var key = GetSecretKey(passwordBytes, saltBytes);

                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create a decrytor to perform the stream transform.
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        private static string GetPassword()
        {
            return "Delivery.C#_SDK";
        }

        private static Rfc2898DeriveBytes GetSecretKey(byte[] passwordBytes, byte[] saltBytes)
        {
#if NET
            return new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000, HashAlgorithmName.SHA1);
#else
            return new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
#endif
        }

        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[]? encryptedBytes = null;

            var saltBytes = GetSalt();

            // Create an Aes object
            // with the specified key and IV.
            using (var aesAlg = Aes.Create())
            {
                aesAlg.KeySize = 256;
                aesAlg.BlockSize = 128;

                var key = GetSecretKey(passwordBytes, saltBytes);

                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create a decrytor to perform the stream transform.
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (var ms = new MemoryStream())
                {
                    // Create a decrytor to perform the stream transform.
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encryptedBytes;
        }
    }
}
