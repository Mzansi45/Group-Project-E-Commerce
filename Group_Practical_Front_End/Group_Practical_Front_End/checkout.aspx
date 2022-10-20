<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="Group_Practical_Front_End.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <!-- Favicon -->
    <link href="img/favicon.ico" rel="icon">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap" rel="stylesheet">  

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">

    <!-- Libraries Stylesheet -->
    <link href="lib/animate/animate.min.css" rel="stylesheet">
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">

    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/style.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Breadcrumb Start -->
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
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Address</span></h5>
                <h6 class="section-title position-relative text-uppercase mb-3"  style="color:red;"><span class="bg-secondary pr-3" id="error_message" runat="server"></span></h6>
                <div class="bg-light p-30 mb-5">
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>First Name</label>
                            <input class="form-control" type="text" placeholder="John" runat="server" id="first_name">
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Last Name</label>
                            <input class="form-control" type="text" placeholder="Doe" runat="server" id="surname">
                        </div>
                        <div class="col-md-6 form-group">
                            <label>E-mail</label>
                            <input class="form-control" type="email" placeholder="example@email.com" runat="server" id="email">
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Mobile No</label>
                            <input class="form-control" type="tel" placeholder="+123 456 789" runat="server" id="phone">
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Street</label>
                            <input class="form-control" type="text" placeholder="3564 Jozi" runat="server" id="address1">
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Town</label>
                            <input class="form-control" type="text" placeholder="APK" runat="server" id="address2">
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Country</label>
                            <select class="custom-select" runat="server" id="country">
                                <option selected>South Africa</option>
                                <option>Zimbabwe</option>
                                <option>Botswana</option>
                                <option>Zambia</option>
                            </select>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>City</label>
                            <input class="form-control" type="text" placeholder="Johannesburg" runat="server" id="city">
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Province</label>
                            <input class="form-control" type="text" placeholder="Gauteng" runat="server" id="province">
                        </div>
                        <div class="col-md-6 form-group">
                            <label>ZIP Code</label>
                            <input class="form-control" type="text" placeholder="123" runat="server" id="zipcode">
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Order Total</span></h5>
                <div class="bg-light p-30 mb-5">
                    <div class="border-bottom" id="checkout_products" runat="server">
                        <h6 class="mb-3">Products</h6>
                        <div class="d-flex justify-content-between">
                            <p>Product Name 1</p>
                            <p>$150</p>
                        </div>
                        <div class="d-flex justify-content-between">
                            <p>Product Name 2</p>
                            <p>$150</p>
                        </div>
                        <div class="d-flex justify-content-between">
                            <p>Product Name 3</p>
                            <p>$150</p>
                        </div>
                    </div>
                    <div class="pt-2">
                        <div class="d-flex justify-content-between mt-2">
                            <h5>Total</h5>
                            <h5 runat="server" id="total">$160</h5>
                        </div>
                    </div>
                </div>

                <div class="mb-5">
                    <div class="input-group">
                        <input type="text" runat="server" id="coupon" class="form-control border-0 p-4" placeholder="Coupon Code">
                    </div>
                </div>

                <div class="mb-5">
                    <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Delivery Type</span></h5>
                    <div class="bg-light p-30">
                         <div class="form-group">
                            <div>
                                <input type="radio" runat="server" name="delivery" id="regular">
                                <label  for="regular">Standard 2-4 days  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cost: R80 </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div>
                                <input type="radio"  runat="server" name="delivery" id="drone">
                                <label  for="drone">Drone Delivery 1-2 days
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cost: R150</label>
                            </div>
                        </div>
                        <div class="form-group mb-4">
                            <div>
                                <input type="radio"  runat="server" name="delivery" id="pick_up">
                                <label for="pick_up">Pick Up &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cost: R0</label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="mb-5">
                    <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Payment</span></h5>

                    <div class="bg-light p-30">
                        <div class="form-group">
                            <div>
                                <input name="payment" type="radio" runat="server" id="paypal">
                                <label for="paypal">Paypal</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div>
                                <input type="radio" name="payment" runat="server" id="eft">
                                <label  for="eft">EFT</label>
                            </div>
                        </div>
                        <div class="form-group mb-4">
                            <div>
                                <input name="payment" type="radio" runat="server" id="banktransfer">
                                <label  for="banktransfer">Bank Transfer</label>
                            </div>
                        </div>
                        <asp:Button OnClick="PlaceOrder_Click" class="btn btn-block btn-primary font-weight-bold py-3" runat="server" Text="Payment"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Checkout End -->

        <!-- JavaScript Libraries -->
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
    <script src="lib/easing/easing.min.js"></script>
    <script src="lib/owlcarousel/owl.carousel.min.js"></script>

    <!-- Contact Javascript File -->
    <script src="mail/jqBootstrapValidation.min.js"></script>
    <script src="mail/contact.js"></script>

    <!-- Template Javascript -->
    <script src="js/main.js"></script>
</asp:Content>
