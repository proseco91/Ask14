<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="UserControl/forum.ascx" TagName="forum" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        var timeClearSlider = setTimeout(function () { }, 1000);
        clearTimeout(timeClearSlider);
        $(document).ready(function () {
            actionSilder(0);
            $('.btnSlider').click(function () {
                var index = $('.btnSlider').index($(this));
                actionSilder(index);
            });
        });
        function actionSilder(index) {
            if (index >= $('.rslides .itemSilder').size())
                index = 0;
            $('.rslides .itemSilder').parent().parent().removeClass('itemSilderSelect');
            $('.rslides .itemSilder').parent().parent().eq(index).addClass('itemSilderSelect');
            $('.listSliderBtn .btnSlider').removeClass('btnSliderSelect');
            $('.listSliderBtn .btnSlider').eq(index).addClass('btnSliderSelect');
            clearTimeout(timeClearSlider);
            timeClearSlider = setTimeout(function () {
                actionSilder($('.rslides .itemSilder').parent().parent().index($('.rslides').find('.itemSilderSelect')) + 1);
            }, 5000);
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.tuvantructuyen').click(function () {
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
                } else {
                    $('.panelOfflineMessage').removeClass('panelOfflineMessage_Hiddel');
                }
            });
        });
        
    </script>
    <style type="text/css">
        .ul_al ul li {
            background: rgba(0, 0, 0, 0) url("http://hentocdo.vn/images/li.png") no-repeat scroll 0 2px;
            padding: 0 0 5px 20px;
            font-size: 12px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <section id="banner">
        <div class="panelSilder">
            <div class="panelHomeFixed" style="position: relative; width: 100%; border: 0 none; margin: 0 auto; max-width: 100%;">
                <!-- Slideshow 2 -->
                <ul class="rslides" id="slider2">
                    <%
                        System.Data.DataTable dbSide = dbGetSlide();
                        for (int i = 0; i < dbSide.Rows.Count; i++)
                        {
                            string _name = dbSide.Rows[i]["NAME"].ToString();
                            string _image = dbSide.Rows[i]["IMAGE"].ToString();
                            string _link = dbSide.Rows[i]["LINK"].ToString();
                    %>
                    <li><a href="<%=_link %>">
                        <img class="itemSilder" alt="<%=_name %>"
                            src="http://ask14.vn/images/SlideShow/<%=_image %>">
                    </a>
                        <div class="bgText">
                            <p class="textbold">Lịch tư vấn trực tiếp</p>
                            <p class="textFree">Miễn phí từ</p>
                            <p class="timeStroke">10h30 - 13h30</p>
                            <p class="allDay">Tất cả các ngày, trừ CN</p>
                            <a href="javascript:;" onclick="showAAAA();">
                                <p class="allDay" style="font-weight: normal;">(Chi tiết)</p>
                            </a>
                            <p class="tuvantructuyen">Tư vấn online </p>
                        </div>
                    </li>
                    <%
                        }
                    %>
                </ul>
                <div class="listSliderBtn">
                    <%
                        for (int i = 0; i < dbSide.Rows.Count; i++)
                        { %>
                    <span class="btnSlider"><%=i+1 %> </span>
                    <%
                        } %>
                </div>
            </div>
        </div>
    </section>
    <div style="clear: both">
    </div>
    <uc1:forum ID="forum1" runat="server" />

    <section id="eventHot" class="sectionElement">
        <div id="bgEventHotParent" class="bgSectionParent"></div>
        <div class="bgModule">
            <div class="inner" style="height: 100%;">
                <div class="bgEventHot">
                    <h2>Sự kiện hot
                    </h2>
                </div>
            </div>
        </div>
        <div class="inner">
            <div class="subjectContent">
                <div class="contentModule">

                    <%
                        CategoryController objCate = new CategoryController();
                        System.Data.DataTable dbEventHot = dbNewsHightLight();
                        for (int i = 0; i < dbEventHot.Rows.Count; i++)
                        {
                            string _image = dbEventHot.Rows[i]["IMAGE"].ToString();
                            string _name = dbEventHot.Rows[i]["TITLE"].ToString();
                            string _id = dbEventHot.Rows[i]["ID"].ToString();
                            string _cateID = dbEventHot.Rows[i]["CATEGORYID"].ToString().Split(';')[0];
                            string _cateName = "";


                            System.Data.DataTable dbCate = objCate.GetDataByID(_cateID.ToString());
                            if (dbCate.Rows.Count > 0)
                            {
                                _cateName = dbCate.Rows[0]["NAME"].ToString();
                            }
                            string _link = Lib.LocDau(_cateName) + "/" + Lib.LocDau(_name) + "-c" + _cateID + "-n" + _id + ".htm";                                                                
                    %>

                    <div class="item-content-eventHot">
                        <figure>
                            <img src="images/news/<%=_image %>" alt="<%=_name %>" />
                        </figure>
                        <figcaption class="titleEventHot">
                            <a href="<%=_link %>"><%=_name %></a>
                        </figcaption>
                    </div>
                    <%
                        }
                    %>
                </div>
            </div>
        </div>
    </section>

    <section id="s-expert" class="sectionElement">
        <div id="bgSExpertParent" class="bgSectionParent"></div>
        <div class="bgModule">
            <div class="inner" style="height: 100%;">
                <div class="bgSExpert">
                    <h2>Giới thiệu chuyên gia
                    </h2>
                </div>
            </div>
        </div>
        <div class="inner">
            <div class="subjectContent">
                <div class="contentModule">
                    <div class="SlideTestimonial">
                        <div id="slidwWith">
                            <div id="slides_container_testimonial">

                                <%
                                    System.Data.DataTable dbTest = dbGetTestimonial();
                                    for (int i = 0; i < dbTest.Rows.Count; i++)
                                    {
                                        string _Name = dbTest.Rows[i]["NAME"].ToString();
                                        string _Image = dbTest.Rows[i]["IMAGE"].ToString();
                                        string _Summury = dbTest.Rows[i]["SUMMURY"].ToString();
                                        string _Content = dbTest.Rows[i]["DESCRIPTION"].ToString();
                                %>

                                <div class="slide-item">

                                    <img style="cursor: pointer;" src="images/testimonial/<%=_Image %>" alt="<%=_Name %>" />
                                    <div class="slide-item-sum slide-item-expertName">
                                        <%=_Name %>
                                    </div>
                                    <div class="slide-item-sum">
                                        <%=_Summury %>
                                        <%=_Content %>
                                    </div>
                                </div>
                                <%
                                    }
                                %>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="btnSlide_testimonial">
                            <div style="text-align: center; margin-top: 8px;">
                                <span class="btnClickSlide_testimonial"></span>
                                <span class="btnClickSlide_testimonial"></span>
                                <span class="btnClickSlide_testimonial"></span>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <section id="partner" class="sectionElement">
        <div class="inner">
            <div class="itemPartner">
                <a href="#">
                    <img src="images/logoPlan.png" alt="Plan" />
                </a>
            </div>
            <div class="itemPartner">
                <a href="#">
                    <img src="images/logo_UNTF.png" alt="Csaga" />
                </a>
            </div>
            <div class="itemPartner">
                <a href="#">
                    <img src="images/logoSGDHN.png" alt="Sở giáo dục Hà Nội" />
                </a>
            </div>
            <div class="itemPartner">
                <a href="#">
                    <img src="images/logoCSAGA.png" alt="Csaga" />
                </a>
            </div>

        </div>
    </section>
</asp:Content>
