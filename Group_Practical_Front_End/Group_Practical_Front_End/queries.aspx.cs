using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class queries : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            query_Table.InnerHtml = "";

            List<Query> list = new List<Query>();
            list = sv.GetQueries().ToList();

            foreach(Query q in list)
            {
                query_Table.InnerHtml += "<tr><td class='align-middle'>" + q.Id + "</td>";
                query_Table.InnerHtml += "<td class='align-middle'>" + q.Email + "</td>";
                query_Table.InnerHtml += "<td class='align-middle'>" + q.Query_Subject+ "</td>";
                query_Table.InnerHtml += "<td class='align-middle'>" + q.Submission_Date + "</td>";
                if(q.Answered ==1)
                {
                    query_Table.InnerHtml += "<td class='align-middle'><img src='img/tick.png' alt='Sent' style='width:50px;'></td>";
                    query_Table.InnerHtml += "<td class='align-middle'><a href='#' target='_blank'><button class='btn btn-primary py-2 px-4'>Send Response</button></a></td>";
                }
                else
                {
                    query_Table.InnerHtml += "<td class='align-middle'><img src='img/pending.png' alt='Pending' style='width:50px;'></td>";
                    query_Table.InnerHtml += "<td class='align-middle'><a href='queryresponse.aspx?Id=" + q.Id + "'><img src='img/responsebtn.png' alt=''></a></td>";
                }
                
                
                query_Table.InnerHtml += "</tr>";
            }
        }
    }
}