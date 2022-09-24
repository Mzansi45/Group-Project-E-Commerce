using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class addproduct : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LoggedIn"] != null && Session["UserType"].ToString().Equals("Seller"))
            {

            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Manufacturer = manufacturer.Value;
            product.Product_Name = product_name.Value;
            product.Product_Price = Convert.ToDecimal(product_price.Value);

            if(dimensions.Value ==null || dimensions.Value.Length<=0)
            {
                product.Dimensions_XYZ =null;
            }
            {
                product.Dimensions_XYZ = dimensions.Value;
            }   
            product.Category = category.Value;
            product.Available = 1;
            product.Color = color.Value;
            product.Description = description.Value;
            product.Image = image.Value;
            product.Seller_ID = Convert.ToInt32(Session["UserID"].ToString());

            product.Weight_KG = Convert.ToDecimal(weight.Value.Replace('.',','));
            product.Discount_Price = null;

            if(sv.addProduct(product))
            {
                Response.Redirect("home.aspx");
            }
        }
    }
}