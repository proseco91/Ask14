<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" Inherits="Administrator_UploadFile" %>

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
                    Thay đổi SlideShow
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
                                Chọn File từ máy tính:</label></div>
                        <div class="input">
                            <asp:FileUpload ID="FileUpload1" CssClass="required file" runat="server" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Link download:</label>
                        </div>
                        <div class="input">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Link view pdf:</label>
                        </div>
                        <div class="input">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Upload"
                                    ID="btnSubmit" runat="server" OnClick="btnUpload_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href='../Administrator/ListUpload.aspx'" type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
