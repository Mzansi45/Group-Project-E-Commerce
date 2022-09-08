<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Group_Practical_Front_End.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

         *, *::before, *::after {
        box-sizing: border-box;
        /*font-family: Arial, Helvetica, sans-serif;*/
        }

        :root {
            
        --primary-light-hsl: 200, 100%, 91%;

        --primary-hsl:56, 100%, 50%;
        /*--primary-hsl: 200, 100%, 50%;*/

        /*--primary-dark-hsl: 200, 100%, 6%;*/
        --primary-dark-hsl:56, 100%, 50%;

        --success-hsl: 100, 60%, 50%;
        --error-hsl: 0, 60%, 50%;
        }

        body {
        margin: 0;
        }

        .full-screen-container {
        background-image: url("background-image.jpg");
        height: 100vh;
        width: 100vw;
        background-size: cover;
        background-position: center;
        display: flex;
        justify-content: center;
        align-items: center;
        }

        .login-container {
        --color: hsl(var(--primary-dark-hsl), .3);
        background-color: var(--color);
        box-shadow: 0 0 15px 0 var(--color);
        padding: 40px 30px;
        width: 80%;
        max-width: 600px;
        border-radius: 20px;
        }

        .login-title {
        margin: 0;
        color: black;
        text-align: center;
        font-size: 2rem;
        font-weight: normal;
        }

        .form {
        display: flex;
        flex-direction: column;
        gap: 20px;
        margin-top: 40px;
        }

        .input-group {
        display: flex;
        flex-direction: column;
        gap: 7px;
        }

        .input-group label {
        color: black;
        font-weight: lighter;
        }

        .input-group input {
        font-size: 1.25rem;
        padding: .5em;
        background-color: hsl(var(--primary-light-hsl), .3);
        border: none;
        outline: none;
        border-radius: .25em;
        color: black;
        font-weight: lighter;
        }

        .input-group.success input {
        box-shadow: 0 0 0 1px hsl(var(--success-hsl));
        }

        .input-group.error input {
        box-shadow: 0 0 0 1px hsl(var(--error-hsl));
        }

        .input-group input:focus {
        box-shadow: 0 0 0 1px hsl(var(--primary-hsl));
        }

        .input-group .msg {
        display: none;
        font-size: .75rem;
        }

        .input-group.success .msg,
        .input-group.error .msg {
        display: block;
        }

        .input-group.error .msg {
        color: hsl(var(--error-hsl));
        }

        .input-group.success .msg {
        color: hsl(var(--success-hsl));
        }

        .login-button {
        padding: .5em 1em;
        font-size: 1.5rem;
        font-weight: lighter;
        color:black;
        background-color: hsl(var(--primary-hsl), 1);
        border: 1px solid hsl(var(--primary-hsl));
        border-radius: .25em;
        outline: none;
        cursor: pointer;
        }

        .login-button:hover,
        .login-button:focus {
        background-color: hsl(var(--primary-hsl), .4);
        }
  </style>
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
