<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="run-quiz.aspx.cs" Inherits="View_run_quiz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/strucnew.css" rel="stylesheet" />
    <link href="Styles/fonts-new.css" rel="stylesheet" />

    <script src="Scripts/wz_jsgraphics.js"></script>
    <script src="Scripts/strucnew.js"></script>
    <%--<script src="linktamchat/Scripts/chat/popup.js"></script>
    <link href="linktamchat/Styles/chat/popup.css" rel="stylesheet" />--%>
    <style type="text/css">
        body
        {
            line-height: normal;
        }

        .contentQuesaa
        {
            width: 800px;
            max-width: calc(100% - 20px);
            margin: 0 400px 0 auto;
            position:relative;
        }

        .contentListEx
        {
            box-shadow: none;
        }

        #iconQuickShare
        {
            display: none;
        }

        .panelInfoHocTap-Content
        {
            background-color: #EEE;
            height: 100%;
            position: absolute;
            left:calc(100% + 30px);
            top: 0;
            transition: right 0.3s ease-out 0s;
            width: 245px;
            z-index:1;
        }
    </style>
    <script type="text/javascript">
        var cbRandom = false;
        var cbThuTuLam = true;
        var ID_DE = <%=Request.QueryString["ID"]%>;
        var keyguid = '<%=keyguid%>';
        var demNguocTime = <%=totalSec %>;
        var idTimeIn = setInterval(function () {
            var totalMin = parseInt(demNguocTime / 60)
            var totalSec = parseInt(demNguocTime % 60);
            $('.panelBox-NewLB-Time span').last().text(totalMin + " : " + totalSec);
            demNguocTime--;
            if(demNguocTime<0){
                createJsonSaveServer();
                clearInterval(idTimeIn);
            }
        }, 1000);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <%
        System.Collections.Generic.List<StrucQuestionNew> _array = getQuestion();
    %>
    <div style="clear: both; height: 30px;"></div>
    <div id="loadingBarCrazy"></div>
    <%--<div class="btnQuestionNopBai">Nộp bài</div>--%>
    <div class="contentQuesaa">
        <div class="contentInfoLamBai">
            <div class="contentInfoLamBai-Ex" style="<%=_array.Count<=1?"display:none;": ""%>">
                <div class="contentInfoLamBai-Ex-Hidden">
                    <%for (int i = 1; i <= _array.Count; i++)
                      {%>
                    <div class="contentInfoLamBai-Ex-Item">
                        Exercise
                                    <%=i %>
                        <div>
                        </div>
                    </div>
                    <%}%>
                </div>
            </div>

            <div class="contentListEx">
                <%
                    string htmlScript = "";
                    try
                    {
                        foreach (StrucQuestionNew itemEx in _array)
                        {
                %>
                <div class="contentListEx-itemparent" valnext="false">
                    <%if (!String.IsNullOrEmpty(itemEx.title))
                      { %>
                    <div class="contentListEx-itemparent-title">
                        <%=itemEx.title%>
                    </div>
                    <%}%>
                    <div class="contentListEx-itemparent-page">
                        <div class="contentListEx-itemparent-page-hiddel">
                            <%for (int i = 1; i <= itemEx.arrayQuestion.Count; i++)
                              {%>
                            <div class="contentListEx-itemparent-page-item">
                                Question
                                            <%=i %><div></div>
                            </div>
                            <%}%>
                        </div>
                    </div>
                    <div class="contentListEx-itemparent-data">
                        <%=getHTMLContentQuestion(itemEx.arrayQuestion) %>
                    </div>
                </div>
                <%
                        }
                        Session["listArrayStrucNew-" + Request.QueryString["ID"] + '-' + keyguid] = _array;
                    }
                    catch (Exception ex)
                    {
                        htmlScript = "jConfirm('Thông báo', '<div style=\"text-align:left;\">" + Regex.Replace(ex.Message, "\n", "") + "</div>', null, null, 500);$('#social').remove();$('.confirm-Close').remove();";
                    }
                %>
                <script type="text/javascript">
                    $(document).ready(function () {
                        <%=htmlScript %>
                    });
                </script>
                <div class="contentListEx-Btn">
                    <div dis-mousedown="true" class="contentListEx-Btn-Click contentListEx-Btn-Click-Prev contentListEx-Btn-Prev contentListEx-Btn-Click-Show">
                        <div>
                            <span></span>
                        </div>
                        Prev<div>
                            <span style="background-color: #FFF; border-color: #FFF;"></span>
                        </div>
                    </div>
                    <div dis-mousedown="true" class="contentListEx-Btn-Click contentListEx-Btn-Next contentListEx-Btn-Click-Show">
                        <div>
                            <span style="background-color: #FFF; border-color: #FFF;"></span>
                        </div>
                        Next<div>
                            <span></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panelInfoHocTap-Content">
        <div style="height: 213px; position: relative;" class="panelBox-NewLB panelBox-NewLB-Time-Parent panelBox-NewLB-Time-Parent-Show">
            <div class="panelEFFRightInfo panelBox-NewLB-Time-Fixed" style="top: 0px;">
                <div class="panelBox-NewLB-Time">
                    <span></span><span>0 : 0</span><div>
                    </div>
                    <div>
                    </div>
                </div>
                <div>

                    <div class="intemInfoNew" aaa-group2 aaa-none>
                        <div class="intemInfoNew-title">Số câu đúng</div>
                        <div class="intemInfoNew-content" aaa-suc></div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div class="intemInfoNew" aaa-group2 aaa-none>
                        <div class="intemInfoNew-title">Số câu sai</div>
                        <div class="intemInfoNew-content" aaa-sai></div>
                        <div style="clear: both;">
                        </div>
                    </div>

                    <div class="intemInfoNew" aaa-group1>
                        <div class="intemInfoNew-title">Total Exercise</div>
                        <div class="intemInfoNew-content"><%=_array.Count%></div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div class="intemInfoNew" aaa-group1>
                        <div class="intemInfoNew-title">Total Question</div>
                        <div class="intemInfoNew-content"><%=totalEx%></div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div class="intemInfoNew" aaa-group1>
                        <div class="intemInfoNew-title">Chưa làm/Tổng số</div>
                        <div class="intemInfoNew-content datatotalAAAAAAAAAAAA">80/80</div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div style="overflow: hidden;" aaa-group1>
                        <div dis-mousedown="true" class="btnQuestionNopBai">Xem kết quả</div>

                        <div dis-mousedown="true" class="btnQuestionChuaLam" valindex="0" style="display: block;">Tìm câu chưa làm</div>

                        <div style="clear: both;">
                        </div>
                    </div>
                    <div id="Div1">
                        <div class="loadingBarCrazyPt" style="transition: width 0s ease-out 0s; width: 0%;"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

    
</asp:Content>

