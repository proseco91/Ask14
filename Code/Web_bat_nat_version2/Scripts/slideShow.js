var indexSelect = 0;
var timeSlide = setInterval(function () { }, 0);
var clickBtnSlide;
function slideSwitchNew() {
    var _index = indexSelect + 1;
    if ($('#slides_container_testimonial .slide-item').size() - 1 == indexSelect) {
        _index = 0;
    }
    actionSlide(_index);
}

function actionSlide(_index) {
    if (_index > indexSelect) {
        $('#slides_container_testimonial .slide-item').eq(_index).css({ 'margin-left': '800px', 'display': 'block' });
        //                $('#slides_container_testimonial').stop().animate({ 'margin-left': '-100px' }, 500, function () {
        $('#slides_container_testimonial').animate({ 'margin-left': '-800px' }, 300, function () {
            $('#slides_container_testimonial .slide-item').eq(indexSelect).css({ 'margin-left': '0px', 'display': 'none' });
            $('#slides_container_testimonial .slide-item').eq(_index).css({ 'margin-left': '0px', 'display': 'block' });
            $('#slides_container_testimonial').css({ 'margin-left': '0px' });
            indexSelect = _index;
            for (var i = 0; i < clickBtnSlide.size(); i++) {
                if (i == _index) {
                    clickBtnSlide.eq(i).removeClass('btnClickSlide_testimonial').addClass('btnClickSlide_testimonial_Select');
                } else {
                    clickBtnSlide.eq(i).removeClass('btnClickSlide_testimonial_Select').addClass('btnClickSlide_testimonial');
                }
            }
            //                    });
        });

    } else if (_index < indexSelect) {
        $('#slides_container_testimonial .slide-item').eq(_index).css({ 'margin-left': '-800px', 'display': 'block' });
        //                $('#slides_container_testimonial').stop().animate({ 'margin-left': '100px' }, 500, function () {
        $('#slides_container_testimonial').animate({ 'margin-left': '800px' }, 300, function () {
            $('#slides_container_testimonial .slide-item').eq(indexSelect).css({ 'margin-left': '0px', 'display': 'none' });
            $('#slides_container_testimonial .slide-item').eq(_index).css({ 'margin-left': '0px', 'display': 'block' });
            $('#slides_container_testimonial').css({ 'margin-left': '0px' });
            indexSelect = _index;
            for (var i = 0; i < clickBtnSlide.size(); i++) {
                if (i == _index) {
                    clickBtnSlide.eq(i).removeClass('btnClickSlide_testimonial').addClass('btnClickSlide_testimonial_Select');
                } else {
                    clickBtnSlide.eq(i).removeClass('btnClickSlide_testimonial_Select').addClass('btnClickSlide_testimonial');
                }
            }
            //                    });
        });
    }
}
$(function () {
    clickBtnSlide = $('#btnSlide_testimonial div span');
    if (clickBtnSlide.size() > 0) {
        clickBtnSlide.eq(0).removeClass('btnClickSlide_testimonial').addClass('btnClickSlide_testimonial_Select');
        clickBtnSlide.click(function () {
            var _index = clickBtnSlide.index($(this));
            clearInterval(timeSlide);
            actionSlide(_index);
            //                    timeSlide = setInterval("slideSwitchNew()", 5000);
        });
    }
    $('#slides_container_testimonial .slide-item').eq(0).css({ 'display': 'block' });
    //            timeSlide = setInterval("slideSwitchNew()", 5000);
});