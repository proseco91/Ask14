<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="ListTags.aspx.cs" Inherits="Administrator_ListTags" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <script type="text/javascript">
            var index = "";
            $(document).ready(function () {
                $("input.add").click(function () {
                    window.location.replace(window.location.pathname + "?module=clipsadd");
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


                $("input[title=displayStatus]").click(function () {
                    var input = $(this);
                    $.ajax({
                        type: "POST",
                        url: "../services/WebService.asmx/DisplayStatusTags",
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
            });
        </script>
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <div class="box">
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5 id="txtTitle">Danh sách Tags <span style="font-size: 10px; font-style: italic;">(Tags tiêu biểu là tags có trạng thái màu xanh.)</span>
                </h5>
            </div>
            <div id="divMessage" runat="server">
            </div>
            <div class="first-action">
                <div class="button">
                    <asp:Button aria-disabled="false" role="button" CssClass="add ui-button ui-widget ui-state-default ui-corner-all"
                        Text="Thêm Mới" runat="server" ID="btnAdnew1" OnClick="btnAdnew1_Click" />
                    <asp:Button role="button" ID="btnDelete" Text="Xóa" class="del ui-button ui-widget ui-state-default ui-corner-all"
                        runat="server" OnClick="btnDelete_Click" />
                    <br>
                </div>
            </div>
            <!-- end box / title -->
            <div class="table">
                <table>
                    <thead>
                        <tr>
                            <th class="stt">STT
                            </th>
                            <th>Tên tags
                            </th>
                            <th>Trạng thái
                            </th>
                            <th>Ngày tạo
                            </th>
                            <th class="selected last">
                                <input class="checkall" type="checkbox" />
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptData">
                            <ItemTemplate>
                                <tr id='<%#Eval("ID") %>'>
                                    <td align="center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td valign="middle" align="center">
                                        <a title='<%# Eval("ID")%>' href='<%#"TagsEdit.aspx?ID="+Eval("ID")%>'>
                                            <%#Eval("NAME")%>
                                        </a>
                                    </td>
                                    <td valign="middle" align="center">
                                        <input type="button" title="displayStatus" class='<%#(Eval("STATUS").ToString() == "1"? "True" : "False") %>' />
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("CREATED_DATE")%>
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
                        <asp:Button aria-disabled="false" role="button" CssClass="add ui-button ui-widget ui-state-default ui-corner-all"
                            Text="Thêm Mới" runat="server" ID="Button1" OnClick="btnAdnew1_Click" />
                        <asp:Button role="button" ID="btnDelete2" Text="Xóa" class="del ui-button ui-widget ui-state-default ui-corner-all"
                            OnClick="btnDelete_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <!-- end table -->
    </div>
</asp:Content>

