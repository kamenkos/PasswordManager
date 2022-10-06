using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Interfaces
{
    public interface IVaultRepository
    { 
        List<Vault> GetUserVaults(int userID);
        void InsertVault(int userID, string encryptedVaultData);
        void DeleteVault(int userID, int vaultID);
        void UpdateVault(int userID, int vaultID, string encryptedVaultData);
    }
}
