using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            
            if (Session["LoggedIn"] != null)
            {
                user = sv.getUserById(Convert.ToInt32(Session["UserID"].ToString()));
                account.InnerText = user.First_Name;
                acc.Visible = true;
                log.Visible = false;
                sign.Visible = false;
                sell.Visible = false;
            }
            else
            {
                acc.Visible = false;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("logout.aspx");
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
    }
}