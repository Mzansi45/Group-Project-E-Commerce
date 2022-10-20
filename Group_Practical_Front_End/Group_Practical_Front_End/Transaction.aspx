<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="Group_Practical_Front_End.Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-12">
                <nav class="breadcrumb bg-light mb-30">
                    <a class="breadcrumb-item text-dark" href="home.aspx">Home</a>
                    <a class="breadcrumb-item text-dark" href="shop.aspx">Shop</a>
                    <span class="breadcrumb-item active">Checkout</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->


    <!-- Checkout Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-lg-8">
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Payment Process</span></h5>
                <div class="bg-light p-30 mb-5">
                    <div class="row">

   
                        <!--Image-->
                        <div class="col-md-6 form-group">
                            <img src="img/card.jpeg" Height="280" Width="300"/>
                        </div>

                       <!-- <div class="col-md-6 form-group"> -->

                            <!--Card Number-->
                            <div class="col-md-6 form-group">
                                <label>Card Number</label>
                                <input class="form-control" type="text" placeholder="5422 .... .... ...." runat="server" id="cardNumber">
                            

                            <!--CVV Code-->
                           
                                <label>CVV Code</label>
                                <input class="form-control" type="text" placeholder="..." runat="server" id="CVVCode">
                            

                            <!--Date-->
                            
                                <label>Month and Year</label>
                                <input class="form-control" type="Date" placeholder="27/12" runat="server" id="date">
                            

                            <!--Email Address for the -->
                           <span>
                                <label>Invoice Email</label>
                                <input class="form-control" type="email" placeholder="Phenomenal@gmail.com" runat="server" id="Email">
                            </span>

                            
                        </div>

                        <div class="col-md-6 form-group">
                        <asp:Button OnClick="ProceedPayment_Click" class="btn btn-block btn-primary font-weight-bold py-3" runat="server" Width="603px" Text="Proceed Payment"/>
                        </div>

                    </div>
                </div>

          </div> 
</div>  
        </div>




</asp:Content>
