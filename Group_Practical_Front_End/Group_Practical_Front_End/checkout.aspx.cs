using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class checkout : System.Web.UI.Page
    {
        private decimal Total_Cost = 0;
        private decimal packageWeight = 0;
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            //get products based on shopping cart
            populateProducts();
        }

        protected void PlaceOrder_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();
           
            // input  validations
            if (first_name.Value.Length <=0)
            {
                //error message
                error_message.InnerText = "Name is empty";
                return;
            }

            if (surname.Value.Length <=0)
            {
                //error message
                error_message.InnerText = "Surname is empty";
                return;
            }

            if (email.Value.Length <= 0)
            {
                //error message
                error_message.InnerText = "Email is empty";
                return;
            }

            if (address1.Value.Length <= 0)
            {
                //error message
                error_message.InnerText = "Street is empty";
                return;
            }

            if (address2.Value.Length <= 0)
            {
                //error message
                error_message.InnerText = "Town is empty";
                return;
            }

            if (city.Value.Length <= 0)
            {
                //error message
                error_message.InnerText = "City is empty";
                return;
            }

            if (province.Value.Length <= 0)
            {
                //error message
                error_message.InnerText = "Province is empty";
                return;
            }

            if (country.Value.Length <= 0)
            {
                //error message
                error_message.InnerText = "Country is empty";
                return;
            }

            if (zipcode.Value.Length <= 0)
            {
                //error message
                error_message.InnerText = "Zip Code is empty";
                return;
            }

            
            invoice.City = city.Value;
            invoice.Street = address1.Value;
            invoice.Surname = surname.Value;
            invoice.First_Name = first_name.Value;
            invoice.Country = country.Value;
            invoice.Transaction_Date = DateTime.Now;
            invoice.Email = email.Value;

            //customer ID
            if (Session["LoggedIn"] !=null)
            {
                invoice.Customer_Id = Convert.ToInt32(Session["UserID"].ToString());
            }
            else
            {
                invoice.Customer_Id = 0;
            }

            //town
            invoice.Town = address2.Value;
            //zip code
            invoice.Zip_Code = zipcode.Value;
            //total cost
            invoice.Total_Cost = Total_Cost;
            //province
            invoice.Province = province.Value;
            
            //delivery type / shiphing cost
            if(regular.Checked)
            {
                invoice.Shipping_Cost = 80;
                invoice.Delivery_Method = "Standard delivery";
            }
            else if(pick_up.Checked)
            {
                invoice.Shipping_Cost = 0;
                invoice.Delivery_Method = "Pick Up";
            }
            else if(drone.Checked)
            {
                //if package greater than 5kg the no drone deliveries
                if(packageWeight>5)
                {
                    error_message.InnerText = "Sorry Your package is too heavy for drone delivery please try another method"; 
                    return;
                }

                invoice.Shipping_Cost = 150;
                invoice.Delivery_Method = "Drone delivery";
            }
            else
            {
                //error message
                error_message.InnerText = "Please Choose a delivery Method";
                return;
            }


            //payment methods
            if (paypal.Checked)
            {
                invoice.Payment_Method = "PayPal";
            }
            else if(eft.Checked)
            {
                invoice.Payment_Method = "Electroni Funds Transfer(EFT)";
            }
            else if(banktransfer.Checked)
            {
                invoice.Payment_Method = "Bank Transfer";
            }
            else
            {
                //error message
                error_message.InnerText = "Please choose a Payment Method";
                return;
            }

            //product ids
            if (Session["LoggedIn"]!=null)
            {
                User user = new User();
                user = sv.getUserById(Convert.ToInt16(Session["UserID"].ToString()));
                invoice.Products_IDS = user.Cart_Items;
            }
            else
            {
                invoice.Products_IDS = Session["cart"].ToString();
            }

            int invoiceId = 0;
            invoiceId = sv.addInvoice(invoice);

            bool couponExists = false;

            if (coupon.Value.Length >= 5)
            {
                string temp = coupon.Value;

                int index = temp.IndexOf('(');
                Console.WriteLine(index);


                int size = temp.Length;

                try
                {
                    int couponId = Convert.ToInt32(temp.Remove(0, index + 1));

                    //validate coupon
                    if (sv.ValidateCouponById(couponId))
                    {
                        if (!sv.deleteCoupon(coupon.Value))
                        {
                            //error message
                            error_message.InnerText = "The coupon is invalid";
                            return;
                        }
                        couponExists = true;
                    }
                    else
                    {
                        //error message
                        error_message.InnerText = "The coupon is invalid";
                        return;
                    }
                }
                catch (Exception)
                {
                    //error message
                    error_message.InnerText = "The coupon is invalid";
                    return;
                }
            }

            if(couponExists)
            {
                if (invoiceId != 0)
                {
                    // remove items from cart
                    if (Session["LoggedIn"] != null)
                    {
                        if (sv.deleteCart(Convert.ToInt32(Session["UserID"].ToString())))
                        {
                            // do something for to remove from cart 
                        }
                    }
                    else
                    {
                        Session["cart"] = null;
                    }

                    //send an email containing link to the invoice.
                    //https://localhost:44314/
                    string emailMessage = "Dear " + first_name.Value + "\n \n Thank you for supporing our store by making a purchase \n" +
                        "to access your checkout invoice please find the link to your invoice attatched below \n https://localhost:44314/invoice.aspx?Id=" + invoiceId + "&coupon=" + coupon.Value + "";

                    //sending email
                    Method_Container.sendEmail(emailMessage, "Order Invoice", email.Value);
                    Response.Redirect("invoice.aspx?Id=" + invoiceId + "&coupon=" + coupon.Value + "");
                }
                //Redirect to the Transaction Page with an ID and the type of payment
            }
            else
            {
                if (invoiceId != 0)
                {
                    // remove items from cart
                    if (Session["LoggedIn"] != null)
                    {
                        if (sv.deleteCart(Convert.ToInt32(Session["UserID"].ToString())))
                        {
                            // do something for to remove from cart 
                        }
                    }
                    else
                    {
                        Session["cart"] = null;
                    }

                    //send an email containing link to the invoice.
                    //https://localhost:44314/
                    string emailMessage = "Dear " + first_name.Value + "\n \n Thank you for supporing our store by making a purchase \n" +
                        "to access your checkout invoice please find the link to your invoice attatched below \n https://localhost:44314/invoice.aspx?Id=" + invoiceId + "";

                    //sending email
                    Method_Container.sendEmail(emailMessage, "Order Invoice", email.Value);
                    Response.Redirect("invoice.aspx?Id=" + invoiceId + "");
                }
                //Redirect to the Transaction Page with an ID and the type of payment
            }

        }

        public void populateProducts()
        {
            checkout_products.InnerHtml = "<h6 class='mb-3'>Products</h6>";

            if (Session["LoggedIn"] != null)
            {
                User user = new User();
                user = sv.getUserById(Convert.ToInt32(Session["UserID"].ToString()));

                //check if user has items in the cart
                if (user.Cart_Items == null || user.Cart_Items.Equals(""))
                {
                    //if user does have anything in their cart
                    //shipping.InnerHtml = "R0";
                    //cart_items.InnerHtml = "";
                    //subt.InnerHtml = "R0";
                    total.InnerHtml = "R0";
                }
                else
                {
                    // get string list from database and split it
                    string[] list = user.Cart_Items.Split(' ');

                    int size = list.Length;
                    List<Product> products = new List<Product>();// product that are in the cart

                    List<int> productId = new List<int>(); // list of IDs of products in the cart
                    List<int> NumberOfItems = new List<int>();// number of items per product  from the cart

                    if (size <= 1)
                    {
                        //cart_items.InnerHtml = "";
                        Console.WriteLine(user.Cart_Items);
                        return;
                    }

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
                       // productIDs += id+" ";
                    }

                    
                    for (int x = 0; x < size - 1; x++)
                    {
                        checkout_products.InnerHtml += "<div class='d-flex justify-content-between'>";
                        checkout_products.InnerHtml += "<p>" + products[x].Product_Name + "   X " + NumberOfItems[x] + "</p>";
                        //add package weigth
                        packageWeight += products[x].Weight_KG * NumberOfItems[x];

                        decimal number = 0;

                        if (products[x].Discount_Price ==null)
                        {
                            number = products[x].Product_Price * NumberOfItems[x];
                        }
                        else
                        {
                            number = Convert.ToDecimal(products[x].Discount_Price * NumberOfItems[x]);
                        }
                        
                        Total_Cost += number;
                        checkout_products.InnerHtml += "<p>R" + String.Format("{0:0.##}", number) + "</p></div>";
                    }

                    //display total
                    total.InnerHtml = "R" + String.Format("{0:0.##}", Total_Cost);
                }
            }
            else
            {
                //create cart using session for unlogged In users
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

                    //display things

                    

                    for (int x = 0; x < size - 1; x++)
                    {
                        checkout_products.InnerHtml += "<div class='d-flex justify-content-between'>";
                        checkout_products.InnerHtml += "<p>" + products[x].Product_Name + "   X " + NumberOfItems[x] + "</p>";

                        //add package weight
                        packageWeight += products[x].Weight_KG * NumberOfItems[x];

                        decimal number = 0;

                        if (products[x].Discount_Price == null)
                        {
                            number = products[x].Product_Price * NumberOfItems[x];
                        }
                        else
                        {
                            number = Convert.ToDecimal(products[x].Discount_Price * NumberOfItems[x]);
                        }

                        Total_Cost += number;
                        checkout_products.InnerHtml += "<p>R" + String.Format("{0:0.##}", number) + "</p></div>";
                    }

                    //display total
                    total.InnerHtml = "R" + String.Format("{0:0.##}", Total_Cost);
                }
                else
                {
                    //if user does have anything in their cart
                    //shipping.InnerHtml = "R0";
                    //cart_items.InnerHtml = "";
                    //subt.InnerHtml = "R0";
                    total.InnerHtml = "R0";
                }
            }
        }
    }
}