<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="SchoolList.aspx.cs" Inherits="Administrator_SchoolList" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                        url: "../services/WebService.asmx/DisplayNews",
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
        <script language="javascript" type="text/javascript">

            function OpenAdd() {
                window.location.replace(window.location.pathname + "ReportAdd.aspx");
            }
        </script>
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <div class="box">
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5 id="txtTitle">Danh sách trường học
                </h5>
                <%-- <div class="search">
                    <div class="input">
                        <input name="txtSearch" id="txtSearch" style="width: 200px;" onclick='if (this.value == "Nhập tiêu đề bài viết!") this.value = ""'
                            onblur='if(this.value=="")this.value="Nhập tiêu đề bài viết!"' type="text" runat="server" />
                    </div>
                    <div class="button">
                        <asp:Button ID="btnSearch" Text="Tìm kiếm" runat="server" OnClick="btnSearch_Click" />
                    </div>
                </div>--%>
            </div>
            <div id="divMessage" runat="server">
            </div>
            <div class="first-action">
                <div class="button">
                    <asp:Button aria-disabled="false" role="button" CssClass="add ui-button ui-widget ui-state-default ui-corner-all"
                        Text="Thêm Mới" runat="server" ID="btnAdnew1" OnClick="btnAdnew1_Click" />
                    
                </div>

            </div>
            <!-- end box / title -->
            <div class="table">
                <table>
                    <thead>
                        <tr>
                            <th class="stt">STT
                            </th>
                            <th>Tên trường
                            </th>
                            <th>Ảnh
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
                                <tr id='<%#Eval("ID")%>'>
                                    <td align="center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td valign="middle" align="center">
                                        <a title='<%# Eval("ID")%>' href='<%#"SchoolAdd.aspx?SchoolID="+Eval("ID")%>'>
                                            <%#Eval("School_Name")%>
                                        </a>
                                    </td>

                                    <td align="center" style="vertical-align: middle">
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#"~/Images/schools/"+Eval("School_Image")%>'
                                            Width="100" Height="100" />
                                    </td>

                                    <td align="center" style="vertical-align: middle">
                                        <input type="button" class="<%# (Eval("Status").ToString() == "1"?"True":"False") %>"
                                            title="Display" />
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("Created_Date")%>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

