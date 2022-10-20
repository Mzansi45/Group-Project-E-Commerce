using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class removefromwishlist : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                string returnTo = Request.QueryString["return"];
                int UserId = Convert.ToInt32(Session["UserId"]);
                // int add = Convert.ToInt32(Session["Add"]);

                if (sv.removeFromWishList(UserId, id))
                {
                    Response.Redirect(returnTo);
                }
                else
                {
                    Response.Redirect("home.aspx");
                }
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                string returnTo = Request.QueryString["return"];
                if (Session["wishlist"] != null)
                {
                    string session = Session["wishlist"].ToString();
                    Method_Container.removeFromWishList(id, ref session);
                    Session["wishlist"] = session;
                    Response.Redirect(returnTo);
                }
                else
                {
                    string session = "";
                    Method_Container.removeFromWishList(id, ref session);
                    Session["wishlist"] = session;
                    Response.Redirect(returnTo);
                }
            }

        }
    }
}