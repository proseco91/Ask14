<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="View_News" %>

<%@ Register Src="../UserControl/MenuRight.ascx" TagName="MenuRight" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%=Lib.urlHome() %>/Scripts/business.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
    <script src="<%=Lib.urlHome() %>/Scripts/GetDataNewsByCate.js"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/paging.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/paging.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="inner" style="height: 100%;">
        <div id="newsLeft">
            <div id="tags">

                <%
                    System.Data.DataTable dbTags = dbTagsPresent();
                    for (int i = 0; i < dbTags.Rows.Count; i++)
                    {
                        int ID = Convert.ToInt32(dbTags.Rows[i]["ID"].ToString());
                        string _tags = dbTags.Rows[i]["NAME"].ToString();
                %>
                <span class="tag-xs">
                    <a href="<%=Lib.urlHome()%>/tags<%=ID %>.htm" class="tag-name"><%=_tags %></a>
                </span>
                <%
                    }
                %>
            </div>

            <section id="list_news">
            </section>
            <div id="pagging">
            </div>
        </div>
        <uc1:MenuRight ID="MenuRight1" runat="server" />
    </div>
    <div style="clear: both"></div>

    <script type="text/javascript">
        var _category = "<%=_category %>";
        GetDataNewsByCate.getnews(_category, 5, 1);
        activeitem(_category);
        //activeitemChild(_category);
    </script>
</asp:Content>

