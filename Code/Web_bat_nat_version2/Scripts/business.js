

function cutstring(str, ilength) {
    var strCut = "";
    var strFinish = "";

    if (str.length > ilength) {
        strCut = str.substring(0, ilength);
        var arr = strCut.split(' ');

        for (var i = 0; i < arr.length - 1; i++) {
            strFinish += arr[i] + " ";
        }

        strFinish = strFinish + " ...";
    }
    else {
        strFinish = str;
    }
    return strFinish;
}


function removeclass(id, cl) {
    $("#" + id).removeClass(cl);
}

function addclass(id, cl) {
    var av = document.getElementById(id);
    if (av.value == "Nhập thông tin vào đây") {
        $("#" + id).addClass(cl);
    }
}
function formatDate(value) {
    return value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getYear();
}

function locdau(str) {
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/“/g, "");
    str = str.replace(/”/g, "");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-");
    /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
    str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1- 
    str = str.replace(/^\-+|\-+$/g, "");
    //cắt bỏ ký tự - ở đầu và cuối chuỗi  
    return str;
}



function onchtd(id) {
    var dd = document.getElementById(id);
    if (dd.value == "Nhập nội dung mà bạn muốn gửi đến người ấy") {
        dd.value = "";
        jQuery("#" + id).addClass('addgiftclass');
    }
}
function onbhtd(id) {
    var dd = document.getElementById(id);
    if (dd.value == "") {
        dd.value = "Nhập nội dung mà bạn muốn gửi đến người ấy";
        jQuery("#" + id).removeClass("addgiftclass");
    }
}


function hentocdostep(step, url) {
    jQuery.ajax({
        type: "GET",
        url: "ashx/session.ashx?step=" + step,
        sync: true,
        datatype: "Json",
        success: function (XmlData) {
            if (XmlData == "true") {
                document.location.href = url;
            }
        }
    })
}