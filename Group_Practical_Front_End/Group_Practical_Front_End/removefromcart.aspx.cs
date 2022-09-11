using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class removefromcart : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            string returnTo = Request.QueryString["return"];
            int UserId = Convert.ToInt32(Session["UserId"]);
           // int add = Convert.ToInt32(Session["Add"]);

            if (sv.removeFromCart(UserId, id))
            {
                Response.Redirect(returnTo);
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }
    }
}