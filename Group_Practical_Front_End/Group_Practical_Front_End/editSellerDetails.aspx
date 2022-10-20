<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="editSellerDetails.aspx.cs" Inherits="Group_Practical_Front_End.editSellerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="bg-light p-30 mb-5" style="width: 800px; margin: auto; left: 0; right: 0; top: 0; bottom: 0; margin-top: 100px; border-width: 1px;">

        <div>
            <h1 style="text-align: center;">Edit Seller Info</h1>
            <br />
        </div>

        <div class="row">
            <div class="col-md-6 form-group">
                <label>First Name*</label>
                <input class="form-control" type="text" id="name" runat="server">
            </div>

            <div class="col-md-6 form-group">
                <label>Last Name*</label>
                <input class="form-control" type="text" id="surname" runat="server">
            </div>

             <div class="col-md-6 form-group">
                <label>Username*</label>
                <input class="form-control" type="text" id="username" runat="server">
            </div>

            <div class="col-md-6 form-group">
                <label>E-mail*</label>
                <input class="form-control" type="email" id="email" runat="server">
            </div>

            <div class="col-md-6 form-group">
                <label>Mobile No*</label>
                <input class="form-control" type="tel" id="phone" runat="server">
            </div>

             <div class="col-md-6 form-group">
                <label>Identity*</label>
                <input class="form-control" type="text" id="identity" runat="server">
            </div>

            <div class="col-md-12 form-group">
                <asp:Button runat="server" class="btn btn-block btn-primary font-weight-bold py-3" Text="Submit Changes" ID="editSellerInfo" OnClick="editSellerInfo_Click" />
            </div>

            <div class="col-md-12 form-group">
                <p id="errormessage" style="color:red;visibility: hidden;" runat="server" >Could Not Edit the Seller Information</p>
            </div>
        </div>
    </div>
</asp:Content>
