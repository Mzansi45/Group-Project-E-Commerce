<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Group_Practical_Front_End.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .login_page {
            border-style: solid;
            width: 400px;
            align-self:center;
            align-content: center;
            height: 550px;
            padding: 25px;
            border-radius: 10px;
            margin: auto;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
            margin-top: 100px;
            border-width: 1px;
            box-shadow: 20px;
            background-color: rgba(248, 252, 5, 0.4);
         }

        body {
            background-color: rgba(235, 238, 234, 0.5);
        }

        label {
            font-size: 25px;
        }


        .row {
            align-content: center;
            padding-top: 10px;
        }

        .login_class{
            width: 350px;
            height: 40px;
            outline: none;
            cursor: pointer;
            border-radius: 5px;
            border-color: yellowgreen;
            align-content: center;
            background-color: rgba(255, 255, 0, 0.774);
        }

        .login_class:hover {
            background-color: rgba(230, 230, 8, 0.877);
        }

        h1{
            text-align: center;
        }

        .inp {
            width: 350px;
            height: 30px;
            background-color: rgba(255, 255, 251, 0.76);
            border-radius: 5px;
            gap: 10px;
        }

        .inp:focus, .inp:hover {
            border-color: rgba(228, 228, 25, 0.404);
        }

        .bottom_text {
            font-size: 18px;
            color: black;
        }

        .bottom_text:hover {
            color: rgb(168, 168, 8);
        }

        #forgot_password {
            padding-left: 0px;
        }

        #create_account {
            padding-left: 70px;
        }

        .error_message {
            color: red;
            visibility: hidden;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
       <div class="login_page">
        <h1>Welcome</h1>
        <div class="row">
            <label for="username" >Username</label>
            <br>
            <input type="text" id="username" class="inp" runat="server">
            <br>
            <br>
            <label for="password">Password</label>
            <input type="password" id="password" class="inp" runat="server">
            <div>
                <br /> 
			    <label for="customer" style="font-size:18px">Customer</label>
			    <input type="radio" id="customer" runat="server" name="type"><br />
			    <label for="seller" style="font-size:18px">Seller</label>
			    <input type="radio" id="seller" runat="server" name="type"><br />
                <label for="manager" style="font-size:18px">Manager</label>
                <input type="radio" id="manager" runat="server" name="type"/><br />
            </div>  
            <br />
            <br>
            <br>
            <asp:Button runat="server" OnClick="login_Click" ID="sign_in" CssClass="login_class" Text="Login"/>
            <br />
            <br />
            <a href="forgotpassword.aspx"class="bottom_text" id="forgot_password">forgot password</a> 
            <a class="bottom_text" href="register.aspx" id="create_account">create account</a>
            <br>
            <br>
            <p runat="server" id="errormessage" visible="false" style="color:red">Incorrect Password/Username</p>
        </div>
    </div>
</asp:Content>
