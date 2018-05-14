
$(document).ready(function () {
    $('.btnClickLogInDangNhap').click(function () {
        if (thisConnect != '') {

            var _popUpLogin = $(this).attr('valL');

            //KIểm tra xem đã đăng nhập chưa? Nếu chưa đăng nhập thì hiển thị popup đăng nhập? Đã đăng nhập hiển thị popup thông tin cá nhân

            if (_popUpLogin == 1) {
                var _html = "<div class='item-wrap'>";
                _html += "<div class='itemM itemTuVan'><a class='info-person'>Thông tin cá nhân</a></div>";
                _html += "<div class='itemM itemTuVan'><a class='info-person'>Lịch sử CHAT</a></div>";
                _html += "<div class='itemM itemTuVan'><a href='lich-su-comment.htm'>Lịch sử COMMENT</a></div>";
                _html += "<div class='itemM itemTuVan'><a class='school_up'>Cập nhật trường học</a></div>";
                _html += "</div>";
                popUpNew(true, true, _html);
            } else {
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
            }

        } else {
            $('.btnClickLogInDangNhap').parent('.dropdown').addClass('loading-datlich');
            clearInterval(window["timeout_titledangnhap"]);
            window["timeout_titledangnhap"] = setInterval(function () {
                if (thisConnect != '') {
                    $('.btnClickLogInDangNhap').click();
                    clearInterval(window["timeout_titledangnhap"]);
                    $('.btnClickLogInDangNhap').parent('.dropdown').removeClass('loading-datlich');
                }
            }, 1000);
        }
    });
});
var even_megasage = function (e) {
    try {
        var eReturn = JSONfn.parse(e.data);
        if (eReturn.nameevent == 'returnlogin_megasage') {
            var use_login_send = JSONfn.parse(eReturn.usereturn);
            //console.log(emailLogin);
            //console.log(use_login_send.email);
            if (use_login_send.email != emailLogin) {

                location.href = location.href;
            }

            $('.logout').attr('href', 'http://ask14.vn/dang-xuat.htm?Connect=' + thisConnect + '&token=' + idWeb + '&guid=' + guid_id_ran_linktam);

        }
    } catch (e) {

    }
}
window.addEventListener('message', even_megasage, false);
