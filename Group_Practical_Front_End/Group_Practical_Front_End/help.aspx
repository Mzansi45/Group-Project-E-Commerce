<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="help.aspx.cs" Inherits="Group_Practical_Front_End.help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-left: 300px;">
        <div class="container-fluid">
            <div class="row px-xl-5">
                <div class="col-lg-8">    
                    <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Login and Register</span></h5>
                    <br>To create an account a user can click on account on the top right and a drop down menu will show with 3
                    options wich is login,sign up and Seller register. User can register as customer which is sign up or they can
                     register as seller should they want to sell on our Website.

                </div>

                <div class="col-lg-8">
                    <br>
                    
                    <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Adding Products to cart</span></h5>
                    A user can add products by hovering on the product and add to cart option will pop-up, user will then be able to add to Cart
                                       
                    or add to wish list. user can also click on search button to got to a page where they can see all products details. 
                    they will also be able to see products similar to the product they are looking at

                </div>

                <div class="col-lg-8">
                    <br>

                    <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Check out and Payments</span></h5>
                    <p>
                        To check out a product a user can navigate to pages on the navigation bar and click on checkout or cart. if user clicks on cart they will be taken to their cart and they will be able to see the 
                        products they added to their cart. In the bottom of the cart there is a button for checking out which takes them to a page where they can enter checkout details
                        <br><br>
                        the checkout page lets user enter their shipping address and choose a delivery method and payment type.
                        they also have the option to enter a coupon if the have it, they will the get a lower checkout price based of the</p>
                    <br />
                </div>

                <div class="col-lg-8">
                    <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Seller Functions</span></h5>
                    When a seller is logged in they can see the products they have added, they will be able to add products to the shop by clicking on add product from the navbar
                    sellers can also edit their products. Seller cannot  buy  products using their seller account, they would have to 
                    create a customer account before they can purchase anything.<br /><br />
                </div>

                <div class="col-lg-8">
                    <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Manager Functions</span></h5>
                    Managers can update any of the company products, add other employees and issue rewards for customes who made purchases from our store.
                    employees and also able to respond to queris submitted via the contact page.
                    Managers can view company reports<br /><br />
                </div>
            </div>
        </div>     
    </div>
</asp:Content>
