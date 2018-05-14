<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogOut.aspx.cs" Inherits="View_LogOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function event_call_megasage() {
            window.location.href = "<%=_home %>";
        }
    </script>
</head>
<body>
    <iframe onload="event_call_megasage();" scrolling="no" frameborder="0" allowtransparency="true" style="border: none; overflow: hidden; width: 0px; height: 0px; display: none;" src="http://sirenchat.com/logout-sirenchat.htm?Connect=<%=Request.QueryString["Connect"] %>&token=<%=Request.QueryString["token"] %>&guid=<%=HttpUtility.UrlEncode(Request.QueryString["guid"]) %>"></iframe>
</body>
</html>
