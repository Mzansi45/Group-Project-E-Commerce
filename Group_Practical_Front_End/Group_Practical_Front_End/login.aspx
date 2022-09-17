<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Group_Practical_Front_End.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="css/loginstyle.css" rel="stylesheet">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="full-screen-container">
    <div class="login-container">
      <h1 class="login-title">Welcome</h1>
      <form class="form">
        <div class="input-group success"> <!--change group to error-->
          <label for="username">Username</label>
          <input type="text" name="username" id="username" runat="server">
          <!--span class="msg">Valid email</span-->
        </div>

        <div class="input-group success">
          <label for="password">Password</label>
          <input type="password" name="password" id="password" runat="server">
          
        </div>

        <div >
            <p><a href="#" style="color: rgb(180, 124, 233);">forgot password</a> 
            <a href="#" style="padding-left: 55%; 
            color: rgb(180, 124, 233);">Create Account</a></p>
        </div>

        <asp:Button Text="Login" runat="server" CssClass="login-button" ID="sign_in" OnClick="login_Click" />

        <div>
            <span class="msg" id="errormessage" runat="server"></span>
        </div>    
      </form>
    </div>
  </div>
</asp:Content>
