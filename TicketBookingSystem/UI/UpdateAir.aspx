<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="UpdateAir.aspx.cs" Inherits="TicketBookingSystem.UI.UpdateAir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Update Air</h2>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Flight No</span>
            <asp:TextBox ID="txtFlightNo" class="form-control" placeholder="Flight-XX" autocomplete="off" runat="server"></asp:TextBox>
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
            <span>Departure Time</span>
            <asp:TextBox ID="txtDepartureTime" class="form-control" TextMode="Time" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Quickest Time</span>
            <asp:TextBox ID="txtQuickestTime" class="form-control" TextMode="Time" runat="server"></asp:TextBox>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-12 col-lg-6">
            <span>Seat Capacity</span>
            <asp:TextBox ID="txtSeatCap" class="form-control" TextMode="Number" min="50" runat="server"></asp:TextBox>
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
        <div class="col-12 col-lg-6 p-3">
            <asp:Button ID="btnUpdate" class="btn btn-primary wd-100" OnClick="btnUpdate_OnClick"  runat="server" Text="Update Air" />
        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>
