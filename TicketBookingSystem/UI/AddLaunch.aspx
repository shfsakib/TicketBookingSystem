<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" CodeBehind="AddLaunch.aspx.cs" EnableEventValidation="false" Inherits="TicketBookingSystem.UI.AddLaunch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Add Launch</h2>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Launch Name</span>
            <asp:TextBox ID="txtName" class="form-control" placeholder="xyz" autocomplete="off" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Launch No.</span>
            <asp:TextBox ID="txtLaunchNo" class="form-control" autocomplete="off" placeholder="XXX-XXX" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Launch Type</span>
            <asp:DropDownList ID="ddlType" runat="server" class="form-control">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Ac</asp:ListItem>
                <asp:ListItem>Non Ac</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>District From</span><br/>
            <asp:DropDownList ID="ddlDistrictFrom" runat="server" class="select2 form-control">
                <asp:ListItem>Select</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>District To</span><br/>
            <asp:DropDownList ID="ddlDistrictTO" runat="server" class="form-control select2">
                <asp:ListItem>Select</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Starting Point</span>
            <asp:TextBox ID="txtStartPoint" class="form-control" placeholder="Place Name" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>End Point</span>
            <asp:TextBox ID="txtEndPoint" class="form-control" placeholder="Place Name" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Departure Time</span>
            <asp:TextBox ID="txtDepartureTime" class="form-control" TextMode="Time" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Arrival Time</span>
            <asp:TextBox ID="txtArrivalTime" class="form-control" TextMode="Time" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Seat Type</span>
            <asp:DropDownList ID="ddlSeatType" runat="server" class="form-control">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>B Class</asp:ListItem>
                <asp:ListItem>E Class</asp:ListItem>

            </asp:DropDownList>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Seat Capacity</span>
            <asp:TextBox ID="txtSeatCapa" class="form-control" TextMode="Number" min="50" runat="server"></asp:TextBox>
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
            <span>Bus Status</span>
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
            <asp:Button ID="btnAdd" class="btn btn-primary wd-100" OnClick="btnAdd_OnClick"  runat="server" Text="Add Launch" />
        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>
