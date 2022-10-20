<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="newpassword.aspx.cs" Inherits="Group_Practical_Front_End.newpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- forgot password Start -->
    
    <div class="col-lg-10" style="padding-left: 200px;">
        <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Password Reset</span></h5>
        <div class="bg-light p-30 mb-5">
            <div class="col">
                <div class="col-md-6 form-group">
                    <label>Password</label>
                    <input class="form-control" type="password" runat="server" id="password" placeholder="pass">
                </div>
                <br>
                <div class="col-md-6 form-group">
                    <label>Confirm Password</label>
                    <input class="form-control" type="password" runat="server" id="confirm_password" placeholder="same pass">
                </div>
                <div class="col-md-6 form-group">
                    <br>
                </div>
                <div class="col-md-6 form-group">
                    <asp:Button runat="server" OnClick="Reset_Click" class="btn btn-primary py-2 px-12" Text="Reset Password"/>
                </div>
                <div class="col-md-6 form-group" runat="server" id="error_message">

                </div>
            </div>
        </div>
    </div>

    <!-- forgot password End -->
</asp:Content>
