<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter-New.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="View_News" %>

<%@ Register Src="../UserControl/MenuRight.ascx" TagName="MenuRight" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%=Lib.urlHome() %>/Scripts/business.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
    <script src="<%=Lib.urlHome() %>/Scripts/GetDataNewsByCate.js"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/paging.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/paging.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-menu .item-menu').removeClass('active');
            $('.list-menu .item-menu[valid="<%=_category%>"]').addClass('active');
        });
    </script>
    <style type="text/css">
        #pagging {
            float: none;
            margin: 0px;
            background-color: #FFF;
            padding: 20px;
        }

            #pagging .pagingcontent {
                float: right;
            }

        [tag-xs] {
            position: relative;
            height: 40.2px;
            display: inline-block;
            margin-right: 50px;
        }

            [tag-xs]:before {
                content: " ";
                position: absolute;
                width: 42.21px;
                height: 100%;
                background-position: center center;
                background-repeat: no-repeat;
                left: 0px;
                top: 0px;
                background-size: contain;
            }

        [tag-xs="1"]:before {
            background-image: url('../images/image-news/bg-tag-1.png');
        }

        [tag-xs="2"]:before {
            background-image: url('../images/image-news/bg-tag-2.png');
        }

        [tag-xs="3"]:before {
            background-image: url('../images/image-news/bg-tag-3.png');
        }

        [tag-xs] a {
            position: relative;
            left: 38.85px;
            height: 32.16px;
            top: calc(50% - 14.07px);
            padding-right: 40.2px;
            padding-left: 13.4px;
            font-size: 12.73px;
            color: #333;
            font-weight: bold;
            line-height: 32.16px;
            display: block;
        }

            [tag-xs] a::before {
                content: " ";
                position: absolute;
                left: 0px;
                width: calc(100% - 37px);
                top: 0px;
                background-image: url(../images/image-news/bg-tag-bg.png);
                z-index: -1;
                height: 100%;
                background-position: left top;
                background-size: contain;
            }

            [tag-xs] a:after {
                content: " ";
                position: absolute;
                right: 0px;
                height: 100%;
                width: 37px;
                top: 0px;
                background-image: url(../images/image-news/bg-tag-affter.png);
                z-index: -1;
                background-size: contain;
                background-repeat: no-repeat;
            }

        .head, #tags {
            margin-bottom: 15px;
        }

        .news .tuvantructuyen {
            position: relative;
            height: 95px;
            margin-top: 115px;
        }

            .news .tuvantructuyen .content-max {
                display: block;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="body-max news">
        <div class="content-max">
            <div id="newsLeft">
                <%if (_category != "49" && _category != "64")
                    {%>
                <div id="tags">
                    <%
                        Random random = new Random();
                        int numberOLD = 0;
                        System.Data.DataTable dbTags = dbTagsPresent();
                        for (int i = 0; i < dbTags.Rows.Count; i++)
                        {
                            int ID = Convert.ToInt32(dbTags.Rows[i]["ID"].ToString());
                            string _tags = dbTags.Rows[i]["NAME"].ToString();
                            int numberNow = random.Next(1, 4);
                            while (numberNow == numberOLD)
                            {
                                numberNow = random.Next(1, 4);
                            }
                            numberOLD = numberNow;
                    %>
                    <span tag-xs="<%=numberNow %>">
                        <a href="<%=Lib.urlHome()%>/tags<%=ID %>.htm" class="tag-name"><%=_tags %></a>
                    </span>
                    <%
                        }
                    %>
                </div>
                <%}%>
                <section id="list_news">
                </section>
                <div id="pagging">
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
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


    <script type="text/javascript">
        var _category = "<%=_category %>";
        GetDataNewsByCate.getnews(_category, 5, 1);
        activeitem(_category);
        //activeitemChild(_category);
    </script>
</asp:Content>

