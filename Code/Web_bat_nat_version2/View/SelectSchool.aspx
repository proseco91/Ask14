<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectSchool.aspx.cs" Inherits="Styles_SelectSchool" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .wrap {
            width: 300px;
            border: 10px solid #808080;
            padding: 20px;
            float: left;
            background-color: #eeeeee;
        }

        .textShool {
            float: left;
            width: 100px;
        }

        .selectSchool {
            float: left;
        }

        .button {
            margin-top: 10px;
            float: right;
        }

        .readMore {
            background-color: #64c735;
            border: medium none;
            color: #fff;
            cursor: pointer;
            float: right;
            padding: 5px 15px;
            transition: all 0.4s linear 0.1s;
        }

            .readMore:hover {
                background-color: #3c9f0d;
            }

        .warning {
            float: left;
            text-align: left;
            font-size: 12px;
            font-family: Arial;
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="wrap">
            <div class="textShool">Chọn trường: </div>
            <div class="selectSchool">
                <asp:DropDownList Width="200" ID="drvSelectSchool" runat="server" />
            </div>
            <div style="clear: both"></div>
            <div class="button">
                <asp:Button ID="btnUpdate" CssClass="readMore" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click" />
            </div>
            <div style="clear: both"></div>
            <div class="warning">
                <asp:Literal ID="ltwarning" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
