<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Administrator_Contact" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/thickbox.js" type="text/javascript"></script>
    <link href="../Styles/thickbox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #content div.box .unapprove td
        {
            background-color: #ffffcc;
        }
        #content div.box .unapprove td
        {
            background-color: #ffffcc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <script type="text/javascript">
            var index = "";
            $(document).ready(function () {
                $("input.add").click(function () {
                    window.location.open(window.location + "ReportAdd.aspx");
                });
                $("input.del").click(function () {
                    $("table input[type=checkbox].item").each(function () {
                        var checked = $(this).attr("checked");
                        if (checked) {
                            index = index + $(this).attr("value") + ";";
                        }
                    });
                    $("#<%=hdfCheck.ClientID%>").val(index);
                    if (index == "") return false;
                    else return confirm("Xác nhận xóa !");
                });
                $("input[title=Display]").click(function () {
                    var input = $(this);
                    $.ajax({
                        type: "POST",
                        url: "../services/TodayEnglishCenter.asmx/Display_Teacher",
                        data: "{'TEACHER_ID':'" + $(this).parent().parent().attr("id") + "'}",
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
        <script language="javascript" type="text/javascript">

            function OpenAdd() {
                window.location.replace(window.location.pathname + "ReportAdd.aspx");
            }
        </script>
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <div class="box">
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5 id="txtTitle">
                    Danh sách liên hệ
                </h5>
            </div>
            <div id="divMessage" runat="server">
            </div>
            <div class="first-action">
                <div class="button">
                </div>
            </div>
            <!-- end box / title -->
            <div class="table">
                <table>
                    <thead>
                        <tr>
                            <th class="stt">
                                STT
                            </th>
                            <th>
                                Tên
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                                Số điện thoại
                            </th>
                            <th>
                                Tiêu đề
                            </th>
                            <th>
                                Nội dung
                            </th>
                            <th>
                                Ngày gửi
                            </th>
                            <th>
                                Trả lời
                            </th>
                            <th>
                                Xem trả lời
                            </th>
                            <th>
                                Trạng thái
                            </th>
                            <th class="selected last">
                                <input class="checkall" type="checkbox" />
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptData">
                            <ItemTemplate>
                                <tr class='<%#(Eval("STATUS1").ToString() == "1"? "approve" : "unapprove") %>'>
                                    <td align="center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("CUSTOMER_NAME")%>
                                    </td>
                                    <td align="center" style="vertical-align: middle">
                                        <%#Eval("EMAIL")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("PHONENUMBER")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("TITLE")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("CONTENT")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("CREATED_DATE1")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <span class="replymail"><a href="replyemailLienHe.aspx?id=<%#Eval("ID1")%>&height=650&width=700&modal=false&TB_iframe=true"
                                            class="thickbox links">Gửi mail</a></span>
                                    </td>
                                    <td valign="middle" align="center">
                                        <a href="noidungtraloi_lienhe.aspx?id=<%#Eval("ID1")%>&height=450&width=700&modal=false&TB_iframe=true"
                                            class="thickbox links">Xem</a>
                                    </td>
                                    <td align="center" style="vertical-align: middle">
                                        <input type="button" class="<%# (Eval("STATUS1").ToString() == "1"?"True":"False") %>"
                                            title="Display" />
                                    </td>
                                    <td align="center" class="last">
                                        <input type="checkbox" value="<%#Eval("ID")%>" class="item" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="pagination pagination-left last">
                    <div id="pagerContainer" class="pagerContainer">
                        <cc1:CollectionPager ID="CollectionPager1" runat="server">
                        </cc1:CollectionPager>
                    </div>
                </div>
                <div class="action">
                    <div class="button">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
