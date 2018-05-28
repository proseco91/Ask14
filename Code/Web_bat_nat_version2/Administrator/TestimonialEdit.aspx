<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="TestimonialEdit.aspx.cs" Inherits="Administrator_TestimonialEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>
                    Cập nhật Testimonial
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
                                Tên</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtTitle" MaxLength="500" CssClass="required medium" Style="width: 500px;"
                                runat="server" TextMode="MultiLine"></asp:TextBox>

                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Ảnh minh họa(156x154)</label></div>
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
                                Giới thiệu</label></div>
                        <div class="textarea">
                            <CKEditor:CKEditorControl ID="txtIntro" runat="server"></CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Nội dung</label></div>
                        <div class="textarea">
                            <CKEditor:CKEditorControl ID="txtDescription" runat="server"></CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Cho phép hiển thị</label></div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" />
                            <div id="ctl00_NOTE_DISPLAY" class="note">
                                Đồng ý cho nội dung này hiển thị .</div>
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Thêm mới"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href='../Administrator/TestimonialList.aspx'"
                                type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
