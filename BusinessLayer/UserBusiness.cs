using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces;
using Shared.Models;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Security.Cryptography;

namespace BusinessLayer
{

    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository userRepository;

        public UserBusiness(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }

        public UserBusiness() { }
        //  =================================== METHODS FOR VALIDATION  ===================================


        // Method for validating email from user input
        public bool IsValidEmailAddress(string emailAddress)
        {

            if (EmailValidationWithNetMail(emailAddress))
            {
                if (!IsEmailAddressContainsOtherSpecialChars(emailAddress))
                    return true;
            }

            return false;

        } // End of  IsValidEmailAddress method

        public bool EmailValidationWithNetMail(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }

        }


        public bool IsEmailAddressContainsOtherSpecialChars(string emailAddress)
        {
            emailAddress = emailAddress.Trim();

            emailAddress = RemoveValidSpecialCharactersFromString(emailAddress);

            Regex filter = new Regex(@"[^0-9a-zA-Z]+");

            if (filter.Match(emailAddress).Success)
                return true;

            return false;

        }


        private string RemoveValidSpecialCharactersFromString(string input)
        {
            string filteredString = "";
            foreach (var item in input)
            {
                if (!IsContainingSpecialCharacters(item.ToString()))
                    filteredString += item;
            }



            return filteredString;
        }




        // Method for checking if password contains special characters
        private bool IsContainingSpecialCharacters(string input)
        {

            char[] specialCharacters = new char[] {
           '`', '~', '!', '@', '#', '$', '%', '^',
            '&', '*', '(', ')', '-', '=', '+', '[',
            ']', '{', '}', '\\', '|', ';', '"', '\'',
            ',', '.', ':', '<', '>', '/', '?', '_'
            };


            return input.IndexOfAny(specialCharacters) != -1;

        }

        // Method for checking if user password fulfills minimum requirements
        public List<bool> ValidationOfPasswordRequirements(string password)
        {

            List<bool> requirements = new List<bool>() { false, false, false, false, false };


            // List[0] => true if password is 12 or more characters long
            // List[1] => true if password have at least one number
            // List[2] => true if password have at least one lowercase letter
            // List[3] => true if password have at least one uppercase letter
            // List[4] => true if password contains at least one special character

            if (password.Length >= 12)
                requirements[0] = true;
            if (Regex.Match(password, "[0-9]{1}").Success)
                requirements[1] = true;
            if (Regex.Match(password, "[a-z]{1}").Success)
                requirements[2] = true;
            if (Regex.Match(password, "[A-Z]{1}").Success)
                requirements[3] = true;
            if (IsContainingSpecialCharacters(password))
                requirements[4] = true;



            return requirements;
        }
        // End of  IsValidPassword() method


        // Method for checking if email address already exist if user try to register with same email address

        public bool IsEmailAddressExist(string emailAddress)
        {
            List<String> emailAddresses = userRepository.GetAllEmailAddresses();

            if (emailAddresses.Contains(emailAddress))
                return true;

            return false;
        }


        // End of method  IsEmailAddressExist(string emailAddress)

        public bool LoginValidation(string emailAddress, string password)
        {
            Dictionary<string, string> AuthKeyAndSalt = userRepository.GetAuthKeyAndSalt(emailAddress);

            string AuthKeyFromDataBase = AuthKeyAndSalt["AuthKey"];

            byte[] salt = Convert.FromBase64String(AuthKeyAndSalt["Salt"]);


            string AuthKey = CryptoHelper.CreateAuthKey(password, emailAddress, salt);

            if (AuthKeyFromDataBase == AuthKey)
                return true;


            return false;
        }



        //  =================================== END OF VALIDATION METHODS  ==========================


        //  =================================== PASSWORD METHODS  ===================================

        public int CalculatePasswordPoolSize(string password)
        {
            password = password.Trim();

            int passwordPoolSize = 0;

            List<int> poolSizes = new List<int>() { 10, 26, 26, 32 };

            List<bool> isPasswordContains = ValidationOfPasswordRequirements(password);

            for (int i = 0, j = 1; i < poolSizes.Count && j < 5; i++, j++)
            {
                if (isPasswordContains[j])
                {
                    passwordPoolSize += poolSizes[i];
                }
            }


            return passwordPoolSize;

        }


        public int CalculatePasswordEntropy(string password)
        {

            password = password.Trim();

            // Calcuate password entropy
            // Formula E = L * log2(R)
            // E = Entropy
            // L = password length
            // R = size of the pool

            int R;

            int L = password.Length;

            // Calculate R

            R = CalculatePasswordPoolSize(password);

            // To get log with base two u can do log(10)X / log(10)2

            // Calculate log(2) from R
            double E = Math.Log10(R) / Math.Log10(2);

            int positionOfDecimalDot = E.ToString().IndexOf('.');

            // Calculate password Entropy
            int integerValueOfE = Convert.ToInt32(E.ToString().Substring(0, positionOfDecimalDot)) * L;


            return integerValueOfE;

        }


        public int CalculatePasswordEntropyScore(string password)
        {

            int Score = 0;

            password = password.Trim();

            int entropy = CalculatePasswordEntropy(password);


            if (entropy <= 28) Score = 2;
            if (entropy > 28 && entropy <= 47) Score = 4;
            if (entropy > 47 && entropy <= 66) Score = 6;
            if (entropy > 66 && entropy <= 85) Score = 8;
            if (entropy > 85) Score = 10;

            return Score;

        }


        public bool CommonPasswordChecker(string password)
        {

            password = password.Trim();
            Regex filter = new Regex("(password|pass)", RegexOptions.IgnoreCase);

            var match = filter.Match(password);

            if (match.Success)
                return true;



            return false;

        }

        public List<string> ContainsNumbersInRange(string password)
        {

            password = password.Trim();

            Regex filter = new Regex(@"[0-9]{3,}");

            List<string> matchesList = new List<string>();
            foreach (Match match in filter.Matches(password))
            {
                matchesList.Add(match.ToString());
            }



            return matchesList;
        }

        public int CountTripletsInRange(string password)
        {

            int countTripletsSeries = 0;

            List<string> matchesList = ContainsNumbersInRange(password);
            foreach (string match in matchesList)
            {
                for (int i = 0; i < match.Length; i++)
                {
                    int first = (int)match[i] - '0';
                    // formula for sum from a .. b is (n/2)*(a+b)
                    int regularSum = Convert.ToInt32(((3 / 2.0)) * (first * 2 + 2));

                    int sum = 0;
                    int j = i;

                    if (j + 2 >= match.Length)
                        break;
                    for (j = i; j < i + 3; j++)
                    {
                        int value = (int)match[j] - '0';
                        sum += value;
                    }

                    if (regularSum == sum)
                        countTripletsSeries++;
                }
            }


            return countTripletsSeries;

        }

        public int CalculateNumberRangesScore(string password)
        {
            int Score = 8;

            int countTriplets = CountTripletsInRange(password);

            if (countTriplets != 0)
                Score += countTriplets * (-1);



            return Score;


        }

        public bool IsPasswordPredictable(string password)
        {
            password = password.Trim();

            Regex filterLowerCaseRange = new Regex(@"[a-z]{8,}");
            Regex filterUpperCaseRange = new Regex(@"[A-Z]{8,}");
            Regex filterNumberRange = new Regex(@"[0-9]{8,}");

            if (filterLowerCaseRange.IsMatch(password) || filterUpperCaseRange.IsMatch(password) || filterNumberRange.IsMatch(password))
                return true;

            return false;
        }

        public bool isPasswordValid(string password)
        {

            List<bool> requirements = ValidationOfPasswordRequirements(password);

            for (int i = 0; i < requirements.Count - 1; i++)
            {
                if (!requirements[i])
                    return false;
            }

            return true;
        }




        public string CalculatePasswordStrength(string password)
        {

            password = password.Trim();


            string resultScore = "Weak";

            if (IsPasswordPredictable(password) || CommonPasswordChecker(password) || !isPasswordValid(password))
            {
                resultScore = "Weak";
                return resultScore;

            }

            int entropyScore = CalculatePasswordEntropyScore(password);
            int numberRangesScore = CalculateNumberRangesScore(password);

            int averageScore = Convert.ToInt32((entropyScore + numberRangesScore) / 2.0);


            if (averageScore > 4 && averageScore <= 8)
                resultScore = "Fair";

            else if (averageScore > 8)
                resultScore = "Strong";

            return resultScore;

        }


        //  =================================== END OF PASSWORD METHODS  ==============================

        //  =================================== METHODS FOR WORKING WITH DATABASE  ============================




        // Method for inserting new User in database
        public void InsertUser(string password, string emailAddress)
        {
            password = password.Trim();
            emailAddress = emailAddress.Trim();

            // Create AuthKey and salt 
            byte[] saltBytes = CryptoHelper.CreateHashSalt();

            string saltString = Convert.ToBase64String(saltBytes);

            string AuthKey = CryptoHelper.CreateAuthKey(password, emailAddress, saltBytes);

            // Create User object
            User newUser = new User(emailAddress, AuthKey, saltString);

            // Call method from DataLayer through IUserRepository interface to insert User in database
            userRepository.InsertUser(newUser);

        } // End of method InsertUser()

        public User GetUserInformation(string email)
        {
            return userRepository.GetUserInformation(email);
        }




        //  =================================== END OF METHODS FOR WORKING WITH DATABASE  =====================

    }
}