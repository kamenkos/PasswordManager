using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;
using Shared.Interfaces;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BusinessLayer
{
    public class VaultBusiness : IVaultBusiness
    {
        private readonly IVaultRepository vaultRepository;


        public VaultBusiness(IVaultRepository _vaultRepository)
        {
            this.vaultRepository = _vaultRepository;
        }
        // ============================ METHODS FOR DATA MANIPULATION =================================


        public string ConvertVaultDataObjectToJsonString(VaultData vaultData)
        {
            return JsonSerializer.Serialize(vaultData);

        }

        public VaultData ConvertJsonStringToObjectVaultData(string vaultDataJsonString)
        {
            return JsonSerializer.Deserialize<VaultData>(vaultDataJsonString);
        }

        // ========================== END OF METHODS FOR DATA MANIPULATION ============================


        //  ============================== METHODS FOR WORKING WITH DATABASE  =========================

        public List<Vault> GetUserVaults(int userID, string vaultKey)
        {

            List<Vault> vaults = vaultRepository.GetUserVaults(userID);

            if (vaults.Count != 0)
            {

                byte[] vaultKeyBytes = Convert.FromBase64String(vaultKey);

                foreach (Vault vault in vaults)
                {
                    string decryptedVaultData = CryptoHelper.DecryptData(vault.VaultDataEncrypted, vaultKeyBytes);

                    VaultData vaultData = ConvertJsonStringToObjectVaultData(decryptedVaultData);

                    vault.VaultDataDecrypted = vaultData;
                }

            }
            return vaults;

        }

        public void InsertVault(int userID, string vaultKey, VaultData vaultData)
        {
            string vaultDataJsonString = ConvertVaultDataObjectToJsonString(vaultData);

            byte[] vaultKeyBytes = Convert.FromBase64String(vaultKey);

            string vaultEncrypted = CryptoHelper.EncryptData(vaultDataJsonString, vaultKeyBytes);

            vaultRepository.InsertVault(userID, vaultEncrypted);

        }

        public void DeleteVault(int userID, int vaultID)
        {
            vaultRepository.DeleteVault(userID, vaultID);
        }

        public void UpdateVault(int userID, int vaultID, string vaultKey, VaultData vaultData)
        {

            string vaultDataJsonString = ConvertVaultDataObjectToJsonString(vaultData);

            byte[] vaultKeyBytes = Convert.FromBase64String(vaultKey);

            string vaultEncrypted = CryptoHelper.EncryptData(vaultDataJsonString, vaultKeyBytes);

            vaultRepository.UpdateVault(userID, vaultID, vaultEncrypted);

        }

        //  ============================ END OF METHODS FOR WORKING WITH DATABASE  =====================


        public string CreateVaultKey(string emailAddress, string password, string salt)
        {
            return Convert.ToBase64String(CryptoHelper.CreateVaultKey(emailAddress, password, salt));
        }



        // Method for creating random password
        public string CreateRandomPassword(int length)
        {// Characters allowed in password
            string upperCase = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            string lowerCase = "abcdefghijklmnopqrstuvwxyz";

            string numbers = "0123456789";

            string specialCharacters = "!@#$%^&*?_-";
            Random random = new Random();


            string all = $"{upperCase}{lowerCase}{numbers}{specialCharacters}";

            char[] chars = new char[length];

            // Ensure password has at least one uppercase, number and special character
            chars[random.Next(0, length)] = upperCase[random.Next(0, upperCase.Length)];
            chars[random.Next(0, length)] = numbers[random.Next(0, numbers.Length)];
            chars[random.Next(0, length)] = specialCharacters[random.Next(0, specialCharacters.Length)];



            for (int i = 0; i < length; i++)
            {
                if (chars[i] == '\0')
                    chars[i] = all[random.Next(0, all.Length)];
            }


            return new string(chars);
        }
        // End of method CreateRandomPassword(int length)
    }
}
