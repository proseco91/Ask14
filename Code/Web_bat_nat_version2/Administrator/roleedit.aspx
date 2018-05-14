<%@ Page Title="Cập nhật quyền quản trị" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="roleedit.aspx.cs" Inherits="Administrator_roleedit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <div class="title">
                <h5>
                    Cập nhật quyền quản trị
                </h5>
            </div>
            <!-- end box / title -->
            <div id="divMessage" runat="server">
            </div>
            <div class="form">
                <div class="fields">
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Tiêu đề</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="required2 medium"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Trạng thái</label></div>
                        <div class="input">
                            <asp:CheckBox ID="chkStatus" runat="server" Checked="true" CssClass="checkbox" />
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button ID="btnSubmit" runat="server" Text="Thêm mới" CssClass="ui-button ui-widget ui-state-default ui-corner-all"
                                    OnClick="btnSubmit_Click" />
                            </div>
                            <input class="ui-button ui-widget ui-state-default ui-corner-all" value="Quay lại"
                                onclick="location.href='role.aspx'" type="button" />
                            <input class="ui-button ui-widget ui-state-default ui-corner-all" value="Làm Lại"
                                type="reset" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
