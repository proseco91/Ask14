<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="CategoryEdit.aspx.cs" Inherits="Administrator_CategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>
                    Cập nhật danh mục
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
                                Tên danh mục</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtName" MaxLength="500" CssClass="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Danh mục cha</label></div>
                        <div class="input">
                            <asp:DropDownList ID="drvCategory" runat="server" Width="350" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Link</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtLink" MaxLength="500" CssClass="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Thứ tự hiển thị</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtSortDisplay" MaxLength="500" CssClass="required medium number"
                                Style="width: 500px;" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Meta keywords</label></div>
                        <div class="input">
                            <textarea ID="txtMetaKeyWords" Height="50" placeholder="Nhập meta keywords" MaxLength="500"
                                CssClass="medium " Style="width: 500px;" runat="server"></textarea>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Meta title</label></div>
                        <div class="input">
                            <textarea ID="txtMetaTitle" Height="50" placeholder="Nhập meta title" MaxLength="500"
                                CssClass="medium " Style="width: 500px;" runat="server"></textarea>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Meta description</label></div>
                        <div class="input">
                            <textarea ID="txtMetaDescription" Height="50" placeholder="Nhập meta description" MaxLength="500"
                                CssClass="medium " Style="width: 500px;" runat="server"></textarea>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Hiển thị trên menu</label></div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkDisplayMenu" Checked="True" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Cho phép hiển thị</label></div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" />
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Thêm mới"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href='../Administrator/Category.aspx'" type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
