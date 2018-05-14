<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="BaiVietTheoChuDe.aspx.cs" Inherits="View_BaiVietTheoChuDe" %>

<%@ Register Src="../UserControl/MenuRight.ascx" TagName="MenuRight" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
    <script src="<%=Lib.urlHome() %>/Scripts/business.js"></script>
    <script src="<%=Lib.urlHome() %>/Scripts/GetDataBySubject.js"></script>
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
            <article>
                <h2 class="titleSubject">Các comment liên quan tới
                <asp:Literal ID="ltContent" runat="server" />
                </h2>
                <section id="list_news">
                </section>
                <div id="pagging">
                </div>
            </article>
            <article id="relate-news">
                <span>Các chủ đề liên quan:</span>
                <ul class="related">
                    <%
                        System.Data.DataTable SubjectRelates = getSubject();
                        if (SubjectRelates.Rows.Count > 0)
                        {
                            for (int i = 0; i < SubjectRelates.Rows.Count; i++)
                            {
                                string _ID = SubjectRelates.Rows[i]["ID"].ToString();
                                string _title = SubjectRelates.Rows[i]["NAME"].ToString();                                    
                    %>
                    <li class="related">
                        <a href="<%=Lib.LocDau(_title)%>-s<%=_ID%>.htm"><%=_title %></a>
                    </li>
                    <%
                            }
                        }
                    %>
                </ul>
            </article>


        </div>
        <uc1:MenuRight ID="MenuRight1" runat="server" />
    </div>
    <div style="clear: both"></div>
    <script type="text/javascript">
        var _category = "<%=subjectID %>";
        GetDataBySubject.getBySubject(_category, 10, 1);
        activeitem(62);
        //activeitemChild(_category);
    </script>
</asp:Content>

