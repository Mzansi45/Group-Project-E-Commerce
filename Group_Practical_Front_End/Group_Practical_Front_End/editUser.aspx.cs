using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class editUser : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uID = Convert.ToInt32(Session["UserID"].ToString()); // Request.QueryString["LoggedInUserID"].ToString()
                var userLoggein = sv.getUserById(uID);

                username.Value = userLoggein.Username;
                name.Value = userLoggein.First_Name;
                surname.Value = userLoggein.Surname;
                phone.Value = userLoggein.Phone;
                email.Value = userLoggein.Email;

            }
        }

        protected void editUserInfo_Click(object sender, EventArgs e)
        {
            var UpdateUser = new User
            {
                Id = Convert.ToInt32(Session["UserID"].ToString()),
                First_Name = name.Value,
                Surname = surname.Value,
                Phone = phone.Value,
                Email = email.Value,
                Username = username.Value,
            };

            bool Update = sv.editUser(UpdateUser);

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