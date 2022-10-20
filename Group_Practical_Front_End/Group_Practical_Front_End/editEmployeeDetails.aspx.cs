using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class editEmployeeDetails : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uID = Convert.ToInt32(Session["UserID"].ToString()); // Request.QueryString["LoggedInUserID"].ToString()

                var sellerLoggein = sv.gettingEmployeeByID(uID);

                username.Value = sellerLoggein.Username;
                name.Value = sellerLoggein.Employee_Name;
                surname.Value = sellerLoggein.Surname;
                email.Value = sellerLoggein.Email;
            }
        }

        protected void editEmployeeInfo_Click(object sender, EventArgs e)
        {
            var UpdateEmployee = new Employee
            {
                Id = Convert.ToInt32(Session["UserID"].ToString()),
                Employee_Name = name.Value,
                Surname = surname.Value,
                Username = username.Value,
                Email = email.Value,
            };

            bool Update = sv.editEmployeeDetails(UpdateEmployee);

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