<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" AutoEventWireup="true" CodeBehind="BusTicket.aspx.cs" Inherits="TicketBookingSystem.Web.BusTicket" %>

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
                            <asp:TextBox ID="txtDisFrom" AutoPostBack="True" OnTextChanged="txtDisFrom_OnTextChanged" class="form-control wd-100 textbox" Style="height: 60px;" placeholder="FROM" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-6 col-lg-3">
                            <i class="fas fa-map-marker-alt fa-lg txtIcon"></i>
                            <asp:TextBox ID="txtDisTo"  AutoPostBack="True" OnTextChanged="txtDisTo_OnTextChanged"  class="form-control wd-100 textbox" Style="height: 60px;" placeholder="TO" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-6 col-lg-2 mp mt-1 mt-lg-0">
                            <span class="spanDate">Journey Date</span>
                            <asp:TextBox ID="txtJourneyDate" class="form-control wd-100 textbox" placeholder="Journey date" Style="height: 60px;"  TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-6 col-lg-2  mt-1 mt-lg-0">
                            <span class="spanDate">Bus Type</span>
                            <asp:DropDownList ID="ddlType" class="form-control wd-100 textbox" Style="height: 60px;" runat="server">
                                <asp:ListItem>Non Ac</asp:ListItem>
                                <asp:ListItem>Ac</asp:ListItem>
                            </asp:DropDownList>
                             </div>
                        <div class="col-12 col-lg-2 mt-1 mt-lg-0">
                            <asp:LinkButton ID="btnSearch" OnClick="btnSearch_OnClick" class="btn btn-success wd-100" Style="height: 60px; padding-top: 20px;" runat="server"><i class="fas fa-bus fa-lg"></i>&nbsp;&nbsp;Search Buses</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12 busList table-responsive p-5" style="min-height: 250px">
             <asp:GridView ID="gridBuses" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridBuses_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Bus Found" AllowPaging="True" PageSize="30" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("BusId")%>' />
                            <div class="row">
                                <div class="col-12 col-lg-3">
                                    <asp:Label ID="Label1" class="d-block" style="font-size: 18px;font-weight: bold" runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                   <span class="d-block"><asp:Label ID="Label2"  runat="server"  style="font-size: 16px;" Text='<%#Eval("BusName") %>'></asp:Label>&nbsp;<asp:Label ID="Label3" style="font-size: 14px;font-weight: bold" runat="server" Text='<%#Eval("BusType") %>'></asp:Label></span>
                                    <span class="d-inline-block">Starting Point: </span><asp:Label ID="Label5" class="d-inline-block" style="font-size: 14px; font-weight: bold; color: cornflowerblue" runat="server" Text='<%#Eval("StartingPoint") %>'></asp:Label><br/>
                                    <span class="d-inline-block">End Point: </span><asp:Label ID="Label4" class="d-inline-block" style="font-size: 14px; font-weight: bold; color: cornflowerblue" runat="server" Text='<%#Eval("EndPoint") %>'></asp:Label>
                                
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span>Departure Time</span><br class="d-none d-lg-block"/>
                                    <asp:Label ID="Label6" class="d-inline-block" runat="server" Text='<%#Eval("DepartureTime") %>'></asp:Label>                                    
                                </div>
                                 <div class="col-12 col-lg-2 text-lg-center">
                                    <span>Arrival Time</span><br class="d-none d-lg-block"/>
                                    <asp:Label ID="Label7" class="d-inline-block" runat="server" Text='<%#Eval("ArrivalTime") %>'></asp:Label>                                    
                                </div>
                                <div class="col-12 col-lg-2 text-lg-center">
                                    <span>Seat Available</span><br class="d-none d-lg-block"/>
                                    <asp:Label ID="Label8" class="d-inline-block" runat="server" Text="25"></asp:Label>                                    
                                </div>
                                <div class="col-12 col-lg-1 text-lg-center">
                                    <asp:Label ID="Label9" class="d-inline-block pt-2" runat="server" style="font-size: 18px; font-weight: bold; color: green;" Text='<%#"৳"+Eval("TicketPrice")%>'></asp:Label>                                    
                                </div>
                                 <div class="col-12 col-lg-2 text-lg-center">
                                     <asp:LinkButton ID="lnkView" class="btn btn-success wd-100 pt-3" runat="server">View Seats</asp:LinkButton>                            
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
                                title: 'Location not found',
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
