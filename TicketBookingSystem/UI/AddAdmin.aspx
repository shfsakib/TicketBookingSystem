<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AddAdmin.aspx.cs" Inherits="TicketBookingSystem.UI.AddAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Add Admin</h2>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <div class="row">
                <div class="col-12">
                    <span>Name</span>
                    <asp:TextBox ID="txtName" class="form-control wd-100" runat="server" placeholder="Mr. X,Y"></asp:TextBox>
                </div>
                <div class="col-6">
                    <span>Email</span>
                    <asp:TextBox ID="txtEmail" class="form-control wd-100" runat="server" placeholder="example@example.com" TextMode="Email"></asp:TextBox>
                </div>
                <div class="col-6">
                    <span>Contact No.</span>
                    <asp:TextBox ID="txtMobile" class="form-control wd-100" runat="server" placeholder="01XXXXXXXXX"></asp:TextBox>
                </div>
                <div class="col-6">
                    <span>Gender</span>
                    <asp:DropDownList ID="ddlGender" class="form-control wd-100" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-6">
                    <span>Date of Birth</span>
                    <asp:TextBox ID="txtDob" class="form-control wd-100" runat="server" placeholder="mm/dd/yyyy" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-12">
                    <span>Address</span>
                    <asp:TextBox ID="txtAddress" class="form-control wd-100" runat="server" Height="80px" placeholder="House no.,Area,Thana,District,Division" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="col-6">
                    <span>New Password</span>
                    <asp:TextBox ID="txtNewPass" class="form-control wd-100" runat="server" placeholder="********" TextMode="Password"></asp:TextBox>
                </div>
                <div class="col-6">
                    <span>Confirm Password</span>
                    <asp:TextBox ID="txtConfirmPassword" class="form-control wd-100" runat="server" placeholder="********" TextMode="Password"></asp:TextBox>
                </div>
                
                <div class="col-12">
                    <span>Upload Profile Picture</span>
                    <asp:FileUpload ID="FileUpload1" class="form-control" onchange="ImagePreview(this)" runat="server" />
                </div>
                <div class="col-12 p-3">
                    <img id="imgUser" runat="server" style="border: 1px solid #696969; border-radius: 10px; width: 225px; height: 225px;" src="../ReferenceFile/images/DummyPic.png" />
                </div>
                <div class="col-12">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-12 p-2">
                    <asp:Button ID="btnNext" class="btn btn-success wd-100" OnClick="btnNext_OnClick" runat="server" Text="Create Admin" />
                </div>
            </div>
        </div>
        <div class="col-3"></div>
    </div>
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgUser.ClientID%>').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
</asp:Content>
