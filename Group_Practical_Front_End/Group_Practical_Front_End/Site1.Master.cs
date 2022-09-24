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
                if (Session["UserType"].ToString().Equals("Customer"))
                {
                    user = sv.getUserById(Convert.ToInt32(Session["UserID"].ToString()));

                    account.InnerText = user.First_Name;
                    acc.Visible = true;
                    log.Visible = false;
                    sign.Visible = false;
                    sell.Visible = false;
                    wishListCartdiv.Visible = true;
                    addproduct.Visible = false;


                    // get items on users wish list
                    if (user.Wish_List == null)
                    {
                        wish_list_items.InnerText = "0";
                    }
                    else
                    {
                        string[] tokens = user.Wish_List.Split(' ');
                        wish_list_items.InnerText = Convert.ToString(tokens.Length - 1);
                    }

                    // get items on users Cart list
                    if (user.Cart_Items == null || user.Cart_Items.Equals(""))
                    {
                        cart_items.InnerHtml = "0";
                    }
                    else
                    {
                        string[] tokens = user.Cart_Items.Split(' ');
                        cart_items.InnerText = Convert.ToString(tokens.Length - 1);
                    }
                }
                else if (Session["UserType"].ToString().Equals("Seller"))
                {
                    Seller seller = new Seller();
                    seller = sv.getSellerByID(Convert.ToInt32(Session["UserID"].ToString()));
                    account.InnerText = seller.S_Name;

                    //enable and disable fields
                    acc.Visible = true;
                    log.Visible = false;
                    sign.Visible = false;
                    sell.Visible = false;
                    wishListCartdiv.Visible = true;
                    addproduct.Visible = true;
                    home.Visible = false;
                    Pages.Visible = false;
                    shop.InnerText = "My Products";
                    wishListCartdiv.Visible = false;
                }   
            }
            else
            {
                // get items from session cart
                if (Session["cart"] !=null)
                {
                    string[] tokens = Session["cart"].ToString().Split(' ');
                    cart_items.InnerText = Convert.ToString(tokens.Length - 1);
                }

                // disable logout button
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

        protected void RegisterSeller_Click(object sender, EventArgs e)
        {
            Response.Redirect("sellerregister.aspx");
        }
    }
}