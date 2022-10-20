<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="Group_Practical_Front_End.shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Breadcrumb Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-12">
                <nav class="breadcrumb bg-light mb-30">
                    <a class="breadcrumb-item text-dark" href="home.aspx">Home</a>
                    <a class="breadcrumb-item text-dark" href="shop.aspx">Shop</a>
                    <span class="breadcrumb-item active">Shop List</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->


    <!-- Shop Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <!-- Shop Sidebar Start -->
            <div class="col-lg-3 col-md-4">
                <!-- Price Start -->
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Filter by price</span></h5>
                <div class="bg-light p-4 mb-30">
                     <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                     <input type="range" id="price" runat="server" step="50" value="30000" min="1" max="30000" oninput="this.nextElementSibling.value = this.value">
                     <output runat="server" id="p_range">R30000</output>
                     </div>
                     <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                         <asp:Button runat="server" id="price_all" OnClick="Price_Click" style="width: 200px; height: 40px;border-radius: 10px;" Text="Apply Filter"/>
                     </div>
                </div>
                <!-- Price End -->
                
                <!-- Color Start -->
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Filter by color</span></h5>
                <div class="bg-light p-4 mb-30">
                    
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button OnClick="All_Click" id="all_colors" style="width: 200px; height: 30px;border-radius: 10px;background:linear-gradient(red,green,blue,yellow,black,purple)" runat="server" />
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button OnClick="White_Click" id="white" style="width: 200px; height: 30px;border-radius: 10px; background-color:White" Text="White" runat="server"/>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button OnClick="Blue_Click" id="blue" style="width: 200px; height: 30px;border-radius: 10px; background-color:Blue" Text="Blue" runat="server" />
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button OnClick="Red_Click" id="red" style="width: 200px; height: 30px;border-radius: 10px; background-color:Red" Text="Red" runat="server" />
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button OnClick="Black_Click" runat="server" id="black" style="width: 200px; height: 30px;border-radius: 10px; background-color:Black; color:White" Text="Black"/>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between">
                            <asp:Button OnClick="Gray_Click" runat="server" id="gray" style="width: 200px; height: 30px;border-radius: 10px; background-color:gray" Text="Gray"/>    
                        </div>
                </div>
                <!-- Color End -->

                <!-- Category Start -->
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Filter by Category</span></h5>
                <div class="bg-light p-4 mb-30">
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button ID="all_categories" OnClick="All_Click" runat="server" Text="All Categories" style="width: 200px; height: 30px;border-radius: 10px;"/>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button ID="cameras" OnClick="Cameras_Click" runat="server" Text="Cameras" style="width: 200px; height: 30px;border-radius: 10px;"/>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button ID="drones" runat="server" OnClick="Gadget_Click" style="width: 200px; height: 30px;border-radius: 10px;" Text="Gadget"/>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button ID="furniture" runat="server" OnClick="Furniture_Click" style="width: 200px; height: 30px;border-radius: 10px;" Text="Furniture"/>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button ID="tools" OnClick="Tools_Click" style="width: 200px; height: 30px;border-radius: 10px;" runat="server" Text="Tools" />
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:Button ID="clothes" Text="Clothes" OnClick="Clothes_Click" runat="server" style="width: 200px; height: 30px;border-radius: 10px;" />
                        </div>
                </div>
                <!-- Category End -->
            </div>
            <!-- Shop Sidebar End -->


            <!-- Shop Product Start -->
            <div class="col-lg-9 col-md-8">
                <div class="row pb-3">
                    <p runat="server" id="productsSection">

                    </p>
                </div>
            </div>
            <!-- Shop Product End -->
        </div>
    </div>
    <!-- Shop End -->
</asp:Content>
