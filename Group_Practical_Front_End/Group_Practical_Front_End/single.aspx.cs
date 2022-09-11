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
            if(Request.QueryString["Id"] !=null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);

                Product prod = new Product();

                prod = (Product)sv.getProductByID(Id);

                image.InnerHtml = "<img class='w-100 h-100' src='" + prod.Image + "' alt='Image'>";
                product_name.InnerHtml = prod.Product_Name;
                if (prod.Discount_Price != null)
                {
                    price.InnerHtml = "R"+ String.Format("{0:0.##}", prod.Discount_Price);
                }
                else
                {
                    price.InnerHtml = "R"+ String.Format("{0:0.##}", prod.Product_Price);
                }
                description.InnerText = prod.Description;
                description2.InnerText = prod.Description;

               // plus.InnerHtml = "<a href='addtocart.aspx?Id=" + prod.Id + "&return=single.aspx?Id="+prod.Id+"'><button class='btn btn-primary btn-plus'><i class='fa fa-plus'></i></button></a>";
            }

        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);

                Product prod = new Product();

                prod = (Product)sv.getProductByID(Id);

                Response.Redirect("addtocart.aspx?Id=" + prod.Id + "&return=single.aspx?Id=" + prod.Id + "&Add=0");
            }
        }

        protected void Minus_Click(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);

                Product prod = new Product();

                prod = (Product)sv.getProductByID(Id);

                Response.Redirect("addtocart.aspx?Id=" + prod.Id + "&return=single.aspx?Id=" + prod.Id + "&Add=-1");
            }
        }
    }
}