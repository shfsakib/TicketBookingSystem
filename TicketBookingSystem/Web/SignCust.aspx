<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignCust.aspx.cs" Inherits="TicketBookingSystem.Web.SignCust" %>

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
<body style="overflow-x: hidden;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row fonts">
            <div class="col-2"></div>
            <div class="col-8 p-3">
                <div class="row"></div>
                <div class="row">
                    <div class="col-12 p-3" style="text-align: center;">
                        <h1 class="fonts font-weight-bold">Sign up</h1>
                    </div>
                </div>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <div class="row">
                                    <div class="col-12">
                                        <span>Name</span>
                                        <asp:TextBox ID="txtName" class="form-control wd-100" runat="server" placeholder="Mr. X,Y"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <span>Email</span>
                                        <asp:TextBox ID="txtEmail" class="form-control wd-100" runat="server" placeholder="example@example.com"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <span>Contact No.</span>
                                        <asp:TextBox ID="txtMobile" class="form-control wd-100" runat="server" placeholder="01XXXXXXXXX"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <span>Gender</span>
                                        <asp:DropDownList ID="ddlGender" class="form-control wd-100" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-6">
                                        <span>Date of Birth</span>
                                        <asp:TextBox ID="txtDob" class="form-control wd-100" runat="server" placeholder="mm/dd/yyyy" TextMode="Date"></asp:TextBox>
                                    </div>
                                    <div class="col-12">
                                        <span>Address</span>
                                        <asp:TextBox ID="txtAddress" class="form-control wd-100" runat="server" Height="80px" placeholder="House no.,Area,Thana,District,Division" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <span>New Password</span>
                                        <asp:TextBox ID="txtNewPass" class="form-control wd-100" runat="server" placeholder="********" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <span>Confirm Password</span>
                                        <asp:TextBox ID="txtConfirmPassword" class="form-control wd-100" runat="server" placeholder="********" TextMode="Password"></asp:TextBox>

                                    </div>
                                    <div class="col-12 p-2">
                                        <asp:Button ID="btnNext" class="btn btn-success wd-100" runat="server" Text="Next" />
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnNext" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <span>Upload Profile Picture</span>
                                        <asp:FileUpload ID="FileUpload1" class="form-control" onchange="ImagePreview(this)" runat="server" />
                                    </div>
                                    <div class="col-3"></div>
                                    <div class="col-3"></div>

                                    <div class="col-6 p-3">
                                        <img id="imgUser" runat="server" style="border: 1px solid #696969; border-radius: 10px; width: 225px; height: 225px;" src="../ReferenceFile/images/DummyPic.png" />
                                    </div>
                                    <div class="col-3"></div>
                                    <div class="col-3"></div>
                                    <div class="col-6 p-2">
                                        <asp:Button ID="btnSign" class="btn btn-success wd-100" runat="server" Text="Sign up" />
                                    </div>
                                    <div class="col-3"></div>

                                </div>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                    <div class="row">
                        <div class="col-3"></div>
                        <div class="col-6 p-2">
                            <p><h3>Enter Verification Code</h3></p>
                            <asp:HiddenField ID="hiddenRandom" runat="server" />
                            <asp:TextBox ID="txtCode" class="form-control wd-100" runat="server" placeholder="XXXXXX"></asp:TextBox>
                        </div>
                        <div class="col-3"></div>
                        <div class="col-3"></div>
                        <div class="col-6 p-2">
                            <asp:Button ID="btnConfirm" class="btn btn-primary wd-100" runat="server" Text="Confirm Code" />
                        </div>
                        <div class="col-3"></div>
                    </div>
                    </asp:View>
                </asp:MultiView>
            </div>
            <div class="col-2"></div>
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/10.12.0/sweetalert2.min.js" integrity="sha512-zEQoqfKfcrv7/Yedd5AvIMN3Y+ecqNKJdDqDnBW2C7/TevxmW1myCKlSU2meW+bcF5m3OhpPL4lFsKVWjbyFGg==" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/10.12.0/sweetalert2.all.min.js" integrity="sha512-8IAW5sOZRkubYGtDUS3aDaKdAmG0Hye5XnY/ZiJOCAmTsHGLP0GUUoCGHQjIpbUHAk4v6vnwCRGK2+gYsmQHeg==" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/10.12.0/sweetalert2.css" integrity="sha512-i++eR2u4MtevO3tOPI55hNUccQVQ0+hf9cpevM2q/GmdM+UZMtzHn5pSxFmVuUK1kikm5qUiZB1ef6rWqLXb3Q==" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgUser.ClientID%>').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
</body>
</html>
