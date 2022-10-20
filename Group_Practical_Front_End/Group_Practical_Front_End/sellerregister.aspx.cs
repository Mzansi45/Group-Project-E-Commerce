using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class sellerregister : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Add_Click(object sender,EventArgs e)
        {
            if (username.Value.Length <= 0 || password.Value.Length <= 0
                || phone.Value.Length <= 0 || surname.Value.Length <= 0 || name.Value.Length <= 0
                || idnumber.Value.Length<=0)
            {
                errormessage.InnerText = "Invalid data input!";
                return;
            }

            //password validation
            if (confirmpass.Value.Length != password.Value.Length)
            {
                errormessage.InnerText = "Passwords do not match!!!";
                return;
            }

            Seller seller = new Seller();
            seller.S_Name = name.Value;
            seller.S_Surname = surname.Value;
            seller.Identity_Number = idnumber.Value;
            seller.Password =HashPass.Secrecy.HashPassword(password.Value);
            seller.Email = email.Value;
            seller.Username = username.Value;
            seller.Phone = phone.Value;

            if(sv.addSeller(seller))
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                errormessage.Visible = true;
            }
        }
    }
}