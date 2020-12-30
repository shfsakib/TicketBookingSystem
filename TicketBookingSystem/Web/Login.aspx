<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TicketBookingSystem.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | My Tickets</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS -->
    <link href="../ReferenceFile/css/style.css" type="text/css" rel="stylesheet" />
    <link href="../ReferenceFile/css/bootstrap-datepicker.css" type="text/css" rel="stylesheet" />
    <!-- Favicon -->
    <!-- Favicon and Touch Icons -->
    <link href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.14/svgs/solid/search-location.svg" rel="shortcut icon" type="image/png" />
    <link href="/ReferenceFile/images/apple-touch-icon.png" rel="apple-touch-icon" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.12.1/css/all.min.css" type="text/css" rel="stylesheet" />
    <link href="../ReferenceFile/OwnStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="color: black; font-family: Roboto; font-size: 16px;">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 p-3">
                <div class="row">
                    <div class="col-12 text-center">
                        <h1>Log in</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 p-1">
                        <span>Email</span>
                        <asp:TextBox ID="txtEmail" class="form-control" TextMode="Email" placeholder="example@example.com" Style="border: 1px solid #696969;" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 p-1">
                        <span>Password</span>
                        <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" placeholder="********" Style="border: 1px solid #696969;" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 p-1">
                        <asp:LinkButton ID="lnkForgot" CssClass="text-primary" runat="server">Forgot password</asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 p-1">
                        <asp:LinkButton ID="btnLogin" OnClick="btnLogin_OnClick" CssClass="btn btn-success wd-100" runat="server">Log in</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="col-4"></div>
        </div>
    </form>
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="/ReferenceFile/js/jquery.min.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/popper.min.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/functions.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/owl.carousel.min.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/slick.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/swiper.min.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/main.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/jquery.fancybox.min.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
    <script src="/ReferenceFile/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/10.12.0/sweetalert2.min.js" integrity="sha512-zEQoqfKfcrv7/Yedd5AvIMN3Y+ecqNKJdDqDnBW2C7/TevxmW1myCKlSU2meW+bcF5m3OhpPL4lFsKVWjbyFGg==" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/10.12.0/sweetalert2.all.min.js" integrity="sha512-8IAW5sOZRkubYGtDUS3aDaKdAmG0Hye5XnY/ZiJOCAmTsHGLP0GUUoCGHQjIpbUHAk4v6vnwCRGK2+gYsmQHeg==" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/10.12.0/sweetalert2.css" integrity="sha512-i++eR2u4MtevO3tOPI55hNUccQVQ0+hf9cpevM2q/GmdM+UZMtzHn5pSxFmVuUK1kikm5qUiZB1ef6rWqLXb3Q==" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</body>
</html>
