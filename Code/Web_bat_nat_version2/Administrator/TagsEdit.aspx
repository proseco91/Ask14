<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="TagsEdit.aspx.cs" Inherits="Administrator_TagsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>Cập nhật tags
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
                                Tags</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtTags" MaxLength="500" class="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
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
                                value="Quay lại" onclick="location.href = '../Administrator/ListTags.aspx'"
                                type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

