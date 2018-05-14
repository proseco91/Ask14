<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="SubjectAdd.aspx.cs" Inherits="Administrator_SubjectAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>Cập nhật chủ đề
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
                            <asp:TextBox ID="txtSubjectName" MaxLength="500" class="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Ảnh mô tả (800 x 600px)</label>
                        </div>
                        <div class="input">
                            <asp:FileUpload runat="server" ID="fuImage" CssClass="file" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                            </label>
                        </div>
                        <div class="input">
                            <asp:Image ID="imgDes" runat="server" Width="100" Height="100" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Mô tả</label>
                        </div>
                        <div class="input">
                            <asp:TextBox TextMode="MultiLine" CssClass="required" ID="txtSummury" runat="server" Width="500px" Height="150px" />
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
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Chủ đề chính</label>
                        </div>
                        <div class="input">
                            <asp:CheckBox ID="chkIsHot" runat="server" />
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Cập nhật"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href = '../Administrator/Subject.aspx'" type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
