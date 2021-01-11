<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="BookedBusList.aspx.cs" Inherits="TicketBookingSystem.UI.BookedBusList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Bus Booking List</h2>
    </div>
    <div class="row">
        <div class="col-12 table-responsive p-3">
            <asp:GridView ID="gridBooking" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridBooking_OnPageIndexChanging" OnRowDataBound="gridBooking_OnRowDataBound" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Bus Found" AllowPaging="True" PageSize="30" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("TokenId")%>' />
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("UserId")%>' />
                            <div class="row">
                                <div class="col-12 col-lg-3">
                                    <asp:Label ID="Label1" class="d-block" Style="font-size: 18px; font-weight: bold" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    <asp:Label ID="Label11" class="d-block" Style="font-size: 16px;" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                    <span class="d-block">
                                        <asp:Label ID="Label2" runat="server" Style="font-size: 16px;" Text='<%#Eval("CoachName") %>'></asp:Label>&nbsp;<asp:Label ID="lblType" Style="font-size: 14px; font-weight: bold" runat="server" Text='<%#Eval("CoachType") %>'></asp:Label></span>
                                    <asp:Label ID="Label5" class="d-inline-block" Style="font-size: 14px; font-weight: bold; color: cornflowerblue" runat="server" Text='<%#"From "+Eval("FromLocation")+" to " +Eval("ToLocation") %>'></asp:Label><br />

                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <span class="font-weight-bold">Departure Time:</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label6" class="d-inline-block" runat="server" Text='<%#TimeC(Eval("DepartureTime").ToString())%>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span class="font-weight-bold">Seat Name</span><br class="d-none d-lg-block" />
                                    <span class="d-block m-auto">
                                        <asp:DataList ID="DataListSeat" Width="100%" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("SeatName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:DataList></span>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span class="font-weight-bold">Passengers:</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="lblSeat" class="d-inline-block" runat="server" Text='<%#Eval("Seat") %>'></asp:Label>
                                    <span class="font-weight-bold d-block">Journey Date:</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label8" class="d-inline-block" runat="server" Text='<%#Eval("JourneyDate") %>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <span class="d-inline-block"><span class="font-weight-bold">Bkash No:</span><br class="d-none d-lg-block" />
                                        <asp:Label ID="Label4" class="d-inline-block" runat="server" Text='<%#Eval("BkashNo") %>'></asp:Label></span>
                                    <span class="d-block"><span class="font-weight-bold">Trans No:</span><br class="d-none d-lg-block" />
                                        <asp:Label ID="Label10" class="d-inline-block" runat="server" Text='<%#Eval("TransactionNo") %>'></asp:Label></span>
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <span class="font-weight-bold">Service Charge:</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label9" class="d-inline-block" runat="server" Text='<%#Eval("ServiceCharge") %>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <span class="font-weight-bold">Advance</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label7" class="d-inline-block" runat="server" Text='<%#Eval("Advance") %>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <asp:Label ID="lblPrice" class="d-inline-block pt-2" runat="server" Style="font-size: 18px; font-weight: bold; color: green;" Text='<%#"Total: ৳"+SubValue(Eval("GrandTotal").ToString())%>'></asp:Label>
                                    <asp:LinkButton ID="lblRem" OnClick="lblRem_OnClick" class="btn btn-danger wd-100 d-block" runat="server" title="Cancel"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
