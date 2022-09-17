using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class shop : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["category"]!=null)
            {
                string category = Request.QueryString["category"];
                if(category.Equals("discount"))
                {
                    //filter by discounted products
                    filterByDiscount();
                }else 
                {
                    filterByCategory(Request.QueryString["category"]);
                }
               
            }
            else
            {
                buttonHighights();

                List<Product> list = new List<Product>();

                dynamic prods = sv.getProducts().ToList();


                foreach (dynamic item in prods)
                {
                    list.Add(item);
                }

                productsSection.InnerHtml = "";
                foreach (Product prod in list)
                {
                    display(prod);
                }
            }

        }

        //@T gulube 219020988
        protected void All_Click(object sender, EventArgs e)
        {
            buttonHighights();

            List<Product> list = new List<Product>();

            dynamic prods = sv.getProducts().ToList();

            foreach (dynamic item in prods)
            {
                list.Add(item);
            }
            productsSection.InnerHtml = "";
            foreach(Product prod in list)
            {
                display(prod);
            }
            
        }

        //@T gulube 219020988
        protected void Black_Click(object sender, EventArgs e)
        {
            filterByColor("black");
        }
        protected void Red_Click(object sender, EventArgs e)
        {
            filterByColor("red");
        }
        protected void Gray_Click(object sender, EventArgs e)
        {
            filterByColor("gray");
        }
        protected void Blue_Click(object sender, EventArgs e)
        {
            filterByColor("blue");
        }
        protected void White_Click(object sender, EventArgs e)
        {
            filterByColor("white");
        }
        //@T gulube 219020988
        // filter by price functions
        protected void R500_Click(object sender, EventArgs e)
        {
            R500.BackColor = Color.Yellow;
            R400.BackColor = Color.LightGray;
            R300.BackColor = Color.LightGray;
            R200.BackColor = Color.LightGray;
            R100.BackColor = Color.LightGray;
            price_all.BackColor = Color.LightGray;
            filterByPrice(500);
        }
        //@T gulube 219020988
        protected void R400_Click(object sender, EventArgs e)
        {
            R500.BackColor = Color.LightGray;
            R400.BackColor = Color.Yellow;
            R300.BackColor = Color.LightGray;
            R200.BackColor = Color.LightGray;
            R100.BackColor = Color.LightGray;
            price_all.BackColor = Color.LightGray;
            filterByPrice(400);
        }
        //@T gulube 219020988
        protected void R300_Click(object sender, EventArgs e)
        {
            R500.BackColor = Color.LightGray;
            R400.BackColor = Color.LightGray;
            R300.BackColor = Color.Yellow;
            R200.BackColor = Color.LightGray;
            R100.BackColor = Color.LightGray;
            price_all.BackColor = Color.LightGray;
            filterByPrice(300);
        }
        //@T gulube 219020988
        protected void R200_Click(object sender, EventArgs e)
        {
            R500.BackColor = Color.LightGray;
            R400.BackColor = Color.LightGray;
            R300.BackColor = Color.LightGray;
            R200.BackColor = Color.Yellow;
            R100.BackColor = Color.LightGray;
            all_colors.BackColor = Color.LightGray;
            filterByPrice(200);
        }
        //@T gulube 219020988
        protected void R100_Click(object sender, EventArgs e)
        {
            R500.BackColor = Color.LightGray;
            R400.BackColor = Color.LightGray;
            R300.BackColor = Color.LightGray;
            R200.BackColor = Color.LightGray;
            R100.BackColor = Color.Yellow;
            all_colors.BackColor = Color.LightGray;
            filterByPrice(100);
        }

        //@T gulube 219020988
        //filter by category
        protected void Clothes_Click(object sender, EventArgs e)
        {
            tools.BackColor = Color.LightGray;
            furniture.BackColor = Color.LightGray;
            cameras.BackColor = Color.LightGray;
            drones.BackColor = Color.LightGray;
            clothes.BackColor = Color.Yellow;
            all_categories.BackColor = Color.LightGray;
            filterByCategory("clothe");
        }

        //@T gulube 219020988
        protected void Tools_Click(object sender, EventArgs e)
        {
            tools.BackColor = Color.Yellow;
            furniture.BackColor = Color.LightGray;
            cameras.BackColor = Color.LightGray;
            drones.BackColor = Color.LightGray;
            clothes.BackColor = Color.LightGray;
            all_categories.BackColor = Color.LightGray;
            filterByCategory("tool");
        }

        //@T gulube 219020988
        protected void Furniture_Click(object sender, EventArgs e)
        {
            tools.BackColor = Color.LightGray;
            furniture.BackColor = Color.Yellow;
            cameras.BackColor = Color.LightGray;
            drones.BackColor = Color.LightGray;
            clothes.BackColor = Color.LightGray;
            all_categories.BackColor = Color.LightGray;
            filterByCategory("furniture");
        }

        //@T gulube 219020988
        protected void Drones_Click(object sender, EventArgs e)
        {
            tools.BackColor = Color.LightGray;
            furniture.BackColor = Color.LightGray;
            cameras.BackColor = Color.LightGray;
            drones.BackColor = Color.Yellow;
            clothes.BackColor = Color.LightGray;
            all_categories.BackColor = Color.LightGray;

            filterByCategory("drone");
        }

        //@T gulube 219020988
        protected void Cameras_Click(object sender, EventArgs e)
        {
            tools.BackColor = Color.LightGray;
            furniture.BackColor = Color.LightGray;
            cameras.BackColor = Color.Yellow;
            drones.BackColor = Color.LightGray;
            clothes.BackColor = Color.LightGray;
            all_categories.BackColor = Color.LightGray;
            filterByCategory("camera");
        }

        //@T gulube 219020988
        public void filterByCategory(string Category)
        {
            List<Product> list = new List<Product>();

            dynamic prods = sv.getProducts().ToList();

            foreach (dynamic item in prods)
            {
                list.Add(item);
            }

            productsSection.InnerHtml = "";
            foreach (Product prod in list)
            {
                if(prod.Category.ToLower().Contains(Category.ToLower()))
                {
                    display(prod);
                }
            }

        }

        //@T gulube 219020988
        public void filterByColor(string Color)
        {
            List<Product> list = new List<Product>();

            dynamic prods = sv.getProducts().ToList();

            foreach (dynamic item in prods)
            {
                list.Add(item);
            }

            productsSection.InnerHtml = "";
            foreach (Product prod in list)
            {
                if(Color.ToLower().Equals(prod.Color.ToLower()))
                {
                    display(prod);
                }
            }
        }

        //@T gulube 219020988
        // filter products by discount
        public void filterByDiscount()
        {
            List<Product> list = new List<Product>();

            dynamic prods = sv.getProducts().ToList();

            foreach (dynamic item in prods)
            {
                list.Add(item);
            }

            productsSection.InnerHtml = "";
            foreach (Product prod in list)
            {
                if (prod.Discount_Price!=null) // get products with prices less than specified price
                {
                    display(prod);
                }
            }
        }

        //@T gulube 219020988
        // this filters products by their price
        public void filterByPrice(decimal price)
        {
            List<Product> list = new List<Product>();

            dynamic prods = sv.getProducts().ToList();

            foreach (dynamic item in prods)
            {
                list.Add(item);
            }

            productsSection.InnerHtml = "";
            foreach (Product prod in list) 
            {     
                if (prod.Product_Price <= price) // get products with prices less than specified price
                {
                    display(prod);
                }
            }
        }

        //@T gulube 219020988
        //pass a product and its is the displayed to shop
        public void display(Product prod)
        {       
            productsSection.InnerHtml += "<div class='col-lg-4 col-md-6 col-sm-6 pb-1'>";
            productsSection.InnerHtml += "<div class='product-item bg-light mb-4'>";
            productsSection.InnerHtml += "<div class='product-img position-relative overflow-hidden'>";
            productsSection.InnerHtml += "<a href='single.aspx?Id="+prod.Id+"'><img class='img-fluid w-100' src=" + prod.Image + " alt=''></a>";

            // disable cart/wish list options for users that are not logged in
            if (Session["LoggedIn"] != null)
            {
                productsSection.InnerHtml += "<div class='product-action'>";
            }
            else
            {
                productsSection.InnerHtml += "<div class='product-action' style='visibility:hidden;'>";
            }

            productsSection.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='addtocart.aspx?Id="+prod.Id+"&return=shop.aspx&Add=0'><i class='fa fa-shopping-cart'></i></a>";
            productsSection.InnerHtml += "<a class='btn btn-outline-dark btn-square' href=''><i class='far fa-heart'></i></a>";
            productsSection.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='shop.aspx'><i class='fa fa-sync-alt'></i></a>";
            productsSection.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='single.aspx?Id="+prod.Id+"'><i class='fa fa-search'></i></a></div></div>";
            productsSection.InnerHtml += "<div class='text-center py-4'>";
            productsSection.InnerHtml += "<a class='h6 text-decoration-none text-truncate' href='single.aspx?Id=" + prod.Id + "'>" + prod.Product_Name + "</a>";
            productsSection.InnerHtml += "<div class='d - flex align-items-center justify-content-center mt-2'>";
            if(prod.Discount_Price !=null)
            {
                productsSection.InnerHtml += "<a href='single.aspx?Id=" + prod.Id + "'>< h5>R" + String.Format("{0:0.##}", prod.Discount_Price) + "</h5><h6 class='text-muted ml-2'>R<del>" + String.Format("{0:0.##}", prod.Product_Price) + "</</del></h6></div></a>";
            }
            else
            {
                productsSection.InnerHtml += "<a href='single.aspx?Id=" + prod.Id + "'><h5>R" + String.Format("{0:0.##}", prod.Product_Price) + "</h5></div></a>";
            }
            productsSection.InnerHtml += "<div class='d-flex align-items-center justify-content-center mb-1'>";
            productsSection.InnerHtml += "<small class='fa fa-star text-primary mr-1'></small>";
            productsSection.InnerHtml += "<small class='fa fa-star text-primary mr-1'></small>";
            productsSection.InnerHtml += "<small class='fa fa-star text-primary mr-1'></small>";
            productsSection.InnerHtml += "<small class='fa fa-star text-primary mr-1'></small>";
            productsSection.InnerHtml += "<small class='fa fa-star text primary mr-1'></small>";
            productsSection.InnerHtml += "<small>(99)</small>";
            productsSection.InnerHtml += "</div></div></div></div>";
        }

        //@T gulube 219020988
        public void buttonHighights()
        {
            //price default colors
            R500.BackColor = Color.LightGray;
            R400.BackColor = Color.LightGray;
            R300.BackColor = Color.LightGray;
            R200.BackColor = Color.LightGray;
            R100.BackColor = Color.LightGray;
            price_all.BackColor = Color.Yellow;

            //category default colors
            tools.BackColor = Color.LightGray;
            furniture.BackColor = Color.LightGray;
            cameras.BackColor = Color.LightGray;
            drones.BackColor = Color.LightGray;
            clothes.BackColor = Color.LightGray;
            all_categories.BackColor = Color.Yellow;
        }
    }
}