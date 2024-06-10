using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using MyShoeWorldApp.Models;
using System.Data;
using System.ComponentModel;

namespace MyShoeWorldApp.Dal
{
    public class UserDal
    {
        private readonly string connectionString;
        public UserDal()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyShoeWorldConStr"].ConnectionString;
        }
        public int RegisterNewUser(User user)
        {
            using (MySqlConnection CN = new MySqlConnection(connectionString))
            {
                CN.Open();
                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = CN;
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "InsertUser";
                CMD.Parameters.AddWithValue("e_Email", user.Email);
                CMD.Parameters.AddWithValue("e_Password", user.Password);
                CMD.Parameters.AddWithValue("e_Role", user.Role);
                int result = CMD.ExecuteNonQuery();
                return result;
            }
        }
        public User CheckCredentials(User user)
        {
            using (MySqlConnection CN = new MySqlConnection(connectionString))
            {
                CN.Open();
                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = CN;
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "CheckCredentials";
                CMD.Parameters.AddWithValue("e_Email", user.Email);
                CMD.Parameters.AddWithValue("e_Password", user.Password);
                MySqlDataReader DR = CMD.ExecuteReader();
                DR.Read();
                return new User()
                {
                    Email = DR["Email"].ToString(),
                    Role= DR["Role"].ToString()
                };
            }
        }
    }
}