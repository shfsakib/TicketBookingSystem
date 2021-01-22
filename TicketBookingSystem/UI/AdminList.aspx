<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminList.aspx.cs" Inherits="TicketBookingSystem.UI.AdminList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <h2>Admin List</h2>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
    </asp:UpdatePanel>
    <div class="row p-4"></div>
    <div class="row">
        <div class="col-12 mt-2 table-responsive">
            <asp:GridView ID="gridUser" Width="100%" class="table table-hover table-bordered table-striped" OnRowDataBound="gridUser_OnRowDataBound" OnPageIndexChanging="gridUser_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Admin Found" AllowPaging="True" PageSize="15" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Admin_Name">
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("RegId")%>' />
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="Label41" runat="server" Text='<%#Eval("Gender")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date_of_Birth">
                        <ItemTemplate>
                            <asp:Label ID="Label51" runat="server" Text='<%#Eval("DateofBirth")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Picture">
                        <ItemTemplate>
                            <asp:Image ID="Image11" ImageUrl='<%#Eval("Picture")%>'  style="width: 75px; height: 75px;" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkInactive" class="btn btn-danger" OnClick="lnkInactive_OnClick" runat="server" ToolTip="Make Inactive"><i class="fas fa-times fa-lg"></i>&nbsp;Restrict</asp:LinkButton>
                            <asp:LinkButton ID="lbkActive" class="btn btn-primary" OnClick="lbkActive_OnClick" runat="server" ToolTip="Make Active"><i class="fas fa-check fa-lg"></i>&nbsp;Active</asp:LinkButton>
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
                            url: "/WebService.asmx/GetAdmin",
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
                                title: 'Passenger not found',
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
