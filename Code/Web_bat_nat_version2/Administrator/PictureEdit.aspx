<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="PictureEdit.aspx.cs" Inherits="Administrator_PictureEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        var index = "";
        var index2 = "";
        $(document).ready(function () {
            $("input.add").click(function () {
                window.location.open(window.location + "ReportAdd.aspx");
            });
            $("input[title=Display]").click(function () {
                var input = $(this);
                $.ajax({
                    type: "POST",
                    url: "../service/WebService.asmx/DisplayNews",
                    data: "{'ID':'" + $(this).parent().parent().attr("id") + "'}",
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
            $('.removeImgNew').click(function () {
                var type = $(this).next('input:hidden').val();
                var _this = $(this);
                if (type == 1) {
                    $(this).next('input:hidden').next('img').stop().animate({ 'opacity': '0.5' }, 300, function () {
                        _this.next('input:hidden').val(0);
                        _this.css('background', "url('../images/Button-Remove-icon.png')");
                    });
                } else {
                    $(this).next('input:hidden').next('img').stop().animate({ 'opacity': '1' }, 300, function () {
                        _this.next('input:hidden').val(1);
                        _this.css('background', "url('../images/Accept-icon.png')");
                    });
                }
            });
        });
    </script>
    <style type="text/css">
        .listPhoto
        {
            float: left;
            margin: 20px 20px 0px 0px;
        }
        .listPhoto img
        {
            width: 100px;
            height: 100px;
        }
        .removeImgNew
        {
            position: absolute;
            width: 24px;
            height: 24px;
            cursor: pointer;
            background: url('../images/Accept-icon.png');
            margin: -8px 0px 0px 86px;
            z-index: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <asp:HiddenField ID="hdfCheck2" runat="server" />
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>
                    Cập nhật bộ ảnh
                </h5>
            </div>
            <!-- end box / title -->
            <div id="divMessage" runat="server">
            </div>
            <div class="form">
                <div class="fields">
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Tên bộ ảnh</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtName" MaxLength="500" CssClass="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Ảnh đại diện(Width:500px)</label></div>
                        <div class="input">
                            <asp:FileUpload ID="fuImage" runat="server" CssClass="file" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                            </label>
                        </div>
                        <div class="input">
                            <asp:Image runat="server" ID="imgDescription" Width="150px" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Mô tả</label></div>
                        <div class="textarea">
                            <CKEditor:CKEditorControl runat="server" ID="TextBox1" Height="500px">
                            </CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Photo View</label></div>
                        <div class="input">
                            <div style="clear: left;">
                                <asp:FileUpload ID="uploadPhoTo" runat="server" CssClass="file" multiple /></div>
                            <div style="clear: left;">
                                <% if (String.IsNullOrEmpty(Request.QueryString["ID"]) == false)
                                   {
                                       foreach (System.Data.DataRow item in getPhoto().Rows)
                                       {
                                %>
                                <div class="listPhoto">
                                    <div class="removeImgNew">
                                    </div>
                                    <input type="hidden" value="1" name="imgOld<%=item["ID"] %>" />
                                    <img src="../images/photoView/<%=item["FILENAME"] %>" />
                                </div>
                                <%}
                                   } %>
                            </div>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Cho phép hiển thị</label></div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" />
                            <div id="ctl00_NOTE_DISPLAY" class="note">
                                Đồng ý cho bài tin này hiển thị .</div>
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all addBook"
                                    Text="Thêm mới" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href='../Administrator/PictureList.aspx'"
                                type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
