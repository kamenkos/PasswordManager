using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Interfaces {
    public interface IUserBusiness {
        bool IsValidEmailAddress(string emailAddress);
        List<bool> ValidationOfPasswordRequirements(string password);
        bool IsEmailAddressExist(string emailAddress);
        void InsertUser(string emailAddress, string password);
        string CalculatePasswordStrength(string password);
        bool LoginValidation(string emailAddress, string password);
        User GetUserInformation(string email);

    }
}
