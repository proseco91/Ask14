LichSuComment = {
    // lay du lieu tin tuc su kien
    GetDataByComment: function (customerID, numberitem, iSelect) {


        //setTimeout(function () {
        //    $('html,body').animate({
        //        scrollTop: 200
        //    }, 'slow')
        //}, 1000);




        var from = parseInt(iSelect - 1) * numberitem + 1;
        var to = parseInt(iSelect) * numberitem;

        $.ajax({
            type: "GET",
            url: "ashx/HistoryComment.ashx?from=" + from + "&to=" + to + "&customerID=" + customerID,
            sync: true,
            datatype: "XML",
            success: function (XmlData) {

                var Xml = XmlData;
                var htm = "";
                var iCount = $(Xml).find("Row").length;

                var iTotalItem = $(Xml).find("Row[id ='" + 0 + "']").find("RecordsTotal").text();
                if (iTotalItem == '') {
                    iTotalItem = 0;
                    $('#list_news').html('Bạn chưa comment bài viết nào.');
                }
                else {

                    for (var i = 0; i < iCount; i++) {
                        var id = $(Xml).find("Row[id ='" + i + "']").find("ID").text();
                        var SubjectID = $(Xml).find("Row[id ='" + i + "']").find("SubjectID").text();
                        var CUSTOMER_NAME = $(Xml).find("Row[id ='" + i + "']").find("CUSTOMER_NAME").text();
                        var Age = $(Xml).find("Row[id ='" + i + "']").find("Age").text();
                        var Avatar = $(Xml).find("Row[id ='" + i + "']").find("Avatar").text();
                        var Article_Name = $(Xml).find("Row[id ='" + i + "']").find("Article_Name").text();
                        var Article_Content = $(Xml).find("Row[id ='" + i + "']").find("Article_Content").text();

                        var SubjectName = $(Xml).find("Row[id ='" + i + "']").find("SubjectName").text();
                        var Created_Date = $(Xml).find("Row[id ='" + i + "']").find("Created_Date").text();
                        var contentcut = cutstring(Article_Content, 250);
                        var COUNTCOMMENT = $(Xml).find("Row[id ='" + i + "']").find("COUNTCOMMENT").text();

                        htm += '<div class="item-new-share">';
                        htm += '<div class="item-new-share-avatar">';
                        htm += '<p class="item-new-share-img">';
                        htm += '<img src="' + Avatar + '" alt="' + CUSTOMER_NAME + '" />';
                        htm += '</p>';
                        htm += '<p class="item-new-share-name">' + CUSTOMER_NAME + '</p>';
                        htm += '<p class="item-new-share-age">' + Age + ' tuổi</p>';
                        htm += '</div>';
                        htm += '<div class="item-new-shareR">';
                        htm += '<div class="item-new-share-content">';
                        htm += '<div class="bgSh">';
                        htm += '</div>';
                        htm += '<div class="bgShContent">';
                        htm += '<p class="contentS">' + contentcut + '</p>';
                        htm += '<p class="p-rm">';
                        htm += '<a class="bgShContent-readMore" href="../dien-dan/' + locdau(SubjectName) + '/' + locdau(Article_Name) + '-td' + id + '.htm">Xem thêm</a>';
                        htm += '</p>';
                        htm += '</div>';
                        htm += '</div>';
                        htm += '<div class="item-new-share-view">';
                        htm += '<div class="itv-lay">Comment: <span>' + COUNTCOMMENT + '</span> </div>';
                        htm += '<div class="itv-lay">Ngày viết: <span>' + Created_Date + '</span> </div>';
                        htm += '</div>';
                        htm += '</div>';
                        htm += '</div>';
                    }

                    $('#list_news').html(htm);

                    var htmPaging = "";
                    if (iTotalItem > numberitem) {

                        htmPaging = LT_DrawPaging(iSelect, numberitem, iTotalItem, "LichSuComment.GetDataByComment(" + SubjectID + "," + numberitem + ",");
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