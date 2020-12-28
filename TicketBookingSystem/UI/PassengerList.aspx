<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="PassengerList.aspx.cs" Inherits="TicketBookingSystem.UI.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
       <h2> User List</h2>
    </div>
    <div class="row pt-4">
        <div class="col-4">
            <asp:DropDownList ID="ddlType" class="form-control wd-100" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged" runat="server">
                <asp:ListItem Value="A">Active</asp:ListItem>
                <asp:ListItem Value="I">Restricted</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtSearch" class="form-control wd-100" placeholder="Search by name" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-12 mt-2 table-responsive">
            <asp:GridView ID="gridUser" Width="100%" class="table table-hover table-bordered table-striped" OnRowDataBound="gridUser_OnRowDataBound" OnPageIndexChanging="gridUser_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Passenger Found" AllowPaging="True" PageSize="15" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Passenger_Name">
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
                            <asp:Image ID="Image11" ImageUrl='<%#Eval("Picture")%>' runat="server" />
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
</asp:Content>
