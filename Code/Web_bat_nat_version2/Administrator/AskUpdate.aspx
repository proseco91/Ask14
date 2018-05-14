<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="AskUpdate.aspx.cs" Inherits="Administrator_AskUpdate" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>Cập nhật hỏi đáp
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
                                Câu hỏi</label>
                        </div>
                        <div class="textarea">
                            <CKEditor:CKEditorControl runat="server" ID="txtQuestion"  CssClass="required">
                            </CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Câu trả lời</label>
                        </div>
                        <div class="textarea">
                            <CKEditor:CKEditorControl runat="server" ID="txtAnswe12312312312rytuy" Height="500"  CssClass="required">
                            </CKEditor:CKEditorControl>
                        </div>
                    </div>

                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Trạng thái</label>
                        </div>
                        <div class="input">
                            <asp:CheckBox ID="chkStatus" runat="server" />
                        </div>
                    </div>

                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Cập nhật"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href = '../Administrator/ask.aspx'"
                                type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

