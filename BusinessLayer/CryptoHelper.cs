using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class CryptoHelper
    {
        // Generate 24bytes long PBKDF2 hash 
        public static byte[] CreatePBKDF2Hash(string input, byte[] salt, int lengthInBytes)
        {
            // Generate the hash
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, iterations: 10000); // hard coded 10000 iterations
            return pbkdf2.GetBytes(lengthInBytes);
            // 24 bytes(192 bits) is for AuthKey
            // 32 bytes(256 bits) is for encryption/decryption key for AES256

        }


        // Generate a 128-bit salt using a random sequence of nonzero values
        public static byte[] CreateHashSalt()
        {
            byte[] salt = new byte[128 / 8];

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return salt;
        }


        // Generate AuthKey for authentication using PBKDF2 hash function

        // Formula: AuthKey = H(H(password,email)+password)
        // H (hash function) = PBKDF2
        public static string CreateAuthKey(string password, string email, byte[] salt)
        {

            byte[] AuthKeyHash = CreatePBKDF2Hash(Convert.ToBase64String(CreatePBKDF2Hash(password + email, salt, 24)) + password, salt, 24);


            return Convert.ToBase64String(AuthKeyHash);
        }


        // Generate VaultKey for data encryption/decryption using PBKDF2 hash function

        // Formula: VaultKey = H(email,password)
        // H (hash function) = PBKDF2

        public static byte[] CreateVaultKey(string emailAddress, string password, string saltBase64String)
        {
   
            byte[] salt = Convert.FromBase64String(saltBase64String);

            byte[] VaultKey = CreatePBKDF2Hash(emailAddress + password, salt, 32); // Key size is 32bytes(256bits) for AES256


            return VaultKey;
        }

        // AES SUPPORTS certain key sizes
        // 128bits(16bytes) -> AES128
        // 192bits(24bytes) -> AES192
        // 256bits(32bytes) -> AES256
        // so make sure your hashing function returnshash with that size
        public static string EncryptData(string data, byte[] key)
        {
            var aes = new AesCryptoServiceProvider();
            var iv = aes.IV;
            using (var memStream = new System.IO.MemoryStream())
            {
                memStream.Write(iv, 0, iv.Length);  // Add the IV to the first 16 bytes of the encrypted value
                using (var cryptStream = new CryptoStream(memStream, aes.CreateEncryptor(key, aes.IV), CryptoStreamMode.Write))
                {
                    using (var writer = new System.IO.StreamWriter(cryptStream))
                    {
                        writer.Write(data);
                    }
                }
                var buf = memStream.ToArray();
                return Convert.ToBase64String(buf, 0, buf.Length);
            }
        }

        // Method for decrypting vault data
        public static string DecryptData(string data, byte[] key)
        {
            var bytes = Convert.FromBase64String(data);
            var aes = new AesCryptoServiceProvider();
            using (var memStream = new System.IO.MemoryStream(bytes))
            {
                var iv = new byte[16];
                memStream.Read(iv, 0, 16);  // Pull the IV from the first 16 bytes of the encrypted value
                using (var cryptStream = new CryptoStream(memStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    using (var reader = new System.IO.StreamReader(cryptStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }





    }
}
