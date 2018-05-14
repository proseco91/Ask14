<%@ Page Title="Hỏi đáp" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="ask.aspx.cs" Inherits="Administrator_ask" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ask-content {
            margin-bottom: 10px;
        }

        .ask-date {
            color: #646464;
            font-weight: bold;
        }

        .ask-mail {
            color: #646464;
            font-weight: bold;
            margin-left: 10px;
        }

        .replymail {
            margin-left: 20px;
            font-weight: bold;
        }

        #content div.box .unapprove td {
            background-color: #ffffcc;
        }

        #content div.box .unapprove td {
            background-color: #ffffcc;
        }
    </style>
    <link href="../Styles/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="../Script/thickbox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <script type="text/javascript">
            var index = "";
            $(document).ready(function () {
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
                $("input[title=Status]").click(function () {
                    var r = confirm("Bạn có muốn cập nhật trạng thái không?");
                    if (r == true) {
                        var input = $(this);

                        $.ajax({
                            type: "POST",
                            url: "../ajax/Ajax.aspx",
                            data: {
                                type: "updateStatusAsk",
                                id: input.next('input').val()
                            },
                            async: true,
                            dataType: "json",
                            beforeSend: function () {
                                $("div.message").html("");
                            },
                            success: function (message) {
                                if (message[0] == false) {
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
                    }
                });
            });
        </script>
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <div class="box">
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5 id="txtTitle">Danh sách hỏi đáp
                </h5>
            </div>
            <div id="divMessage" runat="server">
            </div>
            <div class="first-action">
                <div class="button">
                    <asp:Button role="button" ID="btnAdd" Text="Thêm mới" class="add ui-button ui-widget ui-state-default ui-corner-all"
                        runat="server" OnClick="btnAdd_Click" />
                    <asp:Button role="button" ID="btnDelete" Text="Xóa" class="del ui-button ui-widget ui-state-default ui-corner-all"
                        runat="server" OnClick="btnDelete_Click" />
                    <br />
                </div>
            </div>
            <!-- end box / title -->
            <div class="table">
                <table>
                    <thead>
                        <tr>
                            <th class="stt">STT
                            </th>
                            <th>Tên
                            </th>
                            <th>Email
                            </th>
                            <th>Câu hỏi
                            </th>
                            <%--<th>Người giải đáp
                            </th>--%>
                            <th>trả lời
                            </th>
                            <th>Sửa
                            </th>
                            <th>Hiển thị ngoài trang chủ
                            </th>
                            <th class="selected last">
                                <input class="checkall" type="checkbox" />
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptData">
                            <ItemTemplate>
                                <tr class='<%#(Eval("STATUS").ToString() == "1"? "approve" : "unapprove") %>'>
                                    <td align="center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("CUSTOMER_NAME")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("EMAIL")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("DESCRIPTION")%>
                                    </td>
                                    <%-- <td style="width: 500px">
                                        <div class="ask-content">
                                            <span class="ask-date">Ngày:
                                                <%#Eval("CREATED_DATE")%></span> <span class="ask-mail">Email:
                                                    <%#Eval("EMAIL")%></span> <span class="replymail"><a href="replyemail.aspx?id=<%#Eval("ID")%>&height=650&width=700&modal=false&TB_iframe=true"
                                                        class="thickbox links">Gửi mail</a></span>
                                        </div>
                                        <div style="width: 500px;">
                                        </div>
                                    </td>--%>
                                    <td valign="middle" align="center">
                                        <%--    <a href="noidungtraloi.aspx?id=<%#Eval("ID")%>&height=450&width=700&modal=false&TB_iframe=true"
                                            class="thickbox links">Xem</a>--%>

                                        <%# Lib.CutString(Eval("ANSWER").ToString(),200) %>

                                    </td>
                                    <td align="center">
                                        <a href="AskUpdate.aspx?ID=<%#Eval("ID") %>">Chỉnh sửa</a>
                                    </td>
                                    <td align="center">
                                        <input type="button" class='<%#(Eval("STATUS").ToString() == "1"? "True" : "False") %>'
                                            title='Status' />
                                        <input type="hidden" value="<%#Eval("ID") %>" />
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
                        <cc1:CollectionPager ID="CollectionPager1" runat="server" MaxPages="50" PageSize="20">
                        </cc1:CollectionPager>
                    </div>
                </div>
                <div class="action">
                    <div class="button">
                        <asp:Button role="button" ID="Button1" Text="Thêm mới" class="add ui-button ui-widget ui-state-default ui-corner-all"
                            runat="server" OnClick="btnAdd_Click" />
                        <asp:Button role="button" ID="btnDelete2" Text="Xóa" class="del ui-button ui-widget ui-state-default ui-corner-all"
                            runat="server" OnClick="btnDelete2_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
