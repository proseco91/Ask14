<%@ Control Language="C#" AutoEventWireup="true" CodeFile="forum.ascx.cs" Inherits="UserControl_forum" %>



<script type="text/javascript">
    var isSlideShowSuc = true;
    $(document).ready(function () {
        var _countItem = $('.item-content-forum').size() * 125;
        $('#wrapC').css('width', _countItem + 'px');


        $('.preview').click(function () {
            if (isSlideShowSuc) {
                isSlideShowSuc = false;
                var _index = $('.preview').index($(this));
                var numberThis = parseInt($(this).attr('valenum'));
                var data_content = $('#wrapC');
                var totalCount = parseInt(data_content.eq(_index).children('.item-content-forum').size());

                if (numberThis <= 0) {
                    data_content.eq(_index).stop().animate({ 'margin-left': '-' + (totalCount - 8) * 130 + 'px' }, 300, function () {
                        isSlideShowSuc = true;
                        $('.preview').eq(_index).attr('valenum', totalCount - 8);
                        $('.next').eq(_index).attr('valenum', totalCount);
                    });
                } else {
                    data_content.eq(_index).stop().animate({ 'margin-left': '+=130px' }, 300, function () {
                        isSlideShowSuc = true;
                        $('.preview').eq(_index).attr('valenum', numberThis - 1);
                        $('.next').eq(_index).attr('valenum', (parseInt($('.next').eq(_index).attr('valenum'))) - 1);
                    });
                }
            }
        });
        $('.next').click(function () {
            if (isSlideShowSuc) {
                isSlideShowSuc = false;
                var index = $('.next').index($(this));
                var numberThis = parseInt($(this).attr('valenum'));
                var data_content = $('#wrapC');
                var totalCount = parseInt(data_content.eq(index).children('.item-content-forum').size());
                $('#wrapC').css('width', totalCount * 130);
                if (numberThis >= totalCount) {
                    data_content.eq(index).stop().animate({ 'margin-left': '0px' }, 300, function () {
                        isSlideShowSuc = true;
                        $('.preview').eq(index).attr('valenum', '0');
                        $('.next').eq(index).attr('valenum', '8');
                    });
                } else {
                    data_content.eq(index).stop().animate({ 'margin-left': '-=130px' }, 300, function () {
                        isSlideShowSuc = true;
                        $('.preview').eq(index).attr('valenum', numberThis + 1);
                        $('.next').eq(index).attr('valenum', (parseInt($('.preview').eq(index).attr('valenum'))) + 1);
                    });
                }
            }
        });
    });
</script>



<section id="subject" class="sectionElement">
    <div style="text-align: center; width: 100%;">
        <div class="bgText" id="textWap">
            <div style="position: relative; height: 100%;">
                <p class="textbold">Lịch tư vấn trực tiếp</p>
                <p class="textFree">Miễn phí từ</p>
                <p class="timeStroke">10h30 - 13h30</p>
                <p class="allDay">Tất cả các ngày, trừ CN</p>
                <a href="javascript:;" onclick="showAAAA();">
                    <p class="allDay" style="font-weight: normal;">(Chi tiết)</p>
                </a>
                <p class="tuvantructuyen">Tư vấn online </p>
            </div>
        </div>
    </div>
    <div id="bgSubjectParent" class="bgSectionParent"></div>
    <div class="bgModule">
        <div class="inner" style="height: 100%;">
            <div class="bgsubject bgA">
                <h2>Chủ đề
                </h2>
            </div>
        </div>
    </div>
    <div class="inner">
        <div class="subjectContent">
            <div class="contentModule">
                <%
                    System.Data.DataTable GetSubject = dbGetTop5Subject();
                    for (int i = 0; i < GetSubject.Rows.Count; i++)
                    {
                        string _name = GetSubject.Rows[i]["NAME"].ToString();
                        string _image = GetSubject.Rows[i]["IMAGE"].ToString();
                        string _id = GetSubject.Rows[i]["ID"].ToString();
                        string _className = "";
                        string _isHot = GetSubject.Rows[i]["isHot"].ToString();
                        if (_isHot == "1")
                        {
                            _className = "subjectMail";
                        }

                        string _styleCaptionPadding = "";
                        if ((i + 1) % 2 == 0)
                        {
                            _styleCaptionPadding = "style='background-color:#b0b0b0;'";
                        }
                        else
                        {
                            _styleCaptionPadding = "style='background-color: rgb(221, 221, 221);'";
                        }                                                    
                %>
                <div class="item-content-module <%=_className %>">
                    <div class="iconBackground">
                        <div style="background-image: url('images/subject/<%=_image%>')" class="iconIg"></div>
                    </div>
                    <%
                        if (i < GetSubject.Rows.Count - 1)
                        {                            
                    %>
                    <div class="bgShadowLayer"></div>
                    <%
                        }
                    %>
                    <div class="captionPadding caption<%=i+1 %>" <%=_styleCaptionPadding %>>
                        <a href="dien-dan/<%=Lib.LocDau(_name) %>-s<%=_id %>.htm"><%=_name %></a>
                    </div>
                </div>
                <%
                    }
                %>
            </div>
        </div>
    </div>
</section>

<section id="new_share" class="sectionElement">
    <div id="bgnew_shareParent" class="bgSectionParent"></div>
    <div class="bgModule">
        <div class="inner" style="height: 100%;">
            <div class="bgNewShare bgA">
                <h2>Chia sẻ mới nhất
                </h2>
            </div>
        </div>
    </div>
    <div class="inner">
        <div class="subjectContent">
            <div class="contentModule">
                <div id="share-Left">
                    <%
                        CommentForum objComment = new CommentForum();
                        System.Data.DataTable dbTa1 = dbGetTop3Forum();
                        for (int i = 0; i < dbTa1.Rows.Count; i++)
                        {
                            string _avatar = dbTa1.Rows[i]["AVARTA"].ToString();
                            string _CustomerName = dbTa1.Rows[i]["CUSTOMER_NAME"].ToString();
                            int _age = 15;
                            try
                            {
                                _age = DateTime.Now.Year - Convert.ToDateTime(dbTa1.Rows[i]["DOB"].ToString()).Year;
                            }
                            catch
                            {
                                _age = 15;
                            }
                            string _articleContent = Lib.CutString(dbTa1.Rows[i]["Article_Content"].ToString(), 250);
                            string SubjectName = dbTa1.Rows[i]["NAME"].ToString();
                            string _ArticleName = dbTa1.Rows[i]["Article_Name"].ToString();
                            string _created = "";
                            try
                            {
                                _created = Convert.ToDateTime(dbTa1.Rows[i]["Created_Date"].ToString()).ToString("dd/MM/yyyy");
                            }
                            catch
                            {
                            }

                            string id = dbTa1.Rows[i]["ID"].ToString();

                            int _count = 0;
                            try
                            {
                                System.Data.DataTable dbCountCommentForm = objComment.GetDataByForumID(Convert.ToInt32(id));
                                _count = dbCountCommentForm.Rows.Count;
                            }
                            catch
                            {
                                _count = 0;
                            }
                                
                                
                    %>
                    <div class="item-new-share">
                        <div class="item-new-share-avatar">
                            <p class="item-new-share-img">
                                <img src="<%=_avatar %>" alt="<%=_CustomerName %>" />
                            </p>
                            <p class="item-new-share-name"><%=_CustomerName %></p>
                            <p class="item-new-share-age"><%=_age %> tuổi</p>
                        </div>

                        <div class="item-new-shareR">
                            <div class="item-new-share-content">
                                <div class="bgSh">
                                </div>
                                <div class="bgShContent">
                                    <p class="contents-title"><%=SubjectName %></p>
                                    <p class="contentS">
                                        <%=_articleContent %>
                                    </p>
                                    <p class="p-rm">
                                        <a class="bgShContent-readMore" href="dien-dan/<%=Lib.LocDau(SubjectName) %>/<%=Lib.LocDau(_ArticleName) %>-td<%=id %>.htm">Xem thêm</a>
                                    </p>
                                </div>
                            </div>
                            <div class="item-new-share-view">
                                <div class="itv-lay">Comment: <span><%=_count %></span> </div>
                                <div class="itv-lay">Ngày viết: <span><%=_created %></span> </div>
                            </div>
                        </div>
                    </div>

                    <%
                        }
                    %>
                </div>
                <div id="share-Right">

                    <%
                        if (!string.IsNullOrEmpty(Session["email"].ToString()))
                        {                            
                    %>

                    <div class="item-new-share-avatar">
                        <p class="item-new-share-img">
                            <img src="<%=Customer_avatar %>" alt="<%=_customerName %>" />
                        </p>
                    </div>
                    <div class="bgmtr"></div>
                    <div class="item-new-share-myStories">
                        <div class="item-new-share-myStories">

                            <p class="item-new-share-myStories-cont">
                                Đây là câu chuyện của tôi...
                            </p>
                        </div>
                        <div style="clear: both"></div>
                        <div class="p-rm">
                            <a class="bgShContent-readMore" href="<%= Lib.urlHome() %>/chia-se-cau-chuyen.htm">Chia sẻ câu chuyện của bạn</a>
                        </div>
                    </div>
                    <%
                        }
                    %>
                </div>
            </div>
        </div>
    </div>
</section>

<section id="box-intro">
    <div class="inner">
        <div style="width: calc(100% - 40px); padding: 20px;">
            <div id="titleBoxIntro">
                <h3>
                    <asp:Literal ID="Literal1" runat="server" />
                </h3>
            </div>
            <div id="date-boxIntro">
                <span class="date"><i class="icon-calendar-empty"></i><time datetime="6/11/2015 10:27:28 AM ">
                    <asp:Literal ID="ltDateTime" runat="server" />
                </time></span>
            </div>
            <div id="contentBoxIntro">
                <asp:Literal ID="ltBoxIntro" runat="server" />
            </div>
        </div>
    </div>
</section>


<section id="forum" class="sectionElement">
    <div id="bgForumParent" class="bgSectionParent"></div>
    <div class="bgModule">
        <div class="inner" style="height: 100%;">
            <div class="bgForum">
                <%System.Data.DataTable dbGetAlllSchool = GetAllSchool();
                  int _total = dbGetAlllSchool.Rows.Count;
                %>
                <h2>Tin tức trường học (<%=_total %>)
                </h2>
            </div>
        </div>
    </div>
    <div class="inner">
        <div class="subjectContent">
            <div class="contentModule">
                <div class="preview" valenum="0">
                </div>
                <div class="next" valenum="8">
                </div>

                <div id="wrapC">
                    <%
                        SchoolController objSchool = new SchoolController();
                        for (int i = 0; i < dbGetAlllSchool.Rows.Count; i++)
                        {
                            string _image = dbGetAlllSchool.Rows[i]["School_Image"].ToString();
                            string _name = dbGetAlllSchool.Rows[i]["School_Name"].ToString();
                            string _schoolID = dbGetAlllSchool.Rows[i]["ID"].ToString();
                            System.Data.DataTable dbSchool = objSchool.CoutNewsInSchool(Convert.ToInt32(_schoolID));
                            int count = Convert.ToInt32(dbSchool.Rows[0]["Total"].ToString());                            
                    %>
                    <div class="item-content-forum">
                        <%
                            if (count > 0)
                            {                                                           
                        %>
                        <span class="count_comment"><%=count %></span>
                        <%
                            }
                        %>
                        <figure>
                            <img src="images/schools/<%=_image %>" alt="<%=_name %>" />
                        </figure>
                        <figcaption>
                            <a href="<%=Lib.LocDau(_name) %>-ns<%=_schoolID %>.htm"><%=_name %></a>
                        </figcaption>
                    </div>
                    <%
                        }
                    %>
                </div>
            </div>
        </div>
    </div>
</section>
<section id="accountOnline" class="sectionElement">
    <div id="bgAccOnlineParent" class="bgSectionParent"></div>
    <div class="bgModule">
        <div class="inner" style="height: 100%;">
            <div class="bgAccOnline">
                <h2>Tài khoản đang online
                </h2>
            </div>
        </div>
    </div>
    <div class="inner">
        <div class="subjectContent">
            <div class="contentModule">

                <%                        
                    System.Data.DataTable dbCustOnline = dbGetTopOnline();
                    for (int i = 0; i < dbCustOnline.Rows.Count; i++)
                    {
                        string _avatar = dbCustOnline.Rows[i]["AVARTA"].ToString();
                        string _name = dbCustOnline.Rows[i]["CUSTOMER_NAME"].ToString();
                        string schoolID = dbCustOnline.Rows[i]["SCHOOL_ID"].ToString();
                        string _imageSchool = "";
                        if (schoolID != "" && schoolID != "-99")
                        {
                            System.Data.DataTable dbSchool = objSchool.GetDataByID(Convert.ToInt32(schoolID));
                            if (dbSchool.Rows.Count > 0)
                            {
                                _imageSchool = dbSchool.Rows[0]["School_Image"].ToString();
                            }
                        }
                %>

                <div class="item-content-AccOnline <%= i%2==0?"":"noMargin" %>">
                    <figure>
                        <span class="bgSchoolO" style="background-image: url('images/schools/<%=_imageSchool%>');"></span>
                        <a href="#">
                            <img src="<%=Lib.urlHome() %>/cat-anh.htm?url=<%=_avatar %>&width=105&height=105" alt="<%=_name %>" />

                        </a>
                    </figure>
                </div>
                <%
                    }
                %>
            </div>
        </div>
    </div>
</section>
