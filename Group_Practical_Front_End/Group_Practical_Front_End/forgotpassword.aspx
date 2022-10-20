<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="Group_Practical_Front_End.forgotpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- forgot password Start -->
    
    <div class="col-lg-10" style="padding-left: 200px;">
        <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Password Reset</span></h5>
        <div class="bg-light p-30 mb-5">
            <div class="col">
                <div class="col-md-6 form-group">
                    <label>Username*</label>
                    <input class="form-control" runat="server" id="username" type="text" placeholder="John">
                </div>
                <br>
                <div class="col-md-6 form-group">
                    <label>E-mail*</label>
                    <input class="form-control" type="email" runat="server" id="email" placeholder="example@email.com">
                </div>
                <div class="col-md-6 form-group">
                    <br>
                </div>
                <div class="col-md-6 form-group">
                    <asp:Button runat="server" OnClick="Send_Click" Text="Reset Password" class="btn btn-primary py-2 px-12" type="submit"/>
                </div>
                <div class="col-md-6 form-group" runat="server" id="error_message">
                    <p>Important! Make sure your credentials are correct</p>
                    <p style="color: green;" runat="server" visible="false" id="success">An email has been sent with a link to reset password<br></p>
                </div>
            </div>
        </div>
    </div>

    <!-- forgot password End -->
</asp:Content>
