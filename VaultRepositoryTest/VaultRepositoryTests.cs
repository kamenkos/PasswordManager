using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Shared.Models;
using DataLayer;

namespace VaultRepositoryTest
{
    [TestClass]
    public class VaultRepositoryTests
    {
        public Vault vault;
        public VaultRepository vaultRepository;
        public UserRepository userRepository;
        public string emailAddress;
        public User user;
        public string dataToInsert;
        public string dataToUpdate;

        [TestInitialize]
        public void init()
        {

            userRepository = new UserRepository();
            vaultRepository = new VaultRepository();

            emailAddress = "example@example.com";

            dataToInsert = "mqdGp9d8uXKi13x2xbI+IpQ060LlWKZbDO3wrBVxZcXeRfry133vwnW3b6KdYLISr3sEW1FOaP6MbrFhR10BuKsmpZQgB6QViSFCx5uCh0FHxhmCZp+G3gw+amhX2bsWBS5w/mYOdfNN5s8xPh38nL7xiu8C0ao/yyQhG0oeGvs=";
            dataToUpdate = "e6cTSdKsdFTeHZk4B9GluXi+Ynh+Mqfk6N5T2OuWDfMbvlMsOHVyDKmSYuyFcsAD+F4fBQV1iRICaslr2Cw9I4ZmhY6A7td4AqqLVvAyDxZr/qUS5CnChHDZt6dRc7Y1zm4RETJkXdV7AF4MV8NhYIbbQJR4g0v0rmCXpFTnT5g=";

            user = userRepository.GetUserInformation(emailAddress);


        }
        [TestMethod]
        public void IsVaultInserted()
        {
            bool result;
            try
            {
                vaultRepository.InsertVault(user.UserID, dataToInsert);
                result = true;
            }
            catch {

                result = false;
            }

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void IsVaultUpdated()
        {
            Vault vault = vaultRepository.GetUserVaults(user.UserID)[0];
            bool result;
            try
            {
                vaultRepository.UpdateVault(user.UserID, vault.VaultID, dataToUpdate);
                result = true;
            }
            catch
            {

                result = false;
            }

            Assert.IsTrue(result);

        }
        [TestMethod]
        public void GetAllUserVaultsTest()
        {
            Assert.IsNotNull(vaultRepository.GetUserVaults(user.UserID));
        }
    }
}
