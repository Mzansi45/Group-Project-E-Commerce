using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class addtocart : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"]!=null)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]); //ID of product to be added
                string returnTo = Request.QueryString["return"]; // this is the page we return to after adding 
                int UserId = Convert.ToInt32(Session["UserId"]); //ID of the user

                //add determines if we add or minus from the cart 0 for adding
                if (Request.QueryString["Add"] != null)
                {
                    int add = Convert.ToInt32(Request.QueryString["Add"]);
                    if (sv.addToCart(UserId, id, add))
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
                    int add = 0;
                    if (sv.addToCart(UserId, id, add))
                    {
                        Response.Redirect(returnTo);
                    }
                    else
                    {
                        Response.Redirect("home.aspx");
                    }
                }
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                string returnTo = Request.QueryString["return"];

                if (Request.QueryString["Add"] != null)
                {
                    int add = Convert.ToInt32(Request.QueryString["Add"]);

                    if (Session["cart"] != null)
                    {
                        string session = Session["cart"].ToString();
                        Method_Container.addToSessionCart(id, ref session, add);
                        Session["cart"] = session;
                        Response.Redirect(returnTo);
                    }
                    else
                    {
                        string session = "";
                        Method_Container.addToSessionCart(id, ref session, add);
                        Session["cart"] = session;
                        Response.Redirect(returnTo);
                    }
                }
                else
                {
                    // operation for guest shoppers
                    int add = 0;
                    if (Session["cart"] != null)
                    {
                        string session = Session["cart"].ToString();
                        Method_Container.addToSessionCart(id, ref session, add);
                        Session["cart"] = session;
                        Response.Redirect(returnTo);
                    }
                    else
                    {
                        string session = "";
                        Method_Container.addToSessionCart(id, ref session, add);
                        Session["cart"] = session;
                        Response.Redirect(returnTo);
                    }
                }
            }           
        }
    }
}