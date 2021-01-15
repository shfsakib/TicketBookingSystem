<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AddEvent.aspx.cs" Inherits="TicketBookingSystem.UI.AddEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Add Event</h2>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Event Name</span>
            <asp:TextBox ID="txtEventName" class="form-control" placeholder="xyz" autocomplete="off" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Event Address</span>
            <asp:TextBox ID="txtAddress" TextMode="MultiLine" Height="80px" class="form-control" placeholder="Location,Thana" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>District</span><br />
            <asp:DropDownList ID="ddlDistrict" runat="server" class="select2 form-control">
                <asp:ListItem>Select</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-3"></div>
    </div>

    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Start Time</span>
            <asp:TextBox ID="txtStartTime" class="form-control" TextMode="Time" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>End Time</span>
            <asp:TextBox ID="txtEndTime" class="form-control" TextMode="Time" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Event Date</span>
            <asp:TextBox ID="txtDate" class="form-control" TextMode="Date" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Ticket Limit</span>
            <asp:TextBox ID="txtSeatCapa" class="form-control" TextMode="Number" min="30" Text="0" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Ticket Price</span>
            <asp:TextBox ID="txtTPrice" class="form-control" placeholder="BDT XXX" TextMode="Number" min="0" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Event Picture</span><br />
            <asp:FileUpload ID="fileMovie" accept="image/*" runat="server" onchange="ImagePreview(this)" />
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <asp:Image ID="imgPre" Style="margin-top: 20px; border: 1px solid #696969; border-radius: 10px; width: 225px; height: 225px;" src="../ReferenceFile/images/DummyPic.png" runat="server" />
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Status</span>
            <asp:DropDownList ID="ddlStatus" runat="server" class="form-control">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem Value="A">Active</asp:ListItem>
                <asp:ListItem Value="I">Inactive</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6 p-3">
            <asp:Button ID="btnAdd" class="btn btn-primary wd-100" OnClick="btnAdd_OnClick" runat="server" Text="Add Movie" />
        </div>
        <div class="col-3"></div>
    </div>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgPre.ClientID%>').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
</asp:Content>
