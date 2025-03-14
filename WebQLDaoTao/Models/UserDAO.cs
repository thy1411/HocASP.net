using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class UserDAO
    {
        public bool ValidateUser(string username, string password)
        {
            bool isValid = false;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select pwd from users where uname=@uname", conn);
            cmd.Parameters.AddWithValue("@uname", username);
            String pwd = (string)cmd.ExecuteScalar();
            if (pwd == null)
            {
                return false;
            }
            else
            {
                isValid = string.Compare(pwd, password, false) == 0;
            }
            return isValid;
        }
    }
}