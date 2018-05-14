<%@ Page Title="Cập nhật chân trang" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="footer.aspx.cs" Inherits="Administrator_footer" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <div class="title">
                <h5>
                    Cập nhật chân trang
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
                                Nội dung</label></div>
                        <div class="textarea">
                            <CKEditor:CKEditorControl ID="txtContent" runat="server"  Height="400px">
                            </CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button ID="btnSubmit" runat="server" Text="Cập nhật" 
                                    CssClass="ui-button ui-widget ui-state-default ui-corner-all" 
                                    onclick="btnSubmit_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="history.back();" type="button">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
