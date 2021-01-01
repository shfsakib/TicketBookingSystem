<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" AutoEventWireup="true" CodeBehind="BusSeatBookNAc.aspx.cs" Inherits="TicketBookingSystem.Web.BusSeatBook" %>

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
    <div class="row">
        <div class="col-12 col-lg-6 p-2 text-right" style="border-right: 1px solid #e6e6fa">
            <div class="row p-3">
                <div class="col-3"></div>
                <div class="col-2 text-center">
                    <asp:Button ID="btnB" runat="server" style="width: 60px; height: 50px; color: white; border: 1px solid #696969; border-radius: 5px;"/>
                    <br />
                    <span>Booked</span>
                </div>
                <div class="col-2 text-center">
                    <asp:Button ID="btnA" runat="server" style="width: 60px; height: 50px;border: 1px solid #696969; color: white; border-radius: 5px;"/>
                    <br />
                    <span>Available</span>
                </div>
                <div class="col-2 text-center">
                    <asp:Button ID="btnS" runat="server" style="width: 60px; height: 50px; border: 1px solid #696969; color: white; border-radius: 5px;"/>
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
                            <asp:Button id="btnA1" runat="server" OnClick="btnA1_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="A1"/>
                        </div>
                        <div class="col-2 text-center">
                            <asp:Button id="btnA2" runat="server" OnClick="btnA2_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="A2"/>
                        </div>
                        <div class="col-3 text-center">
                        </div>
                        <div class="col-2 text-center">
                            <asp:Button id="btnA3" runat="server" OnClick="btnA3_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="A3"/>
                        </div>
                        <div class="col-2 text-center">
                            <asp:Button id="btnA4" runat="server" OnClick="btnA4_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="A4"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnB1" runat="server" OnClick="btnB1_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="B1"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnB2" runat="server" OnClick="btnB2_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="B2"/>
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnB3" runat="server" OnClick="btnB3_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="B3"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnB4" runat="server" OnClick="btnB4_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="B4"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnc1" runat="server" OnClick="btnc1_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="C1"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnC2" runat="server" OnClick="btnC2_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="C2"/>
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnC3" runat="server" OnClick="btnC3_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="C3"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnC4" OnClick="btnC4_OnClick" runat="server" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="C4"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnD1" runat="server" OnClick="btnD1_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="D1"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnD2" runat="server" OnClick="btnD2_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="D2"/>
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnD3" runat="server" OnClick="btnD3_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="D3"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnD4" runat="server" OnClick="btnD4_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="D4"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnE1" runat="server" OnClick="btnE1_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="E1"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnE2" runat="server" OnClick="btnE2_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="E2"/>
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnE3" runat="server" OnClick="btnE3_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="E3"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnE4" runat="server" OnClick="btnE4_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="E4"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnF1" runat="server" OnClick="btnF1_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="F1"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnF2" runat="server" OnClick="btnF2_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="F2"/>
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnF3" runat="server" OnClick="btnF3_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="F3"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnF4" runat="server" OnClick="btnF4_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="F4"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnG1" runat="server" OnClick="btnG1_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="G1"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnG2" runat="server" OnClick="btnG2_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="G2"/>
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnG3" runat="server" OnClick="btnG3_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="G3"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnG4" runat="server" OnClick="btnG4_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="G4"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnH1" runat="server" OnClick="btnH1_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="H1"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnH2" runat="server" OnClick="btnH2_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="H2"/>
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnH3" runat="server" OnClick="btnH3_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="H3"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnH4" runat="server" OnClick="btnH4_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="H4"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnI1" runat="server" OnClick="btnI1_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="I1"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnI2" runat="server" OnClick="btnI2_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="I2"/>
                        </div>
                        <div class="col-3 text-center mt-2">
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnI3" runat="server" OnClick="btnI3_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="I3"/>
                        </div>
                        <div class="col-2 text-center mt-2">
                            <asp:Button id="btnI4" runat="server" OnClick="btnI4_OnClick" style="width: 40px; height: 40px; border: 1px solid #696969; color: white; border-radius: 5px;" Text="I4"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-12 col-lg-6 p-4 text-right" style="border-right: 1px solid #e6e6fa">
            <div class="row">
                <h2 style="color: purple">Seat Information</h2>
            </div>
            <div class="row">
                <div class="col-4">
                    <asp:GridView ID="gridTicket" runat="server" Width="100%" class="table table-hover table-bordered table-striped" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" PageSize="6">
                        <Columns>
                            <asp:TemplateField HeaderText="Seat">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Container.DataItemIndex+1 %>'/>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("SeatName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fare">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Fare") %>'></asp:Label>
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
        </div>
    </div>
</asp:Content>
