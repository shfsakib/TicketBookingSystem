<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="PrintTicket.aspx.cs" Inherits="TicketBookingSystem.Web.PrintTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../ReferenceFile/OwnStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 p-3 text-center">
            <h1>Price Ticket</h1>
        </div>
    </div>
    <div class="row p-2" style="overflow-x: hidden">
        <div class="col-lg-3"></div>
        <div class="col-12 col-lg-4">
            <span>Token Id</span>
            <asp:TextBox ID="txtToken" autocomplete="off" placeholder="XXXXXXXX" class="form-control wd-100" runat="server"></asp:TextBox>
        </div>
        <div class="col-12 col-lg-2">
            <asp:Button ID="btnSearch" OnClick="btnSearch_OnClick" runat="server" class="btn btn-success mt-4" Text="Find Ticket" />
        </div>
        <div class="col-lg-3"></div>
    </div>
    <style>
        @media print {
            body {
                visibility: hidden;
            }

            .printDiv, .printDiv * {
                visibility: visible;
                width: 100%;
            }

            .printDiv {
                position: absolute;
                top: 0;
                left: 0;
            }
        }
    </style>
    <div class="row">
        <div class="col-12 text-right">
            <button onclick="window.print();">Print</button>
        </div>
    </div>
    <div id="printDiv" class="printDiv col-12 wd-100 pl-4" runat="server" visible="False">
        <div class="row p-2" style="overflow-x: hidden; font-family: comic sans ms; font-size: 16px;">
            <div class="col-12 wd-100 text-center">
                <img src="/ReferenceFile/logo.png" style="height: 50px; width: 165px;" />
            </div>
        </div>
        <div class="row">
            <div class="col-12 text-center">
                <h4 class="">Ticket Online Copy</h4>
            </div>
        </div>
        <div class="row p-3">
            <div class="col-12 text-center">
                <h3 class="">
                    <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label>
                    to
                    <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label></h3>
            </div>
        </div>
        <div class="row">
            <br />
        </div>
        <div style="border-radius: 15px; border: 1px solid #696969; padding: 10px;">
            <div class="row ">
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Token Id: </span>
                    <asp:Label ID="lblToken" runat="server" Text="TokenId"></asp:Label>
                </div>
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Bus Coach: </span>
                    <asp:Label ID="lblCompany" runat="server" Text="Coach"></asp:Label>
                </div>
            </div>
            <div class="row ">
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Book Time: </span>
                    <asp:Label ID="lblBookTime" runat="server" Text="Time"></asp:Label>
                </div>
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Journey Date: </span>
                    <asp:Label ID="lblJourney" runat="server" Text="date"></asp:Label>
                </div>
            </div>
            <div class="row ">
                <div class="col-12 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Seat Name: </span>
                    <asp:Label ID="lblSeatName" runat="server" Text="seat"></asp:Label>
                </div>

            </div>
            <div class="row ">
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Departure: </span>
                    <asp:Label ID="lblDeparture" runat="server" Text="Time"></asp:Label>
                </div>
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Passenger/Seat: </span>
                    <asp:Label ID="lblSeat" runat="server" Text="Time"></asp:Label>
                </div>
            </div>

            <div class="row ">
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Starting Point: </span>
                    <asp:Label ID="lblStart" runat="server" Text="start"></asp:Label>
                </div>
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">End Point: </span>
                    <asp:Label ID="lblEnd" runat="server" Text="End"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <br />
        </div>
        <div style="border-radius: 15px; border: 1px solid #696969; padding: 10px;">
            <div class="row ">
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Payment Details: </span>

                </div>
                <div class="col-6 text-left" style="font-size: 18px;">
                </div>
            </div>
            <div class="row ">
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Name: </span>
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                </div>
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Email: </span>
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </div>
            </div>
            <div class="row ">
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Seat Fare (per seat): </span>
                    <asp:Label ID="lblSeatFare" runat="server" Text="seat"></asp:Label>
                </div>
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Service Charge: </span>
                    <asp:Label ID="lblService" runat="server" Text="charge"></asp:Label>
                </div>

            </div>
            <div class="row ">
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Advance: </span>
                    <asp:Label ID="lblAdvance" runat="server" Text="advance"></asp:Label>
                </div>
                <div class="col-6 text-left" style="font-size: 18px;">
                    <span class="font-weight-bold">Grand Total: </span>
                    <asp:Label ID="lblTotal" runat="server" Text="total"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <br />
        </div>
        <div class="text-center" style="border-radius: 15px; border: 1px solid #696969; padding: 10px;">
            Thanks for Buying ticket from MyTickets.
        </div>
        <asp:GridView ID="gridSeat" Visible="False" style="display: none;" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="SeatName" runat="server" Text='<%#Eval("SeatName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="row">
        <br />
    </div>
</asp:Content>
