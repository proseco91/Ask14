<%@ Page Title="Cập nhật module" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="functionedit.aspx.cs" Inherits="Administrator_functionedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <div class="title">
                <h5>
                    Cập nhật module
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
                            <asp:TextBox ID="txtFunctionName" runat="server" CssClass="required medium"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Module cha</label></div>
                        <div class="input">
                            <asp:DropDownList ID="ddlParent" runat="server" Width="400px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Url</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtUrl" runat="server" CssClass="medium" Width="520px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Thứ tự</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtIndex" runat="server" CssClass="medium digits" Width="520px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Hiển thị</label></div>
                        <div class="input">
                            <asp:CheckBox ID="chkDisplay" runat="server" Checked="true" CssClass="checkbox" />
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button ID="btnSubmit" runat="server" Text="Thêm mới" CssClass="ui-button ui-widget ui-state-default ui-corner-all"
                                    OnClick="btnSubmit_Click" />
                            </div>
                            <input class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href='function.aspx'" type="button" />
                            <input class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Làm Lại" type="reset" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
