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

            if(username.Value.Length<=0 || password.Value.Length<=0)
            {
                //errormessage.InnerHtml = "Incorrect Username/Password";
                errormessage.Visible = true;
                return;
            }

            string HashedPassword = HashPass.Secrecy.HashPassword(password.Value);  

            if(manager.Checked)
            {
                if (sv.searchEmployee(username.Value, HashedPassword))
                {
                    Session["LoggedIn"] = true;
                    Session["UserID"] = sv.getEmployeeID(username.Value, HashedPassword);
                    Session["UserType"] = "Manager";

                    int id = Convert.ToInt32(sv.getEmployeeID(username.Value, HashedPassword));
                     Response.Redirect("shop.aspx");       
                }
                else
                {
                    //errormessage.InnerHtml = "Incorrect Username/Password";
                    errormessage.Visible = true;
                }
            }
            else if(customer.Checked)
            {
                if (sv.searchUser(username.Value, HashedPassword))
                {
                    Session["LoggedIn"] = true;
                    Session["UserID"] = sv.getUserID(username.Value, HashedPassword);
                    Session["UserType"] = "Customer";

                    int id = Convert.ToInt32(sv.getUserID(username.Value, HashedPassword));

                    if (sv.setUserActive(id,DateTime.Now))
                    {
                        Response.Redirect("home.aspx");
                    }      
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

                    int id = Convert.ToInt32(sv.getSellerId(username.Value, HashedPassword));

                    if(sv.setSellerActive(id,DateTime.Now))
                    {
                        Response.Redirect("shop.aspx");
                    }
                    
                }
                else
                {
                    //errormessage.InnerHtml = "Incorrect Username/Password";
                    errormessage.Visible = true;
                }
            }

            if(!manager.Checked && !seller.Checked && !customer.Checked)
            {
                if (sv.searchUser(username.Value, HashedPassword))
                {
                    Session["LoggedIn"] = true;
                    Session["UserID"] = sv.getUserID(username.Value, HashedPassword);
                    Session["UserType"] = "Customer";

                    int id = Convert.ToInt32(sv.getUserID(username.Value, HashedPassword));

                    if (sv.setUserActive(id, DateTime.Now))
                    {
                        Response.Redirect("home.aspx");
                    }
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