<%@ Page Title="Cây dịch vụ theo quyền quản trị" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="rolefunction.aspx.cs" Inherits="Administrator_rolefunction" %>

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
        .rolelist
        {
            width: 300px;
            float:left;
        }
        .tree
        {
            float:left;
            width:400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <asp:HiddenField ID="hdfCheck" runat="server" />
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5>
                    Cây dịch vụ theo quyền quản trị
                </h5>
            </div>
            <div id="divMessage" runat="server">
            </div>
            <!-- end box / title -->
            <div class="form">
                <div class="fields">
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="rolelist" 
                        AutoPostBack="True" onselectedindexchanged="ddlRole_SelectedIndexChanged">
                    </asp:DropDownList>
                    <div class="buttons" style="width:100px; margin:0 0 0 10px; padding:0; float:left;">
                        <div class="button ">
                            <asp:Button role="button" ID="btnUpdate" Text="Cập nhật" class="ui-button ui-widget ui-state-default ui-corner-all"
                                runat="server" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="tree">
                        <asp:TreeView ID="trvFunction" runat="server" CssClass="treeview" ShowCheckBoxes="All">
                        </asp:TreeView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
