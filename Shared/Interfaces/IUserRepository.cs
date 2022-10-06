using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;


namespace Shared.Interfaces
{
    public interface IUserRepository
    {
        List<string> GetAllEmailAddresses();
        void InsertUser(User user);

        Dictionary<string, string> GetAuthKeyAndSalt(string emailAddress);

        User GetUserInformation(string email);
    }
}
