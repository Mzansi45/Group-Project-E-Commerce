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
            string HashedPassword = HashPass.Secrecy.HashPassword(password.Value);
            if(sv.addUser(username.Value,HashedPassword,surname.Value,name.Value,email.Value,phone.Value))
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                errormessage.Visible = true;
            }
        }
    }
}