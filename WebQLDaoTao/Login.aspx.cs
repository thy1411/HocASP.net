using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class Login : System.Web.UI.Page
    {
        UserDAO uDAO = new UserDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            if (uDAO.ValidateUser(username, password)) //Login 
            {
                FormsAuthentication.RedirectFromLoginPage(username, true); //Luu lai thong tin xac thuc
            }
            else
            {
                lbThongBao.Text = "Đăng nhập không thành công";
            }
        }
    }
}