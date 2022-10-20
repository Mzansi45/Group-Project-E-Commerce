using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class editSellerDetails : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uID = Convert.ToInt32(Session["UserID"].ToString()); // Request.QueryString["LoggedInUserID"].ToString()

                var sellerLoggein = sv.gettingSellerByID(uID);

                username.Value = sellerLoggein.Username;
                name.Value = sellerLoggein.S_Name;
                surname.Value = sellerLoggein.S_Surname;
                email.Value = sellerLoggein.Email;
                phone.Value = sellerLoggein.Phone;
                identity.Value = Convert.ToString(sellerLoggein.Identity_Number);

            }
        }

        protected void editSellerInfo_Click(object sender, EventArgs e)
        {
            var UpdateSeller = new Seller
            {
                Id = Convert.ToInt32(Session["UserID"].ToString()),
                S_Name = name.Value,
                S_Surname = surname.Value,
                Username = username.Value,
                Email = email.Value,
                Phone = phone.Value,
                Identity_Number = identity.Value,
            };

            bool Update = sv.editSellerDetails(UpdateSeller);

            if (Update)
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