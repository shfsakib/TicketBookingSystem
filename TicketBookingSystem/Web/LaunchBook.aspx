<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" AutoEventWireup="true" CodeBehind="LaunchBook.aspx.cs" Inherits="TicketBookingSystem.Web.LaunchBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 p-3 text-center">
            <h1>Book Launch Ticket</h1>
        </div>
    </div>
    <div class="row" style="overflow-x: hidden">
        <div class="col-2"></div>
        <div class="col-8 p-2">
            <div class="row">
                <div class="col-12 col-lg-6">
                    <span>Seat Avaiilable</span>
                    <asp:TextBox ID="txtSeatAvailable" class="form-control" placeholder="Seat Available" ReadOnly="True" runat="server"></asp:TextBox>
                </div>
                <div class="col-12 col-lg-6">
                    <span>Number of Seats</span>
                    <asp:TextBox ID="txtSeatNo" AutoPostBack="True" Text="0" OnTextChanged="txtSeatNo_OnTextChanged" class="form-control" TextMode="Number" min="0" max="6" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-lg-6">
                    <span>Sub Total</span>
                    <asp:TextBox ID="txtSubTotal" class="form-control" placeholder="Sub Total" ReadOnly="True" runat="server"></asp:TextBox>
                </div>
                <div class="col-12 col-lg-6">
                    <span>Service Charge</span>
                    <asp:TextBox ID="txtService" placeholder="Service charge" ReadOnly="True" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
             <div class="row">
                <div class="col-12">
                    <span>Total Price</span>
                    <asp:TextBox ID="txtTotal" class="form-control" placeholder="0" ReadOnly="True" runat="server"></asp:TextBox>
                </div>
                
            </div>
            <div class="row p-2"></div>
            <div class="row pl-3">
                <h2 style="color: purple">Payment Method</h2>
            </div>
            <hr />
            <div class="row">
                <div class="col-12 text-left">
                    <h6>
                        <p>
                            Please pay BDT <span runat="server" id="paymentPercentage"></span> as advance for book your ticket. You won't get it back if you cancel your ticket. Bkash your advance to this number <b><span id="number" runat="server"></span></b>.Use 
                                "<b><asp:Label ID="lblRandom" runat="server"></asp:Label></b>" as reference id.
                        </p>
                    </h6>
                </div>
            </div>
            <div class="row p-1">
                <br/>
            </div>
            <div class="row">
                <div class="col-12">
                    <span>Bkash No.(Last 6 digits only)</span>
                    <asp:TextBox ID="txtBkashNo" runat="server" TextMode="Number" min="0" placeholder="XXXXXX" MaxLength="6" class="form-control wd-100"></asp:TextBox>
                </div>
            </div>
             <div class="row">
                <div class="col-12">
                    <span>Transaction no.</span>
                    <asp:TextBox ID="txtTransNo" autocomplete="off" runat="server" placeholder="XXXXXXXXXX" class="form-control wd-100"></asp:TextBox>
                </div>
            </div>
             <div class="row">
                <div class="col-12">
                    <span>Amount</span>
                    <asp:TextBox ID="txtAmount" runat="server" placeholder="XXXXXXXX" TextMode="Number" class="form-control wd-100"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12 pt-2">
                    <asp:Button ID="btnBuy" runat="server" OnClick="btnBuy_OnClick" CssClass="btn btn-success wd-100" Text="Confirm Ticket" />
                     </div>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
