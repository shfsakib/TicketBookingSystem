<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" AutoEventWireup="true" CodeBehind="BusTicket.aspx.cs" Inherits="TicketBookingSystem.Web.BusTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mp">
        <div class="col-12 ticketSearchDiv">
            <div class="row">
                <div class="col-12 ticketSearchBar">
                    <div class="row">
                        <div class="col-3">
                            <i class="fas fa-map-marker-alt fa-lg txtIcon"></i>
                            <asp:TextBox ID="txtDisFrom" class="form-control wd-100 textbox" Style="height: 60px;" placeholder="FROM" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-3">
                            <i class="fas fa-map-marker-alt fa-lg txtIcon"></i>
                            <asp:TextBox ID="txtDisTo" class="form-control wd-100 textbox" Style="height: 60px;" placeholder="TO" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-3">
                            <i class="fas fa-calender fa-lg txtIcon"></i>
                            <asp:TextBox ID="txtJourneyDate" class="form-control wd-100 textbox" Style="height: 60px;" placeholder="" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-3">
                            <asp:Button ID="btnSearch" class="btn btn-success wd-100" runat="server" Text="Search Buses" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
