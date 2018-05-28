<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter-New.master" AutoEventWireup="true" CodeFile="Introduction.aspx.cs" Inherits="View_Introduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/news.css" rel="stylesheet" />
    <link href="../Styles/SlideShow.css" rel="stylesheet" />
    <script src="<%=Lib.urlHome() %>/Scripts/slideShow.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-menu .item-menu').removeClass('active');
            $('.list-menu .item-menu[valid="gioithieu"]').addClass('active');
        });
    </script>
    <script type="text/javascript">
        var timeClearSlider = setTimeout(function () { }, 1000);
        clearTimeout(timeClearSlider);
        $(document).ready(function () {
            actionSilder(0);
            $('.btnSlider').click(function () {
                var index = $('.btnSlider').index($(this));
                actionSilder(index);
            });

            $('.prev').click(function () {
                var index = $('span.btnSliderSelect').index();
                var sizeIndex = $('span.btnSlider').size();
                if (index == 0) {
                    actionSilder(sizeIndex - 1);
                } else {
                    actionSilder(index - 1);
                }
            });
            $('.next').click(function () {
                var index = $('span.btnSliderSelect').index();
                var sizeIndex = $('span.btnSlider').size();
                if (index == (sizeIndex - 1)) {
                    actionSilder(0);
                } else {
                    actionSilder(index + 1);
                }
            });


        });
        function actionSilder(index) {
            if (index >= $('.rslides .itemSilder').size())
                index = 0;
            $('.rslides .itemSilder').parent().removeClass('itemSilderSelect');
            $('.rslides .itemSilder').parent().eq(index).addClass('itemSilderSelect');
            $('.listSliderBtn .btnSlider').removeClass('btnSliderSelect');
            $('.listSliderBtn .btnSlider').eq(index).addClass('btnSliderSelect');
            clearTimeout(timeClearSlider);
            timeClearSlider = setTimeout(function () {
                actionSilder($('.rslides .itemSilder').parent().index($('.rslides').find('.itemSilderSelect')) + 1);
            }, 5000);
        }
    </script>
    <style type="text/css">
        /*.listSliderBtn {
            background-color: rgba(255, 255, 255, 0.5);
            border-radius: 5px;
            margin-top: -495px;
            overflow: hidden;
            padding: 5px;
            position: absolute;            
            z-index: 3;            
        }
         .listSliderBtn {
            background:none;
            position:statics;
            text-align:center;
            margin:20px 0px;
            position:relative;
            left:0px;
            padding:0px;
        }
            */

        .listSliderBtn {
            background: none;
            text-align: center;
            margin: 20px 0px;
            position: relative;
            left: 0px;
            padding: 0px;
        }

        .blue-button {
            border: 0px;
            width: 100%;
            padding-left: 0px;
            padding-right: 0px;
            font-size: 15px;
        }

        .head {
            margin-bottom: 20px;
        }

        #lien-he {
            /* padding-top: 20px; */
            background-color: #FFF;
            padding: 10px 20px;
        }

        #formLienHe .itemLienHe .itemLienHe-input {
            float: left;
            width: calc(100% - 25%);
        }
        textarea{
            width:100%;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="body-max news">
        <div class="content-max">
            <section id="slide-intro">
                <div class="panelSilder">
                    <div class="panelHomeFixed" style="position: relative; width: 100%; border: 0 none; margin: 0 auto; max-width: 100%;">
                        <!-- Slideshow 2 -->
                        <ul class="rslides" id="slider2">

                            <%
                                System.Data.DataTable dbSlide = dbGetSlideGioiThieu();
                                for (int i = 0; i < dbSlide.Rows.Count; i++)
                                {
                                    string _image = dbSlide.Rows[i]["IMAGE"].ToString();
                                    string _description = dbSlide.Rows[i]["DESCRIPTION"].ToString();
                            %>
                            <li>
                                <img class="itemSilder" alt="banner design"
                                    src="http://ask14.vn/images/SlideShow/<%=_image %>">
                                <p class="caption"><%=_description %></p>
                            </li>
                            <%
                                }
                            %>
                        </ul>

                        <a class="callbacks_nav callbacks4_nav prev" href="javascript:void(0)">Previous</a>
                        <a class="callbacks_nav callbacks4_nav next" href="javascript:void(0)">Next</a>

                        <div class="listSliderBtn">
                            <%
                                for (int i = 0; i < dbSlide.Rows.Count; i++)
                                { %>
                            <span class="btnSlider"><%= i+1 %></span>
                            <%
                                }
                            %>
                        </div>
                    </div>
                </div>

                <%--<div id="commentFacebook">
                <div class="fb-comments" data-href="http://yes.edu.vn/cau-chuyen-ve-nguoi-linh-my-day-tieng-anh-mien-phi-o-viet-nam-684-21.htm"
                    data-width="100%">
                </div>
            </div>--%>
            </section>
            <section id="lien-he">
                <h2>Liên hệ/Gửi bài
                </h2>
                <div id="formLienHe">
                    <h4>Thông tin liên hệ</h4>
                    <div class="itemLienHe">
                        <div class="itemLienHe-span">
                            Họ tên:
                        </div>
                        <div class="itemLienHe-input">
                            <asp:TextBox ID="txtFullName" placeholder="Nhập họ tên" runat="server" CssClass="required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="itemLienHe">
                        <div class="itemLienHe-span">
                            Email:
                        </div>
                        <div class="itemLienHe-input">
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Nhập email" CssClass="required email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="itemLienHe">
                        <div class="itemLienHe-span">
                            Điện thoại:
                        </div>
                        <div class="itemLienHe-input">
                            <asp:TextBox ID="txtPhoneNumber" placeholder="Nhập điện thoại" runat="server" CssClass="required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="itemLienHe">
                        <div class="itemLienHe-span">
                            Địa chỉ:
                        </div>
                        <div class="itemLienHe-input">
                            <asp:TextBox ID="txtDiaChi" placeholder="Nhập địa chỉ" runat="server" CssClass="required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="itemLienHe">
                        <div class="itemLienHe-span">
                            Nội dung:
                        </div>
                        <div class="itemLienHe-input">
                            <textarea id="txtNoiDung" placeholder="Nhập nội dung" runat="server" height="50" cols="82" cssclass="required"></textarea>
                        </div>
                    </div>
                    <div class="itemLienHe">
                        <div class="itemLienHe-span">
                            Mã xác nhận:
                        </div>
                        <div class="itemLienHe-input">
                            <div style="float: left; height: 28px;">
                                <asp:Image ID="imgCapcha" runat="server" />
                            </div>
                            <div style="float: left; margin: 0px 0px 0px 10px;">
                                <asp:TextBox ID="txtCapcha" runat="server" CssClass="txtCapCha"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 1px 0px 0px 10px; font-size: 12px; font-weight: bold; color: Red;">
                                <asp:Literal ID="labCaptcha" runat="server"></asp:Literal>
                            </div>

                        </div>
                    </div>
                    <div class="itemLienHe">
                        <asp:Button ID="btnSend" runat="server" CssClass="blue-button" Text="Gửi liên hệ" OnClick="btnSend_Click" />
                    </div>
                </div>

            </section>
        </div>
    </div>
    <%--<div class="inner" style="height: 100%;">
        

        <section id="googleMaps">



            <iframe width="1100px" height="480px" frameborder="0" marginheight="0" marginwidth="0" src="http://maps.google.com/maps/ms?msa=0&msid=201479424960230660146.0004a5066b068e5e1d8ad&hl=vi&ie=UTF8&source=embed&ll=21.040167,105.783105&spn=0.018024,0.025277&z=15&iwloc=0004a5066e9e277847dc7&output=embed" scrolling="no"></iframe>
        </section>


    </div>--%>
    <div style="clear: both"></div>

    <%--<script type="text/javascript">
        var _category = "59";
        //GetDataNewsByCate.getnews(_category, 5, 1);
        activeitem(_category);
        //activeitemChild(_category);
    </script>--%>
</asp:Content>

