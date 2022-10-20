using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class newpassword : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["username"]!=null)
            {
                string username = Request.QueryString["username"];
                string email = Request.QueryString["email"];

                int userId = sv.getUserIdByEmail(username, email);
                
                if (password.Value.Length>0 && confirm_password.Value.Length>0)
                {
                    string hashedPass = HashPass.Secrecy.HashPassword(password.Value);
                        
                    if (sv.EditPassword(userId,hashedPass))
                    {
                        Response.Redirect("login.aspx");
                    }
                    else
                    {
                        error_message.InnerHtml = "<p style='color:Red;>Password reset failed</p>";
                    }
                }
                else
                {
                    error_message.InnerHtml = "<p style='color:Red;>Passwords Do not Match</p>";
                }
                
            }
        }
    }
}