using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class queryresponse : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Id"] ==null || Session["LoggedIn"]!=null && !Session["UserType"].ToString().Equals("Manager"))
            {
                Response.Redirect("Error");
            }

            int queryId = Convert.ToInt32(Request.QueryString["Id"]);

            Query query = new Query();
            query = sv.GetQueryByID(queryId);

            user_message.InnerText = query.Query_Message;
        }

        protected void Send_Click(object sender,EventArgs e)
        {
            int queryId = Convert.ToInt32(Request.QueryString["Id"]);

            Query query = new Query();
            query = sv.GetQueryByID(queryId);

            if(message.Value.Length <=0)
            {
                // error message
                success.InnerHtml = "<p style='color:red'> Cannot an empty response message</p>";
            }
            else
            {
                Method_Container.sendEmail(message.Value,"Query Response",query.Email);
                query.Answered = 1;
                if(sv.markQueryRead(query))
                {
                    Response.Redirect("queries.aspx");
                }
                else
                {
                    Response.Redirect("#");
                }
                
                
            }
            
        }
    }
}