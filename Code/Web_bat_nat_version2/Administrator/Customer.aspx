<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Administrator_Customer" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                    else return confirm("Xác nhận xóa, việc xóa sẽ làm không thể khôi phục, hãy đảm bảo sự chắc chắn  !");
                });

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
                    $('.viewcomment').keypress(function (event) {
                        if (event.which == 13) {
                            var _this = $(this);
                            event.preventDefault();
                            var ID_Customer = $(this).attr("valID");
                            $.ajax({
                                type: "POST",
                                url: "../ashx/calldetail.ashx?id=" + ID_Customer + "&desc=" + $(this).val() + "&serviceType=" + 'cskh',
                                dataType: "json",
                                success: function (data) {
                                    if (data[0]) {
                                        alert("Nhập comment thành công");
                                    }
                                },
                                error: function (errormessage) {
                                    $("div.message").html("<div id='message-error' class='message message-error'><div class='image'><img src='../resources/images/icons/error.png' alt='Error' height='32' /></div><div class='text'><h6>Lỗi</h6><span>Chưa thực hiện được!</span></div><div class='dismiss'><a href='#message-error'></a></div></div>");
                                    alert('Hệ thống không lưu được comment. Mời bạn thao tác lại hoặc liên hệ với ADMIN để được trợ giúp.');
                                }
                            });
                        }
                    });
                });

            });
        </script>
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <div class="box">
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5 id="txtTitle">
                    Danh sách khách hàng
                </h5>
                <div class="search">
                    <div class="input">
                        <input name="txtSearch" id="txtSearch" style="width: 200px;" onclick='if(this.value=="Nhập tên khách hàng!")this.value=""'
                            onblur='if(this.value=="")this.value="Nhập tên khách hàng!"' type="text" runat="server" />
                    </div>
                    <div class="button">
                        <asp:Button runat="server" role="button" CssClass="ui-button ui-widget ui-state-default ui-corner-all"
                            Text="Tìm kiếm" ID="btnSearch" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
            <div id="divMessage" runat="server">
            </div>
            <br />
            <div class="first-action">
                <div class="button">
                    <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                        value="Thêm mới" onclick="location.href='../Administrator/DetailCustomer.aspx'"
                        type="button" />
                    <asp:Button runat="server" Text="Xóa" CssClass="del ui-button ui-widget ui-state-default ui-corner-all"
                        ID="btnDel" OnClick="btnDel_Click" />
                </div>
                <div>
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
                                Tên khách hàng
                            </th>
                            <th style="width: 100px;">
                                Email
                            </th>
                            <th style="width: 50px;">
                                Số điện thoại
                            </th>
                            <th style="width: 50px;">
                                Ngày tạo
                            </th>
                            <th style="width: 30px;">
                                Trạng thái
                            </th>
                            <th>
                                Comment
                            </th>
                            <th class="selected last">
                                <input class="checkall" type="checkbox" />
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptData" OnItemDataBound="rptData_ItemDataBound">
                            <ItemTemplate>
                                <tr id="<%#Eval("ID")%>">
                                    <td align="center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td valign="middle" align="center">
                                        <a title='<%# Eval("CUSTOMER_NAME")%>' href='<%#"DetailCustomer.aspx?ID="+Eval("ID")%>'>
                                            <%#Eval("CUSTOMER_NAME")%>
                                        </a>
                                    </td>
                                    <td valign="middle" align="center" style="width: 100px;">
                                        <%#Eval("EMAIL")%>
                                    </td>
                                    <td valign="middle" align="center" style="width: 50px;">
                                        <%#Eval("PHONENUMBER")%>
                                    </td>
                                    <td valign="middle" align="center" style="width: 50px;">
                                        <%#Eval("CREATED_DATE")%>
                                    </td>
                                    <td valign="middle" align="center" style="width: 30px;">
                                        <input type="button" class="<%# (Eval("STATUS").ToString() == "1"?"True":"False") %>"
                                            title="" />
                                    </td>
                                    <td valign="middle" align="center">
                                        <asp:Literal ID="litText" runat="server"></asp:Literal>
                                        <a href="listcskhcomment.aspx?id=<%#Eval("ID")%>&height=500&width=900&modal=false&TB_iframe=true"
                                            class="thickbox links">
                                            <img src="../images/icons/ListViewIcon.jpg" alt="" />
                                        </a>
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
                        <cc1:CollectionPager ID="CollectionPager1" runat="server" MaxPages="10000">
                        </cc1:CollectionPager>
                    </div>
                </div>
                <div class="action">
                    <div class="button">
                        <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                            value="Thêm mới" onclick="location.href='../Administrator/DetailCustomer.aspx'"
                            type="button" />
                        <asp:Button role="button" ID="btnDelete2" Text="Xóa" class="del ui-button ui-widget ui-state-default ui-corner-all"
                            runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
