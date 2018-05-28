<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter-New.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(window).resize(function () {
                $('.head').css('height', ($('.head').outerWidth(false) * 0.5625) + 'px');
            }).resize();
            $('.list-menu .item-menu').removeClass('active');
            $('.list-menu .item-menu[valid="0"]').addClass('active');
        });
    </script>
    <style type="text/css">
        .tuvantructuyen {
            height: 95px;
        }

            .tuvantructuyen .content-max {
                display: block;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="content-max">
        <div style="margin-bottom: 80px;">
            <div panel-title="dichvu">
                <span>Dịch Vụ</span>
            </div>
            <div class="panel-dichvu" style="margin-top: 20px;">
                <%foreach (var item in GetDichVu())
                    {%>
                <div class="item-dichvu">
                    <a href="/kien-thuc/<%=(item.CATEGORYNAME.ToString() != "quiz" ? Lib.LocDau(item.TITLE.ToString()) + "-c61-n" + item.ID : "../quiz-" + Lib.LocDau(item.TITLE.ToString()) + "-" + item.ID) + ".htm" %>">
                        <div class="item-dichvu-img" style="background-image: url('http://ask14.vn/images/news/<%=item.IMAGE %>');">
                        </div>
                    </a>
                    <a href="/kien-thuc/<%=(item.CATEGORYNAME.ToString() != "quiz" ? Lib.LocDau(item.TITLE.ToString()) + "-c61-n" + item.ID : "../quiz-" + Lib.LocDau(item.TITLE.ToString()) + "-" + item.ID) + ".htm" %>">
                        <div class="item-dichvu-title" title="<%=item.TITLE %>">
                            <%=item.TITLE %>
                        </div>
                    </a>
                    <div class="item-dichvu-des">
                        <%=item.SUMMARY %>
                    </div>
                    <div class="item-dichvu-link">
                        <a href="/kien-thuc/<%=(item.CATEGORYNAME.ToString() != "quiz" ? Lib.LocDau(item.TITLE.ToString()) + "-c61-n" + item.ID : "../quiz-" + Lib.LocDau(item.TITLE.ToString()) + "-" + item.ID) + ".htm" %>">Chi tiết</a>
                    </div>
                </div>
                <%} %>
            </div>
        </div>
        <div style="margin-bottom: 80px;">
            <div panel-title="hotro">
                <span>Hỗ Trợ Khẩn Cấp</span>
            </div>
            <div class="panel-hotro" style="margin-top: 20px;">
                <%foreach (var item in GetHoTro())
                    {%>
                <div class="item-hotro">
                    <a href="/tin-tuc--su-kien/<%=(item.CATEGORYNAME.ToString() != "quiz" ? Lib.LocDau(item.TITLE.ToString()) + "-c61-n" + item.ID : "../quiz-" + Lib.LocDau(item.TITLE.ToString()) + "-" + item.ID) + ".htm" %>">
                        <div class="item-hotro-img" style="background-image: url('http://ask14.vn/images/news/<%=item.IMAGE %>');">
                        </div>
                    </a>
                    <a href="/tin-tuc--su-kien/<%=(item.CATEGORYNAME.ToString() != "quiz" ? Lib.LocDau(item.TITLE.ToString()) + "-c61-n" + item.ID : "../quiz-" + Lib.LocDau(item.TITLE.ToString()) + "-" + item.ID) + ".htm" %>">
                        <div class="item-hotro-title" title="<%=item.TITLE %>">
                            <%=item.TITLE %>
                        </div>
                    </a>
                    <div class="item-hotro-des">
                        <%=item.SUMMARY %>
                    </div>
                    <div class="item-hotro-link">
                        <a href="/tin-tuc--su-kien/<%=(item.CATEGORYNAME.ToString() != "quiz" ? Lib.LocDau(item.TITLE.ToString()) + "-c61-n" + item.ID : "../quiz-" + Lib.LocDau(item.TITLE.ToString()) + "-" + item.ID) + ".htm" %>">Chi tiết</a>
                    </div>
                </div>
                <%} %>
            </div>
        </div>
        <div style="margin-bottom: 80px;">
            <div panel-title="tracnghiem">
                <span>Trắc Nghiệm</span>
            </div>
            <div class="panel-tracnghiem" style="margin-top: 20px;">
                <%for (int i = 1; i <= 3; i++)
                    {%>
                <%
                    var arraData = GetTracNghiem(i);
                %>
                <%if (arraData.Count > 0)
                    { %>
                <div class="item-tracnghiem">
                    <a href="<%="../quiz-" + Lib.LocDau(arraData[0].TITLE.ToString()) + "-" + arraData[0].ID + ".htm" %>" title="<%=arraData[0].TITLE %>">
                        <div class="item-tracnghiem-first">
                            <span class="item-tracnghiem-first-img" style="background-image: url('http://ask14.vn/images/news/<%=arraData[0].IMAGE %>');"></span>
                            <span class="item-tracnghiem-first-content">
                                <%=arraData[0].TITLE %>
                            </span>
                            <span class="item-tracnghiem-first-des">
                                <%=arraData[0].SUMMARY %>
                            </span>
                        </div>
                    </a>
                    <div class="item-tracnghiem-list">
                        <%for (int j = 1; j < arraData.Count; j++)
                            {%>
                        <a href="<%="../quiz-" + Lib.LocDau(arraData[j].TITLE.ToString()) + "-" + arraData[j].ID + ".htm" %>" title="<%=arraData[j].TITLE %>">
                            <div class="item-tracnghiem-list-item">
                                <%=arraData[j].TITLE %>
                            </div>
                        </a>
                        <%} %>
                    </div>
                </div>
                <%}%>
                <%} %>
            </div>
        </div>
        <div style="margin-bottom: 80px;">
            <div panel-title="chuyengia">
                <span>Chuyên Gia</span>
            </div>
            <div class="panel-chuyengia" style="margin-top: 20px;">
                <%foreach (var item in dbGetTestimonial())
                    {%>
                <div class="item-chuyengia">
                    <div class="item-chuyengia-head">
                        <span class="item-chuyengia-img" style="background-image: url('http://ask14.vn/images/testimonial/<%=item["IMAGE"] %>');"></span>
                        <span class="item-chuyengia-content">
                            <%=item["NAME"] %>
                        </span>
                    </div>
                    <div class="item-chuyengia-des">
                        <%=item["DESCRIPTION"] %>
                    </div>
                </div>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
