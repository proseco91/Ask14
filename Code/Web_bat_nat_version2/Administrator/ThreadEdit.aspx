<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="ThreadEdit.aspx.cs" Inherits="Administrator_ThreadEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>Cập nhật Thread
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
                                Tên chủ đề</label>
                        </div>
                        <div class="input">
                            <asp:DropDownList ID="drvSubject" runat="server" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Tên khách hàng</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtCustomerName" MaxLength="500" ReadOnly="true" CssClass="medium" runat="server"
                                Width="300px"> </asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Tên bài viết</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtArticleName" CssClass="required medium"  runat="server"
                                Width="500px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Nội dung bài viết</label>
                        </div>
                        <div class="input">
                            <textarea id="txtArticleContent" runat="server" cols="70" rows="20" ></textarea>
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
                                value="Quay lại" onclick="location.href = '../Administrator/ListThread.aspx'"
                                type="button" />                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

