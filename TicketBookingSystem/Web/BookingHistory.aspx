<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" AutoEventWireup="true" CodeBehind="BookingHistory.aspx.cs" Inherits="TicketBookingSystem.Web.BookingHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 text-center p-3">
            <h1>Booking History</h1>
        </div>
    </div>
    <div class="row p-3">
        <div class=" col-8 col-lg-4">
            <asp:TextBox ID="txtToken" class="form-control" AutoPostBack="True" OnTextChanged="txtToken_OnTextChanged" placeholder="Search by token id" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-12 table-responsive p-3">
            <asp:GridView ID="gridBooking" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridBuses_OnPageIndexChanging" OnRowDataBound="gridBuses_OnRowDataBound" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Bus Found" AllowPaging="True" PageSize="30" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("TokenId")%>' />
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("CompanyId")%>' />
                            <div class="row">
                                <div class="col-12 col-lg-3">
                                    <asp:Label ID="Label1" class="d-block" Style="font-size: 18px; font-weight: bold" runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                    <span class="d-block">
                                        <asp:Label ID="Label2" runat="server" Style="font-size: 16px;" Text='<%#Eval("CoachName") %>'></asp:Label>&nbsp;<asp:Label ID="lblType" Style="font-size: 14px; font-weight: bold" runat="server" Text='<%#Eval("CoachType") %>'></asp:Label></span>
                                    <span class="d-inline-block">Travel Location: </span>
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
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script>
        function pageLoad() {
            $("#<%=txtToken.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetToken",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtToken.ClientID %>").val() + "'}",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item,
                                    value: item
                                };
                            }));
                        },
                        error: function (result) {
                            Swal.fire({
                                position: 'center',
                                icon: 'warning',
                                title: 'Token not found',
                                showConfirmButton: true,
                                timer: 6000
                            });
                        }
                    });
                },
                minLength: 1,
            });
        };
    </script>
</asp:Content>
