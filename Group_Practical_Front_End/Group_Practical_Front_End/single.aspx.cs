using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class single : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Id"] == null)
            {
                Response.Redirect("shop.aspx");
            }

            Product singleProduct = null;
            if (Request.QueryString["Id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);

                Product prod = new Product();

                prod = (Product)sv.getProductByID(Id);
                singleProduct = new Product();
                singleProduct = prod;

                image.InnerHtml = "<a href='editProduct.aspx?Id=" + prod.Id + "'><img class='w-100 h-100' src='" + prod.Image + "' alt='Image'></a>";
                product_name.InnerHtml = prod.Product_Name;
                if (prod.Discount_Price != null)
                {
                    price.InnerHtml = "<a href='editProduct.aspx?Id=" + prod.Id + "'>R" + String.Format("{0:0.##}", prod.Discount_Price) + "</a>";
                }
                else
                {
                    price.InnerHtml = "R" + String.Format("{0:0.##}", prod.Product_Price);
                }
                description.InnerText = prod.Description;
                description2.InnerText = prod.Description;

                // plus.InnerHtml = "<a href='addtocart.aspx?Id=" + prod.Id + "&return=single.aspx?Id="+prod.Id+"'><button class='btn btn-primary btn-plus'><i class='fa fa-plus'></i></button></a>";
            }
            
            // display cart button for Customer or edit button for Managers and sellers
            if (Session["UserType"]!=null && Session["UserType"].ToString().Equals("Customer"))
            {
                cart.Visible = true;
            }
            else if(Session["UserType"] != null && !Session["UserType"].ToString().Equals("Customer"))
            {
                edit.Visible = true;
            }
            else
            {
                cart.Visible = true;
            }

            /// similar products for customers
            if (Session["LoggedIn"] == null || Session["UserType"].ToString().Equals("Customer"))
            {
                List<Product> products = new List<Product>();
                products = sv.getProducts().ToList();

                int count = 0;
                may_like.InnerHtml = "";

                foreach (Product product in products)
                {
                    if (singleProduct.Category.ToLower().Contains(product.Category.ToLower())
                        || product.Manufacturer.ToLower().Equals(singleProduct.Manufacturer.ToLower())
                        || product.Product_Name.ToLower().Contains(singleProduct.Product_Name))
                    {
                        LoadSimilarProducts(product);

                        count++;
                    }

                    if (count > 6)
                    {
                        break;
                    }
                }
            }
            else
            {
                //disable for seller
                likes.Visible = false;
            }
            
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {

                int Id = Convert.ToInt32(Request.QueryString["Id"]);

                Product prod = new Product();

                prod = (Product)sv.getProductByID(Id);

                Response.Redirect("addtocart.aspx?Id=" + prod.Id + "&return=single.aspx?Id=" + prod.Id + "&Add=0");
           
        }

        protected void EditProduct_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            Product prod = new Product();

            prod = (Product)sv.getProductByID(Id);

            Response.Redirect("editProduct.aspx?Id=" + prod.Id + "&return=single.aspx?Id=" + prod.Id + "&Add=0");
        }

        private void LoadSimilarProducts(Product prod)
        { 

            may_like.InnerHtml += "<div class='product-item bg-light mb-4'>";
            may_like.InnerHtml += "<div class='product-img position-relative overflow-hidden'>";
            may_like.InnerHtml += "<img class='img-fluid w-100' src='"+prod.Image+"' alt=''>";
            may_like.InnerHtml += "<div class='product-action'>";
            may_like.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='addtocart.aspx?Id=" + prod.Id + "&return=shop.aspx&Add=0'><i class='fa fa-shopping-cart'></i></a>";
            may_like.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='addtowishlist.aspx?Id=" + prod.Id + "&return=shop.aspx'><i class='far fa-heart'></i></a>";
            may_like.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='#'><i class='fa fa-sync-alt'></i></a>";
            may_like.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='#'><i class='fa fa-search'></i></a></div></div>";
            may_like.InnerHtml += "<div class='text-center py-4'>";
            may_like.InnerHtml += "<a class='h6 text-decoration-none text-truncate' href='single.aspx?Id=" + prod.Id + "'>" + prod.Product_Name + "</a>";
            may_like.InnerHtml += "<div class='d - flex align-items-center justify-content-center mt-2'>";
            if (prod.Discount_Price != null)
            {
                may_like.InnerHtml += "<a href='#'><h5>R" + String.Format("{0:0.##}", prod.Discount_Price) + "</h5><h6 class='text-muted ml-2'>R<del>" + String.Format("{0:0.##}", prod.Product_Price) + "</</del></h6></div></a>";
            }
            else
            {
                may_like.InnerHtml += "<a href='#'><h5>R" + String.Format("{0:0.##}", prod.Product_Price) + "</h5></div></a>";
            }
            may_like.InnerHtml += "<div class='d-flex align-items-center justify-content-center mb-1'>";
            may_like.InnerHtml += "<small class='fa fa-star text-primary mr-1'></small>";
            may_like.InnerHtml += "<small class='fa fa-star text-primary mr-1'></small>";
            may_like.InnerHtml += "<small class='fa fa-star text-primary mr-1'></small>";
            may_like.InnerHtml += "<small class='fa fa-star text-primary mr-1'></small>";
            may_like.InnerHtml += "<small class='fa fa-star text primary mr-1'></small>";
            may_like.InnerHtml += "<small>(99)</small>";
            may_like.InnerHtml += "</div></div></div>";

            //may_like.InnerHtml += product;
            /*
             * 
             * 
             */
        }
    }
}