using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Shared.Models;
using Shared.Interfaces;

namespace DataLayer
{
    public class UserRepository: IUserRepository
    {
        public List<string> GetAllEmailAddresses()
        {
            List<string> EmailAddresses = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString("PasswordManagerDB")))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SELECT EmailAddress FROM USERS";
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while(sqlDataReader.Read())
                    {
                        EmailAddresses.Add(sqlDataReader.GetString(0));
                    }
                }    
            }
            return EmailAddresses;
        }
       
        public void InsertUser(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString("PasswordManagerDB")))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "INSERT INTO USERS VALUES (@EmailAddress,@AuthKey,@Salt)";
                    sqlCommand.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    sqlCommand.Parameters.AddWithValue("@AuthKey", user.AuthKey);
                    sqlCommand.Parameters.AddWithValue("@Salt", user.Salt);
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        sqlConnection.Close();
                        throw;
                    }
                }
            }
        }
        public Dictionary<string, string> GetAuthKeyAndSalt(string emailAddress)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            using (SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString("PasswordManagerDB")))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SELECT AuthKey, Salt FROM USERS WHERE EmailAddress = @emailAddress";
                    sqlCommand.Parameters.AddWithValue("@emailAddress", emailAddress);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        dict.Add("AuthKey", sqlDataReader.GetString(0));
                        dict.Add("Salt", sqlDataReader.GetString(1));
                    }
                }

            }
            return dict;
        }
        public User GetUserInformation(string email)
        {
            User user = new User();
            using (SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString("PasswordManagerDB")))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SELECT * FROM USERS WHERE EmailAddress = @email";
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        user.UserID = sqlDataReader.GetInt32(0);
                        user.EmailAddress = sqlDataReader.GetString(1);
                        user.AuthKey = sqlDataReader.GetString(2);
                        user.Salt = sqlDataReader.GetString(3);
                    }
                }
            }
            return user;
        }

    }
    
}
