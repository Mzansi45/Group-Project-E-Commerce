using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class addcoupon : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || !Session["UserType"].ToString().Equals("Manager"))
            {
                Response.Redirect("shop.aspx");
            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] !=null)
            {
                int customerId = Convert.ToInt32(Request.QueryString["Id"]);
                if(customerId ==0)
                {
                    failed.Visible = true;
                    return;
                }
                if(price.Value.Length<=0)
                {
                    failed.Visible = true;
                    error_message.InnerText = "Please enter a connect price";
                }

                User user = new User();
                user = sv.getUserById(customerId);

                Coupon coupon = new Coupon();
                coupon.Customer_Id = customerId;
                try
                {
                    coupon.Price = Convert.ToInt32(price.Value);
                }
                catch(Exception)
                {
                    failed.Visible = true;
                    error_message.InnerText = "Please enter a connect price";
                    return;
                }
                
                DateTime time = new DateTime();
                time = DateTime.Now;
                coupon.Creation_Date = time;
                coupon.Employee_Id = Convert.ToInt32(Session["UserID"].ToString());
                coupon.Used = 0;

                if(sv.addCoupon(coupon))
                {
                    int id = sv.getCouponId(customerId, time);

                    string CouponValue = "";
                    Random rand = new Random();
                    for (int x=0;x<5;x++)
                    {                     
                        int n = rand.Next(1,3);

                        if(n==1)
                        {
                            int ascii_index = rand.Next(65, 91); //ASCII character codes 65-90
                            char letter = Convert.ToChar(ascii_index); //produces any char A-Z
                            CouponValue += letter;
                        }
                        else if(n==2)
                        {
                            //random lowercase letter:
                            int ascii_index2 = rand.Next(97, 123); //ASCII character codes 97-123
                            char letter = Convert.ToChar(ascii_index2);
                            CouponValue += letter;
                        }
                        else if(n==3)
                        {
                            CouponValue += rand.Next(0, 9);
                        }
                    }

                    CouponValue += "(" + id;

                    if (sv.addCouponValue(id, CouponValue))
                    {
                        string message = "As a reward for your support we have attached a" +
                            " coupon which you can iuse the next time you Purchase with us \n" +
                            "Coupon: "+CouponValue+"";

                        Method_Container.sendEmail(message, "Customer reward", user.Email);
                        sent.Visible = true;
                    }
                }
            }
        }
    }
}