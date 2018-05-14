<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="NewsBySchool.aspx.cs" Inherits="View_NewsBySchool" %>

<%@ Register Src="../UserControl/MenuRight.ascx" TagName="MenuRight" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%=Lib.urlHome() %>/Scripts/business.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
    <script src="<%=Lib.urlHome() %>/Scripts/GetDataNewsBySchool.js"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/paging.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/paging.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="inner" style="height: 100%;">
        <div id="newsLeft">
            <div id="schoolName">
                <h3>
                    <asp:Literal ID="ltSchoolName" runat="server" />
                </h3>
                <h5>Link Facebook:
                    <asp:Literal ID="ltFacebookSchool" runat="server" />
                </h5>
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
        var _schoolID = "<%=_schoolID %>";
        GetDataBySchoolID.getnews(_schoolID, 5, 1);
    </script>
</asp:Content>

