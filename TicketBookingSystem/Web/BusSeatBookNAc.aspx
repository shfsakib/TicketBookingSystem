<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="BusSeatBookNAc.aspx.cs" Inherits="TicketBookingSystem.Web.BusSeatBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../ReferenceFile/Ownjs.js"></script>
    <link href="../ReferenceFile/OwnStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-12 p-3 text-center">
            <h1>Book Bus Ticket</h1>
        </div>
    </div>
    <div class="row" style="overflow-x: hidden">
        <div class="col-12 col-lg-6 p-2 text-right" style="border-right: 1px solid #e6e6fa">
            <div class="row p-3">
                <div class="col-3"></div>
                <div class="col-2 text-center">
                    <asp:Button ID="btnB" runat="server" Style="width: 60px; height: 50px; color: white; border: 1px solid #696969; border-radius: 5px;" />
                    <br />
                    <span>Booked</span>
                </div>
                <div class="col-2 text-center">
                    <asp:Button ID="btnA" runat="server" Style="width: 60px; height: 50px; border: 1px solid #696969; color: white; border-radius: 5px;" />
                    <br />
                    <span>Available</span>
                </div>
                <div class="col-2 text-center">
                    <asp:Button ID="btnS" runat="server" Style="width: 60px; height: 50px; border: 1px solid #696969; color: white; border-radius: 5px;" />
                    <br />
                    <span>Selected</span>
                </div>
            </div>
            <style>
                .seatDiv {
                    margin-left: 30% !important;
                    border: 1px solid #8fbc8f;
                    min-height: 450px;
                    min-width: 285px;
                }
            </style>
            <div class="row text-center">
                <div class="col-5 pb-2 seatDiv">
                    <div class="row">
                        <div class="col-8">
                        </div>
                        <div class="col-4 p-2">
                            <img src="/ReferenceFile/wheel.png" style="height: 40px; width: 40px;" />
                        </div>
                    </div>
                    <hr class="mp" />
                    <div class="row">
                        <div class="col-2 text-center">
                            <asp:Button ID="btnA1" runat="server" OnClick="btnA1_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="A1" />
                        </div>
                        <div class="col-2 text-center">
                            <asp:Button ID="btnA2" runat="server" OnClick="btnA2_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="A2" />
                        </div>
                        <div class="col-3 text-center">
                        </div>
                        <div class="col-2 text-center">
                            <asp:Button ID="btnA3" runat="server" OnClick="btnA3_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="A3" />
                        </div>
                        <div class="col-2 text-center">
                            <asp:Button ID="btnA4" runat="server" OnClick="btnA4_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="A4" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnB1" runat="server" OnClick="btnB1_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="B1" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnB2" runat="server" OnClick="btnB2_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="B2" />
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnB3" runat="server" OnClick="btnB3_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="B3" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnB4" runat="server" OnClick="btnB4_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="B4" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnc1" runat="server" OnClick="btnc1_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="C1" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnC2" runat="server" OnClick="btnC2_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="C2" />
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnC3" runat="server" OnClick="btnC3_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="C3" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnC4" OnClick="btnC4_OnClick" runat="server" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="C4" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnD1" runat="server" OnClick="btnD1_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="D1" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnD2" runat="server" OnClick="btnD2_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="D2" />
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnD3" runat="server" OnClick="btnD3_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="D3" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnD4" runat="server" OnClick="btnD4_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="D4" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnE1" runat="server" OnClick="btnE1_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="E1" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnE2" runat="server" OnClick="btnE2_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="E2" />
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnE3" runat="server" OnClick="btnE3_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="E3" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnE4" runat="server" OnClick="btnE4_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="E4" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnF1" runat="server" OnClick="btnF1_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="F1" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnF2" runat="server" OnClick="btnF2_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="F2" />
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnF3" runat="server" OnClick="btnF3_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="F3" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnF4" runat="server" OnClick="btnF4_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="F4" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnG1" runat="server" OnClick="btnG1_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="G1" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnG2" runat="server" OnClick="btnG2_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="G2" />
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnG3" runat="server" OnClick="btnG3_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="G3" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnG4" runat="server" OnClick="btnG4_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="G4" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnH1" runat="server" OnClick="btnH1_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="H1" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnH2" runat="server" OnClick="btnH2_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="H2" />
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnH3" runat="server" OnClick="btnH3_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="H3" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnH4" runat="server" OnClick="btnH4_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="H4" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnI1" runat="server" OnClick="btnI1_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="I1" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnI2" runat="server" OnClick="btnI2_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="I2" />
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnI3" runat="server" OnClick="btnI3_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="I3" />
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button ID="btnI4" runat="server" OnClick="btnI4_OnClick" Style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="I4" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-12 col-lg-3 pt-4 p-2 text-right">
            <div class="row">
                <h2 class="pl-3" style="color: purple">Seat Information</h2>
            </div>
            <hr />
            <div class="row">
                <div class="col-4">
                    <asp:GridView ID="gridTicket" runat="server" Width="100%" class="table table-hover table-bordered table-striped" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" PageSize="6">
                        <Columns>
                            <asp:TemplateField HeaderText="Seat_Name">
                                <ItemStyle Width="150px"></ItemStyle>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Container.DataItemIndex+1 %>' />
                                    <asp:Label ID="lblSeat" runat="server" Text='<%#Eval("SeatName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fare">
                                <ItemTemplate>
                                    <asp:Label ID="lblFare" runat="server" Text='<%#Eval("Fare") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <table class="table table-borderless">
                        <tr>
                            <td class="text-left" style="width: 100px">Sub Total:</td>
                            <td class="text-right">
                                <asp:Label ID="lblSubTotal" runat="server" Text="0"></asp:Label><span>৳</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" style="width: 100px">Service Charge:</td>
                            <td class="text-right">
                                <asp:Label ID="lblServiceCharge" runat="server" Text="0"></asp:Label><span>৳</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" style="width: 100px">Grand Total:</td>
                            <td class="text-right">
                                <asp:Label ID="lblGrandTotal" runat="server" Text="0"></asp:Label><span>৳</span>
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
            <div class="row">
                <div class="col-12">
                    <asp:Button ID="btnBuy" runat="server" OnClick="btnBuy_OnClick" CssClass="btn btn-success wd-100" Text="Confirm Ticket" />
                </div>
            </div>
        </div>

        <div class="col-12 col-lg-3 p-2 pt-4 text-left">
            <asp:Panel ID="panelPayment" runat="server">
                <div class="row pl-3">
                    <h2 style="color: purple">Payment Method</h2>
                </div>
                <hr />
                <div class="row">
                    <div class="col-12 text-left">
                        <h6>
                            <p>
                                Please pay BDT <span runat="server" id="paymentPercentage"></span>as advance for book your ticket. You won't get it back if you cancel your ticket. Bkash your advance to this number <b><span id="number" runat="server"></span></b>.Use 
                                "<b><asp:Label ID="lblRandom" runat="server"></asp:Label></b>" as reference id.
                            </p>
                        </h6>
                    </div>
                </div>
                <div class="row p-1">
                    <br />
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
                        <asp:Button ID="btnPay" runat="server" OnClick="btnPay_OnClick" CssClass="btn btn-primary wd-100" Text="Pay Bill" />
                    </div>
                </div>
            </asp:Panel>
        </div>

    </div>
</asp:Content>
