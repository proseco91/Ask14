GetDataFAQ = {
    // lay du lieu tin tuc su kien
    getByFAQ: function (numberitem, iSelect) {


        //setTimeout(function () {
        //    $('html,body').animate({
        //        scrollTop: 200
        //    }, 'slow')
        //}, 1000);




        var from = parseInt(iSelect - 1) * numberitem + 1;
        var to = parseInt(iSelect) * numberitem;

        $.ajax({
            type: "GET",
            url: "ashx/GetFAQ.ashx?from=" + from + "&to=" + to,
            sync: true,
            datatype: "XML",
            success: function (XmlData) {

                var Xml = XmlData;
                var htm = "";
                var iCount = $(Xml).find("Row").length;

                var iTotalItem = $(Xml).find("Row[id ='" + 0 + "']").find("RecordsTotal").text();
                if (iTotalItem == '') {
                    iTotalItem = 0;
                    $('#list_FAQ').html('Hiện tại danh mục đang được cập nhật. Mời bạn quay lại sau.');
                }
                else {

                    for (var i = 0; i < iCount; i++) {
                        var id = $(Xml).find("Row[id ='" + i + "']").find("ID").text();


                        var DESCRIPTION = $(Xml).find("Row[id ='" + i + "']").find("DESCRIPTION").text();
                        var ANSWER = $(Xml).find("Row[id ='" + i + "']").find("ANSWER").text();
                        var Created_Date = $(Xml).find("Row[id ='" + i + "']").find("CREATED_DATE").text();



                        htm += '<article class="itemFAQ">';
                        htm += '<div class="itemFAQ-image">';
                        htm += '<img src="images/AdminS.jpg" alt="admin" />';
                        htm += '</div>';
                        htm += '<div class="itemFAQ-contentQ">';
                        htm += '<p class="itemSP"><span> Câu hỏi</span></p>';
                        htm += '<p class="itemFAQ-name"><span></span></p>';
                        htm += '<span class="date">';
                        htm += '<i class="icon-calendar-empty"></i>';
                        htm += '<time datetime="2015-05-09T20:39:30+00:00">' + Created_Date + '</time>';
                        htm += '</span>';
                        htm += '<p class="itemFAQ-desc">' + DESCRIPTION + '</p>';
                        htm += '</div>';
                        htm += '</article>';
                        htm += '<article class="itemAnswer">';
                        htm += '<div class="itemFAQ-image">';
                        htm += '<img src="" alt="" />';
                        htm += '</div>';
                        htm += '<div class="itemFAQ-contentQ">';
                        htm += '<p class="itemSP">';
                        htm += '<span>Trả lời</span>';
                        htm += '</p>';
                        htm += '<p class="itemFAQ-name"></p>';
                        htm += '<p class="itemFAQ-desc">' + ANSWER + '</p>';
                        htm += '</div>';
                        htm += '</article>';
                    }

                    $('#list_FAQ').html(htm);

                    var htmPaging = "";
                    if (iTotalItem > numberitem) {

                        htmPaging = LT_DrawPaging(iSelect, numberitem, iTotalItem, "GetDataFAQ.getByFAQ(" + numberitem + ",");
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