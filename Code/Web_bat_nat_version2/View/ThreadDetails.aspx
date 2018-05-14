<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="ThreadDetails.aspx.cs" Inherits="View_ThreadDetails" %>

<%@ Register Src="../UserControl/MenuRight.ascx" TagName="MenuRight" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%=Lib.urlHome() %>/Scripts/autosize.js"></script>
    <link href="<%=Lib.urlHome() %>/Styles/news.css" rel="stylesheet" />
    <link href="<%=Lib.urlHome() %>/Styles/forum.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            autosize(document.querySelectorAll('#<%=txtComment.ClientID%>'));
            //Đăng comment
            <%=scttttt%>;
            var sessionEmail1231231231231231231 = '<%=Session["email"] %>';
            if (sessionEmail1231231231231231231 != "") {

                var _threadID = '<%=_threadID %>';
                $.ajax({
                    type: 'POST',
                    url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                    data: {
                        type: "checkLikeThread",
                        _threadID: _threadID,
                        _email: sessionEmail1231231231231231231
                    },
                    async: true,
                    dataType: "json",
                    success: function (data) {
                        if (data[0]) {

                            var _countLike = data[1];
                            $('#spanCountLike').text(_countLike);
                            $('#spanCountLike').parent().children('a').removeClass("like-button");
                            $('#spanCountLike').parent().children('a').addClass("unlike-button");

                            abcUnLike();
                        } else {

                            var _countLike = data[1];

                            if (_countLike == 0 || _countLike == "") {
                                _countLike = 0;
                            }
                            $('#spanCountLike').text(_countLike);
                            $('#spanCountLike').parent().children('a').removeClass("unlike-button");
                            $('#spanCountLike').parent().children('a').addClass("like-button");

                            abcLike();
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    }
                });
            } else {


                var _threadID = '<%=_threadID %>';
                $.ajax({
                    type: 'POST',
                    url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                    data: {
                        type: "countLikeThread",
                        _threadID: _threadID
                    },
                    async: true,
                    dataType: "json",
                    success: function (data) {
                        if (data[0]) {

                            var _countLike = data[1];
                            $('#spanCountLike').text(_countLike);
                            $('#spanCountLike').parent().children('a').addClass("like-button");

                            abcLike();
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    }
                });
            }
            $('.btnDangLen').click(function () {
                var sessionEmail = '<%=Session["email"] %>';
                if (sessionEmail == '') {
                    if ($('.linktam_panel_login_data_none').size() > 0) {
                        var objEvent = {
                            nameevent: 'getheight',
                            element: '#ifreame_login_new',
                            width: $('.linktam_panel_login_data').width()
                        }
                        $('.linktam_panel_login_data').attr('valclick', 0).children('#ifreame_login_new').css({ 'width': (objEvent.width) + 'px' });
                        document.getElementById("ifreame_login_new").contentWindow.postMessage(JSONfn.stringify(objEvent), "*");
                        setTimeout(function () {
                            $('.linktam_panel_login_data').removeClass('linktam_panel_login_data_none');
                        }, 50);
                         <%=scttttt %>
                    }
                }
                else {
                    <%=scttttt %>
                }
            });
            function abcUnLike() {
                $('.unlike-button').click(function () {
                    var _this = $(this);
                    var sessionEmail = '<%=Session["email"] %>';
                    if (sessionEmail == '') {
                        if ($('.linktam_panel_login_data_none').size() > 0) {
                            var objEvent = {
                                nameevent: 'getheight',
                                element: '#ifreame_login_new',
                                width: $('.linktam_panel_login_data').width()
                            }
                            $('.linktam_panel_login_data').attr('valclick', 0).children('#ifreame_login_new').css({ 'width': (objEvent.width) + 'px' });
                            document.getElementById("ifreame_login_new").contentWindow.postMessage(JSONfn.stringify(objEvent), "*");
                            setTimeout(function () {
                                $('.linktam_panel_login_data').removeClass('linktam_panel_login_data_none');
                            }, 50);
                        }
                    } else {
                        var _threadID = '<%=_threadID %>';
                        $.ajax({
                            type: 'POST',
                            url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                            data: {
                                type: "deleteLikeThread",
                                _threadID: _threadID,
                                _email: sessionEmail
                            },
                            async: true,
                            dataType: "json",
                            success: function (data) {
                                if (data) {
                                    _this.addClass("like-button");
                                    _this.removeClass("unlike-button");

                                    var _valueCount = $('#spanCountLike').text();
                                    _valueCount = parseInt(_valueCount) - 1;
                                    $('#spanCountLike').text(_valueCount);

                                    _this.unbind("click");
                                    $('.like-button').click(function () {
                                        var _threadID = '<%=_threadID %>';
                                        $.ajax({
                                            type: 'POST',
                                            url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                                            data: {
                                                type: "insertLikeThread",
                                                _threadID: _threadID,
                                                _email: sessionEmail
                                            },
                                            async: true,
                                            dataType: "json",
                                            success: function (data) {
                                                if (data) {
                                                    _this.addClass("unlike-button");
                                                    _this.removeClass("like-button");

                                                    var _valueCount = $('#spanCountLike').text();
                                                    _valueCount = parseInt(_valueCount) + 1;
                                                    $('#spanCountLike').text(_valueCount);

                                                    _this.unbind("click");
                                                    $('.unlike-button').click(function () {
                                                        alert('Bạn đã Like/Unlike bài viết. Nếu muốn tiếp tục thao tác, hãy tải lại trang web.');
                                                    });

                                                } else {
                                                    alert('Liên hệ với quản trị để được hỗ trợ.');
                                                }
                                            },
                                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                            }
                                        });
                                    });
                                } else {
                                    alert('Liên hệ với quản trị để được hỗ trợ.');
                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                            }
                        });
                    }
                });
            }

            function abcLike() {
                $('.like-button').click(function () {
                    var _this = $(this);
                    var sessionEmail = '<%=Session["email"] %>';
                    if (sessionEmail == '') {
                        if ($('.linktam_panel_login_data_none').size() > 0) {
                            var objEvent = {
                                nameevent: 'getheight',
                                element: '#ifreame_login_new',
                                width: $('.linktam_panel_login_data').width()
                            }
                            $('.linktam_panel_login_data').attr('valclick', 0).children('#ifreame_login_new').css({ 'width': (objEvent.width) + 'px' });
                            document.getElementById("ifreame_login_new").contentWindow.postMessage(JSONfn.stringify(objEvent), "*");
                            setTimeout(function () {
                                $('.linktam_panel_login_data').removeClass('linktam_panel_login_data_none');
                            }, 50);
                        }
                    } else {
                        var _threadID = '<%=_threadID %>';
                        $.ajax({
                            type: 'POST',
                            url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                            data: {
                                type: "insertLikeThread",
                                _threadID: _threadID,
                                _email: sessionEmail
                            },
                            async: true,
                            dataType: "json",
                            success: function (data) {
                                if (data) {

                                    _this.addClass("unlike-button");
                                    _this.removeClass("like-button");

                                    var _valueCount = $('#spanCountLike').text();
                                    _valueCount = parseInt(_valueCount) + 1;
                                    $('#spanCountLike').text(_valueCount);

                                    _this.unbind("click");
                                    $('.unlike-button').click(function () {
                                        var _this = $(this);
                                        var _threadID = '<%=_threadID %>';
                                        $.ajax({
                                            type: 'POST',
                                            url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                                            data: {
                                                type: "deleteLikeThread",
                                                _threadID: _threadID,
                                                _email: sessionEmail
                                            },
                                            async: true,
                                            dataType: "json",
                                            success: function (data) {
                                                if (data) {
                                                    _this.addClass("like-button");
                                                    _this.removeClass("unlike-button");

                                                    var _valueCount = $('#spanCountLike').text();
                                                    _valueCount = parseInt(_valueCount) - 1;
                                                    $('#spanCountLike').text(_valueCount);

                                                    _this.unbind("click");
                                                    $('.like-button').click(function () {
                                                        alert('Bạn đã Like/Unlike bài viết. Nếu muốn tiếp tục thao tác, hãy tải lại trang web.');
                                                    });
                                                }
                                            },
                                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                            }
                                        });
                                    });
                                } else {
                                    alert('Liên hệ với quản trị để được hỗ trợ.');
                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                            }
                        });
                    }
                });
            }














            $('.like-buttonComment').click(function () {
                var _this = $(this);
                var sessionEmail = '<%=Session["email"] %>';
                if (sessionEmail == '') {
                    if ($('.linktam_panel_login_data_none').size() > 0) {
                        var objEvent = {
                            nameevent: 'getheight',
                            element: '#ifreame_login_new',
                            width: $('.linktam_panel_login_data').width()
                        }
                        $('.linktam_panel_login_data').attr('valclick', 0).children('#ifreame_login_new').css({ 'width': (objEvent.width) + 'px' });
                        document.getElementById("ifreame_login_new").contentWindow.postMessage(JSONfn.stringify(objEvent), "*");
                        setTimeout(function () {
                            $('.linktam_panel_login_data').removeClass('linktam_panel_login_data_none');
                        }, 50);
                    }
                } else {
                    var _commentId = _this.parent().attr('id').split('quick-icon-item')[1];
                    $.ajax({
                        type: 'POST',
                        url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                        data: {
                            type: "insertLikeCommentThread",
                            _commentId: _commentId,
                            _email: sessionEmail
                        },
                        async: true,
                        dataType: "json",
                        success: function (data) {
                            if (data) {

                                _this.addClass("unlike-buttonComment");
                                _this.removeClass("like-buttonComment");
                                _this.unbind("click");

                                var _classComment = _this.parent().find('.countLikeComment');
                                var _valueCount = _classComment.text();
                                _valueCount = parseInt(_valueCount) + 1;
                                if (_valueCount < 0) {
                                    _valueCount = 0;
                                }
                                _classComment.text(_valueCount);


                                $('.unlike-buttonComment').click(function () {
                                    var _this = $(this);

                                    $.ajax({
                                        type: 'POST',
                                        url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                                        data: {
                                            type: "deleteLikeCommentThread",
                                            _commentId: _commentId,
                                            _email: sessionEmail
                                        },
                                        async: true,
                                        dataType: "json",
                                        success: function (data) {
                                            if (data) {
                                                _this.addClass("like-buttonComment");
                                                _this.removeClass("unlike-buttonComment");
                                                _this.unbind("click");

                                                var _classComment = _this.parent().find('.countLikeComment');
                                                var _valueCount = _classComment.text();
                                                _valueCount = parseInt(_valueCount) - 1;
                                                if (_valueCount < 0) {
                                                    _valueCount = 0;
                                                }
                                                _classComment.text(_valueCount);


                                                $('.like-buttonComment').click(function () {
                                                    alert('Bạn đã Like/Unlike bài viết. Nếu muốn tiếp tục thao tác, hãy tải lại trang web.');
                                                });
                                            }
                                        },
                                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        }
                                    });
                                });
                            } else {
                                alert('Liên hệ với quản trị để được hỗ trợ.');
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                }
            });




            $('.unlike-buttonComment').click(function () {
                var _this = $(this);
                var sessionEmail = '<%=Session["email"] %>';
                if (sessionEmail == '') {
                    if ($('.linktam_panel_login_data_none').size() > 0) {
                        var objEvent = {
                            nameevent: 'getheight',
                            element: '#ifreame_login_new',
                            width: $('.linktam_panel_login_data').width()
                        }
                        $('.linktam_panel_login_data').attr('valclick', 0).children('#ifreame_login_new').css({ 'width': (objEvent.width) + 'px' });
                        document.getElementById("ifreame_login_new").contentWindow.postMessage(JSONfn.stringify(objEvent), "*");
                        setTimeout(function () {
                            $('.linktam_panel_login_data').removeClass('linktam_panel_login_data_none');
                        }, 50);
                    }
                } else {
                    var _commentId = _this.parent().attr('id').split('quick-icon-item')[1];
                    $.ajax({
                        type: 'POST',
                        url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                        data: {
                            type: "deleteLikeCommentThread",
                            _commentId: _commentId,
                            _email: sessionEmail
                        },
                        async: true,
                        dataType: "json",
                        success: function (data) {
                            if (data) {
                                _this.addClass("like-buttonComment");
                                _this.removeClass("unlike-buttonComment");
                                _this.unbind("click");

                                var _classComment = _this.parent().find('.countLikeComment');
                                var _valueCount = _classComment.text();
                                _valueCount = parseInt(_valueCount) - 1;
                                if (_valueCount < 0) {
                                    _valueCount = 0;
                                }
                                _classComment.text(_valueCount);

                                $('.like-buttonComment').click(function () {
                                    $.ajax({
                                        type: 'POST',
                                        url: 'http://localhost:1600/Web_bat_nat_version2/ajax/Ajax.aspx',
                                        data: {
                                            type: "insertLikeCommentThread",
                                            _commentId: _commentId,
                                            _email: sessionEmail
                                        },
                                        async: true,
                                        dataType: "json",
                                        success: function (data) {
                                            if (data) {
                                                _this.addClass("unlike-buttonComment");
                                                _this.removeClass("like-buttonComment");
                                                _this.unbind("click");

                                                var _classComment = _this.parent().find('.countLikeComment');
                                                var _valueCount = _classComment.text();
                                                _valueCount = parseInt(_valueCount) + 1;
                                                if (_valueCount < 0) {
                                                    _valueCount = 0;
                                                }
                                                _classComment.text(_valueCount);


                                                $('.unlike-buttonComment').click(function () {
                                                    alert('Bạn đã Like/Unlike bài viết. Nếu muốn tiếp tục thao tác, hãy tải lại trang web.');
                                                });
                                            }
                                        },
                                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        }
                                    });
                                });
                            } else {
                                alert('Liên hệ với quản trị để được hỗ trợ.');
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                }
            });








        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
    <div class="inner" style="height: 100%;">
        <div id="newsLeft">
            <h2 class="titleSubject">
                <asp:Literal ID="Literal1" runat="server" />
            </h2>
            <section id="newsDetails">
                <article>
                    <div class="newsDetailsLeft">
                        <h2 class="newsDetails-title">
                            <asp:Literal ID="ltTitle" runat="server" />
                        </h2>
                        <div class="entry-meta" style="padding-bottom: 5px; font-size: 11px;">
                            <span class="date">
                                <i class="icon-calendar-empty"></i>
                                <time style="font-size: 11px;" datetime="">
                                    <asp:Literal ID="ltDatetime" runat="server" />
                                </time>
                            </span>
                        </div>

                        <div class="entry-meta" style="padding-bottom: 5px; font-size: 11px;">
                            <span class="date">
                                <i class="icon-pencil"></i>
                                <time style="font-size: 11px;" datetime="">
                                    <asp:Literal ID="Literal2" runat="server" />
                                </time>
                            </span>
                        </div>
                        <div class="entry-meta" style="padding-bottom: 20px; font-size: 11px;">
                            <span class="date">
                                <i class="icon-comment"></i>
                                <time style="font-size: 11px;" datetime="">
                                    Comment: <asp:Literal ID="Literal3" runat="server" />
                                </time>
                            </span>
                        </div>
                        

                    </div>
                    <div class="newsDetailsRight">
                        <img src="<%=_avatar %>" alt="<%=_avatar %>" />
                    </div>

                    <div style="clear: both"></div>



                    <section class="newsDetails-content">
                        <asp:Literal ID="ltContent" runat="server" />
                    </section>
                    <div style="clear: both"></div>
                    <div class="quick-icon">
                        <a class="like-button"></a>

                        <span class="mtCountLike"></span>
                        <span id="spanCountLike" class="countLikeComment"></span>
                    </div>
                    <div style="clear: both"></div>
                    <section id="comment">
                        <div class="boxNhaptext">
                            <div class="boxNhaptextTextEff">
                            </div>
                            <div class="boxNhaptextText">
                                <textarea runat="server" class="required" placeholder="Nhập comment của bạn..." id="txtComment" style="overflow: hidden; word-wrap: break-word; resize: none; height: 48px;"></textarea>
                                <div class="loadingComment">
                                </div>
                            </div>
                            <div class="btnNutAll">
                                <div style="float: right;">
                                    <div class="div_btnDangLen">

                                        <asp:Button CssClass="btnDangLen" ID="btnDang" runat="server" Text="Đăng" OnClick="btnDang_Click" />
                                    </div>
                                </div>
                                <div style="clear: both;">
                                </div>
                            </div>
                        </div>

                        <div id="cmtn" style="display: block;">
                            <%
                                CountLikeCommentController objCountLikeComment = new CountLikeCommentController();
                                System.Data.DataTable dbForum = dbLoadCommentByThread();
                                for (int i = 0; i < dbForum.Rows.Count; i++)
                                {
                                    string _custName = dbForum.Rows[i]["CUSTOMER_NAME"].ToString();
                                    string _CustAvatar = dbForum.Rows[i]["AVARTA"].ToString();
                                    DateTime _DatePost = Convert.ToDateTime(dbForum.Rows[i]["Created_date"].ToString());
                                    string _Comment = dbForum.Rows[i]["Content"].ToString();

                                    int _idComment = Convert.ToInt32(dbForum.Rows[i]["ID"].ToString());
                                    int _countLike = objCountLikeComment.CheckCountThread(_idComment).Rows.Count;
                                    //Kiểm tra xem KH này đã like comment hay chưa?                               
                                    string _classComment = "";
                                    if (String.IsNullOrEmpty(Session["email"].ToString()))
                                    {
                                        _classComment = "like-buttonComment";

                                    }
                                    else
                                    {
                                        System.Data.DataTable dbCheckLike = objCountLikeComment.CheckCount(_idComment, Session["email"].ToString());
                                        if (dbCheckLike.Rows.Count > 0)
                                        {
                                            _classComment = "unlike-buttonComment";
                                        }
                                        else
                                        {
                                            _classComment = "like-buttonComment";
                                        }
                                    }                                                                                                                                                        
                            %>

                            <div class="item-comment" id="comment<%=_idComment %>">
                                <div class="item-comment-avarta">
                                    <img width="50" alt="<%=_custName %>" src="<%=_CustAvatar %>">
                                </div>
                                <div class="item-comment-avarta-content">
                                    <div class="item-post-name"><a href="#"><%=_custName %></a></div>
                                    <div class="time-post-comment"><span><%=_DatePost %></span></div>
                                    <div class="item-post-content"><%=_Comment %> </div>
                                </div>
                                <div class="quick-icon" id="quick-icon-item<%=_idComment %>">
                                    <a class="<%=_classComment %>"></a>
                                    <span class="mtCountLike"></span>
                                    <span class="countLikeComment"><%=_countLike %></span>
                                </div>
                            </div>
                            <%
                                }
                            %>
                        </div>
                    </section>

                </article>
                <article id="relate-news">
                    <span>Bài liên quan:</span>
                    <ul class="related">
                        <%
                            System.Data.DataTable NewsRelate = dbTop5Related();
                            if (NewsRelate.Rows.Count > 0)
                            {
                                for (int i = 0; i < NewsRelate.Rows.Count; i++)
                                {
                                    string _ID = NewsRelate.Rows[i]["ID"].ToString();
                                    string _title = NewsRelate.Rows[i]["Article_Name"].ToString();
                                    
                        %>
                        <li class="related">
                            <a href="<%=Lib.LocDau(_title)%>-td<%=_ID %>.htm"><%=_title %></a>
                        </li>
                        <%
                                }
                            }
                        %>
                    </ul>
                </article>
            </section>
        </div>
        <uc1:MenuRight ID="MenuRight1" runat="server" />
    </div>
    <div style="clear: both"></div>
    <script type="text/javascript">
        activeitem(62);
        //activeitemChild(_category);
    </script>
</asp:Content>

