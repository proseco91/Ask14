<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdministratorEdit.aspx.cs" Inherits="Administrator_AdministratorEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>
                    Cập nhật quản trị viên
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
                                Tên quản trị viên</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtAdminName" MaxLength="500" class="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Tên đăng nhập</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtUserName" MaxLength="500" CssClass="required medium" runat="server"
                                Width="300px"> </asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Password</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtPass" MaxLength="500" CssClass="required medium" runat="server"
                                Width="300px"> </asp:TextBox>
                        </div>
                    </div>

                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Email</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="email" Width="300px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Địa chỉ</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtAddress" runat="server" Width="500px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Số điện thoại</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtPhoneNumber" Width="300" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                TT Hiển thị</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtSortDisplay" Width="100" CssClass="number required" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Vai trò</label></div>
                        <div class="input">
                            <asp:DropDownList ID="ddlRoll" runat="server" Width="206px">
                                <asp:ListItem Value="5">Quản trị viên</asp:ListItem>
                                <asp:ListItem Value="1">Nội dung</asp:ListItem>
                                <asp:ListItem Value="2">Tư vấn viên</asp:ListItem>
                                <asp:ListItem Value="3">Sự kiện</asp:ListItem>
                                <asp:ListItem Value="4">Kinh doanh</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Cập nhật"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                            </div>
                            <a href="Administrator.aspx" role="button" aria-disabled="false" runat="server" class="ui-button ui-widget ui-state-default ui-corner-all">
                                <input type="button" value="Quay lại" role="button" aria-disabled="false" runat="server"
                                    class="ui-button ui-widget ui-state-default ui-corner-all" /></a>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Làm Lại" type="reset">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </a>
</asp:Content>
