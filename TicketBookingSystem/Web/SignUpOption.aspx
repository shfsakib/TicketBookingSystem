<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpOption.aspx.cs" Inherits="TicketBookingSystem.Web.SignUpOption" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Tickets</title>
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
    <form id="form1" runat="server">
        <div class="row fonts">
            <div class="col-3"></div>
            <div class="col-6 p-4" style="text-align: center;">
                <div class="row">
                    <div class="col-12">
                        <h1 class="fonts">Choose Sign up Type</h1>
                    </div>
                </div>
                <div class="row p-4">
                    <div class="col-12">
                        <span>
                            <a class="btn btn-dark wd-100" href="/Web/SignPassenger.aspx" target="_blank">Sign up as Customer</a>
                        </span>
                    </div>
                    <div class="col-12">
                        <span>
                            <a class="btn btn-success wd-100 color-white"  href="/Web/SignAgent.aspx" target="_blank" style="color: white !important;" href="">Sign up as Agency</a>
                        </span>
                    </div>
                </div>
            </div>
            <div class="col-3"></div>
        </div>
    </form>
    <!-- Optional JavaScript -->
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
</body>
</html>
