<%@ Page Title="Module" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="function.aspx.cs" Inherits="Administrator_function" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #content div.box .treeview table
        {
            width: 0px;
        }
        #content div.box .treeview td
        {
            border: none;
        }
        #content div.box .treeview td input
        {
            float: left;
            margin-right: 4px;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $("input.add").click(function () {
                window.location.href = "functionedit.aspx";
            });

            $("input.del").click(function () {
                var index = "";
                $("table input[type=checkbox]").each(function () {
                    var checked = $(this).attr("checked");
                    if (checked) {
                        index++;
                    }
                });
                $("#<%=hdfCheck.ClientID%>").val(index);
                if (index == "") return false;
                else return confirm("Xác nhận xóa !");
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <asp:HiddenField ID="hdfCheck" runat="server" />
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5>
                    Danh sách module
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
            <div class="">
                <asp:TreeView ID="trvFunction" runat="server" CssClass="treeview" ShowCheckBoxes="All">
                </asp:TreeView>
            </div>
        </div>
    </div>
</asp:Content>
