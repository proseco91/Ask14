<%@ Page Title="Danh sách quyền" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="role.aspx.cs" Inherits="Administrator_role" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .cate option
        {
            padding: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <script type="text/javascript">
            var index = "";
            $(document).ready(function () {
                $("input.add").click(function () {
                    window.location.href = "roleedit.aspx";
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
            });
        </script>
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <div class="box">
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5 id="txtTitle">
                    Danh sách quyền
                </h5>
            </div>
            <div id="divMessage" runat="server">
            </div>
            <div class="first-action">
                <div class="button">
                    <input class="add ui-button ui-widget ui-state-default ui-corner-all" value="Thêm Mới"
                        type="button" />
                    <asp:Button role="button" ID="btnDelete" Text="Xóa" class="del ui-button ui-widget ui-state-default ui-corner-all"
                        runat="server" OnClick="btnDelete_Click" />
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
                                Tên quyền
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
                                <tr id='<%# Eval("ROLEID")%>'>
                                    <td align="center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td valign="middle" align="center">
                                        <a title='<%# Eval("ROLEID")%>' href='<%#"roleedit.aspx?id="+Eval("ROLEID")%>'>
                                            <%#Eval("ROLENAME")%>
                                        </a>
                                    </td>
                                    <td valign="middle" align="center">
                                        <input type="button" class='<%#(Eval("STATUS").ToString() == "1"? "True" : "False") %>' />
                                    </td>
                                    <td align="center" class="last">
                                        <div runat="server" id="delete">
                                            <input type="checkbox" value="<%#Eval("ROLEID")%>" class="item" />
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="pagination pagination-left last">
                    <div id="pagerContainer" class="pagerContainer">
                        <cc1:CollectionPager ID="CollectionPager1" runat="server" MaxPages="20" PageSize="20">
                        </cc1:CollectionPager>
                    </div>
                </div>
                <div class="action">
                    <div class="button">
                        <input class="add ui-button ui-widget ui-state-default ui-corner-all" value="Thêm Mới"
                            type="button" />
                        <asp:Button role="button" ID="btnDelete2" Text="Xóa" class="del ui-button ui-widget ui-state-default ui-corner-all"
                            runat="server" OnClick="btnDelete2_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
