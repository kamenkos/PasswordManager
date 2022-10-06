using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Vault
    {
        public int VaultID { get; set; }
        public int UserID { get; set; }
        public string VaultDataEncrypted { get; set; }
        public VaultData VaultDataDecrypted { get; set; }
        public Vault()
        { }
        public Vault(int userID, int vaultID, string vaultDataEncrypted, VaultData vaultDataDecrypted)
        {
            UserID = userID;
            VaultID = vaultID;
            VaultDataEncrypted = vaultDataEncrypted;
            VaultDataDecrypted = vaultDataDecrypted;
        }

    }
}
