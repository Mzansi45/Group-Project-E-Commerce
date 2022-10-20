using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group_Practical_Front_End.ServiceReference1;

namespace Group_Practical_Front_End
{
    public partial class editProduct : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);

                Product prod = sv.getProductByID(id);

                product_name.Value = prod.Product_Name;
                product_price.Value = (Convert.ToDecimal(string.Format("{0:0.00}", prod.Product_Price))).ToString();
                category.Value = prod.Category;
                image.Value = prod.Image;
                color.Value = prod.Color;
                dimensions.Value = prod.Dimensions_XYZ;
                weight.Value = (string.Format("{0:0.00}", prod.Weight_KG)).ToString();
                manufacturer.Value = prod.Manufacturer;
                description.Value = prod.Description;

            }
        }
    

        protected void SubmitChanges_Click(object sender, EventArgs e)
        {
            Product prod = new Product();
            prod.Id = Convert.ToInt32(Request.QueryString["Id"]);
            prod.Product_Name = product_name.Value;
            prod.Product_Price = Convert.ToDecimal(product_price.Value);
            prod.Category = category.Value;
            prod.Manufacturer = manufacturer.Value;
           
            

            if (dimensions.Value == null || dimensions.Value.Length <= 0)
            {
                prod.Dimensions_XYZ = null;
            }
            else
            {
                prod.Dimensions_XYZ = dimensions.Value;
            }
            
            prod.Available = 1;
            prod.Color = color.Value;
            prod.Description = description.Value;
            prod.Image = image.Value;
            prod.Seller_ID = Convert.ToInt32(Session["UserID"].ToString());

            prod.Weight_KG = Convert.ToDecimal(weight.Value.Replace('.', ','));
            prod.Discount_Price = null;

            bool Update = sv.updateProduct(prod);

            if (Update)
            {
                Response.Redirect("single.aspx?Id=" + prod.Id + "");
            }
            else
            {
                errormessage.Visible = true;
            }
        }
    }
}