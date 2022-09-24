<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="Group_Practical_Front_End.addproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="bg-light p-30 mb-5" style="width: 800px;margin: auto;left: 0;right: 0;top: 0;bottom: 0;margin-top: 100px;border-width: 1px;">
        <div>
            <h1 style="text-align:center;">Add Product</h1>
            <br/>
        </div>
        <div class="row">
            <div class="col-md-6 form-group">
                <label>Product Name*</label>
                <input class="form-control" type="text" id="product_name"
                    required="required"
                    runat="server" placeholder="SanDisk 32Gb SDcard">
            </div>
            <div class="col-md-6 form-group">
                <label>Product Price*</label>
                <input class="form-control" type="text" id="product_price"
                    required="required"
                    runat="server" placeholder="500">
            </div>
            <div class="col-md-6 form-group">
                <label>Category*</label>
                <input class="form-control"  required="required" type="text" id="category" runat="server" placeholder="Computer">
            </div>
            <div class="col-md-6 form-group">
                <label>Image*</label>
                <input class="form-control"  required="required" type="text" id="image" runat="server" placeholder="img/hp_notebook.png">
            </div>
            <div class="col-md-6 form-group">
                <label>Color</label>
                <input class="form-control" type="text" id="color" runat="server" placeholder="Black">
            </div>
            <div class="col-md-6 form-group">
                <label>Dimensions*</label>
                <input class="form-control" type="text" id="dimensions" runat="server" placeholder="width heigth length">
            </div>
            <div class="col-md-6 form-group">
                <label>Weight*</label>
                <input class="form-control" required="required" type="text" id="weight" runat="server" placeholder="2kg">
            </div>
                 <div class="col-md-6 form-group">
                <label>Manufacturer*</label>
                <input class="form-control" type="text" id="manufacturer" runat="server" placeholder="eskom">
            </div>
            <div class="col-md-6 control-group">
                <label>Description*</label>
                <textarea class="form-control" rows="8" id="description" runat="server" placeholder="product description"
                required="required"
                data-validation-required-message="Please enter description"></textarea>
                <p class="help-block text-danger"></p>
            </div>

            <div class="col-md-12 form-group">
               <asp:Button runat="server" OnClick="AddProduct_Click" class="btn btn-block btn-primary font-weight-bold py-3" Text="Add Product" ID="add_product" />
            </div>
            <div class="col-md-12 form-group">
                <a href="home.aspx">exit without adding</a>
            </div>
            <div class="col-md-12 form-group">
                <p id="errormessage" style="color:red;visibility: hidden;" runat="server" >Could not add product</p>
            </div>
        </div>
    </div>
</asp:Content>
