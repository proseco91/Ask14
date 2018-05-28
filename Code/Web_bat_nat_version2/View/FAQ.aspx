<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter-New.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="View_FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%=Lib.urlHome() %>/Scripts/business.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
    <script src="<%=Lib.urlHome() %>/Scripts/FAQ.js"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/paging.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/paging.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-menu .item-menu').removeClass('active');
            $('.list-menu .item-menu[valid="hoidap"]').addClass('active');
        });
    </script>
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
    <style type="text/css">
        .news .tuvantructuyen {
            position: relative;
            height: 95px;
            margin-top: 115px;
        }

            .news .tuvantructuyen .content-max {
                display: block;
            }

        #pagging {
            float: none;
            margin: 0px;
            background-color: #FFF;
            padding: 20px;
        }

            #pagging .pagingcontent {
                float: right;
            }

        #list_FAQ {
            background-color: #FFF;
            padding: 20px;
            box-sizing: border-box;
        }

        .itemFAQ p,.itemAnswer p{
            margin: 0px;
            padding: 0px;
        }

        .itemSP {
            font-size: 15px;
        }

        .date {
            font-size: 13px;
            display:block;
            float:none !important;
        }

        .itemFAQ-contentQ .itemFAQ-desc {
            float: left;
            width: 100%;
            text-align: justify;
            font-size: 13px;
            line-height: 20px;
        }
        .itemFAQ-contentQ{
            text-align: justify;
            font-size: 13px;
            line-height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="body-max news">
        <div class="content-max">
            <div id="newsLeft">
                <section id="list_FAQ" class="list_FAQ">
                </section>
                <div id="pagging">
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
        <div style="clear: both"></div>
        <div class="body-max tuvantructuyen">
            <div class="content-max" style="position: relative">
                <div class="quick-alo-phone quick-alo-green quick-alo-show" id="quick-alo-phoneIcon">
                    <div class="quick-alo-ph-circle"></div>
                    <div class="quick-alo-ph-circle-fill"></div>
                    <div class="quick-alo-ph-img-circle"></div>
                </div>
                <div class="content-tuvan">
                    <span style="font-size: 25px; color: #FFF; font-weight: bold; text-transform: uppercase; width: 267px;">Tư vấn trực tuyến
                    </span>
                    <span style="font-size: 13px; color: #242424; padding-left: 35px;">Tất cả các ngày, trừ CN (Các câu hỏi ngoài giờ sẽ được trả lời offline sau đó)
                    </span>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both"></div>

    <script type="text/javascript">
        GetDataFAQ.getByFAQ(5, 1);
    </script>
</asp:Content>

