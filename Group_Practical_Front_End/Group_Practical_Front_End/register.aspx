<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Group_Practical_Front_End.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-light p-30 mb-5" style="width: 800px;margin: auto;left: 0;right: 0;top: 0;bottom: 0;margin-top: 100px;border-width: 1px;">

    <div>
        <h1 style="text-align:center;">Customer Registration</h1>
        <br/>
    </div>

        <div class="row">
            <div class="col-md-6 form-group">
                <label>First Name*</label>
                <input class="form-control" type="text" id="name" runat="server" placeholder="John">
            </div>
            <div class="col-md-6 form-group">
                <label>Last Name*</label>
                <input class="form-control" type="text" id="surname" runat="server" placeholder="Doe">
            </div>
            <div class="col-md-6 form-group">
                <label>E-mail*</label>
                <input class="form-control" type="email" id="email" runat="server" placeholder="example@email.com">
            </div>
            <div class="col-md-6 form-group">
                <label>Mobile No*</label>
                <input class="form-control" type="tel" id="phone" runat="server" placeholder="+123 456 789">
            </div>
            <div class="col-md-6 form-group">
                <label>Password*</label>
                <input class="form-control" type="password" id="password" runat="server" placeholder="Password">
            </div>
            <div class="col-md-6 form-group">
                <label>Username*</label>
                <input class="form-control" type="text" id="username" runat="server" placeholder="Username">
            </div>
            <div class="col-md-6 form-group">
                <label>Confirm Password*</label>
                <input class="form-control" type="password" id="confirmpass" runat="server" placeholder="Confirm Password">
            </div>
            <div class="col-md-12 form-group">
               <asp:Button runat="server" class="btn btn-block btn-primary font-weight-bold py-3" Text="Register" ID="sign_up" OnClick="register_Click" />
            </div>
            <div class="col-md-12 form-group">
                <a href="login.aspx">already have an account</a>
            </div>
            <div class="col-md-12 form-group">
                <p id="errormessage" style="color:red;" runat="server" ></p>
            </div>
        </div>
    </div>

</asp:Content>
