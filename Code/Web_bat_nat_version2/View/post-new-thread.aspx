<%@ Page Title="Chia sẻ câu chuyện" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="post-new-thread.aspx.cs" Inherits="View_post_new_thread" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            <%=scttttt %>

            $('.buttonReadMore').click(function () {
                var sessionEmail = '<%=Session["email"] %>';
                if (sessionEmail == '') {
                    if ($('.linktam_panel_login_data_none').size() > 0) {
                        var objEvent = {
                            nameevent: 'getheight',
                            element: '#ifreame_login_new',
                            width: $('.linktam_panel_login_data').width()
                        }
                        $('.linktam_panel_login_data').attr('valclick', 0).children('#ifreame_login_new').css({ 'width': (objEvent.width) + 'px' });
                        document.getElementById("ifreame_login_new").contentWindow.postMessage(JSONfn.stringify(objEvent), "*");
                        setTimeout(function () {
                            $('.linktam_panel_login_data').removeClass('linktam_panel_login_data_none');
                        }, 50);
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="background-color: #083785; overflow: hidden;">
        <div class="wrapper-inner">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="item-wrap">
                        <div class="item-wrap-name">
                            Chủ đề
                        </div>
                        <div class="item-wrap-input">
                            <asp:DropDownList ID="drvSubject" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drvSubject_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="item-wrap" id="otherSubject" runat="server" visible="false">
                        <div class="item-wrap-name">
                            Tên chủ đề khác
                        </div>
                        <div class="item-wrap-input">
                            <asp:TextBox ID="txtChuDeKhac" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="item-wrap">
                <div class="item-wrap-name">
                    Tên bài viết
                </div>
                <div class="item-wrap-input">
                    <asp:TextBox ID="txtArticleName" CssClass="required" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="item-wrap">
                <div class="item-wrap-name">
                    Nội dung
                </div>
                <div class="item-wrap-input">
                    <textarea id="txtContent" placeholder="Chuyên mục “Diễn đàn ask14.vn” xin chào các bạn!
Diễn đàn ask14.vn là nơi thảo luận, chia sẻ, bày tỏ quan điểm liên quan đến các vấn đề tại trường học như: Bạo lực và bắt nạt học đường, xâm hại tình dục, mối quan hệ với thầy cô – cha mẹ - bạn bè ở trường, làm thế nào để an toàn khi đến trường, sự phát triển của cơ thể. Ba tháng diễn đàn sẽ thảo luận về một chủ đề, bạn có thể tham gia diễn đàn bằng cách Click vào Hình ảnh nội tuyến 1  ở bên trái màn hình, sau đó làm theo hướng dẫn. Những chia sẻ của bạn sẽ update trên trang chủ và mục diễn đàn. Những chia sẻ có nhiều lượt like và comment nhất sẽ được Diễn đàn ask14.vn  đăng trên mục kiến thức của Ask 14.
Diễn đàn ask14.vn  mong nhận được sự ủng hộ, tham gia của các  bạn."
                        class="required" runat="server" cols="50" rows="20"></textarea>
                </div>
            </div>
            <div class="item-wrap">
                <asp:Button ID="btnChiaSeCauChuyenCuaBan" CssClass="buttonReadMore" runat="server" Text="Đăng bài" OnClick="btnChiaSeCauChuyenCuaBan_Click" />
            </div>
        </div>
    </div>

</asp:Content>

