using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Shared.Models;
using DataLayer;

namespace UserRepositoryTest
{
    [TestClass]
    public class UserRepositoryTests
    {
        public User user;
        public UserRepository userRepository;
        [TestInitialize]
        public void init()
        {
            user = new User
            {

                EmailAddress = "example@example.com",
                AuthKey = "IYL4CJb0v0d1/aczHpkzuDtXlHV2gk2Y",
                Salt = "I4lZrxNPDOKFRqm0fJc6fQ=="

            };
            userRepository = new UserRepository();


        }
        [TestMethod]
        public void IsUserInserted()
        {
            bool result;
            try
            {
                userRepository.InsertUser(user);
                result = true;
            }
            catch
            {

                result = false;
            }

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void GetAllEmailsTest()
        {
            Assert.IsNotNull(userRepository.GetAllEmailAddresses());
        }
        [TestMethod]
        public void GetAuthKeyAndSaltTest()
        {
            Assert.IsNotNull(userRepository.GetAuthKeyAndSalt(user.EmailAddress));
        }

        [TestMethod]
        public void GetUserInformationTest()
        {
            Assert.IsNotNull(userRepository.GetUserInformation(user.EmailAddress));
        }

    }
}
