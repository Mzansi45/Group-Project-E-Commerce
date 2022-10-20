using Group_Practical_Front_End.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class invoices : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            invoice_List.InnerHtml = "";

            List<Invoice> list = new List<Invoice>();

            list = sv.GetInvoices().ToList();

            foreach(Invoice invoice in list)
            {
                invoice_List.InnerHtml += "<tr><td class='align-middle'>"+invoice.Id+"</td>";
                invoice_List.InnerHtml += "<td class='align-middle'>"+invoice.Customer_Id+"</td>";
                invoice_List.InnerHtml += "<td class='align-middle'>"+invoice.First_Name+"</td>";
                invoice_List.InnerHtml += "<td class='align-middle'>R"+String.Format("{0:0,##}",invoice.Total_Cost)+"</td>";
                invoice_List.InnerHtml += "<td class='align-middle'>"+invoice.Transaction_Date+"</td>";
                invoice_List.InnerHtml += "<td class='align-middle'><a href='Invoice.aspx?Id="+ invoice.Id + "'><img src='img/viewinvoice.png' alt='View Invoice'></a></td>";
                invoice_List.InnerHtml += "<td class='align-middle'><a href='addcoupon.aspx?Id=" + invoice.Customer_Id + "'><img src='img/reward.png' alt='View Invoice'></a></td>";
                invoice_List.InnerHtml += "</tr>";
            }
        }
    }
}