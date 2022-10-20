using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected  void Send_Click(object sender,EventArgs e)
        {
            if(email.Value.Length<=0 || username.Value.Length<=0)
            {
                //error message
                error_message.InnerHtml = "<p style='color:Red; ' runat='server' id='success'>Invalid Data Input</p>";
            }
            else
            {
                string message = "Password Reset Link \n https://localhost:44314/newpassword.aspx?username="
                    + username.Value + "&email="+email.Value+"";
                Method_Container.sendEmail(message, "Password Reset", email.Value);
                success.Visible = true;
            }
        }
    }
}