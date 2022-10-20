<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addcoupon.aspx.cs" Inherits="Group_Practical_Front_End.addcoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid" style="padding-left: 300px;">
        <div class="row px-xl-5">
             <div class="col-lg-8 table-responsive mb-5">
                <Label for="price">Coupon Price/Amount</Label>
                <input type="text" class="form-control" id="price" runat="server" placeholder="200"/>
            </div>
            <div class="col-lg-8 table-responsive mb-5">
                <asp:Button OnClick="Send_Click" class="btn btn-block btn-primary font-weight-bold py-3" Text="Send Coupon" runat="server"/>
                
            </div>

            <div class="col-lg-8 table-responsive mb-5" runat="server" id="sent" visible="false">
                <img src="img\tick.png" 
                style="width:50px; height:50px;" salt=""> Coupon Sent to Customer Via Email
            </div>

            <div class="col-lg-8 table-responsive mb-5" runat="server" id="failed" visible="false">
                <img src="img\pending.png" 
                style="width:50px; height:50px;" salt=""> <p runat="server" id="error_message">Cannot send coupon to Guest Customer</p>
            </div>
        </div>
    </div>
    <!-- Reward End -->
</asp:Content>
