<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="SlideShowedit.aspx.cs" Inherits="Administrator_SlideShowedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>Cập nhật SlideShow
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
                                Tên SlideShow</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtName" MaxLength="500" CssClass="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Dạng slide</label>
                        </div>
                        <div class="input">
                            <asp:DropDownList ID="drvTypeSlide" runat="server">
                                <asp:ListItem Value="0">Slide trang chủ</asp:ListItem>
                                <asp:ListItem Value="1">Slide Giới thiệu</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Link</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtLink" MaxLength="500" CssClass="required medium" Style="width: 500px;"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>



                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                File (1200px x 400px)</label>
                        </div>
                        <div class="input">
                            <asp:FileUpload ID="fuImage" MaxLength="500" CssClass="medium file" Style="width: 500px;"
                                runat="server"></asp:FileUpload>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                            </label>
                        </div>
                        <div class="input">
                            <asp:Image ID="imgFile" runat="server" Height="100" Width="100" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Mô tả</label>
                        </div>
                        <div class="textarea">
                            <div>
                                <asp:TextBox TextMode="MultiLine" CssClass="" ID="txtSumary" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Thứ tự hiển thị</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtSortDisplay" MaxLength="500" CssClass="required medium number"
                                Style="width: 500px;" runat="server"></asp:TextBox>
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
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href = '../Administrator/SlideShowList.aspx'"
                                type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
