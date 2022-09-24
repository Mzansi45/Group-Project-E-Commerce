using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class login : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender,EventArgs e)
        {
            string HashedPassword = HashPass.Secrecy.HashPassword(password.Value);

            if(manager.Checked)
            {
                //Response.Redirect("home.aspx");
                errormessage.Visible = true;
            }
            else if(customer.Checked)
            {
                if (sv.searchUser(username.Value, HashedPassword))
                {
                    Session["LoggedIn"] = true;
                    Session["UserID"] = sv.getUserID(username.Value, HashedPassword);
                    Session["UserType"] = "Customer";

                    Response.Redirect("home.aspx");
                }
                else
                {
                    //errormessage.InnerHtml = "Incorrect Username/Password";
                    errormessage.Visible = true;
                }
            }
            else
            {
                if (sv.searchSeller(username.Value, HashedPassword))
                {
                    Session["LoggedIn"] = true;
                    Session["UserID"] = sv.getSellerId(username.Value, HashedPassword);
                    Session["UserType"] = "Seller";

                    Response.Redirect("shop.aspx");
                }
                else
                {
                    //errormessage.InnerHtml = "Incorrect Username/Password";
                    errormessage.Visible = true;
                }
            }
        }
    }
}