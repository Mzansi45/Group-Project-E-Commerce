using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class invoice : System.Web.UI.Page
    {
		Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
			// redirect if no url parameter
			if(Request.QueryString["Id"] ==null)
            {
				Response.Redirect("Error");
            }

			//invoice_table.InnerText = "";

			Invoice invoice = new Invoice();
			int invoiceId = Convert.ToInt32(Request.QueryString["Id"]);

			invoice = sv.GetInvoiceByID(invoiceId);

			string table = "<table><tr class='top'><td colspan='2'><table><tr><td class='title'>" +
				"<img src='./img/ecommerce.jpeg' alt='Company logo' style='width:100%; max-width:300px'/>" +
				"</td><td>Invoice No: "+invoice.Id+"<br/>Created: "+invoice.Transaction_Date+"<br/>Delivery Method: "+invoice.Delivery_Method+"" +
				"</td></tr></table></td></tr><tr class='information'><td colspan='2'>" +
				"<table><tr><td>"+invoice.Street+", "+invoice.Town+"<br/>"+invoice.Province+"<br/>"+invoice.Country+", "+invoice.Zip_Code+"</td><td>" +
				"Acme Corp.<br/>"+invoice.First_Name+" "+invoice.Surname+"<br/>"+invoice.Email+"</td></tr></table></td></tr>" +
				"<tr class='heading'><td>Payment Method</td><td>Shipping Cost</td></tr>" +
				"<tr class='details'><td >"+ invoice.Payment_Method + "</td><td>"+ String.Format("{0:0.##}", invoice.Shipping_Cost) + "</td></tr>" +
				"<tr class='heading'><td>Item</td><td>Price</td></tr>";



            string cart_items = invoice.Products_IDS;

            string[] list = cart_items.Split(' ');

            int size = list.Length;
            List<Product> products = new List<Product>();

            List<int> productId = new List<int>();
            List<int> NumberOfItems = new List<int>();

            for (int x = 0; x < size - 1; x++)
            {
                 //get product Id and add it to the list of IDs
                 int startIndex = list[x].IndexOf("(");

                 if (startIndex <= 0)
                 {
                     //cart_items.InnerHtml = "";
                     return;
                 }

                 string[] temp = list[x].Split('(');
                 string str = temp[0];

                 productId.Add(Convert.ToInt32(str));
            }

            string[] list2 = invoice.Products_IDS.Split(' ');
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

            //display things
            decimal Total_Cost = 0;

            for (int x = 0; x < size - 1; x++)
            {
                table += "<tr class='item'>";
                table += "<td>"+ products[x].Product_Name + "   X " + NumberOfItems[x] + "</td>";

                decimal number = 0;

                if (products[x].Discount_Price == null)
                {
                    number = products[x].Product_Price * NumberOfItems[x];
                }
                else
                {
                    number = Convert.ToDecimal(products[x].Discount_Price * NumberOfItems[x]);
                }

                //decimal number = products[x].Product_Price * NumberOfItems[x];
                Total_Cost += number;
                table += "<td>R"+ String.Format("{0:0.##}", number) + "</td></tr>";
            }

            decimal deduction = 0;
            if (Request.QueryString["coupon"]!=null)
            {
                //getcoupon Id then price

                string temp = Request.QueryString["coupon"];

                int index = temp.IndexOf('(');

                int couponId = Convert.ToInt32(temp.Remove(0, index + 1));

                decimal couponPrice = sv.GetCouponPrice(couponId);
                deduction = couponPrice;

                table += "<tr class='item'>";
                table += "<td>Coupon Deduction</td>";
                table += "<td>-R" + String.Format("{0:0.##}", couponPrice) + "</td></tr>";

            }
            //display total

            table += "<tr class='total'>";
            table += "<td></td>";
            if(Total_Cost>2000)
            {
                table += "<td>Total: R" + String.Format("{0:0.##}", Total_Cost -deduction) + "  +Shipping Excluded</td></table>";
            }
            else
            {
                table += "<td>Total: R" + String.Format("{0:0.##}", Total_Cost -deduction) + "  +Shipping R" + String.Format("{0:0.##}", invoice.Shipping_Cost) + "</td></table>";
            }
           

            invoice_table.InnerHtml = table;
        }
    }
}