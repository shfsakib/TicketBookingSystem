﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AirList.aspx.cs" Inherits="TicketBookingSystem.UI.AirList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Air List</h2>
    </div>
    <div class="row pt-4" style="z-index: 900;">
        <div class="col-4">
            <asp:DropDownList ID="ddlStatus" class="form-control wd-100" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_OnSelectedIndexChanged" runat="server">
                <asp:ListItem Value="A">Active</asp:ListItem>
                <asp:ListItem Value="I">Restricted</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col-4">
            <asp:TextBox ID="txtSearch" AutoPostBack="True" OnTextChanged="txtSearch_OnTextChanged" class="form-control wd-100" placeholder="Search by flight no." runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row p-4"></div>
    <div class="row">
        <div class="col-12 mt-2 table-responsive">
            <asp:GridView ID="gridAir" Width="100%" class="table table-hover table-bordered table-striped" OnRowDataBound="gridAir_OnRowDataBound" OnPageIndexChanging="gridAir_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Launch Found" AllowPaging="True" PageSize="15" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Flight_no">
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("CoachId")%>' />
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("CoachName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="District_From">
                        <ItemTemplate>
                            <asp:Label ID="Label31" runat="server" Text='<%#Eval("DistrictFrom")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="District_To">
                        <ItemTemplate>
                            <asp:Label ID="Label41" runat="server" Text='<%#Eval("DistrictTo")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Departure_Time (24 hr.)">
                        <ItemTemplate>
                            <asp:Label ID="Labelw51" runat="server" Text='<%#Eval("DepartureTime")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quickest_Time (24 hr.)">
                        <ItemTemplate>
                            <asp:Label ID="Label110" runat="server" Text='<%#Eval("ArrivalTime")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Ticket_Price">
                        <ItemTemplate>
                            <asp:Label ID="Label101" runat="server" Text='<%#Eval("TicketPrice")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkInactive"  class="btn btn-danger mt-1" OnClick="lnkInactive_OnClick" runat="server" title="Inactive"><i class="fas fa-times fa-lg"></i></asp:LinkButton>
                          
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
                        url: "/WebService.asmx/GetAir",
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
                                title: 'Air not found',
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