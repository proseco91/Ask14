<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="SchoolAdd.aspx.cs" Inherits="Administrator_SchoolAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>Cập nhật trường học
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
                                Tên trường</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtTitle" MaxLength="500" class="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Link Facebook</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtLinkFacebook" MaxLength="500" class="medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Ảnh(200px x 200px)</label>
                        </div>
                        <div class="input">
                            <asp:FileUpload ID="fuImage" runat="server" CssClass="file <%=_ClassRequired %>" />
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
                                Cho phép hiển thị</label>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" />

                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Thêm mới"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click1" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href = '../Administrator/SchoolList.aspx'" type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

