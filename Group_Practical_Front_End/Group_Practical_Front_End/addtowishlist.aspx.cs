using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class addtowishlist : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]); //ID of product to be added
                string returnTo = Request.QueryString["return"]; // this is the page we return to after adding 
                int UserId = Convert.ToInt32(Session["UserId"]); //ID of the user

                //add determines if we add or minus from the cart 0 for adding
                if(sv.addToWishList(UserId,id))
                {
                    Response.Redirect(returnTo);
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                string returnTo = Request.QueryString["return"];

                if (Session["wishlist"] != null)
                {
                    string session = Session["wishlist"].ToString();
                    Method_Container.addToWishList(id, ref session);
                    Session["wishlist"] = session;
                    Response.Redirect(returnTo);
                }
                else
                {
                    string session = "";
                    Method_Container.addToWishList(id, ref session);
                    Session["wishlist"] = session;
                    Response.Redirect(returnTo);
                }
            }
        }
    }
}