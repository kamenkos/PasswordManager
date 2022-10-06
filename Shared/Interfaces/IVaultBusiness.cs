using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Interfaces
{
    public interface IVaultBusiness
    {
        List<Vault> GetUserVaults(int userID, string vaultKey);
        void InsertVault(int userID, string vaultKey, VaultData vaultData);
        void DeleteVault(int userID, int vaultID);
        void UpdateVault(int userID, int vaultID, string vaultKey, VaultData vaultData);
        string CreateVaultKey(string emailAddress, string password, string salt);
        string CreateRandomPassword(int length);
    }
}
