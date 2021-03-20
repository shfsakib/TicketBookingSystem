<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" CodeBehind="BookedListAll.aspx.cs" EnableEventValidation="false" Inherits="TicketBookingSystem.UI.BookedListAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Booked List</h2>
    </div>
    <div class="row">
        <div class="col-lg-4">
            Choose Company:
            <asp:DropDownList ID="ddlCompany" AutoPostBack="True" class="form-control select2" OnSelectedIndexChanged="ddlCompany_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
        </div>
        <div class="col-lg-4">
            Choose Coach Type:
            <asp:DropDownList ID="ddlCoach" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCoach_OnSelectedIndexChanged" runat="server">
                <asp:ListItem>--SELECT--</asp:ListItem>
                <asp:ListItem>Bus</asp:ListItem>
                <asp:ListItem>Launch</asp:ListItem>
                <asp:ListItem>Air</asp:ListItem>
                <asp:ListItem>Movie</asp:ListItem>
                <asp:ListItem>Event</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-12 table-responsive p-3">
            <asp:GridView ID="gridBooking" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridBooking_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Booking Found" AllowPaging="True" PageSize="30" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("TokenId")%>' />
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("UserId")%>' />
                            <asp:HiddenField ID="HiddenField3" runat="server" Value='<%#Eval("Status")%>' />

                            <div class="row">
                                <div class="col-12 col-lg-3">
                                    <asp:Label ID="Label1" class="d-block" Style="font-size: 18px; font-weight: bold" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    <asp:Label ID="Label11" class="d-block" Style="font-size: 16px;" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                    <br />
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <span class="font-weight-bold">Departure Time:</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label6" class="d-inline-block" runat="server" Text='<%#TimeC(Eval("DepartureTime").ToString())%>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span class="font-weight-bold">Total_Ticket</span><br class="d-none d-lg-block" />
                                    <span class="d-block m-auto">
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Seat") %>'></asp:Label>
                                    </span>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
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
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
