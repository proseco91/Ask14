<%@ Page Language="C#" AutoEventWireup="true" CodeFile="replyemail.aspx.cs" Inherits="Administrator_replyemail"
    ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gửi mail - Chống Bắt Nạt Học Đường</title>
    <link href="../Styles/hoidap.css" rel="stylesheet" type="text/css" />    
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
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div class="hoidap-wrapper2" style="background: #FFFFFF; border: 10px solid #7c7c7c;
        margin: 10px auto;">
        <div class="hoidap-close">
            <a class="zme-boxy-close" onclick="self.parent.tb_remove()"></a>
        </div>
        <div class="hoidap-primary">
            <div class="hoidap-title">
                Hỏi đáp</div>
            <div class="hoidap-item">
                <div class="hoidap-item-title">
                    Tên</div>
                <div class="hoidap-item-text">
                    <asp:TextBox ID="txtName" Text="" runat="server" CssClass="textbox2 required2" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="hoidap-item">
                <div class="hoidap-item-title">
                    Email</div>
                <div class="hoidap-item-text">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox2 required2 email2" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div class="hoidap-item">
                <CKEditor:CKEditorControl runat="server" ID="txtContent" CssClass="ckeditor" Height="100px"
                    Width="680px">
                </CKEditor:CKEditorControl>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Gửi mail" CssClass="button button290"
            OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
