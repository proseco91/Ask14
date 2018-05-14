<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="TeacherUpdate.aspx.cs" Inherits="Administrator_TeacherUpdate" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>
                    Cập nhật giáo viên
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
                                Tên giáo viên</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtName" MaxLength="500" class="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                            <div id="Div1" class="note">
                                Nhập tên giáo viên
                            </div>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Ảnh minh họa(76x97)</label></div>
                        <div class="input">
                            <asp:FileUpload ID="fuImage" runat="server" CssClass="file" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                            </label>
                        </div>
                        <div class="input">
                            <asp:Image runat="server" ID="imgDescription" Width="150px" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Mô tả</label></div>
                        <div class="textarea">
                            <CKEditor:CKEditorControl runat="server" ID="txtDescription" Height="500px">
                            </CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Cho phép hiển thị</label></div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" />
                            <div id="ctl00_NOTE_DISPLAY" class="note">
                                Đồng ý cho giáo viên này hiển thị .</div>
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Cập nhật"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href='../Administrator/Teacher.aspx'" type="button" />
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui corner-all"
                                value="Làm Lại" type="reset" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
