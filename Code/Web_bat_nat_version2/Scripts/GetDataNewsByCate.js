GetDataNewsByCate = {
    // lay du lieu tin tuc su kien
    getnews: function (CATEGORYID, numberitem, iSelect) {


        //setTimeout(function () {
        //    $('html,body').animate({
        //        scrollTop: 200
        //    }, 'slow')
        //}, 1000);




        var from = parseInt(iSelect - 1) * numberitem + 1;
        var to = parseInt(iSelect) * numberitem;

        $.ajax({
            type: "GET",
            url: "../ashx/GetDataNewsByCate.ashx?from=" + from + "&to=" + to + "&CATEGORYID=" + CATEGORYID,
            sync: true,
            datatype: "XML",
            success: function (XmlData) {

                var Xml = XmlData;
                var htm = "";
                var iCount = $(Xml).find("Row").length;

                var iTotalItem = $(Xml).find("Row[id ='" + 0 + "']").find("RecordsTotal").text();
                if (iTotalItem == '') {
                    iTotalItem = 0;
                    $('#list_news').html('Hiện tại danh mục đang được cập nhật. Mời bạn quay lại sau.');
                }
                else {

                    for (var i = 0; i < iCount; i++) {
                        var id = $.trim($(Xml).find("Row[id ='" + i + "']").find("ID").text());
                        var CategoryName = $.trim($(Xml).find("Row[id ='" + i + "']").find("CATEGORYNAME").text());
                        var title = $(Xml).find("Row[id ='" + i + "']").find("TITLE").text();
                        var image = $(Xml).find("Row[id ='" + i + "']").find("IMAGE").text();
                        var summury = $(Xml).find("Row[id ='" + i + "']").find("SUMMARY").text();
                        var _createDate = $(Xml).find("Row[id ='" + i + "']").find("CREATED_DATE").text();
                        var contentcut = cutstring(summury, 250);
                        console.log(CategoryName);
                        if (i == 0) {

                            htm += '<article id="news-recent" class="news-post">';
                            htm += '<img width="720" height="540"  src="http://ask14.vn/images/news/' + image + '" alt="' + title + '" />';
                            htm += '<div class="news-recent-info">';
                            htm += '<a href="' + (CategoryName != "quiz" ? locdau(title) + '-c' + CATEGORYID + '-n' + id : '../quiz-' + locdau(title) + '-' + id) + '.htm">';
                            htm += '<p class="sub-title">' + title + '</p>';
                            htm += '</a>';
                            htm += '<div class="entry-meta">';
                            htm += '<span class="date">';
                            htm += '<i class="icon-calendar-empty"></i>';
                            htm += '<time datetime="' + _createDate + '">' + _createDate + '</time>';
                            htm += '</span>';
                            htm += '</div>';
                            htm += '<div class="entry-info">';
                            htm += '' + contentcut + '';
                            htm += '</div>';

                            htm += '<a href="' + (CategoryName != "quiz" ? locdau(title) + '-c' + CATEGORYID + '-n' + id : '../quiz-' + locdau(title) + '-' + id) + '.htm" class="read-more blue-button" id="readMoreHot">Đọc tiếp ...</a>';

                            htm += '</div>';
                            htm += '</article>';
                        } else {
                            htm += '<article class="news-post news-post-child">';
                            htm += '<header class="entry-header two_fifth">';
                            htm += '<div class="blog-thumb">';
                            htm += '<a href="' + (CategoryName != "quiz" ? locdau(title) + '-c' + CATEGORYID + '-n' + id : '../quiz-' + locdau(title) + '-' + id) + '.htm">';
                            htm += '<img width="400" height="300" alt="' + title + '" class="attachment-column2-3/4 wp-post-image" src="http://ask14.vn/images/news/' + image + '"></a>';
                            htm += '</div>';
                            htm += '</header>';
                            htm += '<div class="entry-content three_fifth entry-right">';
                            htm += '<a href="' + (CategoryName != "quiz" ? locdau(title) + '-c' + CATEGORYID + '-n' + id : '../quiz-' + locdau(title) + '-' + id) + '.htm">';
                            htm += '<p class="sub-title">' + title + '</p>';
                            htm += '</a>';
                            htm += '<div class="entry-meta">';
                            htm += '<span class="date">';
                            htm += '<i class="icon-calendar-empty"></i>';
                            htm += '<time datetime="' + _createDate + '">' + _createDate + '</time>';
                            htm += '</span>';
                            htm += '</div>';
                            htm += '<div class="entry-info">' + contentcut + '</div>';

                            htm += '<a href="' + (CategoryName != "quiz" ? locdau(title) + '-c' + CATEGORYID + '-n' + id : '../quiz-' + locdau(title) + '-' + id) + '.htm" class="read-more blue-button" id="readMoreHot">Đọc tiếp ...</a>';
                            htm += '</div>';
                            htm += '<div style="clear: both"></div>';
                            htm += '</article>';
                        }
                    }

                    $('#list_news').html(htm);

                    var htmPaging = "";
                    if (iTotalItem > numberitem) {

                        htmPaging = LT_DrawPaging(iSelect, numberitem, iTotalItem, "GetDataNewsByCate.getnews(" + CATEGORYID + "," + numberitem + ",");
                        $('#pagging').html(htmPaging);
                        $('#pagging').show();
                    }
                    setTimeout(function () {
                        $('html,body').animate({
                            scrollTop: 140
                        }, 'slow')
                    }, 1000);
                }
            }
        })
    }
};