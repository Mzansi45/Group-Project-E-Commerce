using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class cart : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] !=null)
            {
                User user = new User();
                user = sv.getUserById(Convert.ToInt32(Session["UserID"].ToString()));

                //check if user has items in the cart
                if(user.Cart_Items!=null)
                {
                    string[] list = user.Cart_Items.Split(' ');

                    int size = list.Length;
                    List<Product> products = new List<Product>();

                    List<int> productId = new List<int>();
                    List<int> NumberOfItems = new List<int>();

                    for (int x = 0; x < size - 1; x++)
                    {

                        //get product Id and add it to the list of IDs
                        int index = list[x].IndexOf('(');
                        int l = list[x].Length;
                        list[x] = list[x].Remove(index, l - 1);
                        productId.Add(Convert.ToInt32(list[x]));

                    }

                    string[] list2 = user.Cart_Items.Split(' ');
                    for (int x = 0; x < size - 1; x++)
                    {
                        // get amount of prods per product
                        int startAt = list2[x].IndexOf('(');
                        string total = list2[x].Substring(startAt + 1);
                        total = total.Replace(")", string.Empty);
                        int number = Convert.ToInt32(total);
                        NumberOfItems.Add(number);
                    }

                    foreach (int id in productId)
                    {
                        products.Add(sv.getProductByID(id));
                    }

                    cart_items.InnerHtml = "";
                    decimal subtotal = 0;
                    for (int x = 0; x < size - 1; x++)
                    {
                        cart_items.InnerHtml += "<tr><td class='align-middle'><img src='" + products[x].Image + "' alt='' style='width: 50px;'><a href='single.aspx?Id=" + products[x].Id + "'> " + products[x].Product_Name + "<a style='visibility:hidden;'>" + products[x].Id +"</a></a></td>";
                        cart_items.InnerHtml += "<td class='align-middle'>R" + String.Format("{0:0.##}", products[x].Product_Price) + "</td><td class='align-middle'>";
                        cart_items.InnerHtml += "<div class='input-group quantity mx-auto' style='width: 100px;'>";
                        cart_items.InnerHtml += "<div class='input-group-btn'>";
                        cart_items.InnerHtml += "<a class='btn btn-sm btn-primary btn-minus' href='addtocart.aspx?Id=" + products[x].Id +"&return=cart.aspx&Add=-1'><i class='fa fa-minus'></i></a></div>";
                        //cart_items.InnerHtml += "<i class='fa fa-minus'></i></a></div>";
                        cart_items.InnerHtml += "<input type='text' class='form-control form-control-sm bg-secondary border-0 text-center' value='" + NumberOfItems[x] + "'>";
                        cart_items.InnerHtml += "<div class='input-group-btn'><a href='addtocart.aspx?Id=" + products[x].Id +"&return=cart.aspx&Add=0' class='btn btn-sm btn-primary btn-plus'>";
                        cart_items.InnerHtml += "<i class='fa fa-plus'></i></a></div></div></td>";
                        decimal tot = products[x].Product_Price * NumberOfItems[x];
                        subtotal += tot;
                        cart_items.InnerHtml += "<td class='align-middle'>R" + String.Format("{0:0.##}", tot) + "</td>";
                        /*<asp:LinkButton OnClick="AddToCart_Click" runat="server" class="btn btn-primary btn-plus">
                                    <i class="fa fa-plus"></i>
                                </asp:LinkButton>*/
                        cart_items.InnerHtml += "<td class='align-middle'><a class='btn btn-sm btn-danger' href='removefromcart.aspx?Id=" + products[x].Id +"&return=cart.aspx'><i class='fa fa-times'></i></a></td>";
                    }
                    shipping.InnerHtml = "R60";
                    subt.InnerHtml = "R" + String.Format("{0:0.##}", subtotal);

                    decimal totalCartPrice = subtotal + 60;
                    masterTotal.InnerHtml = "R" + String.Format("{0:0.##}", totalCartPrice);
                } 
                else
                {
                    //if user does have anything in their cart
                    shipping.InnerHtml = "R0";
                    cart_items.InnerHtml = "";
                    subt.InnerHtml = "R0";
                    masterTotal.InnerHtml = "R0";
                }
            }
            else
            {
                //create cart using session
                if (Session["cart"] != null)
                {
                    string[] list = Session["cart"].ToString().Split(' ');

                    int size = list.Length;
                    List<Product> products = new List<Product>();

                    List<int> productId = new List<int>();
                    List<int> NumberOfItems = new List<int>();

                    for (int x = 0; x < size - 1; x++)
                    {
                        //get product Id and add it to the list of IDs
                        int index = list[x].IndexOf('(');
                        int l = list[x].Length;
                        if(index<0)
                        {
                            Session["cart"] = "";
                            cart_items.InnerHtml = "";
                            return;
                        }
                        else
                        {
                            list[x] = list[x].Remove(index, l - 1); //flasgs an error when removing
                        }  
                        productId.Add(Convert.ToInt32(list[x]));
                    }

                    string[] list2 = Session["cart"].ToString().Split(' ');
                    for (int x = 0; x < size - 1; x++)
                    {
                        // get amount of prods per product
                        int startAt = list2[x].IndexOf('(');
                        string total = list2[x].Substring(startAt + 1);
                        total = total.Replace(")", string.Empty);
                        int number = Convert.ToInt32(total);
                        NumberOfItems.Add(number);
                    }

                    foreach (int id in productId)
                    {
                        products.Add(sv.getProductByID(id));
                    }

                    cart_items.InnerHtml = "";
                    decimal subtotal = 0;
                    for (int x = 0; x < size - 1; x++)
                    {
                        cart_items.InnerHtml += "<tr><td class='align-middle'><img src='" + products[x].Image + "' alt='' style='width: 50px;'><a href='single.aspx?Id=" + products[x].Id + "'> " + products[x].Product_Name + "<a style='visibility:hidden;'>" + products[x].Id + "</a></a></td>";
                        cart_items.InnerHtml += "<td class='align-middle'>R" + String.Format("{0:0.##}", products[x].Product_Price) + "</td><td class='align-middle'>";
                        cart_items.InnerHtml += "<div class='input-group quantity mx-auto' style='width: 100px;'>";
                        cart_items.InnerHtml += "<div class='input-group-btn'>";
                        cart_items.InnerHtml += "<a class='btn btn-sm btn-primary btn-minus' href='addtocart.aspx?Id=" + products[x].Id + "&return=cart.aspx&Add=-1'><i class='fa fa-minus'></i></a></div>";
                        //cart_items.InnerHtml += "<i class='fa fa-minus'></i></a></div>";
                        cart_items.InnerHtml += "<input type='text' class='form-control form-control-sm bg-secondary border-0 text-center' value='" + NumberOfItems[x] + "'>";
                        cart_items.InnerHtml += "<div class='input-group-btn'><a href='addtocart.aspx?Id=" + products[x].Id + "&return=cart.aspx&Add=0' class='btn btn-sm btn-primary btn-plus'>";
                        cart_items.InnerHtml += "<i class='fa fa-plus'></i></a></div></div></td>";
                        decimal tot = products[x].Product_Price * NumberOfItems[x];
                        subtotal += tot;
                        cart_items.InnerHtml += "<td class='align-middle'>R" + String.Format("{0:0.##}", tot) + "</td>";
                        /*<asp:LinkButton OnClick="AddToCart_Click" runat="server" class="btn btn-primary btn-plus">
                                    <i class="fa fa-plus"></i>
                                </asp:LinkButton>*/
                        cart_items.InnerHtml += "<td class='align-middle'><a class='btn btn-sm btn-danger' href='removefromcart.aspx?Id=" + products[x].Id + "&return=cart.aspx'><i class='fa fa-times'></i></a></td>";
                    }
                    shipping.InnerHtml = "R60";
                    subt.InnerHtml = "R" + String.Format("{0:0.##}", subtotal);

                    decimal totalCartPrice = subtotal + 60;
                    masterTotal.InnerHtml = "R" + String.Format("{0:0.##}", totalCartPrice);
                }
                else
                {
                    //if user does have anything in their cart
                    shipping.InnerHtml = "R0";
                    cart_items.InnerHtml = "";
                    subt.InnerHtml = "R0";
                    masterTotal.InnerHtml = "R0";
                }
            }
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx");
        }
    }
}