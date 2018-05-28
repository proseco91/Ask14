<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter-New.master" AutoEventWireup="true" CodeFile="NewsDetails.aspx.cs" Inherits="View_NewsDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
    <style type="text/css">
        ul li.related{
            list-style:none;
        }
        .head {
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="body-max news">
        <div class="content-max">
            <div id="newsLeft" style="background-color:#FFF;">
                <section id="newsDetails">
                <article>
                    <h2 class="newsDetails-title">
                        <asp:Literal ID="ltTitle" runat="server" />
                    </h2>
                    <div class="entry-meta" style="padding-bottom: 20px; font-size: 11px;">

                        <span class="date">
                            <i class="icon-calendar-empty"></i>
                            <time style="font-size: 11px;" datetime="">
                                <asp:Literal ID="ltDatetime" runat="server" />
                            </time>
                        </span>
                    </div>

                    <section class="newsDetails-content">
                        <asp:Literal ID="ltContent" runat="server" />
                    </section>

                    <div id="tags">
                        <%


                            TagsController objTags = new TagsController();
                            string[] sp_list = _listTags.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < sp_list.Length; i++)
                            {
                                System.Data.DataTable dbTags = objTags.GetDataById(Convert.ToInt32(sp_list[i]));
                                int ID = Convert.ToInt32(dbTags.Rows[0]["ID"].ToString());
                                string _tags = dbTags.Rows[0]["NAME"].ToString();
                        %>
                        <span class="tag-xs">
                            <a href="<%=Lib.urlHome() %>/tags<%=ID %>.htm" class="tag-name"><%=_tags %></a>
                        </span>
                        <%
                            }
                        %>
                    </div>

                </article>
                <article id="relate-news">
                    <span>Tin liên quan:</span>
                    <ul class="related">
                        <%
                            System.Data.DataTable NewsRelate = dbTop5Related();
                            if (NewsRelate.Rows.Count > 0)
                            {
                                for (int i = 0; i < NewsRelate.Rows.Count; i++)
                                {
                                    string _ID = NewsRelate.Rows[i]["ID"].ToString();
                                    string _title = NewsRelate.Rows[i]["TITLE"].ToString();

                        %>
                        <li class="related">
                            <a href="<%=Lib.LocDau(_title)%>-c<%=Request.QueryString["CategoryID"].ToString() %>-n<%=_ID %>.htm"><%=_title %></a>
                        </li>
                        <%
                                }
                            }
                        %>
                    </ul>
                </article>
            </section>
            </div>
        </div>
    </div>
    <div style="clear: both"></div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-menu .item-menu').removeClass('active');
            $('.list-menu .item-menu[valid="<%=Request.QueryString["CategoryID"].ToString() %>"]').addClass('active');
        });
    </script>
    <%--<script type="text/javascript">
        var _category = "<%=Request.QueryString["CategoryID"].ToString() %>";
        activeitem(_category);
        //activeitemChild(_category);
    </script>--%>
</asp:Content>

