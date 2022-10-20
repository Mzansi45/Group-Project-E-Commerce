using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int intemployeeType = Convert.ToInt32(Request.QueryString["Type"].ToString());

                if (intemployeeType == 1)
                {
                    employeeeType.Visible = false;
                    header.InnerHtml = "<p>Add Admin</p>";
                }
            }
        }

        protected void addEmployee_Click(object sender, EventArgs e)
        {
            string HashedPassword = HashPass.Secrecy.HashPassword(password.Value);

            if (HashedPassword == HashPass.Secrecy.HashPassword(confirmpass.Value))
            {

                int intemployeeType = Convert.ToInt32(Request.QueryString["Type"].ToString());

                if (intemployeeType == 0)
                {
                    if ((employeeType.Value).Equals("Manager"))
                    {
                        if (sv.addEmployeee(username.Value, surname.Value, Convert.ToString(0), email.Value, HashedPassword, username.Value))
                        {
                            Response.Redirect("login.aspx");
                        }
                        else
                        {
                            errormessage.Visible = true;
                        }
                    }
                    else if ((employeeType.Value).Equals("Admin"))
                    {
                        if (sv.addEmployeee(username.Value, surname.Value, Convert.ToString(1), email.Value, HashedPassword, username.Value))
                        {
                            Response.Redirect("login.aspx");
                        }
                        else
                        {
                            errormessage.Visible = true;
                        }
                    }
                    else
                    {
                        error.InnerHtml = "<p>Enter All fields</p>";
                    }
                }
                else if (intemployeeType == 1)
                {
                    employeeeType.Visible = false;

                    if (sv.addEmployeee(username.Value, surname.Value, Convert.ToString(1), email.Value, HashedPassword, username.Value))
                    {
                        Response.Redirect("login.aspx");
                    }
                    else
                    {
                        errormessage.Visible = true;
                    }
                }
                else
                {
                    error.InnerHtml = "<p>Request String Null</p>";
                }
            }
        }
    }
}