<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quiz.aspx.cs" Inherits="administrator_Quiz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Styles/fonts-new.css" rel="stylesheet" />
    <script src='../Scripts/jquery-1.10.2.js'></script>
    <script src="../autosize-master/jquery.autosize.js" type="text/javascript"></script>
    <script type="text/javascript" src="../ckeditorNew/ckeditor.js"></script>
    <script type="text/javascript" src="../ckeditorNew/adapters/jquery.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/addTinhHuong.css" />
    <link href="../Styles/admin_style_new.css" rel="stylesheet" />
    <script src="../Scripts/admin_style_new.js"></script>
    <script src='../Scripts/TinhHuong.js'></script>

    <script src="../linktamchat/Scripts/chat/uploadfile.js"></script>
    <script src="../linktamchat/Scripts/chat/popup.js"></script>
    <link href="../linktamchat/Styles/chat/popup.css" rel="stylesheet" />
    <style type="text/css">
        #content div.box table td
        {
            background-color: transparent;
            border: none;
            padding: 0px;
        }

        #content div.box table tr:hover td
        {
            background-color: transparent;
        }
    </style>
    <script type="text/javascript">
        var _ID = <%=string.IsNullOrEmpty(Request.QueryString["ID"])?"-1":Request.QueryString["ID"] %>;
        var strucdata = <%=strucdata %>;
        $(document).ready(function(){
            <%=!struc_load.Equals("{}")?"$('.contentInfoDeThi').loadfrom("+struc_load+");":"" %>
        });
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div class="popuplammo"></div>
        <div id="content">
            <asp:HiddenField ID="hdfCheck" runat="server" />
            <div class="box">
                <!-- box / title -->
                <div style="height: 0px; width: 0px; overflow: hidden; opacity: 0; position: fixed; top: -100px;">
                    <iframe id="scriptUpload" scrolling="no" frameborder="0" allowtransparency="true" style="border: none; overflow: hidden; width: 0px; height: 0px;"
                        src="upload.aspx"></iframe>
                </div>
                <div style="background-color: #3b5998; color: #fff; font-size: 15px; font-weight: bold; padding: 5px 10px;">Nội dung đề</div>
                <div id="divMessage" runat="server"></div>
                <div style="clear: both; height: 20px;"></div>
                <div class="contentInfoDeThi">
                    <div class="panel_from" panel-input-setting>
                        <div class="panel_from_row panel_from_row_input">
                            <lable>Tiêu đề</lable>
                            <span>
                                <input type="text" valname="setting_title" no-empty/>
                            </span>
                        </div>
                        <div style="clear: both; height: 20px;"></div>
                        <div class="panel_from_row panel_from_row_file">
                            <lable> Hình ảnh</lable>
                            <span></span>
                            <span>Tải hình ảnh lên
                                <input type="file" valname="setting_img" no-empty/>
                            </span>
                        </div>
                        <div style="clear: both; height: 20px;"></div>
                        <div class="panel_from_row panel_from_row_input">
                            <lable>Số phút</lable>
                            <span>
                                <input type="text" valname="setting_min" valtype="number" maxlength="9" no-empty/>
                            </span>
                        </div>
                        <div style="clear: both; height: 20px;"></div>
                        <div class="panel_from_row panel_from_row_input">
                            <lable>Giới thiệu</lable>
                            <span>
                                <textarea valname="setting_des" no-empty></textarea>
                            </span>
                        </div>
                        <div style="clear: both; height: 20px;"></div>
                        <div class="panel_from_row panel_from_row_radio_btn panel_from_row_radio_btn_true_false">
                            <lable>Trạng thái</lable>
                            <input type="button" value="Bật" valdata="1" valname="setting_status" class="select" style="border-left: 1px solid #d9d9d9; border-radius: 3px 0 0 3px;" />
                            <input type="button" value="Tắt" valdata="0" valname="setting_status" />
                        </div>
                        <div style="clear: both; height: 20px;"></div>
                    </div>
                </div>
                <div style="border-bottom: 2px dashed #ccc; clear: both; height: 20px;"></div>
                <div class="boxInfo addContext" style="padding: 0px; margin: 20px 0px;">
                </div>
                <div style="text-align: right; margin-right: 20px;">
                    <span class="btnAll btnAddNgay" style="background-image: url('../images/add-icon.png')">Thêm Exercise</span>
                </div>
                <div style="clear: both; height: 20px;"></div>
            </div>
            <!-- end table -->
        </div>
    </form>
</body>
</html>
