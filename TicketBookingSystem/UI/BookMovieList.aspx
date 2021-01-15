﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="BookMovieList.aspx.cs" Inherits="TicketBookingSystem.UI.BookMovieList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Booked Movie List</h2>
    </div>
    <div class="row">
        <div class="col-12 table-responsive p-3">
            <asp:GridView ID="gridBooking" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridBooking_OnPageIndexChanging" OnRowDataBound="gridBooking_OnRowDataBound" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Bus Found" AllowPaging="True" PageSize="30" runat="server">
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
                                    <span class="d-block">
                                        <asp:Label ID="Label2" runat="server" Style="font-size: 16px;" Text='<%#Eval("EventName") %>'></asp:Label>&nbsp;<asp:Label ID="lblType" Style="font-size: 14px; font-weight: bold" runat="server" Text='<%#Eval("SeatType") %>'></asp:Label></span>
                                    <i class="fas fa-map-marker-alt"></i>
                                    <asp:Label ID="Label5" class="d-inline-block" Style="font-size: 14px; font-weight: bold; color: cornflowerblue" runat="server" Text='<%#Eval("EventAddress")+"," +Eval("EventLocation") %>'></asp:Label><br />

                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span class="font-weight-bold">Show Time:</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label6" class="d-inline-block" runat="server" Text='<%#TimeC(Eval("StartTime").ToString())+" - "+TimeC(Eval("EndTime").ToString())%>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <span class="font-weight-bold">Seats</span><br class="d-none d-lg-block" />
                                    <span class="d-block m-auto">
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("SeatName")%>'></asp:Label></span>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span class="font-weight-bold d-block">Premier Date:</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label8" class="d-inline-block" runat="server" Text='<%#Eval("EventDate") %>'></asp:Label>
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
                                    <asp:LinkButton ID="lnkDel" OnClick="lnkDel_OnClick" class="btn btn-danger wd-100 d-block" runat="server" title="Cancel"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
