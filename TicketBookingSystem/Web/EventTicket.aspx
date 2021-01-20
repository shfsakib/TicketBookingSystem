<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EventTicket.aspx.cs" Inherits="TicketBookingSystem.Web.EventTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mp">
        <div class="col-12 ticketSearchDiv" style="text-align: center;">
            <div class="row">
                <div class="ticketSearchBar" style="width: 40%; margin: 0 auto;">
                    <div class="row">
                        <div class="col-12 col-lg-6">
                            <i class="fas fa-map-marker-alt fa-lg" style="position: absolute;left: 25px!important;margin-top: 25px;"></i>
                            <asp:TextBox ID="txtLocation" AutoPostBack="True" OnTextChanged="txtLocation_OnTextChanged" class="form-control wd-100 textbox" Style="height: 60px; text-transform: uppercase" placeholder="District" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-12 col-lg-6 mt-1 mt-lg-0">
                            <asp:LinkButton ID="btnSearch" OnClick="btnSearch_OnClick" class="btn btn-success wd-100" Style="height: 60px; padding-top: 20px;" runat="server"><i class="fas fa-calendar-alt fa-lg"></i>&nbsp;&nbsp;Search Event</asp:LinkButton>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12 busList table-responsive p-5" style="min-height: 250px">
            <asp:GridView ID="gridMovie" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridMovie_OnPageIndexChanging" OnRowDataBound="gridMovie_OnRowDataBound" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Event Found" AllowPaging="True" PageSize="30" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("EventId")%>' />
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("CompanyId")%>' />
                            <div class="row">
                                <div class="col-6 col-lg-2 text-center">
                                    <asp:Image ID="Image1" runat="server" Style="width: 125px; height: 125px;" src='<%#Eval("Picture") %>' />
                                </div>
                                <div class="col-6 col-lg-3">
                                    <asp:Label ID="Label1" class="d-block" Style="font-size: 18px; font-weight: bold" runat="server" Text='<%#Eval("EventName") %>'></asp:Label>
                                    <span class="d-block"><i class="fas fa-map-marker-alt"></i>
                                        <asp:Label ID="Label2" runat="server" Style="font-size: 16px;" Text='<%#Eval("EventAddress")+" , "+ Eval("EventLocation")%>'></asp:Label></span>
                                     <span class="d-block"><i class="fas fa-map-calendar-alt"></i>
                                        <asp:Label ID="lbldate" runat="server" Style="font-size: 16px;" Text='<%#Eval("EventDate")%>'></asp:Label></span>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span>Event_Time</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label6" class="d-inline-block font-weight-bold" runat="server" Text='<%# TimeC(Eval("StartTime").ToString())+" - "+ TimeC(Eval("EndTime").ToString())%>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <span>Start_From</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label4" class="d-inline-block font-weight-bold" runat="server" Text='<%#Eval("EventDate")%>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <span>Ticket Limit</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="lblSeat" class="d-inline-block  font-weight-bold" runat="server" Text='<%#Eval("SeatCapacity") %>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <asp:Label ID="lblPrice" class="d-inline-block pt-2 mt-4" runat="server" Style="font-size: 18px; font-weight: bold; color: green;" Text='<%#"৳"+Eval("Fare")%>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <asp:LinkButton ID="lnkView" class="btn btn-success wd-100 pt-1 mt-4" OnClick="lnkView_OnClick" runat="server">Book Tickets</asp:LinkButton>
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
            $("#<%=txtLocation.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetLocation",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtLocation.ClientID %>").val() + "'}",
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
                                title: 'Location not found',
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
