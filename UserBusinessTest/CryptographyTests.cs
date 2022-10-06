using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Shared.Models;
using Shared.Interfaces;
using BusinessLayer;
using Moq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptographyTest
{
    [TestClass]
    public class CryptographyTests
    {
        [TestMethod]
        public void IsAuthKeyValid()
        {
            // Arrange
            string emailAddress = "example@example.com";
            string password = "zsE1Sw#N2*pSpMA";
            string salt = "I4lZrxNPDOKFRqm0fJc6fQ==";
            string authKey = "IYL4CJb0v0d1/aczHpkzuDtXlHV2gk2Y";

            // Act
            string createdAuthKey = CryptoHelper.CreateAuthKey(password, emailAddress, Convert.FromBase64String(salt));

            // Assert
            Assert.AreEqual(authKey, createdAuthKey);

        }
        [TestMethod]
        public void IsVaultKeyValid()
        {
            // Arrange
            string emailAddress = "example@example.com";
            string password = "zsE1Sw#N2*pSpMA";
            string salt = "I4lZrxNPDOKFRqm0fJc6fQ==";
            string vaultKey = "sc80thhDwkCWIaks48efJvw4QdoM7rxJlx8vba7x82s=";

            // Act
            string createdVaultKey = Convert.ToBase64String(CryptoHelper.CreateVaultKey(emailAddress, password, salt));

            // Assert
            Assert.AreEqual(vaultKey, createdVaultKey);

        }

        [TestMethod]
        public void IsDecryptionWorks()
        {
            // Arrange

            string emailAddress = "example@example.com";
            string password = "zsE1Sw#N2*pSpMA";
            string salt = "I4lZrxNPDOKFRqm0fJc6fQ==";



            string clearTextData = "{\"URL\":\"www.twitter.com\",\"Name\":\"Twitter\",\"Username\":\"testtwitter@email.com\",\"Password\":\"testtwitterpassword\"}";

            byte[] vaultKey = CryptoHelper.CreateVaultKey(emailAddress, password, salt);
            string encryptedData = "wMpWKP7qI5Qha1NS2r5d1hO6IUolpacndy9Y4taJycnGKaLl7tvHbmiDfQ11RZLzcM/3idEICwxmf1FXXVTJeW0EqVQedU7k36tH+tFKfD0NmUmjy7hul7kxYLcX+ZVGu0d4Fznlas5MOdoShLQecLakdkAho9IGmUeMV/Eq1jU=";


            // Act
            string decryptedData = CryptoHelper.DecryptData(encryptedData, vaultKey);

            // Assert

            Assert.AreEqual(clearTextData, decryptedData);

        }
    }
}
