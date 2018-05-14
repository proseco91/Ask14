<%@ Page Language="C#" AutoEventWireup="true" CodeFile="listcskhcomment.aspx.cs"
    Inherits="Administrator_listeventcomment" ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Comment khách hàng</title>

    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.validate.js" type="text/javascript"></script>
    <style type="text/css">
        *
        {
            margin: 0 auto;
        }
        .hoidap-wrapper2
        {
            float: left;
        }
        .table th
        {
            background: none repeat scroll 0 0 #eeeeee;
            border-bottom: 1px solid #cdcdcd;
            border-right: 1px solid #cdcdcd;
            padding: 5px;
        }
        .table tr td
        {
            background: none repeat scroll 0 0 #ffffff;
            border-bottom: 1px solid #cdcdcd;
            border-right: 1px solid #cdcdcd;
            padding: 5px;
        }
        table td input.False
        {
            background-color: transparent;
            background-image: url("../resources/images/icons/16x16/minus_circle.png");
            background-repeat: no-repeat;
            border-style: none;
            cursor: pointer;
            height: 16px;
            width: 16px;
        }
        table td input.True
        {
            background-color: transparent;
            background-image: url("../resources/images/icons/16x16/success_1.png");
            background-repeat: no-repeat;
            border-style: none;
            cursor: pointer;
            height: 16px;
            width: 16px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[title=DisplayStatusComment]").click(function () {
                var input = $(this);
                $.ajax({
                    type: "POST",
                    url: "../service/thucdem.asmx/Display_StatusComment",
                    data: "{'ID':'" + $(this).attr("id") + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () {
                        $("div.message").html("");
                    },
                    success: function (message) {
                        if (message.d == false) {
                            $("div.message").html("<div id='message-error' class='message message-error'><div class='image'><img src='../resources/images/icons/error.png' alt='Error' height='32' /></div><div class='text'><h6>Lỗi</h6><span>Chưa thực hiện được!</span></div><div class='dismiss'><a href='#message-error'></a></div></div>");
                        }
                        else {
                            if ($(input).hasClass("True")) {
                                $(input).removeClass("True");
                                $(input).addClass("False");
                            }
                            else {
                                $(input).removeClass("False");
                                $(input).addClass("True");
                            }
                            $("div.message").html("<div id='message-success' class='message message-success'><div class='image'><img src='../resources/images/icons/success.png' alt='Success' height='32' /></div><div class='text'><h6>Thông Báo</h6><span>Cập nhật thành công !</span></div><div class='dismiss'><a href='#message-success'></a></div></div>");
                        }
                    },
                    error: function (errormessage) {
                        $("div.message").html("<div id='message-error' class='message message-error'><div class='image'><img src='../resources/images/icons/error.png' alt='Error' height='32' /></div><div class='text'><h6>Lỗi</h6><span>Chưa thực hiện được!</span></div><div class='dismiss'><a href='#message-error'></a></div></div>");
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="hoidap-wrapper2" style="background: #FFFFFF; border: 10px solid #7c7c7c;
        float: left">
        <div class="hoidap-primary">
            <div class="table">
                <table>
                    <thead>
                        <tr>
                            <th class="style1">
                                STT
                            </th>
                            <th class="style2">
                                Người gửi
                            </th>
                            <th class="style3">
                                Ngày gửi
                            </th>
                            <th>
                                Content
                            </th>
                          
                          
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptData">
                            <ItemTemplate>
                                <tr id="<%#Eval("ID") %>">
                                    <td style="width: 10px;">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("SENDER")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("CREATEDDATE")%>
                                    </td>
                                    <td style="width: 500px;">
                                        <%#Eval("CONTENT")%>
                                    </td>
                                  
                                   
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
