using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLayer;

namespace ValidationOfUserFormFieldsTest
{
    [TestClass]
    public class ValidationTests
    {
        public UserBusiness userBusiness;

        [TestInitialize]
        public void init()
        {
            userBusiness = new UserBusiness();
        }
        [TestMethod]
        public void EmailValidation()
        {
            string emailValidOne = "test@email.com";
            string emailValidTwo = "test-123@domain123.com";

            string emailInvalidOne = "test#gmail.com";
            string emailInvalidTwo = "....@.....";
            string emailInvalidThree = "дсадас@gmail.com";

            Assert.IsTrue(userBusiness.IsValidEmailAddress(emailValidOne));
            Assert.IsTrue(userBusiness.IsValidEmailAddress(emailValidTwo));


            Assert.IsFalse(userBusiness.IsValidEmailAddress(emailInvalidOne));
            Assert.IsFalse(userBusiness.IsValidEmailAddress(emailInvalidTwo));
            Assert.IsFalse(userBusiness.IsValidEmailAddress(emailInvalidThree));
        }

        [TestMethod]
        public void PasswordStrengthValidation() {

            string passwordWeak = "password123";
            string passwordFair = "semiseCure13A#";
            string passwordStrong = "d1Sf-2^3c+Rq8g3";

            Assert.AreEqual(userBusiness.CalculatePasswordStrength(passwordWeak), "Weak");
            Assert.AreEqual(userBusiness.CalculatePasswordStrength(passwordFair), "Fair");
            Assert.AreEqual(userBusiness.CalculatePasswordStrength(passwordStrong), "Strong");
        }
    }
}
