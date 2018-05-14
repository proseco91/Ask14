<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="EmailTemplateEdit.aspx.cs" Inherits="Administrator_EmailTemplateEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>
                    Cập nhật Email template
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
                                Tiêu đề
                            </label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtDescription" MaxLength="500" class="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Nội dung
                            </label>
                        </div>
                        <div class="textarea">
                            <CKEditor:CKEditorControl runat="server" ID="txtContent" Height="500px"></CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Cập nhật"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                                
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href='../Administrator/EmailTemplate.aspx'"
                                type="button">
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Làm Lại" type="reset">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
