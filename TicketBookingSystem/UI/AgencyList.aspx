<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AgencyList.aspx.cs" Inherits="TicketBookingSystem.UI.AgencyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h2>Agency List</h2>
    </div>
    <asp:updatepanel id="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row pt-4" style="z-index: 900;">
                <div class="col-4">
                    <asp:DropDownList ID="ddlType" class="form-control wd-100" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged" runat="server">
                        <asp:ListItem Value="A">Active</asp:ListItem>
                        <asp:ListItem Value="I">Restricted</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-4">
                    <asp:TextBox ID="txtSearch" AutoPostBack="True" OnTextChanged="txtSearch_OnTextChanged" class="form-control wd-100" placeholder="Search by name" runat="server"></asp:TextBox>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="txtSearch" />
            <asp:PostBackTrigger ControlID="ddlType" />
        </Triggers>
    </asp:updatepanel>
    <div class="row p-4"></div>
    <div class="row">
        <div class="col-12 mt-2 table-responsive">
            <asp:gridview id="gridUser" width="100%" class="table table-hover table-bordered table-striped" onrowdatabound="gridUser_OnRowDataBound" onpageindexchanging="gridUser_OnPageIndexChanging" autogeneratecolumns="False" showheader="True" showheaderwhenempty="True" emptydatatext="No Passenger Found" allowpaging="True" pagesize="15" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Passenger_Name">
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("RegId")%>' />
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Company_Name">
                        <ItemTemplate> 
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="Label21" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile_No.">
                        <ItemTemplate>
                            <asp:Label ID="Label31" runat="server" Text='<%#Eval("ContactNo")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Picture">
                        <ItemTemplate>
                            <asp:Image ID="Image11" ImageUrl='<%#Eval("Picture")%>' style="width: 75px; height: 75px;" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkInactive" class="btn btn-danger" OnClick="lnkInactive_OnClick" runat="server" ToolTip="Make Inactive"><i class="fas fa-times fa-lg"></i>&nbsp;Restrict</asp:LinkButton>
                            <asp:LinkButton ID="lbkActive" class="btn btn-primary" OnClick="lbkActive_OnClick" runat="server" ToolTip="Make Active"><i class="fas fa-check fa-lg"></i>&nbsp;Active</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:gridview>
        </div>
    </div>

    <script>
        function pageLoad() {
            $("#<%=txtSearch.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetAgency",
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
                                    title: 'Agency not found',
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
