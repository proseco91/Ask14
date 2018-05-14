<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/masterpage.master"
    AutoEventWireup="true" CodeFile="ListComment.aspx.cs" Inherits="administrator_ListComment" %>

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

                $("input[title=DisplayStatusComment]").click(function () {
                    var result = confirm("Bạn có chắn chắn cập nhật không?");
                    if (result == true) {
                        var input = $(this);
                        $.ajax({
                            type: "POST",
                            url: "../service/thucdem.asmx/Display_StatusComment",
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
                    } else {
                        return false;
                    }
                });
            });
        </script>
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <div class="box">
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5 id="txtTitle">
                    Danh sách comment
                </h5>
            </div>
            <div id="divMessage" runat="server">
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
                                Họ tên
                            </th>
                            <th>
                                Nội dung
                            </th>
                            <th>
                                Người Comment
                            </th>
                            <th>
                                Ngày Comment
                            </th>
                            <th>
                                Trạng thái
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptData" OnItemDataBound="rptData_ItemDataBound">
                            <ItemTemplate>
                                <tr id="<%#Eval("ID") %>">
                                    <td align="center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td valign="middle" align="center">
                                        <a href="DetailCustomer.aspx?ID=<%#Eval("CUSTOMER_ID")%>" target="_blank">
                                            <%#Eval("CUSTOMER_NAME")%>
                                        </a>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("CONTENT")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("SENDER")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("CREATEDDATE")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <input title="DisplayStatusComment" type="button" class='<%#(Eval("STATUS").ToString() == "1"? "True" : "False") %>' />
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
            </div>
        </div>
        <!-- end table -->
    </div>
</asp:Content>
