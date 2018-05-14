<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Administrator_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link rel="stylesheet" type="text/css" href="../resources/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../resources/css/style.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../resources/css/style_full.css" />
    <link rel="stylesheet" type="text/css" href="../resources/css/blue.css" />
    <!-- scripts (jquery) -->
    <script src="../resources/scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <!--[if IE]><script language="javascript" type="text/javascript" src="../resources/scripts/excanvas.min.js"></script><![endif]-->
    <script src="../resources/scripts/jquery-ui-1.8.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../resources/scripts/jquery.validate.js"></script>
    <script src="../resources/scripts/smooth.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            style_path = "resources/css/colors";

            $("input.focus").focus(function () {
                if (this.value == this.defaultValue) {
                    this.value = "";
                }
                else {
                    this.select();
                }
            });

            $("input.focus").blur(function () {
                if ($.trim(this.value) == "") {
                    this.value = (this.defaultValue ? this.defaultValue : "");
                }
            });

            $("input:submit, input:reset").button();
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#frmLogin").validate();
        });
    </script>
</head>
<body>
    <div id="login">
        <!-- login -->
        <div class="title">
            <h5>
                Đăng nhập vào Admin</h5>
            <div class="corner tl">
            </div>
            <div class="corner tr">
            </div>
        </div>
        <div class="messages">
            <div id="divMessages" runat="server">
            </div>
        </div>
        <div class="inner">
            <form id="frmLogin" action="Login.aspx" method="post" runat="server">
            <div class="form">
                <!-- fields -->
                <div class="fields">
                    <div class="field">
                        <div class="label">
                            <label for="username">
                                Tài khoản:</label>
                        </div>
                        <div class="input">
                            <input type="text" name="txtUser" id="txtUser" size="40" value="Tên tài khoản" class="focus required"
                                runat="server" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label for="password">
                                Mật khẩu:</label>
                        </div>
                        <div class="input">
                            <input type="password" name="txtPassword" id="txtPassword" runat="server" size="40"
                                value="Mật khẩu" class="focus required" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="checkbox">
                            <asp:CheckBox ID="cbremember" runat="server" />
                            <label for="remember">
                                Nhớ mật khẩu</label>
                        </div>
                    </div>
                    <div class="buttons">
                        <asp:Button ID="btnLogin" runat="server" Text="Đăng Nhập" OnClick="btnLogin_Click" />
                    </div>
                </div>
                <!-- end fields -->
                <!-- links -->
                <div class="links">
                    <a href="ForgotPassword.aspx">Quên mật khẩu?</a>
                </div>
                <!-- end links -->
            </div>
            </form>
        </div>
        <!-- end login -->
    </div>
</body>
</html>
