<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MovieList.aspx.cs" Inherits="TicketBookingSystem.UI.MovieList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Movie List</h2>
    </div>
    <div class="row pt-4" style="z-index: 900;">
        <div class="col-4">
            <asp:DropDownList ID="ddlStatus" class="form-control wd-100" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_OnSelectedIndexChanged" runat="server">
                <asp:ListItem Value="A">Active</asp:ListItem>
                <asp:ListItem Value="I">Restricted</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col-4">
            <asp:TextBox ID="txtSearch" AutoPostBack="True" OnTextChanged="txtSearch_OnTextChanged" class="form-control wd-100" placeholder="Search by movie name" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row p-4"></div>
    <div class="row">
        <div class="col-12 mt-2 table-responsive">
            <asp:GridView ID="gridMovie" Width="100%" class="table table-hover table-bordered table-striped" OnRowDataBound="gridMovie_OnRowDataBound" OnPageIndexChanging="gridMovie_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Bus Found" AllowPaging="True" PageSize="15" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Movie_Name">
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("EventId")%>' />
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("EventName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Theatre_address">
                        <ItemTemplate>
                            <asp:Label ID="Label21" runat="server" Text='<%#Eval("EventAddress")+","+Eval("EventLocation")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start_Time">
                        <ItemTemplate>
                            <asp:Label ID="Labelw21" runat="server" Text='<%#Eval("StartTime")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End_Time">
                        <ItemTemplate>
                            <asp:Label ID="Label31" runat="server" Text='<%#Eval("EndTime")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Premier_Date">
                        <ItemTemplate>
                            <asp:Label ID="Label41" runat="server" Text='<%#Eval("EventDate")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seat_Type">
                        <ItemTemplate>
                            <asp:Label ID="Label51" runat="server" Text='<%#Eval("SeatType")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seat_Capacity">
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("SeatCapacity")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fare">
                        <ItemTemplate>
                            <asp:Label ID="Labelw51" runat="server" Text='<%#Eval("Fare")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Picture">
                        <ItemTemplate>
                            <asp:Image ID="Image1" style="width: 75px; height: 75px;" runat="server" ImageUrl='<%#Eval("Picture") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkInactive" class="btn btn-danger mt-1" OnClick="lnkInactive_OnClick" runat="server" title="Inactive"><i class="fas fa-times fa-lg"></i></asp:LinkButton>
                            <asp:LinkButton ID="lnkUpdate" class="btn btn-primary mt-1" OnClick="lnkUpdate_OnClick" runat="server" title="Update"><i class="fas fa-edit fa-lg"></i></asp:LinkButton>
                            <asp:LinkButton ID="lnkRemove" class="btn btn-danger mt-1" OnClick="lnkRemove_OnClick" runat="server" title="Remove"><i class="fas fa-trash-alt fa-lg"></i></asp:LinkButton>
                            <asp:LinkButton ID="lnkActive" class="btn btn-success mt-1" OnClick="lnkActive_OnClick" Visible="False" runat="server" title="Active"><i class="fas fa-check fa-lg"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script>
        function pageLoad() {
            $("#<%=txtSearch.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetMovie",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtSearch.ClientID %>").val() + "'}",
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
                                title: 'Movie not found',
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
