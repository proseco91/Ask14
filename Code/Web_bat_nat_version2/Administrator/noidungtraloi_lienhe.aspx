<%@ Page Language="C#" AutoEventWireup="true" CodeFile="noidungtraloi_lienhe.aspx.cs"
    Inherits="Administrator_noidungtraloi_lienhe" ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gửi mail - Hẹn tốc độ</title>
    <link href="../Styles/control.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.validate.js" type="text/javascript"></script>
    <link href="../Styles/hoidap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#form1").validate();
        });
    </script>
    <style type="text/css">
        .button290
        {
            position: relative;
            left: 610px;
            top: -5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="hoidap-wrapper2" style="background: #FFFFFF; border: 10px solid #7c7c7c;
        margin: 10px auto;">
        <div class="hoidap-close">
            <a class="zme-boxy-close" onclick="self.parent.tb_remove()"></a>
        </div>
        <div class="hoidap-primary" style="text-align: center;">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div>
                        <%# Eval("ANSWER")%>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div style="clear: both">
        </div>
    </div>
    </form>
</body>
</html>
