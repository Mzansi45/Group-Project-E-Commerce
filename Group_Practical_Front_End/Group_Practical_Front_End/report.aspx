<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="Group_Practical_Front_End.report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            border-collapse: collapse;
            width: 100%
        }

        th, td {
            border: 2px solid yellow;
            padding: 15px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div style="padding: 15px">
        <div align="center" style="font-size: 30px">Products Info Report</div>
        <div align="center" id="ReportViewer" visible="true" runat="server">

            <br />

            <asp:Button ID="LoadReport" runat="server" Text="Load Product Report" BackColor="#CCCC00" Font-Bold="True" Font-Size="Large" ForeColor="#CCCCCC" Height="36px" OnClick="LoadProductReport_Click" Width="194px" />

            <br />

            <div align="center" id="ReportViewerDiv" visible="true" runat="server"></div>
  
            <br />  <br />  <br /> <br />
        </div>

        <div align="center" style="font-size: 30px">Seller Info Report</div>
        <div align="center" id="SellerDiv" visible="true" runat="server">
            <asp:Button ID="SellerReport" runat="server" Text="Load User Report" BackColor="#CCCC00" Font-Bold="True" Font-Size="Large" ForeColor="#CCCCCC" Height="36px" OnClick="LoadSellerReport_Click" Width="194px" />
        </div>

    </div>
</asp:Content>
