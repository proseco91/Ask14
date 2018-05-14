video = {
    // lay du lieu tin tuc su kien
    getVideo: function (numberitem, iSelect) {


        var from = parseInt(iSelect - 1) * numberitem + 1;
        var to = parseInt(iSelect) * numberitem;

        $.ajax({
            type: "GET",
            url: "ashx/video.ashx?from=" + from + "&to=" + to,
            sync: true,
            datatype: "XML",
            success: function (XmlData) {

                var Xml = XmlData;
                var htm = "";
                var iCount = $(Xml).find("Row").length;

                var iTotalItem = $(Xml).find("Row[id ='" + 0 + "']").find("RecordsTotal").text();
                if (iTotalItem == '')
                    iTotalItem = 0;

                for (var i = 0; i < iCount; i++) {
                    var VIDEO_ID = $(Xml).find("Row[id ='" + i + "']").find("VIDEO_ID").text().trim();
                    var NAME = $(Xml).find("Row[id ='" + i + "']").find("NAME").text().trim();
                    var ID_YOUTUBE = $(Xml).find("Row[id ='" + i + "']").find("LINK_YOUTUBE").text();
                    ID_YOUTUBE = ID_YOUTUBE.split('/').slice(-1)[0].trim();
                    var SUMMURY = $(Xml).find("Row[id ='" + i + "']").find("SUMMURY").text();
                    var contentcut = cutstring(SUMMURY, 250);

                    htm += '<div class="itemNews">';
                    htm += '<div class="itemNewsImg">';
                    htm += '<a href="video/' + locdau(NAME) + '-v' + VIDEO_ID + '.htm">';
                    htm += '<img src="http://todayenglish.edu.vn/cat-anh.htm?url=http://img.youtube.com/vi/' + ID_YOUTUBE + '/0.jpg&width=300&height=170" alt="' + NAME + '" />';
                    htm += '</a>';
                    htm += '</div>';
                    htm += '<div class="itemNewsSum">';
                    htm += '<p class="itemNewsSumTitle">';
                    htm += '<a href="video/' + locdau(NAME) + '-v' + VIDEO_ID + '.htm">' + NAME + '</a>';
                    htm += '</p>';
                    htm += '<p class="item-news-summury">' + contentcut + '</p>';
                    htm += '<p class="readmore btn">';
                    htm += '<a href="video/' + locdau(NAME) + '-v' + VIDEO_ID + '.htm">Chi tiết »</a>';
                    htm += '</p>';
                    htm += '</div>';
                    htm += '</div>';
                }

                $('#ContentNews').html(htm);

                var htmPaging = "";
                if (iTotalItem > numberitem) {

                    htmPaging = LT_DrawPaging(iSelect, numberitem, iTotalItem, "GetDataNewsByCate.getnews(" + numberitem + ",");
                    $('#pagging').html(htmPaging);
                    $('#pagging').show();
                }
            }
        })
    }
};