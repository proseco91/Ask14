(function ($) {
    $.fn.startRotate = function (number) {
        var oldRote = this.attr('valRote');
        if (typeof oldRote == 'undefined')
            oldRote = 0;
        oldRote = parseInt(oldRote);
        this.css({ 'transform': 'rotate(' + (oldRote + number) + 'deg)', '-webkit-transform': 'rotate(' + (oldRote + number) + 'deg)', '-ms-transform': 'rotate(' + (oldRote + number) + 'deg)' }).attr('valRote', (oldRote + number));

    };
    $.fn.stopRotate = function () {
        var oldRote = this.attr('valRote');
        if (typeof oldRote == 'undefined')
            oldRote = 0;
        oldRote = parseInt(oldRote);
        this.css({ 'transform': 'rotate(' + (oldRote + 360) + 'deg)', '-webkit-transform': 'rotate(' + (oldRote + 360) + 'deg)', '-ms-transform': 'rotate(' + (oldRote + 360) + 'deg)' }).attr('valRote', (oldRote + 360));
    };
    $.fn.startOpacity = function (sleep) {
        var _this = this;
        var _trueFalse = true;
        var id_identity = _this.attr('identity');
        if (typeof id_identity == 'undefined') {
            var exitCreateIdentity = false;
            while (!exitCreateIdentity) {
                var nameIdentity = Math.floor((Math.random() * 1000) + 1) + "_" + Math.floor((Math.random() * 1000) + 1) + "_" + Math.floor((Math.random() * 1000) + 1);
                if ($('*[identity="' + nameIdentity + '"]').size() <= 0) {
                    id_identity = nameIdentity;
                    exitCreateIdentity = true;
                }
            }
            if (typeof window[id_identity] == 'undefined') {
                window[id_identity] = setInterval(function () { }, 1000);
                clearInterval(window[id_identity]);
                _this.attr('identity', id_identity);
            }
        }
        _this.css({ 'transition': 'opacity ' + sleep + 's ease-out 0s', 'opacity': '1' });
        clearInterval(window[id_identity]);
        window[id_identity] = setInterval(function () {
            if (_trueFalse) {
                _this.css({ 'opacity': '1' });
                _trueFalse = false;
            } else {
                _this.css({ 'opacity': '0' });
                _trueFalse = true;
            }
        }, sleep * 1000);
    };
    $.fn.stopOpacity = function (opacity) {
        var _this = this;
        var id_identity = _this.attr('identity');
        if (typeof id_identity != 'undefined') {
            if (typeof window[id_identity] != 'undefined') {
                clearInterval(window[id_identity]);
                delete window[id_identity];
            }
            _this.removeAttr('identity');
        }
        _this.css({ 'opacity': opacity });
    };

    $.fn.setCursorPosition = function (pos) {
        this.each(function (index, elem) {
            if (elem.setSelectionRange) {
                elem.setSelectionRange(pos, pos);
            } else if (elem.createTextRange) {
                var range = elem.createTextRange();
                range.collapse(true);
                range.moveEnd('character', pos);
                range.moveStart('character', pos);
                range.select();
            }
        });
        return this;
    };
    $.fn.getCursorPosition = function () {
        var input = this.get(0);
        if (!input) return; // No (input) element found
        if ('selectionStart' in input) {
            // Standard-compliant browsers
            return input.selectionStart;
        } else if (document.selection) {
            // IE
            input.focus();
            var sel = document.selection.createRange();
            var selLen = document.selection.createRange().text.length;
            sel.moveStart('character', -input.value.length);
            return sel.text.length - selLen;
        }
    }
    $.fn.addTextCursorPosition = function (txt) {
        var input = this;
        var _textOld = input.val();
        var _indexCus = input.getCursorPosition();
        input.val(_textOld.substring(0, _indexCus) + txt + _textOld.substring(_indexCus));
        return _indexCus;
    }
    $.fn.offsetRelative = function (top) {
        var $this = $(this);
        var $parent = $this.offsetParent();
        var offset = $this.position();
        if (!top) return offset; // Didn't pass a 'top' element
        else if ($parent.get(0).tagName == "BODY") return offset; // Reached top of document
        else if ($(top, $parent).length) return offset; // Parent element contains the 'top' element we want the offset to be relative to
        else if ($parent[0] == $(top)[0]) return offset; // Reached the 'top' element we want the offset to be relative to
        else { // Get parent's relative offset
            var parent_offset = $parent.offsetRelative(top);
            offset.top += parent_offset.top;
            offset.left += parent_offset.left;
            return offset;
        }
    };
    $.fn.positionRelative = function (top) {
        return $(this).offsetRelative(top);
    };
    $.fn.loadingbar = function (number, remove) {
        var _this = this;
        if (number == -1) {
            number = Math.floor((Math.random() * 50) + 1);
        }
        if (_this.children('.loadingBarCrazyPt').size() <= 0) {
            _this.append('<div class="loadingBarCrazyPt"></div>');
        }
        if (number == 0) {
            _this.children('.loadingBarCrazyPt').css({ 'transition': 'width 0s ease-out 0s', 'width': number + '%' });
        } else if (number == 100) {
            _this.children('.loadingBarCrazyPt').css({ 'transition': 'width 0.5s ease-out 0s', 'width': number + '%' });
            if (remove)
                setTimeout(function () { _this.loadingbar(0); }, 500);
        } else {
            _this.children('.loadingBarCrazyPt').css({ 'transition': 'width 0.5s ease-out 0s', 'width': number + '%' });
        }
        return number;
    };

}(jQuery));


var arayColor = new Array();
arayColor[0] = "56bd86";
arayColor[1] = "0b80c1";
arayColor[2] = "e44b4b";
arayColor[3] = "d8b032";
arayColor[4] = "736170";
arayColor[5] = "75abdc";
arayColor[6] = "dc1c9f";
arayColor[7] = "546283";
arayColor[8] = "465eb3";
arayColor[9] = "3859e3";
arayColor[10] = "2a5515";
arayColor[11] = "1c5145";
arayColor[12] = "a2c1d0";
arayColor[13] = "94bd01";
arayColor[14] = "86b832";
arayColor[15] = "78b462";
arayColor[16] = "6ab092";
arayColor[17] = "e1f676";
arayColor[18] = "d2f1a6";
var timeResizeMatching;
var btnclickObjAAAA = false;



function check_all_question_da_lam(element) {
    var _parent = element.children('.contentListEx-itemparent-data');
    var _question = _parent.children('.contentListEx-itemparent-data-item');
    var countChuaLamXong = 0;
    var indexChuaLam = -1;
    _question.each(function (index) {
        if (!checkQuestionChuaLam($(this))) {
            _parent.find('span[attr-number-question]:eq(' + index + ')').attr('attr-number-question-err', '');
            countChuaLamXong++;
            indexChuaLam = index;
        } else {
            _parent.find('span[attr-number-question]:eq(' + index + ')').removeAttr('attr-number-question-err');
        }
    });
    if (countChuaLamXong > 0) {
        var _top = _question.eq(indexChuaLam).offset().top;
        $('html, body').animate({ "scrollTop": _top - 100 }, 300);
        return false;
    }
    return true;
}



$(document).ready(function () {
    $(document).click(function () {
        setTimeout(function () {
            var countChuaLamXong = 0;
            var _question = $('.contentListEx-itemparent-data-item');
            _question.each(function (index) {
                if (!checkQuestionChuaLam($(this)))
                    countChuaLamXong++;
            });
            $('.datatotalAAAAAAAAAAAA').text(countChuaLamXong + "/" + _question.size());
        }, 500);
    });
    $('a').on('click', function () {
        var href = $(this).attr('href');
        if (href.length > 0 && href.indexOf('javascript:') <= -1) {
            jConfirmLinkTam('Thông báo', '<div style="text-align:left;">Bạn chắc chắn muốn rời bỏ?</div>', "Vẫn ở trang này", "Rời bỏ", 350, function (status) {
                if (status) {
                    $.confirmLinkTam._close();
                } else {
                    $(window).unbind('beforeunload');
                    location.href = href;
                }
            });
            return false;
        }
    });

    //$(window).bind('beforeunload', function (event) {
    //    return "Bạn có chắc chắn muốn thoát khỏi trang này?";
    //});
    $('*[dis-mousedown="true"]').mousedown(function (event) {
        event.preventDefault();
    });
    $(window).scroll(function () {
        var sTop = $(window).scrollTop();
        var SSSS = $('.panelBox-NewLB-Time-Parent');
        if (SSSS.size() > 0) {
            if (sTop >= SSSS.offset().top) {
                var _paneEff = SSSS.addClass('panelBox-NewLB-Time-Parent-Show').find('.panelEFFRightInfo');
                _paneEff.addClass('panelBox-NewLB-Time-Fixed').css('top', (sTop - (SSSS.offset().top)) + 'px');
                if ((_paneEff.offsetRelative().top + _paneEff.height()) >= $('.panelInfoHocTap-Content').height())
                    _paneEff.addClass('panelBox-NewLB-Time-Fixed').css('top', ($('.panelInfoHocTap-Content').height() - _paneEff.height()) + 'px');
            } else {
                SSSS.removeClass('panelBox-NewLB-Time-Parent-Show').find('.panelEFFRightInfo').removeClass('panelBox-NewLB-Time-Fixed').css('top', '0px');
            }
        }
    }).scroll();
    createEvenParentLamBai();
    if (typeof disLoad == 'undefined') {
        eventKeoThaCau();
        eventDienCau();
        eventMatching();
        eventPhanLoai();
        eventChonCauDoan();
        eventImage();
    }
});
function createEvenParentLamBai() {
    var strucItemEx = $('.contentInfoLamBai-Ex .contentInfoLamBai-Ex-Item');
    var strucHiddel = $('.contentInfoLamBai-Ex-Hidden');
    var _width = 0;
    strucItemEx.each(function (index) {
        $(this).css('z-index', (strucItemEx.size() - index));
        _width += $(this).outerWidth();
        if (index == strucItemEx.size() - 1) {
            if (_width < strucHiddel.parent('.contentInfoLamBai-Ex').outerWidth()) {
                var _padingAdd = (strucHiddel.parent('.contentInfoLamBai-Ex').outerWidth() - _width) / (strucItemEx.size() * 2) - (20 / (strucItemEx.size() * 2));
                strucItemEx.css({ 'padding-left': '+=' + _padingAdd + 'px', 'padding-right': '+=' + _padingAdd + 'px' })
            }
        }
    });
    strucItemEx.mousedown(function (event) {
        event.preventDefault();
    });
    strucItemEx.click(function () {
        if (cbThuTuLam) {
            var eleePrev = $(this).prev('.contentInfoLamBai-Ex-Item');
            if (eleePrev.size() > 0) {
                var _index = $('.contentInfoLamBai-Ex-Item').index(eleePrev);
                var _paren = $('.contentListEx-itemparent:eq(' + _index + ')');
                if (!check_all_question_da_lam(_paren))
                    return;
            }
        }
        var _this = $(this);
        var ofset = _this.offsetRelative();
        var leftParent = parseInt($('.contentInfoLamBai-Ex-Hidden').css('left').replace("px", ""));
        var widthParent = $('.contentInfoLamBai-Ex').outerWidth();
        var leftNow = (ofset.left + leftParent);
        var leftCss = 0;
        var indexOld = strucItemEx.index(strucHiddel.find('.contentInfoLamBai-Ex-Item-Select'));
        var indexNow = strucItemEx.index(_this);
        if (indexOld != -1 && indexNow > indexOld) {
            var itemNext = _this.next('.contentInfoLamBai-Ex-Item');
            if (itemNext.size() > 0) {
                var ofsetChi = itemNext.offsetRelative();
                var leftChi = (ofsetChi.left + leftParent) + itemNext.outerWidth();
                if (leftChi >= widthParent) {
                    leftCss = leftChi;
                    var itemNextNew = itemNext.next('.contentInfoLamBai-Ex-Item');
                    if (itemNextNew.size() > 0) {
                        leftCss += (itemNextNew.outerWidth() / 2);
                    } else {
                        leftCss += 20;
                    }
                }
            } else {
                var ofsetChi = _this.offsetRelative();
                leftCss = (ofsetChi.left + leftParent) + _this.outerWidth() + 20;
            }
            if (leftCss > widthParent) {
                strucHiddel.css('left', ((widthParent - leftCss + leftParent)) + 'px');
            }
        } else if (indexOld != -1 && indexNow < indexOld && leftParent < 0) {
            var leftParentDuong = -(leftParent);
            var itemPrev = _this.prev('.contentInfoLamBai-Ex-Item');
            if (itemPrev.size() > 0) {
                var ofsetChi = itemPrev.offsetRelative();
                if (ofsetChi.left <= leftParentDuong) {
                    leftCss = itemPrev.outerWidth();
                    var itemPrevNew = itemPrev.prev('.contentInfoLamBai-Ex-Item');
                    if (itemPrevNew.size() > 0) {
                        leftCss += (itemPrevNew.outerWidth() / 2);
                        var _leftEFF = (leftParent + leftCss);
                        if (_leftEFF > 0)
                            _leftEFF = 0
                        strucHiddel.css('left', _leftEFF + 'px');

                    } else {
                        strucHiddel.css('left', '0px');
                    }
                }

            } else {
                strucHiddel.css('left', '0px');
            }
        }
        strucItemEx.removeClass('contentInfoLamBai-Ex-Item-Select');
        _this.addClass('contentInfoLamBai-Ex-Item-Select');
        var listPanelItem = $('.contentListEx .contentListEx-itemparent');
        if (indexOld == -1) {
            listPanelItem.eq(indexNow).css('display', 'block').addClass('contentListEx-itemparent-show');
            resetBtnNextPrev();
        } else if (indexOld != indexNow) {
            listPanelItem.eq(indexOld).removeClass('contentListEx-itemparent-show');
            setTimeout(function () {
                listPanelItem.eq(indexOld).css('display', 'none');
                listPanelItem.eq(indexNow).css('display', 'block');
                setTimeout(function () {
                    listPanelItem.eq(indexNow).addClass('contentListEx-itemparent-show');
                    resetBtnNextPrev();

                    var listPag = listPanelItem.eq(indexNow).find('.contentListEx-itemparent-page-item');
                    var _widthNew = 0;
                    listPag.each(function (index) {
                        $(this).css('z-index', (listPag.size() - index));
                        _widthNew += $(this).outerWidth();
                        if (index == listPag.size() - 1) {
                            $(this).parent('.contentListEx-itemparent-page-hiddel').css('width', (_widthNew + 100) + 'px');
                            if (_widthNew < $(this).parents('.contentListEx-itemparent-page').outerWidth()) {
                                var _padingAdd = ($(this).parents('.contentListEx-itemparent-page').outerWidth() - _widthNew) / (listPag.size() * 2) - (11 / (listPag.size() * 2));
                                listPag.css({ 'padding-left': '+=' + _padingAdd + 'px', 'padding-right': '+=' + _padingAdd + 'px' });
                            }
                        }
                    });

                }, 300);
            }, 300);
        }

    });
    strucItemEx.eq(0).click();

    $('.contentListEx-itemparent .contentListEx-itemparent-page-item').mousedown(function (event) {
        event.preventDefault();
    });
    $('.contentListEx-itemparent .contentListEx-itemparent-page-item').click(function () {
        var _this = $(this);
        if (_this.parents('.contentListEx-itemparent').attr('valnext') == "false") {
            var allPageClick = _this.parents('.contentListEx-itemparent').find('.contentListEx-itemparent-page-item');
            var strucHiddel2 = _this.parents('.contentListEx-itemparent-page-hiddel');
            var ofset = _this.offsetRelative();
            var leftParent = parseInt(strucHiddel2.css('left').replace("px", ""));
            var widthParent = strucHiddel2.parents('.contentListEx-itemparent-page').outerWidth();
            var leftNow = (ofset.left + leftParent);
            var leftCss = 0;
            var indexOld = allPageClick.index(strucHiddel2.find('.contentListEx-itemparent-page-item-Select'));
            var indexNow = allPageClick.index(_this);

            if (indexOld != -1 && indexNow > indexOld) {
                var itemNext = _this.next('.contentListEx-itemparent-page-item');
                if (itemNext.size() > 0) {
                    var ofsetChi = itemNext.offsetRelative();
                    var leftChi = (ofsetChi.left + leftParent) + itemNext.outerWidth();
                    if (leftChi >= widthParent) {
                        leftCss = leftChi;
                        var itemNextNew = itemNext.next('.contentListEx-itemparent-page-item');
                        if (itemNextNew.size() > 0) {
                            leftCss += (itemNextNew.outerWidth() / 2);
                        } else {
                            leftCss += 11;
                        }
                    }
                } else {
                    var ofsetChi = _this.offsetRelative();
                    leftCss = (ofsetChi.left + leftParent) + _this.outerWidth() + 11;
                }
                if (leftCss > widthParent) {
                    strucHiddel2.css('left', ((widthParent - leftCss + leftParent)) + 'px');
                }
            } else if (indexOld != -1 && indexNow < indexOld && leftParent < 0) {
                var leftParentDuong = -(leftParent);
                var itemPrev = _this.prev('.contentListEx-itemparent-page-item');
                if (itemPrev.size() > 0) {
                    var ofsetChi = itemPrev.offsetRelative();
                    if (ofsetChi.left <= leftParentDuong) {
                        leftCss = itemPrev.outerWidth();
                        var itemPrevNew = itemPrev.prev('.contentListEx-itemparent-page-item');
                        if (itemPrevNew.size() > 0) {
                            leftCss += (itemPrevNew.outerWidth() / 2);
                            var _leftEFF = (leftParent + leftCss);
                            if (_leftEFF > 0)
                                _leftEFF = 0
                            strucHiddel2.css('left', _leftEFF + 'px');

                        } else {
                            strucHiddel2.css('left', '0px');
                        }
                    }

                } else {
                    strucHiddel2.css('left', '0px');
                }
            }

            var listPanelItem = _this.parents('.contentListEx-itemparent').find('.contentListEx-itemparent-data-item');
            if (indexOld == -1) {
                listPanelItem.eq(indexNow).css('display', 'block').addClass('contentListEx-itemparent-data-item-show');
                resetBtnNextPrev();
            } else if (indexOld != indexNow) {
                _this.parents('.contentListEx-itemparent').attr('valnext', 'true');
                listPanelItem.eq(indexOld).removeClass('contentListEx-itemparent-data-item-show');
                setTimeout(function () {
                    listPanelItem.eq(indexOld).css('display', 'none');
                    listPanelItem.eq(indexNow).css('display', 'block');
                    setTimeout(function () {
                        listPanelItem.eq(indexNow).addClass('contentListEx-itemparent-data-item-show');
                        _this.parents('.contentListEx-itemparent').attr('valnext', 'false');
                        resetBtnNextPrev();
                    }, 300);
                }, 300);
            }
            allPageClick.removeClass('contentListEx-itemparent-page-item-Select');
            _this.addClass('contentListEx-itemparent-page-item-Select');
        }
    });
    $('.contentListEx-itemparent').each(function () {
        var listPag = $(this).find('.contentListEx-itemparent-page-item');
        var _widthNew = 0;
        listPag.each(function (index) {
            $(this).css('z-index', (listPag.size() - index));
            _widthNew += $(this).outerWidth();
            if (index == listPag.size() - 1) {
                $(this).parent('.contentListEx-itemparent-page-hiddel').css('width', (_widthNew + 100) + 'px');
                if (_widthNew < $(this).parents('.contentListEx-itemparent-page').outerWidth()) {
                    var _padingAdd = ($(this).parents('.contentListEx-itemparent-page').outerWidth() - _widthNew) / (listPag.size() * 2) - (11 / (listPag.size() * 2));
                    listPag.css({ 'padding-left': '+=' + _padingAdd + 'px', 'padding-right': '+=' + _padingAdd + 'px' });
                }
            }
        });
        listPag.eq(0).click();
    });
    var timeClearNextPrev = setTimeout(function () { });
    $('.contentListEx .contentListEx-Btn .contentListEx-Btn-Prev').click(function () {
        var _prev = $('.contentInfoLamBai-Ex-Item-Select').prev('.contentInfoLamBai-Ex-Item');
        if (_prev.size() > 0) {
            _prev.click();
            setTimeout(function () {
                var _top = $('.contentListEx-itemparent-show').offset().top;
                $('html, body').animate({ "scrollTop": _top - 50 }, 300);
            }, 1000);
        }

        //        if ($(this).attr('class').indexOf('contentListEx-Btn-Click-Show') > -1) {
        //            btnclickObjAAAA = true;
        //            var _pPrev = $('.contentInfoLamBai .contentListEx .contentListEx-itemparent-show .contentListEx-itemparent-page-item-Select').prev('.contentListEx-itemparent-page-item');
        //            if (_pPrev.size() > 0) {
        //                _pPrev.click();
        //            } else {
        //                _pPrev = $('.contentInfoLamBai .contentInfoLamBai-Ex .contentInfoLamBai-Ex-Item-Select').prev('.contentInfoLamBai-Ex-Item');
        //                if (_pPrev.size() > 0) {
        //                    _pPrev.click();
        //                    clearTimeout(timeClearNextPrev);
        //                    timeClearNextPrev = setTimeout(function () {
        //                        $('.contentListEx .contentListEx-itemparent').eq($('.contentInfoLamBai-Ex-Item').index($('.contentInfoLamBai-Ex-Item-Select'))).find('.contentListEx-itemparent-page-item').last().click();
        //                    }, 350);
        //                }
        //            }
        //        }
    });

    $('.contentListEx .contentListEx-Btn .contentListEx-Btn-Next').click(function () {

        var _index = $('.contentInfoLamBai-Ex-Item').index($('.contentInfoLamBai-Ex-Item-Select'));
        var _paren = $('.contentListEx-itemparent:eq(' + _index + ')');
        if (cbThuTuLam && check_all_question_da_lam(_paren)) {
            _pNext = $('.contentInfoLamBai .contentInfoLamBai-Ex .contentInfoLamBai-Ex-Item-Select').next('.contentInfoLamBai-Ex-Item').click();
            setTimeout(function () {
                var _top = $('.contentListEx-itemparent-show').offset().top;
                $('html, body').animate({ "scrollTop": _top - 50 }, 300);
            }, 1000);
        } else if (!cbThuTuLam) {
            _pNext = $('.contentInfoLamBai .contentInfoLamBai-Ex .contentInfoLamBai-Ex-Item-Select').next('.contentInfoLamBai-Ex-Item').click();
            setTimeout(function () {
                var _top = $('.contentListEx-itemparent-show').offset().top;
                $('html, body').animate({ "scrollTop": _top - 50 }, 300);
            }, 1000);
        }
        //        if ($(this).attr('class').indexOf('contentListEx-Btn-Click-Show') > -1) {
        //            btnclickObjAAAA = true;
        //            var _pNext = $('.contentInfoLamBai .contentListEx .contentListEx-itemparent-show .contentListEx-itemparent-page-item-Select').next('.contentListEx-itemparent-page-item');
        //            if (_pNext.size() > 0) {
        //                _pNext.click();
        //            } else {
        //                _pNext = $('.contentInfoLamBai .contentInfoLamBai-Ex .contentInfoLamBai-Ex-Item-Select').next('.contentInfoLamBai-Ex-Item');
        //                if (_pNext.size() > 0) {
        //                    _pNext.click();
        //                    clearTimeout(timeClearNextPrev);
        //                    timeClearNextPrev = setTimeout(function () {
        //                        $('.contentListEx .contentListEx-itemparent').eq($('.contentInfoLamBai-Ex-Item').index($('.contentInfoLamBai-Ex-Item-Select'))).find('.contentListEx-itemparent-page-item').first().click();
        //                    }, 350);
        //                }
        //            }
        //        }

    });
    $('.panelBox-NewLB-Time-Parent .panelBox-NewLB-Time span').first().click(function () {
        if ($(this).parent('.panelBox-NewLB-Time').attr('class').indexOf('panelBox-NewLB-Time-Fixed-Down') > -1) {
            $(this).parent('.panelBox-NewLB-Time').removeClass('panelBox-NewLB-Time-Fixed-Down');
        } else {
            $(this).parent('.panelBox-NewLB-Time').addClass('panelBox-NewLB-Time-Fixed-Down');
        }
    });
    $('.btnQuestionChuaLam').click(function () {
        eventCheckQuestionChuaLam();
        var _qu = $('.contentListEx .contentListEx-itemparent-data-item').eq(parseInt($(this).attr('valindex')));
        var _nindex = _qu.parent('.contentListEx-itemparent-data').find('.contentListEx-itemparent-data-item').index(_qu);
        _qu.parent('.contentListEx-itemparent-data').prev('.contentListEx-itemparent-page').find('.contentListEx-itemparent-page-item').eq(_nindex).click();
        var _parenE = _qu.parents('.contentListEx-itemparent');
        if (_parenE.attr('class').indexOf('contentListEx-itemparent-show') <= -1)
            _parenE.parent('.contentListEx').prev('.contentInfoLamBai-Ex').find('.contentInfoLamBai-Ex-Item').eq(_parenE.parent('.contentListEx').find('.contentListEx-itemparent').index(_parenE)).click();

        btnclickObjAAAA = true;
    });
    $('.btnQuestionNopBai').click(function () {
        jConfirmLinkTam('Thông báo', '<div style="text-align:left;">Bạn chắc chắn muốn gửi kết quả</div>', "Chắc chắn", "Đóng", 350, function (status) {
            if (status) {
                createJsonSaveServer();
            }
            $.confirmLinkTam._close();
        });
    });
    //$('#loadingBarCrazy').loadingbar(0);
    $('.btnshowErrInfoQuestion span').click(function () {
        var _index = $(this).parent('.btnshowErrInfoQuestion').find('span').index($(this));
        if (_index == 0) {
            $(this).parent('.btnshowErrInfoQuestion').removeClass('btnshowErrInfoQuestion-ShowDa').prev('.panelShowErrSucNew').css('display', 'none');
        } else {
            $(this).parent('.btnshowErrInfoQuestion').addClass('btnshowErrInfoQuestion-ShowDa').prev('.panelShowErrSucNew').css('display', 'block');
        }
    });
}




function createJsonSaveServer() {
    clearInterval(idTimeIn);
    var createArayJson = new Array();
    var _question = $('.contentListEx .contentListEx-itemparent-data-item');
    _question.each(function (index) {
        var _this = $(this);
        if (_this.find('.panelKeoTha-Cau').size() > 0) {
            _this = _this.find('.panelKeoTha-Cau');
            var arrayItem = new Array();
            _this.find('.panelKeoTha-Cau-ArrayTraLoi-Item').each(function (indexItem) {
                var _thisItem = $(this);
                arrayItem[indexItem] = {
                    id: _thisItem.attr('valid'),
                    a: _thisItem.find('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').eq(0).attr('valtext'),
                    b: _thisItem.find('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').eq(1).attr('valtext')
                };
            });
            var item = {
                id: _this.attr('valid'),
                type: _this.attr('valtype'),
                arrayitem: arrayItem,
                html: _this.parent('.contentListEx-itemparent-data-item').html()
            };
            createArayJson[createArayJson.length] = item;

        } else if (_this.find('.panelMatching').size() > 0) {
            _this = _this.find('.panelMatching');
            var arrayItem = new Array();
            _this.find('.panelMatching-Content-Item').each(function (indexItem) {
                var _thisItem = $(this);
                arrayItem[indexItem] = {
                    id: _thisItem.attr('valid'),
                    dapan: _thisItem.attr('valtext')
                };
            });
            var item = {
                id: _this.attr('valid'),
                type: _this.attr('valtype'),
                arrayitem: arrayItem,
                html: _this.parent('.contentListEx-itemparent-data-item').html()
            };
            createArayJson[createArayJson.length] = item;
        } else if (_this.find('.panelDienCau').size() > 0) {
            _this = _this.find('.panelDienCau');
            var arrayItem = new Array();
            _this.find('.panelDienCau-Content-AddText').each(function (indexItem) {
                var _thisItem = $(this);
                arrayItem[indexItem] = {
                    id: _thisItem.attr('valid'),
                    dapan: _thisItem.find('input:text').val()
                };
            });
            var item = {
                id: _this.attr('valid'),
                type: _this.attr('valtype'),
                arrayitem: arrayItem,
                html: _this.parent('.contentListEx-itemparent-data-item').html()
            };
            createArayJson[createArayJson.length] = item;
        } else if (_this.find('.panelPhanLoai').size() > 0) {
            _this = _this.find('.panelPhanLoai');
            var arrayItemA = new Array();
            var arrayItemB = new Array();
            _this.find('.panelPhanLoai-PanelPhanLoai-Left').find('.panelPhanLoai-PanelPhanLoai-Item:not([valtext=""])').each(function (indexItem) {
                arrayItemA[indexItem] = $(this).attr('valtext')
            });
            _this.find('.panelPhanLoai-PanelPhanLoai-Right').find('.panelPhanLoai-PanelPhanLoai-Item:not([valtext=""])').each(function (indexItem) {
                arrayItemB[indexItem] = $(this).attr('valtext')
            });
            var item = {
                id: _this.attr('valid'),
                type: _this.attr('valtype'),
                a: arrayItemA,
                b: arrayItemB,
                html: _this.parent('.contentListEx-itemparent-data-item').html()
            };
            createArayJson[createArayJson.length] = item;
        } else if (_this.find('.panelChonCauDoan').size() > 0) {
            _this = _this.find('.panelChonCauDoan');
            var arrayItem = new Array();
            _this.find('.panelChonCauDoan-ListItemSelect-Item').each(function (indexItem) {
                var _thisItem = $(this);
                arrayItem[indexItem] = {
                    id: _thisItem.attr('valid'),
                    dapan: _thisItem.attr('valtext')
                };
            });
            var item = {
                id: _this.attr('valid'),
                type: _this.attr('valtype'),
                arrayitem: arrayItem,
                html: _this.html()
            };
            createArayJson[createArayJson.length] = item;
        } else if (_this.find('.panelImage').size() > 0) {
            _this = _this.find('.panelImage');
            var arrayItem = new Array();
            _this.find('.panelImage-ArayItem-Item').each(function (indexItem) {
                var _thisItem = $(this);
                arrayItem[indexItem] = {
                    id: _thisItem.attr('valid'),
                    dapan: _thisItem.attr('valtext')
                };
            });
            var item = {
                id: _this.attr('valid'),
                type: _this.attr('valtype'),
                arrayitem: arrayItem,
                html: _this.parent('.contentListEx-itemparent-data-item').html()
            };
            createArayJson[createArayJson.length] = item;
        }
    });
    $('#loadingBarCrazy').loadingbar(-1, false);
    $.ajax({
        type: "POST",
        url: "services/Quiz.asmx/actionQuiz",
        data: "{'txtJson':" + JSON.stringify(JSON.stringify(createArayJson)) + ",ID:" + ID_DE + ",keyguid:'" + keyguid + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {

        },
        success: function (message) {
            //            var objAv = jQuery.parseJSON(message.d);
            var objAv = message.d;
            $('#loadingBarCrazy').loadingbar(100, true);
            if (objAv[0] == -1) {
                popUpNew(true, true, '<div style="text-align:center;color:#2e7ebc;">Vui lòng đăng nhập để tiếp tục.</div><div><a href="popup-login.htm" onclick="openWindow(this.href, \'Đăng nhập suwphutienganh.com\', 500, 300);popUpNew(false);return false;"><div class="btnBottomNewOk" style="float:right;" >Đăng nhập</div></a></div><div style="clear: both;"></div>');
            } else if (objAv[0] == 0) {
                popUpNew(true, true, '<div style="color: #e44b4b;text-align: center;font-weight: normal;font-size: 13px;">' + objAv[1] + '</div><div style="clear: both;"></div>');
            } else {
                cbThuTuLam = false;


                $('*[aaa-group2]').removeAttr('aaa-none');
                $('*[aaa-group1]').attr('aaa-none', '');
                var totalDung = objAv[1].filter(function (x, index) { return x[2]; }).length;
                var totalSai = objAv[1].filter(function (x, index) { return !x[2]; }).length;
                $('*[aaa-suc]').text(totalDung);
                $('*[aaa-sai]').text(totalSai);

                if (totalDung / objAv[1].length * 100 >= 80) {
                    jConfirmLinkTam('', '<div style="text-align: justify;margin:5px;">Chúc mừng bạn! Bạn đã trả lời đúng được ' + totalDung + ' câu. Bạn có kiến thức và thái độ bình đẳng giới tốt, bạn có các kỹ năng để phòng tránh và ứng phó với bạo lực trên cơ sở giới. Cảm ơn bạn.</div>', null, null, 400,null,true);
                } else {
                    jConfirmLinkTam('', '<div style="text-align: justify;margin:5px;">Cảm ơn bạn! Bạn đã trả lời đúng được ' + totalDung + ' câu. Bạn có muốn thử lại một lần nữa không? </div>', 'Thử lại', 'Hủy bỏ', 350, function (staus) {
                        if (staus)
                            window.location.href = window.location.href;
                        $.confirmLinkTam._close();
                    }, true);
                }
                for (var i = 0; i < objAv[1].length; i++) {
                    var item = objAv[1][i];
                    var itemNext = $('*[valid="' + item[0] + '"]');
                    itemNext.next('.panelShowErrSucNew').html(item[1]).css('display', 'block');
                    itemNext.next('.panelShowErrSucNew').next('.btnshowErrInfoQuestion').css({ 'right': '0px', 'opacity': '1' });
                    if (!item[2])
                        itemNext.parent('.contentListEx-itemparent-data-item').prev('span[attr-number-question]').attr('attr-number-question-err', '')
                    else
                        itemNext.parent('.contentListEx-itemparent-data-item').prev('span[attr-number-question]').attr('attr-number-question-suc', '')

                    //var _index = itemNext.parents('.contentListEx-itemparent').find('.contentListEx-itemparent-data-item').index(itemNext.parent('.contentListEx-itemparent-data-item'));
                    //itemNext.parents('.contentListEx-itemparent').find('.contentListEx-itemparent-page').find('.contentListEx-itemparent-page-item').eq(_index).find('div').addClass('iconStausQuestionFalse');

                }
                evenpanelMatchingSave();
                $('.panelChonCauDoan-ListItemSelect-Item-ABCD').unbind("click");
                $('.panelChonCauDoan-ListItemSelect-Item-ABCD').attr('remove-hover', '');
                $('span.selectChonLuaDoan').parents('.panelChonCauDoan-ListItemSelect-Item-ABCD').removeAttr('remove-hover');
                //$('.contentListEx-itemparent-page-item').each(function () {
                //    if ($(this).find('.iconStausQuestionFalse').size() <= 0)
                //        $(this).find('div').addClass('iconStausQuestionTrue');
                //});
            }
        },
        error: function (errormessage) {

        }
    });
    //JSON.stringify(JSON.stringify(arrayPram))
}
function eventCheckQuestionChuaLam() {
    var _question = $('.contentListEx .contentListEx-itemparent-data-item');
    var countChuaLamXong = 0;
    _question.each(function (index) {
        if (!checkQuestionChuaLam($(this))) {
            if (countChuaLamXong == 0) {
                $('.btnQuestionChuaLam').attr('valindex', index);
            }
            countChuaLamXong++;
        }
    });
    if (countChuaLamXong == 0)
        $('.btnQuestionChuaLam').css('display', 'none');
    else
        $('.btnQuestionChuaLam').css('display', 'block');
    $('.datatotalAAAAAAAAAAAA').text(countChuaLamXong + " / " + _question.size());
}
function checkQuestionChuaLam(_question) {
    if (_question.find('.panelKeoTha-Cau').size() > 0) {
        var _panelCheck = _question.find('.panelKeoTha-Cau');
        var _numDapAn = _panelCheck.find('.panelKeoTha-Cau-ArrayKeo-Item').size();
        var _numDapAnSelect = _panelCheck.find('.dismovekeotha').size();
        if (_numDapAn == _numDapAnSelect)
            return true;
    } else if (_question.find('.panelMatching').size() > 0) {
        var _panelCheck = _question.find('.panelMatching');
        var _numDapAn = _panelCheck.find('.panelMatching-Content-Item-Left').size();
        var _numDapAnSelect = _panelCheck.find('.panelMatchingSelect').size();
        if (_numDapAn == _numDapAnSelect)
            return true;
    } else if (_question.find('.panelDienCau').size() > 0) {
        var _panelCheck = _question.find('.panelDienCau');
        var _numDapAn = _panelCheck.find('.panelDienCau-Content-AddText input:text');
        var flagRe = true;
        _numDapAn.each(function () {
            if ($.trim($(this).val()).length <= 0)
                flagRe = false;
        });
        return flagRe;
    } else if (_question.find('.panelPhanLoai').size() > 0) {
        var _panelCheck = _question.find('.panelPhanLoai');
        var _numDapAn = _panelCheck.find('.panelPhanLoai-ArayItem-Item').size();
        var _numDapAnSelect = _panelCheck.find('.dismovekeotha').size();
        if (_numDapAn == _numDapAnSelect)
            return true;
    } else if (_question.find('.panelChonCauDoan').size() > 0) {
        var _panelCheck = _question.find('.panelChonCauDoan');
        var _numDapAn = _panelCheck.find('.panelChonCauDoan-ListItemSelect-Item').size();
        var _numDapAnSelect = _panelCheck.find('.panelChonCauDoan-ListItemSelect-Item-Selected').size();
        if (_numDapAn == _numDapAnSelect)
            return true;
    } else if (_question.find('.panelImage').size() > 0) {
        var _panelCheck = _question.find('.panelImage');
        var _numDapAn = _panelCheck.find('.panelImage-ArayItem-Item').size();
        var _numDapAnSelect = _panelCheck.find('.panelImage-ArayItem-Item:not([valid=""])').size();
        if (_numDapAn == _numDapAnSelect)
            return true;
    }
    return false;
}
function resetBtnNextPrev() {
    setTimeout(function () {
        var _paren = $('.contentInfoLamBai');
        //if (_paren.find('.contentInfoLamBai-Ex .contentInfoLamBai-Ex-Item-Select').next('.contentInfoLamBai-Ex-Item').size() <= 0 && _paren.find('.contentListEx .contentListEx-itemparent-show .contentListEx-itemparent-page .contentListEx-itemparent-page-item-Select').next('.contentListEx-itemparent-page-item').size() <= 0) {
        //    _paren.find('.contentListEx-Btn-Next').removeClass('contentListEx-Btn-Click-Show');
        //} else {
        //    _paren.find('.contentListEx-Btn-Next').addClass('contentListEx-Btn-Click-Show');
        //}

        //if (_paren.find('.contentInfoLamBai-Ex .contentInfoLamBai-Ex-Item-Select').prev('.contentInfoLamBai-Ex-Item').size() <= 0 && _paren.find('.contentListEx .contentListEx-itemparent-show .contentListEx-itemparent-page .contentListEx-itemparent-page-item-Select').prev('.contentListEx-itemparent-page-item').size() <= 0) {
        //    _paren.find('.contentListEx-Btn-Prev').removeClass('contentListEx-Btn-Click-Show');
        //} else {
        //    _paren.find('.contentListEx-Btn-Prev').addClass('contentListEx-Btn-Click-Show');
        //}
        if (_paren.find('.contentInfoLamBai-Ex .contentInfoLamBai-Ex-Item-Select').next('.contentInfoLamBai-Ex-Item').size() <= 0) {
            _paren.find('.contentListEx-Btn-Next').removeClass('contentListEx-Btn-Click-Show');
        } else {
            _paren.find('.contentListEx-Btn-Next').addClass('contentListEx-Btn-Click-Show');
        }

        if (_paren.find('.contentInfoLamBai-Ex .contentInfoLamBai-Ex-Item-Select').prev('.contentInfoLamBai-Ex-Item').size() <= 0) {
            _paren.find('.contentListEx-Btn-Prev').removeClass('contentListEx-Btn-Click-Show');
        } else {
            _paren.find('.contentListEx-Btn-Prev').addClass('contentListEx-Btn-Click-Show');
        }

        if (btnclickObjAAAA) {
            $('html, body').animate({ "scrollTop": $('.contentInfoLamBai').offset().top - 40 }, 300);
            btnclickObjAAAA = false;
        }
        evenpanelMatchingSave();
        eventCheckQuestionChuaLam();
    }, 10);
}
function evenpanelMatchingSave() {
    var _araypanel = $('.contentListEx-itemparent-show .contentListEx-itemparent-data-item-show .panelShowErrSucNew').children('div');
    if (_araypanel.size() > 0 && parseInt(_araypanel.attr('valtype')) == 2 && typeof _araypanel.attr('valaction') == 'undefined') {
        _araypanel.attr('valaction', 'true');
        _araypanel.find('.panelMatching-Content-Item').each(function () {
            var elementKeo = $(this).children('.panelMatching-Content-Item-Left');
            var elemrntTha = _araypanel.find('.panelMatching-Content-Item-Right[valtext="' + $(this).attr('valtext') + '"]');
            if (elementKeo.size() > 0 && elemrntTha.size() > 0) {
                var _left = elementKeo.find('.panelMatching-Content-Item-Data'); ;
                var _leftO = _left.offsetRelative();
                var _right = elemrntTha;
                var _rightO = _right.offsetRelative($(this).parents('.panelShowErrSucNew'));
                var _index = "panelMatching" + $('.panelMatching').index(_araypanel) + "_" + _araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo);
                $('#' + _index).remove();
                _araypanel.append('<div id="' + _index + '" class="borderBoKeo borderBoKeoAppend "></div>');
                var objNew = new jsGraphics(_index);
                objNew.setStroke(1);
                var _color = arayColor[_araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo)];
                objNew.setColor("#" + _color);
                var _left = elementKeo.find('.panelMatching-Content-Item-Data');
                var _leftO = _left.offsetRelative();
                objNew.drawLine(_leftO.left + _left.width() + 10, _leftO.top + (_left.height() / 2), _rightO.left - 5, _rightO.top + (_right.height() / 2));
                objNew.paint();
                $('#' + _index).children('div').eq(0).prepend('<div style="left:' + (_leftO.left + _left.width() + 10) + 'px;top:' + (_leftO.top + (_left.height() / 2)) + 'px;background-color:#' + _color + ';"></div>');
                $('#' + _index).children('div').eq(0).append('<div style="left:' + (_rightO.left - 5) + 'px;top:' + (_rightO.top + (_right.height() / 2)) + 'px;border: 2px solid #' + _color + ';"></div>');
            }
        });
    } else if (_araypanel.size() > 0 && parseInt(_araypanel.attr('valtype')) == 5 && typeof _araypanel.attr('valaction') == 'undefined') {
        _araypanel.attr('valaction', 'true');
        var _widthNew = (parseInt(_araypanel.find('.panelImage-Data-Image').attr('valwidth')) - 680) / 2;
        _araypanel.find('.panelImage-Data-Image').find('.panelImage-Data-Image-ItemAdd').css('left', '-=' + _widthNew + 'px');
        _araypanel.find('.panelImage-ArayItem-Item').each(function () {
            var elementKeo = $(this);
            var elemrntTha = _araypanel.find('.panelImage-Data-Image-ItemAdd[valid="' + elementKeo.attr('valid') + '"]');
            if (elementKeo.size() > 0 && elemrntTha.size() > 0) {
                var _left = elementKeo;
                var _leftO = _left.offsetRelative();
                var _right = elemrntTha;
                var _rightO = _right.offsetRelative();
                var _index = "panelImage" + $('.panelImage').index(_araypanel) + "_" + _araypanel.find('.panelImage-ArayItem-Item').index(elementKeo);
                $('#' + _index).remove();
                _araypanel.append('<div id="' + _index + '" class="borderBoKeoNew borderBoKeoAppendNew"></div>');
                var objNew = new jsGraphics(_index);
                objNew.setStroke(1);
                var _color = arayColor[_araypanel.find('.panelImage-ArayItem-Item').index(elementKeo)];
                objNew.setColor("#" + _color);
                var _left = elementKeo;
                var _leftO = _left.offsetRelative();
                _leftO.top = _leftO.top + 10;
                var osetNew = _araypanel.find('.panelImage-Data-Image').offsetRelative();
                _rightO.top = _rightO.top + osetNew.top;
                _rightO.left = _rightO.left + osetNew.left;
                objNew.drawLine(_leftO.left + (_left.width() / 2), _leftO.top + _left.height(), _rightO.left + 3, _rightO.top + 3);
                objNew.paint();
                $('#' + _index).children('div').eq(0).prepend('<div style="left:' + (_leftO.left + (_left.width() / 2)) + 'px;top:' + (_leftO.top + _left.height() + 10) + 'px;background-color:#' + _color + ';"></div>');
                $('#' + _index).children('div').eq(0).append('<div style="left:' + (_rightO.left) + 'px;top:' + (_rightO.top) + 'px;background-color:#' + _color + ';"></div>');
            }
        });
    }
}
function eventImage() {
    $(".panelImage").mousedown(function (event) {
        event.preventDefault();
    });
    $(".panelImage-Data-Image").each(function () {
        var _width = (parseInt($(this).attr('valwidth')) - 680) / 2;
        $(this).find('.panelImage-Data-Image-ItemAdd').css('left', '-=' + _width + 'px');
    });
    $(".panelImage").mousemove(function (event) {
        if ($(this).attr('mouse-move') == "true") {
            var element = $(this).find('.panelImage-ArayItem-Item[mouse-move="true"]');
            var _araypanel = element.parents('.panelImage');
            if (element.size() > 0) {
                var _index = "panelImage" + $('.panelImage').index(_araypanel) + "_" + _araypanel.find('.panelImage-ArayItem-Item').index(element);
                $('#' + _index).remove();
                element.append('<div id="' + _index + '" class="borderBoKeoNew borderBoKeoEff"></div>');
                var objNew = new jsGraphics(_index);
                objNew.setStroke(1);
                var _color = arayColor[_araypanel.find('.panelImage-ArayItem-Item').index(element)];
                objNew.setColor("#" + _color);
                var _left = element;
                var _leftO = _left.offsetRelative();
                var _ha = _araypanel.children('.title-question-struc-new');
                var _heightNew = 0;
                if (_ha.size() > 0)
                    _heightNew = _ha.outerHeight();
                event.pageY = event.pageY - _araypanel.offset().top - _heightNew;
                event.pageX = event.pageX - _araypanel.offset().left;

                objNew.drawLine(_leftO.left + (_left.width() / 2), _leftO.top + _left.height(), event.pageX, event.pageY);
                objNew.paint();
                $('#' + _index).children('div').eq(0).prepend('<div style="left:' + (_leftO.left + (_left.width() / 2)) + 'px;top:' + (_leftO.top + _left.height() + 10) + 'px;background-color:#' + _color + ';"></div>');
                $('#' + _index).children('div').eq(0).append('<div style="left:' + (event.pageX) + 'px;top:' + (event.pageY) + 'px;background-color:#' + _color + ';"></div>');
            }
        }
    });
    $(document).mouseup(function () {
        var _araypanel = $('.panelImage[mouse-move="true"]')
        if (_araypanel.size() > 0) {
            _araypanel.attr('mouse-move', 'false');
            var elementKeo = _araypanel.find('*[mouse-move="true"]');
            var elemrntTha = _araypanel.find('*[mouse-hover="true"]');
            if (elementKeo.size() > 0 && elemrntTha.size() > 0) {
                var _left = elementKeo;
                var _leftO = _left.offsetRelative();
                var _right = elemrntTha;
                var _rightO = _right.offsetRelative();
                var _index = "panelImage" + $('.panelImage').index(_araypanel) + "_" + _araypanel.find('.panelImage-ArayItem-Item').index(elementKeo);
                $('#' + _index).remove();
                _araypanel.append('<div id="' + _index + '" class="borderBoKeoNew borderBoKeoAppendNew"></div>');
                var objNew = new jsGraphics(_index);
                objNew.setStroke(1);
                var _color = arayColor[_araypanel.find('.panelImage-ArayItem-Item').index(elementKeo)];
                objNew.setColor("#" + _color);
                var _left = elementKeo;
                var _leftO = _left.offsetRelative();
                var osetNew = _araypanel.find('.panelImage-Data-Image').offsetRelative();

                var _ha = _araypanel.children('.title-question-struc-new');
                var _heightNew = 0;
                if (_ha.size() > 0)
                    _heightNew = _ha.outerHeight(true);

                _rightO.top = _rightO.top + osetNew.top;
                _rightO.left = _rightO.left + osetNew.left;
                _leftO.top = _leftO.top + _heightNew;
                objNew.drawLine(_leftO.left + (_left.width() / 2), _leftO.top + _left.height(), _rightO.left + 3, _rightO.top + 3);
                objNew.paint();
                $('#' + _index).children('div').eq(0).prepend('<div style="left:' + (_leftO.left + (_left.width() / 2)) + 'px;top:' + (_leftO.top + _left.height() + 10) + 'px;background-color:#' + _color + ';"></div>');
                $('#' + _index).children('div').eq(0).append('<div style="left:' + (_rightO.left) + 'px;top:' + (_rightO.top) + 'px;background-color:#' + _color + ';"></div>');
                elementKeo.attr('valid', elemrntTha.attr('valid'));
                elementKeo.attr('mouse-move', 'false');
                elemrntTha.attr('mouse-hover', 'false');
            } else if (elementKeo.size() > 0) {
                var _index = "panelImage" + $('.panelImage').index(_araypanel) + "_" + _araypanel.find('.panelImage-ArayItem-Item').index(elementKeo);
                $('#' + _index).remove();
                elementKeo.attr('mouse-move', 'false').attr('valid', '');
            }
        }
    });

    $('.panelImage .panelImage-ArayItem-Item').mousedown(function (event) {
        if (event.which == 1 && $(this).attr('class').indexOf('dismovekeotha') <= -1) {
            $(this).attr('mouse-move', 'true');
            $(this).parents('.panelImage').attr('mouse-move', 'true');
        }
        event.preventDefault();
    });
    $('.panelImage .panelImage-Data-Image .panelImage-Data-Image-ItemAdd').hover(
        function () {
            var _this = $(this);
            _this.attr('mouse-hover', 'true')
        }, function () {
            var _this = $(this);
            _this.attr('mouse-hover', 'false');
        }
    );
}
function eventChonCauDoan() {
    $(".panelChonCauDoan").mousedown(function (event) {
        event.preventDefault();
    });
    $('.panelChonCauDoan .panelChonCauDoan-ListItemSelect .panelChonCauDoan-ListItemSelect-Item').each(function () {
        $(this).find('.panelChonCauDoan-ListItemSelect-Item-ABCD').eq(0).find('.panelChonCauDoan-ListItemSelect-Item-ABCD-Title').find('span').css('border-color', '#' + arayColor[0]);
        $(this).find('.panelChonCauDoan-ListItemSelect-Item-ABCD').eq(1).find('.panelChonCauDoan-ListItemSelect-Item-ABCD-Title').find('span').css('border-color', '#' + arayColor[0]);
        $(this).find('.panelChonCauDoan-ListItemSelect-Item-ABCD').eq(2).find('.panelChonCauDoan-ListItemSelect-Item-ABCD-Title').find('span').css('border-color', '#' + arayColor[0]);
        $(this).find('.panelChonCauDoan-ListItemSelect-Item-ABCD').eq(3).find('.panelChonCauDoan-ListItemSelect-Item-ABCD-Title').find('span').css('border-color', '#' + arayColor[0]);
    });
    $('.panelChonCauDoan .panelChonCauDoan-ListItemSelect .panelChonCauDoan-ListItemSelect-Item .panelChonCauDoan-ListItemSelect-Item-ABCD').click(function () {
        var _parent = $(this).parents('.panelChonCauDoan-ListItemSelect-Item');
        var _indexNow = _parent.find('.panelChonCauDoan-ListItemSelect-Item-ABCD').index($(this));
        var _indexOld = _parent.find('.panelChonCauDoan-ListItemSelect-Item-ABCD').index(_parent.find('.selectChonLuaDoan').parents('.panelChonCauDoan-ListItemSelect-Item-ABCD'));
        if (_indexNow != _indexOld) {
            _parent.addClass('panelChonCauDoan-ListItemSelect-Item-Selected').attr('valtext', $(this).attr('valtext')).find('.panelChonCauDoan-ListItemSelect-Item-ABCD-Title').find('span').removeClass('selectChonLuaDoan');
            $(this).find('.panelChonCauDoan-ListItemSelect-Item-ABCD-Title').find('span').addClass('selectChonLuaDoan');
        } else {
            _parent.removeClass('panelChonCauDoan-ListItemSelect-Item-Selected').attr('valtext', '').find('.panelChonCauDoan-ListItemSelect-Item-ABCD-Title').find('span').removeClass('selectChonLuaDoan');
        }
    });
}
function eventPhanLoai() {
    $('.panelPhanLoai').each(function () {
        var _numCau = $(this).find('.panelPhanLoai-ArayItem').find('.panelPhanLoai-ArayItem-Item').size();
        for (var i = 0; i < _numCau; i++) {
            $(this).find('.panelPhanLoai-PanelPhanLoai-AddData').append('<div class="panelPhanLoai-PanelPhanLoai-Item" valtext=""></div>')
        }
    });
    $(".panelPhanLoai").mousedown(function (event) {
        event.preventDefault();
    });

    $(".panelPhanLoai").mousemove(function (event) {
        if ($(this).attr('mouse-move') == "true") {
            var element = $(this).find('.panelPhanLoai-ArayItem-Item[mouse-move="true"]');
            if (element.size() > 0) {
                element.find('span').addClass('movekeotha').css({ 'left': (event.pageX - $(document).scrollLeft() - (element.find('span').width() / 2)) + 'px', 'top': (event.pageY - $(document).scrollTop() - 22) + 'px' });
            }
        }
    });
    $('.panelPhanLoai .panelPhanLoai-PanelPhanLoai-AddData .panelPhanLoai-PanelPhanLoai-Item').click(function () {
        var _textOld = $.trim($(this).attr('valtext'));
        if (_textOld.length > 0) {
            $(this).attr('valtext', '').text('');
            $(this).parents('.panelPhanLoai').find('.panelPhanLoai-ArayItem-Item[valtext="' + _textOld + '"]').removeClass('dismovekeotha')
        }
    });
    $(document).mouseup(function () {
        var _araypanel = $('.panelPhanLoai[mouse-move="true"]')
        if (_araypanel.size() > 0) {
            _araypanel.attr('mouse-move', 'false');
            var elementKeo = _araypanel.find('.panelPhanLoai-ArayItem-Item[mouse-move="true"]');
            if (elementKeo.size() > 0) {
                var elementHover = $(this).find('.panelPhanLoai-PanelPhanLoai-Left[mouse-hover="true"],.panelPhanLoai-PanelPhanLoai-Right[mouse-hover="true"]');
                if (elementHover.size() > 0) {
                    var addText = elementHover.find('.panelPhanLoai-PanelPhanLoai-Item[valtext=""]');
                    if (addText.size() > 0) {
                        addText.eq(0).attr('valtext', elementKeo.attr('valtext')).text(elementKeo.attr('valtext'));
                        elementKeo.find('span').removeClass('movekeotha').parent('span').addClass('dismovekeotha')
                    }
                    elementHover.attr('mouse-hover', 'false');
                }
                elementKeo.attr('mouse-move', 'false').find('span').removeClass('movekeotha');
            }
        }
    });

    $('.panelPhanLoai .panelPhanLoai-ArayItem-Item').mousedown(function (event) {
        if (event.which == 1 && $(this).attr('class').indexOf('dismovekeotha') <= -1) {
            $(this).attr('mouse-move', 'true');
            $(this).parents('.panelPhanLoai').attr('mouse-move', 'true');
        }
        event.preventDefault();
    });
    $('.panelPhanLoai .panelPhanLoai-PanelPhanLoai-Left,.panelPhanLoai .panelPhanLoai-PanelPhanLoai-Right').hover(
        function () {
            var _this = $(this);
            _this.attr('mouse-hover', 'true');
        }, function () {
            var _this = $(this);
            _this.attr('mouse-hover', 'false');
        }
    );
}


function eventMatching(ID) {
    $(".panelMatching[id='" + ID + "']").mousedown(function (event) {
        event.preventDefault();
    });
    $('.panelMatching[id="' + ID + '"] .panelMatching-Content-Item .panelMatching-Content-Item-Left').mousedown(function (event) {
        if (event.which == 1) {
            $(this).attr('mouse-move', 'true');
            $(this).parents('.panelMatching[id="' + ID + '"]').attr('mouse-move', 'true');
        }
        event.preventDefault();
    });
    $('.panelMatching[id="' + ID + '"]').mousemove(function (event) {
        var _araypanel = $('.panelMatching[id="' + ID + '"][mouse-move="true"]');
        if (_araypanel.size() > 0) {
            var elementKeo = _araypanel.find('.panelMatching-Content-Item-Left[mouse-move="true"]');
            var _index = "panelMatching" + $('.panelMatching[id="' + ID + '"]').index(_araypanel) + "_" + _araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo);
            $('#' + _index).remove();
            _araypanel.append('<div id="' + _index + '" class="borderBoKeo borderBoKeoEff"></div>');
            var objNew = new jsGraphics(_index);
            objNew.setStroke(1);
            var _color = arayColor[_araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo)];
            objNew.setColor("#" + _color);
            var _left = elementKeo.find('.panelMatching-Content-Item-Data');
            var _leftO = _left.offsetRelative();
            event.pageY = event.pageY - _araypanel.offset().top;
            event.pageX = event.pageX - _araypanel.offset().left;
            objNew.drawLine(_leftO.left + _left.width() + 10, _leftO.top + (_left.height() / 2), event.pageX, event.pageY);
            objNew.paint();
            $('#' + _index).children('div').eq(0).prepend('<div style="left:' + (_leftO.left + _left.width() + 10) + 'px;top:' + (_leftO.top + (_left.height() / 2)) + 'px;background-color:#' + _color + ';"></div>');
            $('#' + _index).children('div').eq(0).append('<div style="left:' + (event.pageX) + 'px;top:' + (event.pageY) + 'px;background-color:#' + _color + ';"></div>');
        }
    });
    $(document).mouseup(function () {
        var _araypanel = $('.panelMatching[id="' + ID + '"][mouse-move="true"]');
        if (_araypanel.size() > 0) {
            _araypanel.attr('mouse-move', 'false');
            var elementKeo = _araypanel.find('*[mouse-move="true"]');
            var elemrntTha = _araypanel.find('*[mouse-hover="true"]');
            if (elementKeo.size() > 0 && elemrntTha.size() > 0) {
                var _left = elementKeo;
                var _leftO = _left.offsetRelative();
                var _right = elemrntTha;
                var _rightO = _right.offsetRelative();
                var _index = "panelMatching" + $('.panelMatching[id="' + ID + '"]').index(_araypanel) + "_" + _araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo);
                $('#' + _index).remove();
                _araypanel.append('<div id="' + _index + '" class="borderBoKeo borderBoKeoAppend "></div>');
                var objNew = new jsGraphics(_index);
                objNew.setStroke(1);
                var _color = arayColor[_araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo)];
                objNew.setColor("#" + _color);
                var _left = elementKeo.find('.panelMatching-Content-Item-Data');
                var _leftO = _left.offsetRelative();
                objNew.drawLine(_leftO.left + _left.width() + 10, _leftO.top + (_left.height() / 2), _rightO.left - 5, _rightO.top + (_right.height() / 2));
                objNew.paint();
                $('#' + _index).children('div').eq(0).prepend('<div style="left:' + (_leftO.left + _left.width() + 10) + 'px;top:' + (_leftO.top + (_left.height() / 2)) + 'px;background-color:#' + _color + ';"></div>');
                $('#' + _index).children('div').eq(0).append('<div style="left:' + (_rightO.left - 5) + 'px;top:' + (_rightO.top + (_right.height() / 2)) + 'px;border: 2px solid #' + _color + ';"></div>');
                elementKeo.attr('mouse-move', 'false').addClass('panelMatchingSelect').parent('.panelMatching-Content-Item').attr('valtext', elemrntTha.attr('valtext'));
                elemrntTha.attr('mouse-hover', 'false');
            } else if (elementKeo.size() > 0) {
                var _index = "panelMatching" + $('.panelMatching[id="' + ID + '"]').index(_araypanel) + "_" + _araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo);
                $('#' + _index).remove();
                elementKeo.attr('mouse-move', 'false').removeClass('panelMatchingSelect').parent('.panelMatching-Content-Item').attr('valtext', '');
            }
        }
    });
    //    $(window).resize(function () {
    //        resizeMatching();
    //    });
    //    $(document).mutate('height width', function (element, info) {
    //        resizeMatching();
    //    });
    $('.panelMatching[id="' + ID + '"] .panelMatching-Content-Item .panelMatching-Content-Item-Right').hover(
        function () {
            var _this = $(this);
            _this.attr('mouse-hover', 'true');
        }, function () {
            var _this = $(this);
            _this.attr('mouse-hover', 'false');
        }
    );


    


}

function eventMatching() {
    $(".panelMatching").mousedown(function (event) {
        event.preventDefault();
    });
    $('.panelMatching .panelMatching-Content-Item .panelMatching-Content-Item-Left').mousedown(function (event) {
        if (event.which == 1) {
            $(this).attr('mouse-move', 'true');
            $(this).parents('.panelMatching').attr('mouse-move', 'true');
        }
        event.preventDefault();
    });
    $('.panelMatching').mousemove(function (event) {
        var _araypanel = $('.panelMatching[mouse-move="true"]');
        if (_araypanel.size() > 0) {
            var elementKeo = _araypanel.find('.panelMatching-Content-Item-Left[mouse-move="true"]');
            var _index = "panelMatching" + $('.panelMatching').index(_araypanel) + "_" + _araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo);
            $('#' + _index).remove();
            _araypanel.append('<div id="' + _index + '" class="borderBoKeo borderBoKeoEff"></div>');
            var objNew = new jsGraphics(_index);
            objNew.setStroke(1);
            var _color = arayColor[_araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo)];
            objNew.setColor("#" + _color);
            var _left = elementKeo.find('.panelMatching-Content-Item-Data');
            var _leftO = _left.offsetRelative();
            event.pageY = event.pageY - _araypanel.offset().top;
            event.pageX = event.pageX - _araypanel.offset().left;
            objNew.drawLine(_leftO.left + _left.width() + 10, _leftO.top + (_left.height() / 2), event.pageX, event.pageY);
            objNew.paint();
            $('#' + _index).children('div').eq(0).prepend('<div style="left:' + (_leftO.left + _left.width() + 10) + 'px;top:' + (_leftO.top + (_left.height() / 2)) + 'px;background-color:#' + _color + ';"></div>');
            $('#' + _index).children('div').eq(0).append('<div style="left:' + (event.pageX) + 'px;top:' + (event.pageY) + 'px;background-color:#' + _color + ';"></div>');
        }
    });
    $(document).mouseup(function () {
        var _araypanel = $('.panelMatching[mouse-move="true"]');
        if (_araypanel.size() > 0) {
            _araypanel.attr('mouse-move', 'false');
            var elementKeo = _araypanel.find('*[mouse-move="true"]');
            var elemrntTha = _araypanel.find('*[mouse-hover="true"]');
            if (elementKeo.size() > 0 && elemrntTha.size() > 0) {
                var _left = elementKeo;
                var _leftO = _left.offsetRelative();
                var _right = elemrntTha;
                var _rightO = _right.offsetRelative();
                var _index = "panelMatching" + $('.panelMatching').index(_araypanel) + "_" + _araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo);
                $('#' + _index).remove();
                _araypanel.append('<div id="' + _index + '" class="borderBoKeo borderBoKeoAppend "></div>');
                var objNew = new jsGraphics(_index);
                objNew.setStroke(1);
                var _color = arayColor[_araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo)];
                objNew.setColor("#" + _color);
                var _left = elementKeo.find('.panelMatching-Content-Item-Data');
                var _leftO = _left.offsetRelative();
                objNew.drawLine(_leftO.left + _left.width() + 10, _leftO.top + (_left.height() / 2), _rightO.left - 5, _rightO.top + (_right.height() / 2));
                objNew.paint();
                $('#' + _index).children('div').eq(0).prepend('<div style="left:' + (_leftO.left + _left.width() + 10) + 'px;top:' + (_leftO.top + (_left.height() / 2)) + 'px;background-color:#' + _color + ';"></div>');
                $('#' + _index).children('div').eq(0).append('<div style="left:' + (_rightO.left - 5) + 'px;top:' + (_rightO.top + (_right.height() / 2)) + 'px;border: 2px solid #' + _color + ';"></div>');
                elementKeo.attr('mouse-move', 'false').addClass('panelMatchingSelect').parent('.panelMatching-Content-Item').attr('valtext', elemrntTha.attr('valtext'));
                elemrntTha.attr('mouse-hover', 'false');
            } else if (elementKeo.size() > 0) {
                var _index = "panelMatching" + $('.panelMatching').index(_araypanel) + "_" + _araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo);
                $('#' + _index).remove();
                elementKeo.attr('mouse-move', 'false').removeClass('panelMatchingSelect').parent('.panelMatching-Content-Item').attr('valtext', '');
            }
        }
    });
    //    $(window).resize(function () {
    //        resizeMatching();
    //    });
    //    $(document).mutate('height width', function (element, info) {
    //        resizeMatching();
    //    });
    $('.panelMatching .panelMatching-Content-Item .panelMatching-Content-Item-Right').hover(
        function () {
            var _this = $(this);
            _this.attr('mouse-hover', 'true');
        }, function () {
            var _this = $(this);
            _this.attr('mouse-hover', 'false');
        }
    );
}
function resizeMatching() {
    if (timeResizeMatching) {
        clearTimeout(timeResizeMatching);
    }
    timeResizeMatching = setTimeout(function () {
        $('.panelMatching .panelMatching-Content-Item[valtext!=""]').each(function () {
            var _araypanel = $(this).parents('.panelMatching');
            var elementKeo = $(this).find('.panelMatching-Content-Item-Left');
            var elemrntTha = _araypanel.find('.panelMatching-Content-Item-Right[valtext="' + $(this).attr('valtext') + '"]');
            if (elementKeo.size() > 0 && elemrntTha.size() > 0) {
                var _left = elementKeo;
                var _leftO = _left.offset();
                var _right = elemrntTha;
                var _rightO = _right.offset();
                var _index = "panelMatching" + $('.panelMatching').index(_araypanel) + "_" + _araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo);
                $('#' + _index).remove();
                $('body').append('<div id="' + _index + '" class="borderBoKeo borderBoKeoAppend"></div>');
                var objNew = new jsGraphics(_index);
                objNew.setStroke(1);
                var _color = arayColor[_araypanel.find('.panelMatching-Content-Item-Left').index(elementKeo)];
                objNew.setColor("#" + _color);
                var _left = elementKeo.find('.panelMatching-Content-Item-Data');
                var _leftO = _left.offset();
                objNew.drawLine(_leftO.left + _left.width() + 10, _leftO.top + (_left.height() / 2), _rightO.left - 5, _rightO.top + (_right.height() / 2));
                objNew.paint();
                $('#' + _index).children('div').eq(0).prepend('<div style="left:' + (_leftO.left + _left.width() + 10) + 'px;top:' + (_leftO.top + (_left.height() / 2)) + 'px;background-color:#' + _color + ';"></div>');
                $('#' + _index).children('div').eq(0).append('<div style="left:' + (_rightO.left - 5) + 'px;top:' + (_rightO.top + (_right.height() / 2)) + 'px;border: 2px solid #' + _color + ';"></div>');
            }
        });
    }, 100);
}
function eventDienCau() {
    $('.panelDienCau .panelDienCau-Content .panelDienCau-Content-AddText input:text').keyup(function (event) {
        var _this = $(this);
        var _parent = _this.parent('.panelDienCau-Content-AddText');
        var textAdd = $.trim(_this.val());
        _parent.find('.panelDienCau-Content-AddText-Data').text(textAdd);
        if (textAdd.length > 0)
            _parent.addClass('panelDienCau-Content-AddText-show');
        else
            _parent.removeClass('panelDienCau-Content-AddText-show');
    }).keyup();
}
function eventKeoThaCau() {
    $(".panelKeoTha-Cau").mousedown(function (event) {
        event.preventDefault();
    });
    $(".panelKeoTha-Cau").mousemove(function (event) {
        if ($(this).attr('mouse-move') == "true") {
            var element = $(this).find('span[mouse-move="true"]');
            if (element.size() > 0) {
                element.find('span').addClass('movekeotha').css({ 'left': (event.pageX - $(document).scrollLeft() - (element.find('span').width() / 2)) + 'px', 'top': (event.pageY - $(document).scrollTop() - 22) + 'px' });
            }
        }
    });
    $(".panelKeoTha-Cau").mouseleave(function (event) {
        $(this).find('span[mouse-move="true"]').attr('mouse-move', 'false').find('span').removeClass('movekeotha');
    });
    $(document).mouseup(function () {
        var _araypanel = $('.panelKeoTha-Cau[mouse-move="true"]')
        if (_araypanel.size() > 0) {
            _araypanel.attr('mouse-move', 'false');
            var elementKeo = _araypanel.find('span[mouse-move="true"]');
            if (elementKeo.size() > 0) {
                var _parent = elementKeo.parents('.panelKeoTha-Cau');
                var elementTha = _parent.find('span[mouse-hover="true"]');
                if (elementTha.size() > 0) {
                    var valtextOld = elementTha.attr('valtext');
                    elementKeo.attr('mouse-move', 'false').find('span').removeClass('movekeotha').parent('span').addClass('dismovekeotha');
                    elementTha.attr('mouse-hover', 'false').attr('valtext', elementKeo.attr('valtext')).addClass('addtextvalue').find('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Data').text(elementKeo.attr('valtext'));
                    _parent.find(".panelKeoTha-Cau-ArrayKeo").find('span[valtext="' + valtextOld + '"]').removeClass('dismovekeotha');
                } else {
                    elementKeo.attr('mouse-move', 'false').find('span').removeClass('movekeotha');
                }
            }
        }
    });
    $('.panelKeoTha-Cau-ArrayKeo-Item').mousedown(function (event) {
        if (event.which == 1 && $(this).attr('class').indexOf('dismovekeotha') <= -1) {
            $(this).attr('mouse-move', 'true');
            var _parenIndex = $(this).parents('.panelKeoTha-Cau').find('.panelKeoTha-Cau-ArrayKeo-Parent').index($(this).parent('.panelKeoTha-Cau-ArrayKeo-Parent'));
            $(this).parents('.panelKeoTha-Cau').attr('mouse-move', 'true').attr('mouse-index', _parenIndex);
        }
        event.preventDefault();
    });
    $('.panelKeoTha-Cau-ArrayTraLoi-Item .panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').click(function () {
        var _this = $(this);
        var valtextOld = $.trim(_this.attr('valtext'));
        var _index = _this.parent('.panelKeoTha-Cau-ArrayTraLoi-Item').find('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').index(_this);
        if (valtextOld != "") {
            $(this).removeClass('addtextvalue').attr('valtext', '').find('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Data').text('');
            var _parent = $(this).parents('.panelKeoTha-Cau');
            _parent.find(".panelKeoTha-Cau-ArrayKeo-Parent").eq(_index).find('span[valtext="' + valtextOld + '"]').removeClass('dismovekeotha');

        }
    });
    $('.panelKeoTha-Cau-ArrayTraLoi-Item .panelKeoTha-Cau-ArrayTraLoi-Item-AddTl .panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Hover').hover(
        function () {
            var _this = $(this);
            var _index = _this.parents('.panelKeoTha-Cau-ArrayTraLoi-Item').find('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').index(_this.parent('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl'));
            if (_index == parseInt(_this.parents('.panelKeoTha-Cau').attr('mouse-index'))) {
                $(this).parent('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').attr('mouse-hover', 'true').addClass('panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Select');
            }
        }, function () {
            var _this = $(this);
            var _index = _this.parents('.panelKeoTha-Cau-ArrayTraLoi-Item').find('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').index(_this.parent('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl'));
            if (_index == parseInt(_this.parents('.panelKeoTha-Cau').attr('mouse-index'))) {
                $(this).parent('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').attr('mouse-hover', 'false').removeClass('panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Select');
            }
        }
    );
    //    $('.panelKeoTha-Cau-ArrayTraLoi-Item .panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').hover(
    //        function () {
    //            var _this = $(this);
    //            var _index = _this.parent('.panelKeoTha-Cau-ArrayTraLoi-Item').find('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').index(_this);
    //            if (_index == parseInt(_this.parents('.panelKeoTha-Cau').attr('mouse-index'))) {
    //                $(this).attr('mouse-hover', 'true').addClass('panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Select');
    //            }
    //        }, function () {
    //            var _this = $(this);
    //            var _index = _this.parent('.panelKeoTha-Cau-ArrayTraLoi-Item').find('.panelKeoTha-Cau-ArrayTraLoi-Item-AddTl').index(_this);
    //            if (_index == parseInt(_this.parents('.panelKeoTha-Cau').attr('mouse-index'))) {
    //                $(this).attr('mouse-hover', 'false').removeClass('panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Select');
    //            }
    //        }
    //    );
}






