using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class register : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_Click(object sender, EventArgs e)
        {
            if(username.Value.Length<=0 || password.Value.Length<=0
                ||phone.Value.Length<=0||surname.Value.Length<=0 || name.Value.Length<=0)
            {
                errormessage.InnerText = "Invalid data input!";
                return;
            }

            //password validation
            if(confirmpass.Value.Length != password.Value.Length)
            {
                errormessage.InnerText = "Passwords do not match!!!";
                return;
            }

            string HashedPassword = HashPass.Secrecy.HashPassword(password.Value);
            if(sv.addUser(username.Value,HashedPassword,surname.Value,name.Value,email.Value,phone.Value))
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                errormessage.InnerText = "User already exists";
            }
        }
    }
}