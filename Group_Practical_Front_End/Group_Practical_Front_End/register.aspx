<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Group_Practical_Front_End.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/registerstyle.css" rel="stylesheet"> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="full-screen-container">
    <div class="login-container">
      <h1 class="login-title">Register</h1>
      <div class="form">
        <!--Username-->
        <div class="input-group success"> <!--change group to error-->
          <label for="username">Username</label>
          <input type="text" name="username" id="username" runat="server">
          <!--span class="msg">Valid email</span-->
        </div>

        <!--Name-->
        <div class="input-group success"> <!--change group to error-->
            <label for="Name">Name</label>
            <input type="text" name="name" id="name" runat="server">
            <!--span class="msg">Valid email</span-->
        </div>

        <!--Surname-->
        <div class="input-group success"> <!--change group to error-->
            <label for="username">Surname</label>
            <input type="text" name="surname" id="surname" runat="server">
            <!--span class="msg">Valid email</span-->
        </div>

        <!--Email Address-->
        <div class="input-group success"> <!--change group to error-->
            <label for="email">Email Address</label>
            <input type="email" name="email" id="email" runat="server">
        </div>

        <!--Phone Number-->
        <div class="input-group success"> <!--change group to error-->
            <label for="phone">Phone Number</label>
            <input type="tel" name="phome" id="phone" runat="server">
        </div>

        <!--Password-->
        <div class="input-group success">
            <label for="password">Password</label>
            <input type="password" name="password" id="password" runat="server">
            
        </div>

        <!--Confirm Password-->
        <div class="input-group success">
            <label for="confirmpass">Confirm Password</label>
            <input type="password" name="confirmpass" id="confirmpass" runat="server">
        </div>

          <asp:Button Text="Create Account" runat="server" CssClass="login-button" ID="sign_up" OnClick="register_Click" />

        <p > <span id="errormessage" style="color: red;" runat="server" visible="false">Account already exits</span>
         <a href="login.html" style="padding-left: 45%; 
            color: rgb(18, 18, 19);">already a member</a></p>
      </div>
    </div>
  </div>
</asp:Content>
