<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="NewsAdd.aspx.cs" Inherits="Administrator_ModuleAdd" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .inputtypeNew:first-child, inputtypeNewTags:first-child {
            padding-left: 0px !important;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            var indexTag = "";
            $('.updateTags').click(function () {

                var arrId = "";
                $('.inputtypeNew input[type=checkbox]').each(function (index) {
                    if ($(this).attr('checked')) {
                        arrId += $(this).val() + ";";
                    }
                });
                $('#<%=listCategory.ClientID %>').val(arrId);




                $('.inputtypeNewTags').find("input[type=checkbox]").each(function () {
                    var checked = $(this).attr("checked");
                    if (checked) {
                        indexTag = indexTag + $(this).attr("value") + ";";
                    }
                });
                $("#<%=listTags.ClientID%>").val(indexTag);
                if (indexTag == "") {
                    //alert('Bạn chưa lựa chọn Tags');
                    //return false;
                }
                else return confirm("Bạn đồng ý cập nhật TAGS đã lựa chọn không!");
            });



        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>Cập nhật bài tin
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
                                Tiêu đề</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtTitle" MaxLength="500" class="required medium" Style="width: 500px;"
                                runat="server">
                            </asp:TextBox>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="field">
                                <div class="label">
                                    <label class="small-label">
                                        Nhóm tin</label>
                                </div>
                                <div class="input">
                                    <style type="text/css">
                                        .inputtypeNew {
                                            margin: 0px 0px 10px 0px;
                                        }

                                            .inputtypeNew input[type=checkbox] {
                                                float: none !important;
                                            }
                                    </style>
                                    <asp:Literal ID="txtCategory" runat="server"></asp:Literal>
                                    <asp:HiddenField ID="listCategory" runat="server" />
                                </div>
                            </div>
                            <div class="field">
                                <div class="label">
                                    <label class="small-label">
                                        Trường học</label>
                                </div>
                                <div class="input">
                                    <asp:DropDownList ID="drvSchool" runat="server" />
                                </div>
                            </div>



                            <div class="field">
                                <div class="label">
                                    <label class="small-label">
                                        Ảnh(800px x 600px)</label>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Mô tả</label>
                        </div>
                        <div class="textarea">
                            <div>
                                <asp:TextBox TextMode="MultiLine" CssClass="required" ID="txtSumary" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Nội dung</label>
                        </div>
                        <div class="textarea">
                            <CKEditor:CKEditorControl runat="server" ID="txtContent" Height="500px" CssClass="required">
                            </CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Meta keywords</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtKeywords" MaxLength="500" class="required medium" Style="width: 500px;"
                                runat="server">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Meta description</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtDescription" MaxLength="500" Height="50px" class="required medium"
                                Style="width: 500px;" runat="server">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Tin hot</label>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkNewsHot" />
                            <div id="Div1" class="note">
                                Đồng ý cho bài tin này là tin hot.
                            </div>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Cho phép hiển thị</label>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" />
                            <div id="ctl00_NOTE_DISPLAY" class="note">
                                Đồng ý cho bài tin này hiển thị .
                            </div>
                        </div>
                    </div>


                    <asp:UpdatePanel ID="panelTags" runat="server">
                        <ContentTemplate>

                            <div class="field">
                                <div class="label">
                                    <label class="small-label">
                                        Tags</label>
                                </div>
                                <div class="input">
                                    <asp:Literal ID="ltTags" runat="server"></asp:Literal>
                                    <asp:HiddenField ID="listTags" runat="server" />
                                    <div style="clear: both">
                                    </div>
                                    <div class="action">
                                        <div class="input">
                                            <span style="font-size: 12px; float: left; padding-right: 20px; line-height: 28px;">Tag:</span>
                                            <asp:TextBox ID="txtTag" Width="150" CssClass="" placeholder="Mời bạn nhập tag"
                                                runat="server" />

                                        </div>
                                        <div class="button" style="float: right; margin-top: 20px;">
                                            <%--<asp:Button aria-disabled="false" role="button" CssClass="add ui-button ui-widget ui-state-default ui-corner-all"
                                                Text="Thêm Mới" runat="server" ID="Button2" OnClientClick="if(!confirm('Bạn đồng ý thêm mới TAGS trên không?')) return false;"
                                                OnClick="Button2_Click" />--%>
                                            <%--<asp:Button role="button" ID="btnCapNhatTags" Text="Cập nhật" class="updateTags add ui-button ui-widget ui-state-default ui-corner-all"
                                                runat="server" OnClick="btnCapNhatTags_Click" />--%>
                                        </div>

                                    </div>
                                    <div style="clear: both"></div>
                                    <div style="color: red; font-weight: bold;">
                                        <asp:Literal ID="ltMess" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="updateTags ui-button ui-widget ui-state-default ui-corner-all" Text="Thêm mới"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click1" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href = '../Administrator/News.aspx'" type="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
