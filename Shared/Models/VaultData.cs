using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class VaultData
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public VaultData()
        { }

        public VaultData(string url, string name, string username, string password)
        {
            URL = url;
            Name = name;
            Username = username;
            Password = password;
        }
    }
}
