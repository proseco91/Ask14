<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="EmailTemplate.aspx.cs" Inherits="Administrator_EmailTemplate" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <script type="text/javascript">
            var index = "";
            $(document).ready(function () {
                $("input.add").click(function () {
                    window.location.open(window.location + "EmailTemplateAdd.aspx");
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
        <script language="javascript" type="text/javascript">

            function OpenAdd() {
                window.location.replace(window.location.pathname + "EmailTemplateAdd.aspx");
            }
        </script>
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <div class="box">
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5 id="txtTitle">
                    Danh sách các Email Template
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
                                Tiêu đề
                            </th>
                            <th>
                                Ngày tạo
                            </th>
                            <th class="selected last">
                                <input class="checkall" type="checkbox" />
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptData">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td valign="middle" align="center">
                                        <a title='<%# Eval("EMAILID")%>' href='<%#"EmailTemplateEdit.aspx?EMAILID="+Eval("EMAILID")%>'>
                                            <%#Eval("DESCRIPTION")%>
                                        </a>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("CREATEDDATE")%>
                                    </td>
                                    <td align="center" class="last">
                                        <input type="checkbox" value="<%#Eval("EMAILID")%>" class="item" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="pagination pagination-left last" style="width: 100%">
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
                            runat="server" OnClick="btnDelete2_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- end table -->
</asp:Content>
