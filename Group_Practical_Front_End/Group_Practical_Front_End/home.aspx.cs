using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    //structure for category at home.
    public struct category
    {
        public string name;
        public string image;
        public int items;
    };

    public partial class home : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        List<category> list = new List<category>();

        // this function add all categories available to the list
        //@T Gulube 219020988
        private void setCategory()
        {
            //shoes category
            category shoes = new category();
            shoes.name = "Shoes";
            shoes.image = "img/cat-3.jpg";
            shoes.items = 0;
            list.Add(shoes);

            //clothes
            category clothes = new category();
            clothes.name = "Clothes";
            clothes.image = "img/cat-1.jpg";
            clothes.items = 0;
            list.Add(clothes);

            //furniture
            category furniture = new category();
            furniture.name = "Furniture";
            furniture.image = "img/product-9.jpg";
            furniture.items = 0;
            list.Add(furniture);

            //camera
            category camera = new category();
            camera.name = "Camera";
            camera.image = "img/cat-2.jpg";
            camera.items = 0;
            list.Add(camera);

            //Drones
            category drone = new category();
            drone.name = "Drone";
            drone.image = "img/product-5.jpg";
            drone.items = 0;
            list.Add(drone);

            //Watches
            category watch = new category();
            watch.name = "Watch";
            watch.image = "img/product-6.jpg";
            watch.items = 0;
            list.Add(watch);

            //Personal
            category personal = new category();
            personal.name = "personal";
            personal.image = "img/cat-4.jpg";
            personal.items = 0;
            list.Add(personal);
        }


        //this function determines number of products in each category
        public void numberOfProductsInCategory()
        {
            //get list of products from service then count number of items in each category then add number to our front end list
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            setCategory();
            // TO-DO

            // Dynamically allocate the products from the database

            // CATEGORIES

            //dynamically populating all categories in the list of categories
            home_categories.InnerHtml = "";
            foreach (category cat in list)
            {
                home_categories.InnerHtml += "<div class='col-lg-3 col-md-4 col-sm-6 pb-1'>";
                home_categories.InnerHtml += "<a class='text-decoration-none' href='shop.aspx?category="+cat.name+"'>";
                home_categories.InnerHtml += "<div class='cat-item d-flex align-items-center mb-4'>";
                home_categories.InnerHtml += "<div class='overflow-hidden' style='width:100px; height:100px;'>";
                home_categories.InnerHtml += "<img class='img-fluid' src='"+cat.image+"' alt=''></div>";
                home_categories.InnerHtml += "<div class='flex-fill pl-3'>";
                home_categories.InnerHtml += "<h6>"+cat.name+"</h6>";
                home_categories.InnerHtml += "<small class='text-body'>"+cat.items+" Products</small></div></div></a></div>";
            }
            // Auction Products

            List<Product> products = new List<Product>();

            //getting auction items and display them
            dynamic prods = sv.getProducts().ToList();
            foreach (dynamic item in prods)
            {
                products.Add(item);
            }

            auction.InnerHtml = "";
            foreach (Product prod in products)
            {
                if(prod.Seller_ID == 0)
                {
                    display(prod);
                }       
            }
        }

        //@T Gulube 219020988
        // this function display a product passed to it to the auction division
        public void display(Product prod)
        {           
            auction.InnerHtml += "<div class='col-lg-3 col-md-4 col-sm-6 pb-1'>";
            auction.InnerHtml += "<div class='product-item bg-light mb-4'>";
            auction.InnerHtml += "<div class='product-img position-relative overflow-hidden'>";
            auction.InnerHtml += "<a href='single.aspx?Id=" + prod.Id + "'><img class='img-fluid w-100' src=" + prod.Image + " alt=''></a>";
            auction.InnerHtml += "<div class='product-action'>";
            auction.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='addtocart.aspx?Id=" + prod.Id + "&return=home.aspx&Add=0'><i class='fa fa-shopping-cart'></i></a>";
            auction.InnerHtml += "<a class='btn btn-outline-dark btn-square' href=''><i class='far fa-heart'></i></a>";
            auction.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='shop.aspx'><i class='fa fa-sync-alt'></i></a>";
            auction.InnerHtml += "<a class='btn btn-outline-dark btn-square' href='single.aspx?Id=" + prod.Id + "'><i class='fa fa-search'></i></a></div></div>";
            auction.InnerHtml += "<div class='text-center py-4'>";
            auction.InnerHtml += "<a class='h6 text-decoration-none text-truncate' href='single.aspx?Id=" + prod.Id + "'>" + prod.Product_Name + "</a>";
            auction.InnerHtml += "<div class='d - flex align-items-center justify-content-center mt-2'>";
            if (prod.Discount_Price != null)
            {
                auction.InnerHtml += "<a href='single.aspx?Id=" + prod.Id + "'><h5>R" + String.Format("{0:0.##}", prod.Discount_Price) + "</h5><h6 class='text-muted ml-2'>R<del>" + String.Format("{0:0.##}", prod.Product_Price) + "</</del></h6></div></a>";
            }
            else
            {
                auction.InnerHtml += "<a href='single.aspx?Id=" + prod.Id + "'><h5>R" + String.Format("{0:0.##}", prod.Product_Price) + "</h5></div></a>";
            }
            auction.InnerHtml += "<div class='d-flex align-items-center justify-content-center mb-1'>";
            auction.InnerHtml += "<small class='far fa-star text-primary mr-1'></small>";
            auction.InnerHtml += "<small class='far fa-star text-primary mr-1'></small>";
            auction.InnerHtml += "<small class='far fa-star text-primary mr-1'></small>";
            auction.InnerHtml += "<small class='far fa-star text-primary mr-1'></small>";
            auction.InnerHtml += "<small class='far fa-star text-primary mr-1'></small>";
            auction.InnerHtml += "<small>(99)</small>";
            auction.InnerHtml += "</div></div></div></div>";
        }
    }
}