<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="View_Search" %>

<%@ Register Src="../UserControl/MenuRight.ascx" TagName="MenuRight" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">


    <div class="inner" style="height: 100%;">
        <div id="newsLeft">
            <div id="PageSearchGoogle">
                <iframe id="iframe1" style="border: 0px; height: 1300px; width: 100%; padding: 3px" src="http://www.google.com/cse?q=<%=keysearch %>&amp;option=googlesearch&amp;ie=UTF-8&amp;oe=UTF-8&amp;cof=FORID%3A9&amp;cx=009484839556271387297:jrp14m7gk6w&amp;hl=<%=langua %>&amp;as_occt=http://ask14.vn&amp;sitesearch=http://ask14.vn&amp;ad=w9&amp;num=10"></iframe>
            </div>
        </div>
        <uc1:MenuRight ID="MenuRight1" runat="server" />
    </div>
    <div style="clear: both"></div>



    <%--https://cse.google.com.vn/cse/publicurl?cx=009484839556271387297:jrp14m7gk6w--%>
</asp:Content>

