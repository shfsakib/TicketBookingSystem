<%@ Page Title="" Language="C#" MasterPageFile="~/Web/IndexMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TicketBookingSystem.Web.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        span {
            font-size: 16px;
            font-family: Roboto;
            font-weight: 600;
            display: block;
        }
    </style>
    <div class="row p-2" style="justify-content: center;">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="col-sm-3 col-md-3" style="border: 1px solid #a5a3d1; text-align: center; border-radius: 10px;">
                    <div class="wd-100">
                        <asp:HiddenField ID="EventId" runat="server" Value='<%#Eval("EventId") %>' />
                        <asp:HiddenField ID="CompanyId" runat="server" Value='<%#Eval("CompanyId") %>' />
                        <asp:HiddenField ID="SeatCapacity" runat="server" Value='<%#Eval("SeatCapacity") %>' />
                        <asp:HiddenField ID="Loc" runat="server" Value='<%#Eval("Loc") %>' />
                        <asp:HiddenField ID="EventDate" runat="server" Value='<%#Eval("EventDate") %>' />
                        <asp:HiddenField ID="Fare" runat="server" Value='<%#Eval("Fare") %>' />
                        <asp:HiddenField ID="Seat" runat="server" Value='<%#Limit(Eval("SeatCapacity").ToString(),Eval("BookedSeat").ToString())%>' />
                        <img src='<%#Eval("Picture") %>' style="width: 225px; height: 225px;" />
                    </div>
                    <h3><%#Eval("EventName") %></h3>
                    <span><i class="fas fa-map-marker-alt"></i>&nbsp;<%#Eval("EventAddress")+" , "+ Eval("EventLocation")%></span>
                    <span><i class="fas fa-calendar-alt"></i>&nbsp;<b><%#Eval("EventDate") %></b></span>
                    <span><i class="far fa-clock"></i>&nbsp;<%#TimeC(Eval("StartTime").ToString())+" - "+TimeC(Eval("EndTime").ToString()) %></span>
                    <span><%#"Ticket Available: "+Limit(Eval("SeatCapacity").ToString(),Eval("BookedSeat").ToString()) %></span>
                    <span><%#"৳ "+Eval("Fare") %></span>
                    <span>
                        <asp:LinkButton ID="lnkBook" class="btn btn-success wd-100" OnClick="lnkBook_OnClick" runat="server">Book now</asp:LinkButton></span>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
