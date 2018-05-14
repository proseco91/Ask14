var clearTimePopup = setInterval(function () { }, 1000);
function popUpNew(status, isClickClose, _html) {
    if (!status) {
        clearInterval(clearTimePopup);
        $('.popupThongBaoLongin').fadeOut(300);
        $('.popupThongBaoLonginContentTitle').children('.popupThongBaoLonginContentBack').css('display', 'none');
    } else {
        $('.popupThongBaoLonginContentContent').removeAttr('style').html(_html);

        var docWidthNew = $(window).width();
        var docHeightNew = $(window).height();
        $('.popupThongBaoLongin').fadeIn(300);
        clearInterval(clearTimePopup);
        clearTimePopup = setInterval(function () {
            docWidthNew = $(window).width();
            docHeightNew = $(window).height();
            $('.popupThongBaoLonginContent').css({ 'top': (docHeightNew / 2 - ($('.popupThongBaoLonginContent').outerHeight() / 2)) + 'px', 'left': (docWidthNew / 2 - ($('.popupThongBaoLonginContent').outerWidth() / 2)) + 'px' });
        }, 300);
        if (isClickClose) {
            $('.popupThongBaoLonginBg').click(function () {
                popUpNew(false, false, "");
            });
        } else {
            $('.popupThongBaoLonginBg').unbind("click");
        }

        $('.info-person').click(function () {
            popUpNew(false, false, "");
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
        });

        $('.school_up').click(function () {
            popUpNew(false, false, "");
            popup('popUpDiv');
            $('#blanket').click(function () {
                //$('#popUpDiv').css('display', 'none');
                //$(this).css('display', 'none');
                popup('popUpDiv');
            });
            //var htm = '<iframe scrolling="no" title="" src="http://ask14.vn/cap-nhat-truong-hoc.htm" frameborder="0"></iframe>';


            //if ($('.linktam_panel_login_data_none').size() > 0) {
            //    var objEvent = {
            //        nameevent: 'getheight',
            //        element: '#ifreame_login_new',
            //        width: $('.linktam_panel_login_data').width()
            //    }
            //    $('.linktam_panel_login_data').attr('valclick', 0).children('#ifreame_login_new').css({ 'width': (objEvent.width) + 'px' });
            //    document.getElementById("ifreame_login_new").contentWindow.postMessage(JSONfn.stringify(objEvent), "*");
            //    setTimeout(function () {
            //        $('.linktam_panel_login_data').removeClass('linktam_panel_login_data_none');
            //    }, 50);
            //}
        });

    }
}


