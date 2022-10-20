<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="queryresponse.aspx.cs" Inherits="Group_Practical_Front_End.queryresponse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Contact Start -->
    <div class="container-fluid">
        <h2 class="section-title position-relative text-uppercase mx-xl-5 mb-4"><span class="bg-secondary pr-3">Contact Us</span></h2>
        <div class="row px-xl-5">
            <div class="col-lg-7 mb-5">
                <div class="contact-form bg-light p-30">
                    <div id="success" runat="server"></div>
                    <form name="sentMessage" id="contactForm" novalidate="novalidate">
                        <div class="control-group">
                            <p runat="server" id="user_message"> the query text lorem</p>
                        </div>
                        <div class="control-group">
                            <textarea class="form-control" rows="8" runat="server" id="message" placeholder="Response Message"></textarea>
                            <p class="help-block text-danger"></p>
                        </div>
                        <div>
                            <asp:Button class="btn btn-primary py-2 px-4" OnClick="Send_Click" id="sendMessageButton" runat="server" Text="Send Response"/>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- Contact End -->
</asp:Content>
