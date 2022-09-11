<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="Group_Practical_Front_End.shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Breadcrumb Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-12">
                <nav class="breadcrumb bg-light mb-30">
                    <a class="breadcrumb-item text-dark" href="#">Home</a>
                    <a class="breadcrumb-item text-dark" href="#">Shop</a>
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
                            <p>
                            <asp:Button runat="server" OnClick="All_Click" ID="price_all" style="width:20px;height:20px;" />
                            <label  for="price_all"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;All Prices&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</label>
                            <span class="badge border font-weight-normal">1000</span>
                        </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <p>
                                <asp:Button runat="server" ID="R500" OnClick="R500_Click" style="width:20px;height:20px;"/>
                                <label  for="R500"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;R400 to R500&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">500</span>
                            </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <p>
                                <asp:Button OnClick="R400_Click" runat="server" ID="R400" style="width:20px;height:20px;"/>
                                <label  for="R400"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;R300 to R400&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">400</span>
                            </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <p>
                                <asp:Button OnClick="R300_Click" runat="server" ID="R300" style="width:20px;height:20px;"/>
                                <label  for="R300"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;R200 to R300&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">300</span>
                            </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <p>
                                <asp:Button OnClick="R200_Click" runat="server" ID="R200" style="width:20px;height:20px;"/>
                                <label  for="R200"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;R100 to R200&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">200</span>
                            </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between">
                            <p>
                                <asp:Button OnClick="R100_Click" runat="server" ID="R100" style="width:20px;height:20px;"/>
                                <label  for="R100"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;R0 to R100&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">100</span>
                            </p>
                        </div>
                </div>
                <!-- Price End -->
                
                <!-- Color Start -->
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Filter by color</span></h5>
                <div class="bg-light p-4 mb-30">
                    
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <p>
                            <asp:Button OnClick="All_Click" id="all_colors" style="width:20px;height:20px;background:linear-gradient(red,green,blue,yellow,black,purple)" runat="server"/>
                            <label for="all_colors"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;All Colors&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</label>
                            <span class="badge border font-weight-normal">1000</span>
                            </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <p>
                                <asp:Button OnClick="White_Click" id="white" style="width:20px;height:20px;background-color:white" runat="server"/>
                                <label  for="white"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;White&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">500</span>
                            </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <p>
                                <asp:Button OnClick="Blue_Click" id="blue" style="width:20px;height:20px;background-color:blue" runat="server"/>
                                <label style="color:blue" for="blue"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;Blue&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">400</span>
                            </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <p>
                                <asp:Button OnClick="Red_Click" id="red" style="width:20px;height:20px; background-color:red" runat="server"/>
                                <label style="color:red" for="red"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;Red&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">300</span>
                            </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <p>
                                <asp:Button OnClick="Black_Click" runat="server" id="black" style="width:20px;height:20px; background-color:black"/>
                                <label style="color:black" for="black"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;Black&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">200</span>
                            </p>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between">
                            <p>
                                <asp:Button OnClick="Gray_Click" runat="server" id="gray" style="width:20px;height:20px; background-color:gray"/>
                                <label style="color:gray" for="gray"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;Gray&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <span class="badge border font-weight-normal">100</span>
                            </p>
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
                            <asp:Button ID="drones" runat="server" OnClick="Drones_Click" style="width: 200px; height: 30px;border-radius: 10px;" Text="Drones"/>
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
                    <div class="col-12 pb-1">
                        <div class="d-flex align-items-center justify-content-between mb-4">
                            <div>
                                <button class="btn btn-sm btn-light"><i class="fa fa-th-large"></i></button>
                                <button class="btn btn-sm btn-light ml-2"><i class="fa fa-bars"></i></button>
                            </div>
                            <div class="ml-2">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-sm btn-light dropdown-toggle" data-toggle="dropdown">Sorting</button>
                                    <div class="dropdown-menu dropdown-menu-right">
                                        <a class="dropdown-item" href="#">Latest</a>
                                        <a class="dropdown-item" href="#">Popularity</a>
                                        <a class="dropdown-item" href="#">Best Rating</a>
                                    </div>
                                </div>
                                <div class="btn-group ml-2">
                                    <button type="button" class="btn btn-sm btn-light dropdown-toggle" data-toggle="dropdown">Showing</button>
                                    <div class="dropdown-menu dropdown-menu-right">
                                        <a class="dropdown-item" href="#">10</a>
                                        <a class="dropdown-item" href="#">20</a>
                                        <a class="dropdown-item" href="#">30</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <p runat="server" id="productsSection">

                    </p>
                    <div class="col-12">
                        <nav>
                          <ul class="pagination justify-content-center">
                            <li class="page-item disabled"><a class="page-link" href="#">Previous</a></li>
                            <li class="page-item active"><a class="page-link" href="#">1</a></li>
                            <li class="page-item"><a class="page-link" href="#">2</a></li>
                            <li class="page-item"><a class="page-link" href="#">3</a></li>
                            <li class="page-item"><a class="page-link" href="#">Next</a></li>
                          </ul>
                        </nav>
                    </div>
                </div>
            </div>
            <!-- Shop Product End -->
        </div>
    </div>
    <!-- Shop End -->
</asp:Content>
