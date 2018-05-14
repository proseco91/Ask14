<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="View_FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%=Lib.urlHome() %>/Scripts/business.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
    <script src="<%=Lib.urlHome() %>/Scripts/FAQ.js"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/paging.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/paging.css" rel="stylesheet" />

    <script type="text/javascript">
        setTimeout(function () {
            $('.itemInput textarea[max-length],.itemInput input:text[max-length],.itemInput input:password[max-length]').keyup(function (event) {
                var maxLeng = parseInt($(this).attr('max-length'));
                var panelShow = $(this).prev('.itemInput-Title');
                if (panelShow.find('.numberCountText').size() <= 0)
                    panelShow.append('<span class="numberCountText"></span>');
                panelShow.find('.numberCountText').text('(' + (maxLeng - $(this).val().length) + ' ký tự)');
            }).keyup;


            $('.itemInput input:text,.itemInput input:password,.itemInput textarea').keyup(function (event) {
                var _text = $(this).val();
                if (_text.length > 0)
                    $(this).parent('.itemInput').addClass('itemInputActive');
                else
                    $(this).parent('.itemInput').removeClass('itemInputActive');
            }).keyup();

            $('.itemInput input:text,.itemInput input:password,.itemInput textarea').focusin(function () {
                $(this).parent('.itemInput').addClass('itemInputActive');
            }).focusout(function () {
                $('.itemInput input:text,.itemInput input:password,.itemInput textarea').keyup();
            });
        }, 10);

        $(document).ready(function () {

              <%=scttttt %>

            $('.buttonLienHe').click(function () {
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
                        <%=scttttt %>
                    }
                }
                else {
                    <%=scttttt %>
                }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="inner" style="height: 100%;">
        <div id="newsLeft">

            <%--<section id="addQuestion">
                <div class="box-panel" style="border-radius: 0px 5px 5px 5px; box-shadow: 0px 0px 1px #838383; margin-top: 40px;">
                    <span class="title-chia-se">Thêm hỏi đáp</span>
                    <div>
                        <div class="itemInput itemInputActive">
                            <div class="itemInput-Title itemInput-Title-textarea">
                                Nội dung
                            </div>
                            <asp:TextBox CssClass="required" ID="txtNoiDung" runat="server" TextMode="MultiLine" max-length="500" placeholder="Ask14 xin chào các em!\nAsk14 là trang web tư vấn miễn phí cho các bạn học sinh, thầy cô, cha mẹ về các vấn đề tại trường học như: Bạo lực và bắt nạt học đường, xâm hại tình dục, mối quan hệ với thầy cô – cha mẹ - bạn bè ở trường, làm thế nào để an toàn khi đến trường, sự phát triển của cơ thể và các câu về Ask14. Vì thời gian tư vấn online chỉ từ 10h30 đến 13h30 tất cả các ngày trong tuần (trừ chủ nhật và ngày nghỉ lễ, tết), nên mục này sẽ là nơi nhận các câu hỏi, thắc mắc, các vấn đề cần tư vấn. Bạn có thể đăng tình huống của mình, các tư vấn và admin sẽ trả lời bạn trong thời gian sớm nhất.\nAsk14.vn chúc các bạn học sinh trải qua tuổi học trò luôn hạnh phúc và mỗi ngày đến trường là một ngày vui."></asp:TextBox>
                        </div>

                    </div>
                </div>
                <div class="itemInput" style="float: right;">                    
                    <asp:Button ID="btnLienHe" CssClass="buttonLienHe" Text="Gửi" runat="server" OnClick="btnLienHe_Click" />
                </div>
            </section>--%>

            <section id="list_FAQ" class="list_FAQ">
            </section>
            <div id="pagging">
            </div>

        </div>
        <div id="newsRight">
            <section id="advertise">
                <img src="<%=Lib.urlHome() %>/images/advertise1.jpg" alt="Quảng cáo" />
            </section>
            <section id="maps-p">
                <a href="#">
                    <img src="<%=Lib.urlHome() %>/images/maps-p.png" alt="Đánh dấu địa điểm bắt nạt" />
                </a>
            </section>
        </div>
    </div>
    <div style="clear: both"></div>

    <script type="text/javascript">
        var _category = "63";
        activeitem(_category);

        GetDataFAQ.getByFAQ(5, 1);
    </script>
</asp:Content>

