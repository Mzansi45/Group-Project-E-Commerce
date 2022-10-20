using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class contact : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Query_Click(object sender,EventArgs e)
        {
            string U_name = name.Value;
            string U_email = email.Value;
            string U_subject = subject.Value;
            string U_message = message.Value;

            if(U_name ==null || U_name.Length<=0)
            {
                success.InnerHtml = "<p style='color:red'>Cannot Submit Query Without a Name</p>";
            }
            if (U_email == null || U_email.Length <= 0)
            {
                success.InnerHtml = "<p style='color:red'>Cannot Submit Query Without an Email</p>";
            }
            if (U_subject == null || U_subject.Length <= 0)
            {
                success.InnerHtml = "<p style='color:red'>Cannot Submit Query Without a Query Subject</p>";
            }
            if (U_message == null || U_message.Length <= 0)
            {
                success.InnerHtml = "<p style='color:red'>Cannot Submit Query Without a Message</p>";
            }
            Query query = new Query();
            query.Answered = 0;
            query.Query_Message = U_message;
            query.Customer_Name = U_name;
            query.Query_Subject = U_subject;
            query.Email = U_email;
            query.Submission_Date = DateTime.Now;

            if(sv.addQuery(query))
            {
                success.InnerHtml = "<p style='color:green'>Query Submitted Successfully</p>";

                Method_Container.sendEmail("Dear "+U_name+"\n" +
                    "This is an auto response to your Query," +
                    " We have received your query and an agent will contact you with a response",
                    "Query Message auto Response", U_email);

                Response.Redirect("home.aspx");
            }

        }
    }
}