using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class wishlist : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                User user = new User();
                user = sv.getUserById(Convert.ToInt32(Session["UserID"].ToString()));

                if(user.Wish_List !=null)
                {
                    string[] items = user.Wish_List.Split(' ');

                    List<string> list = new List<string>();

                    list = items.ToList();

                    list.Remove("");

                    List<Product> products = new List<Product>();

                    foreach (string item in list)
                    {
                        if (item.Equals(""))
                        {
                            continue;
                        }

                        Product product = new Product();
                        product = sv.getProductByID(Convert.ToInt32(item));

                        products.Add(product);
                    }

                    wish_table.InnerHtml = "";
                    //string table = "";
                    foreach (Product product in products)
                    {
                        wish_table.InnerHtml += "<tr>";
                        wish_table.InnerHtml += "<td class='align-middle'><img src='" + product.Image + "' alt='' style='width: 50px;'>" + product.Product_Name + "</td>";
                        wish_table.InnerHtml += "<td class='align-middle'>R" + String.Format("{0:0,##}",product.Product_Price) + "</td>";
                        wish_table.InnerHtml += "<td class='align-middle'><a class='btn btn-sm btn-danger' href='removefromwishlist.aspx?Id=" + product.Id + "&return=wishlist.aspx'><i class='fa fa-times'></i></a></td>";
                        wish_table.InnerHtml += "</tr>";
                    }
                }
                
            }
            else
            {
                if(Session["wishlist"]!=null)
                {
                    string wish_list = Session["wishlist"].ToString();
                    string[] items = wish_list.Split(' ');

                    List<string> list = new List<string>();

                    list = items.ToList();

                    list.Remove("");

                    List<Product> products = new List<Product>();

                    foreach (string item in list)
                    {
                        if(item.Equals(""))
                        {
                            continue;
                        }
                        Product product = new Product();
                        product = sv.getProductByID(Convert.ToInt32(item));

                        products.Add(product);
                    }

                    wish_table.InnerHtml = "";
                    foreach (Product product in products)
                    {
                        wish_table.InnerHtml += "<tr>";
                        wish_table.InnerHtml += "<td class='align-middle'><img src='"+product.Image+"' alt='' style='width: 50px;'>" + product.Product_Name + "</td>";
                        wish_table.InnerHtml += "<td class='align-middle'>" + product.Product_Price + "</td>";
                        wish_table.InnerHtml += "<td class='align-middle'><a class='btn btn-sm btn-danger' href='removefromwishlist.aspx?Id=" + product.Id + "&return=wishlist.aspx'><i class='fa fa-times'></i></a></td>";
                        wish_table.InnerHtml += "</tr>";
                    }
                }
                
            }
           
        }
    }
}