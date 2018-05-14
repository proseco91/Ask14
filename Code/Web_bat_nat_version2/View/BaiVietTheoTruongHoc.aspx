﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="BaiVietTheoTruongHoc.aspx.cs" Inherits="View_BaiVietTheoTruongHoc" %>

<%@ Register Src="../UserControl/MenuRight.ascx" TagName="MenuRight" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
    <script src="<%=Lib.urlHome() %>/Scripts/business.js"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/GetDataBySchoolID.js"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/paging.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/paging.css" rel="stylesheet" />
    <style type="text/css">
        #newsLeft {
            padding-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="inner" style="height: 100%;">
        <div id="newsLeft">
            <h2 class="titleSubject">
                <asp:Literal ID="ltContent" runat="server" />
            </h2>
            <section id="list_news">
            </section>
            <div id="pagging">
            </div>
        </div>
        <uc1:MenuRight ID="MenuRight1" runat="server" />
    </div>
    <div style="clear: both"></div>
    <script type="text/javascript">
        var _category = "<%=SchoolID %>";
        GetDataBySchoolID.GetDataBySchool(_category, 10, 1);
        activeitem(62);
        //activeitemChild(_category);
    </script>
</asp:Content>

