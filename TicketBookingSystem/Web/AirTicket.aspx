<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" AutoEventWireup="true" CodeBehind="AirTicket.aspx.cs" Inherits="TicketBookingSystem.Web.AirTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mp">
        <div class="col-12 ticketSearchDiv">
            <div class="row">
                <div class="col-12 ticketSearchBar">
                    <div class="row">
                        <div class="col-6 col-lg-3">
                            <i class="fas fa-map-marker-alt fa-lg txtIcon"></i>
                            <asp:TextBox ID="txtDisFrom" AutoPostBack="True" OnTextChanged="txtDisFrom_OnTextChanged" class="form-control wd-100 textbox" Style="height: 60px; text-transform: uppercase" placeholder="FROM" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-6 col-lg-3">
                            <i class="fas fa-map-marker-alt fa-lg txtIcon"></i>
                            <asp:TextBox ID="txtDisTo" AutoPostBack="True" OnTextChanged="txtDisTo_OnTextChanged" class="form-control wd-100 textbox" Style="height: 60px; text-transform: uppercase" placeholder="TO" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-12 col-lg-3 mp mt-1 mt-lg-0">
                            <span class="spanDate">Journey Date</span>
                            <asp:TextBox ID="txtJourneyDate" class="form-control wd-100 textbox" placeholder="Journey date" Style="height: 60px;" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-12 col-lg-3  mt-1 mt-lg-0">
                            <asp:LinkButton ID="btnSearch" OnClick="btnSearch_OnClick" class="btn btn-success wd-100" Style="height: 60px; padding-top: 20px;" runat="server"><i class="fas fa-bus fa-lg"></i>&nbsp;&nbsp;Search Air</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12 busList table-responsive p-5" style="min-height: 250px">
            <asp:GridView ID="gridAir" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridAir_OnPageIndexChanging" OnRowDataBound="gridAir_OnRowDataBound" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Launch Found" AllowPaging="True" PageSize="30" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("CoachId")%>' />
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("CompanyId")%>' />
                            <div class="row">
                                <div class="col-12 col-lg-3">
                                    <asp:Label ID="Label1" class="d-block" Style="font-size: 18px; font-weight: bold" runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                    <span class="d-block">
                                        <asp:Label ID="Label2" runat="server" Style="font-size: 16px;" Text='<%#Eval("CoachName") %>'></asp:Label></span>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span>Departure Time</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label6" class="d-inline-block font-weight-bold" runat="server" Text='<%#TimeC(Eval("DepartureTime").ToString())%>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span>Quickest Time</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="Label7" class="d-inline-block  font-weight-bold" runat="server" Text='<%#TimeC(Eval("ArrivalTime").ToString()) %>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <span>Seat Capacity</span><br class="d-none d-lg-block" />
                                    <asp:Label ID="lblSeat" class="d-inline-block  font-weight-bold" runat="server" Text='<%#Eval("SeatCapacity") %>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <asp:Label ID="lblPrice" class="d-inline-block pt-2 mt-4" runat="server" Style="font-size: 18px; font-weight: bold; color: green;" Text='<%#"৳"+Eval("TicketPrice")%>'></asp:Label>
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <asp:LinkButton ID="lnkView" class="btn btn-success wd-100 pt-1 mt-4" OnClick="lnkView_OnClick" runat="server">View Seats</asp:LinkButton>
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
            $("#<%=txtDisTo.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetLocation",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtDisTo.ClientID %>").val() + "'}",
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
                                title: 'Ticket not found',
                                showConfirmButton: true,
                                timer: 6000
                            });
                        }
                    });
                },
                minLength: 1,
            });
            $("#<%=txtDisFrom.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetLocation",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtDisFrom.ClientID %>").val() + "'}",
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
                                title: 'Ticket not found',
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
