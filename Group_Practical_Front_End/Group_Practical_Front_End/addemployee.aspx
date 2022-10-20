<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addemployee.aspx.cs" Inherits="Group_Practical_Front_End.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg-light p-30 mb-5" style="width: 800px;margin: auto;left: 0;right: 0;top: 0;bottom: 0;margin-top: 100px;border-width: 1px;">

    <div>
        <h1 style="text-align:center;" id="header" runat="server">Add Employee</h1>
        <br/>
    </div>

        <div class="row">
            <div class="col-md-6 form-group">
                <label>First Name*</label>
                <input class="form-control" type="text" id="name" runat="server" placeholder="John">
            </div>

            <div class="col-md-6 form-group">
                <label>Last Name*</label>
                <input class="form-control" type="text" id="surname" runat="server" placeholder="Doe">
            </div>

            <div class="col-md-6 form-group" id="employeeeType" runat="server" visible="true">
                <label>Employee Type*</label>
                <input class="form-control" type="text" id="employeeType" runat="server" placeholder="employee Type">
            </div>

            <div class="col-md-6 form-group">
                <label>Email*</label>
                <input class="form-control" type="email" id="email" runat="server" placeholder="jabez@gmail.com">
            </div>

            <div class="col-md-6 form-group">
                <label>Password*</label>
                <input class="form-control" type="password" id="password" runat="server" placeholder="Password">
            </div>

            <div class="col-md-6 form-group">
                <label>Username*</label>
                <input class="form-control" type="text" id="username" runat="server" placeholder="Username">
            </div>

            <div class="col-md-6 form-group">
                <label>Confirm Password*</label>
                <input class="form-control" type="password" id="confirmpass" runat="server" placeholder="Confirm Password">
            </div>

            <div class="col-md-12 form-group">
               <asp:Button runat="server" class="btn btn-block btn-primary font-weight-bold py-3" Text="Add Employee" ID="addEmployee" OnClick="addEmployee_Click" />
            </div>

           <div class="col-md-12 form-group" id="error" runat="server">
                <p id="errormessage" style="color:red;visibility: hidden;" runat="server" >Could Not Add Employee</p>
           </div>
        </div>
    </div>

</asp:Content>
