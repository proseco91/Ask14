<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master"
    AutoEventWireup="true" CodeFile="CategoryNews.aspx.cs" Inherits="View_CategoryNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%=Lib.urlHome() %>/Scripts/business.js" type="text/javascript"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/GetDataNewsByCate.js" type="text/javascript"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/paging.js" type="text/javascript"></script>
    <link href="<%=Lib.urlHome() %>/Styles/paging.css" rel="stylesheet" type="text/css" />
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .pagingcontent li
        {
            background: url('<%=Lib.urlHome() %>/images/pagging.png')no-repeat;
        }
        .pagingcontent .pagingactive
        {
            background: url('<%=Lib.urlHome() %>/images/paggingActive.png')no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="divCenter">
        <div id="newsCate">
            <div id="ContentNews">
            </div>
            <div id="pagging">
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var _category = "<%=_category %>";
        var _categoryParent = "<%=_categoryParent %>";
        GetDataNewsByCate.getnews(_category, 5, 1);
        activeitem(_categoryParent);
        activeitemChild(_category);
    </script>
</asp:Content>
