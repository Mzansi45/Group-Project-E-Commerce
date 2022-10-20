using Group_Practical_Front_End.ServiceReference1;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group_Practical_Front_End
{
    public partial class report : System.Web.UI.Page
    {
        Service1Client sv = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
       

        // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\PHENOMENAL\Desktop\Group Project version 6\Group Project\Group_Practical_Back_End\Group_Practical_Back_End\App_Data\Database1.mdf';Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        protected void LoadProductReport_Click(object sender, EventArgs e)
        {
            //ReportViewer.Visible=true;

            SqlCommand c = new SqlCommand("SELECT * FROM Product", con);
            SqlDataAdapter s = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            // s.Fill(dt);

            // ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            // ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");
            //  ReportViewer1.LocalReport.DataSources.Add(rds);

            // ReportViewer1.LocalReport.Refresh();

            //if (Session["UserType"].ToString().Equals("Manager")) {

            dynamic product = sv.getProductReport();

            // String to be used for displaying
            string prods = "";

            int prod = 0;
            // Loop through the list and call the ImageView of the Products to diplay the report of products
            // Which are higher than 5000 which sold by the company


            foreach (Product p in product)
            {

                if (p.Category.Equals("Camera"))
                {
                    prod += 1;
                }
                if (p.Product_Price > 5000)
                {
                    prods += "<table border='1'>";
                    prods += "<tr><th> Product_Name </th><th> Product_Price </th><th> Category </th></th><th> Product Sold </th></tr>";
                    prods += "<tr><th> " + p.Product_Name + " </th><th>" + p.Product_Price + "</th><th>" + p.Category + "</th><th>" + prod + "</th></tr>";
                    prods += "<table>";

                    ReportViewerDiv.InnerHtml = prods;
                }
            }
        }

        protected void LoadSellerReport_Click(object sender, EventArgs e)
        {
            dynamic seller = sv.getSellerReport();

            // String to be used for displaying
            string sellers = "";


            foreach (Seller l in seller)
            {
                if (l.Average_Rating >= 3)
                {
                    sellers += "<table border='1'>";
                    sellers += "<tr><th> Seller Name </th><th> Seller Surname </th><th> Average_Rating </th></tr>";
                    sellers += "<tr><th> " + l.S_Name + " </th><th>" + l.S_Surname + "</th><th>" + l.Average_Rating + "</th></tr>";
                    sellers += "<table>";

                    SellerDiv.InnerHtml = sellers;
                }
            }
        }
    }
}