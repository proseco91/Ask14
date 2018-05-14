function LT_DrawPaging(iSelectPage, NumberOfItemPerPage, totalItem, funcDrawPage) {
    var temp = parseInt(totalItem) - 1;
    var NumberOfRecord = parseInt(NumberOfItemPerPage);
    var totalPage = Math.floor(temp / NumberOfRecord) + 1;
    var strPage = '';
    iSelectPage = parseInt(iSelectPage);

    if (totalPage > 1) {
        strPage += '<ul class="pagingcontent">';
        if (iSelectPage > 1) {
            strPage += '<li class="paging-img" onclick="' + funcDrawPage + (1) + ');"><img alt="" src="http://ask14.vn/images/first-pager-s.png"/></li>';
            strPage += '<li class="paging-img pagingprev" onclick="' + funcDrawPage + (iSelectPage - 1) + ');"><img alt="" src="http://ask14.vn/images/prev-pager-s.png"/>';
            strPage += '</li>';
        } else {
            strPage += '<li class="first-selected paging-img"><img alt="" src="http://ask14.vn/images/first-pager.png"/></li>';
            strPage += '<li class="first-selected paging-img pagingprev"><img alt="" src="http://ask14.vn/images/prev-pager.png"/>';
            strPage += '</li>';
        }

        if (iSelectPage > totalPage - 1 && iSelectPage > 4)
            strPage += '<li class="pagingdeactive" id="numberPage' + (iSelectPage - 4) + '" onclick="' + funcDrawPage + (iSelectPage - 4) + ');">' + (iSelectPage - 4) + '</li>';
        //neu trang cuoi hoac gan cuoi va so trang lon hon 3 thi hien trang truoc do 3 trang
        if (iSelectPage > totalPage - 2 && iSelectPage > 3)
            strPage += '<li class="pagingdeactive" id="numberPage' + (iSelectPage - 3) + '" onclick="' + funcDrawPage + (iSelectPage - 3) + ');">' + (iSelectPage - 3) + '</li>';
        if (iSelectPage > 2)
            strPage += '<li class="pagingdeactive" id="numberPage' + (iSelectPage - 2) + '" onclick="' + funcDrawPage + (iSelectPage - 2) + ');">' + (iSelectPage - 2) + '</li>';
        if (iSelectPage > 1)
            strPage += '<li class="pagingdeactive" id="numberPage' + (iSelectPage - 1) + '" onclick="' + funcDrawPage + (iSelectPage - 1) + ');">' + (iSelectPage - 1) + '</li>';
        strPage += '<li class="pagingactive" id="numberPage' + iSelectPage + '">' + iSelectPage + '</li>';
        if (iSelectPage < totalPage)
            strPage += '<li class="pagingdeactive" id="numberPage' + (iSelectPage + 1) + '" onclick="' + funcDrawPage + (iSelectPage + 1) + ')">' + (iSelectPage + 1) + '</li>';
        if (iSelectPage + 1 < totalPage)
            strPage += '<li class="pagingdeactive" id="numberPage' + (iSelectPage + 2) + '" onclick="' + funcDrawPage + (iSelectPage + 2) + ')">' + (iSelectPage + 2) + '</li>';
        if (iSelectPage < 3 && totalPage > 2 + iSelectPage)
            strPage += '<li class="pagingdeactive" id="numberPage' + (iSelectPage + 3) + '" onclick="' + funcDrawPage + (iSelectPage + 3) + ');">' + (iSelectPage + 3) + '</li>';
        if (iSelectPage < 2 && totalPage > 4)
            strPage += '<li class="pagingdeactive" id="numberPage' + (iSelectPage + 4) + '" onclick="' + funcDrawPage + (iSelectPage + 4) + ');">' + (iSelectPage + 4) + '</li>';
        if (iSelectPage < totalPage) {
            strPage += '<li class="paging-img pagingnext" onclick="' + funcDrawPage + (iSelectPage + 1) + ');"><img alt="" src="http://ask14.vn/images/next-pager.png"/></li>';
            strPage += '<li class="paging-img" onclick="' + funcDrawPage + (totalPage) + ');"><img alt="" src="http://ask14.vn/images/last-pager.png"/></li>';
            strPage += '</ul>';
        }
        else {
            strPage += '<li class="last-selected paging-img pagingnext"><img alt="" src="http://ask14.vn/images/next-pager-s.png"/></li>';
            strPage += '<li class="last-selected paging-img"><img alt="" src="http://ask14.vn/images/last-pager-s.png"/></li>';
            strPage += '</ul>';
        }
    }
    return strPage;
}



function LT_DrawPagingEmotion(iSelectPage, NumberOfItemPerPage, totalItem, funcDrawPage) {
    var temp = parseInt(totalItem) - 1;
    var NumberOfRecord = parseInt(NumberOfItemPerPage);
    var totalPage = Math.floor(temp / NumberOfRecord) + 1;
    var strPage = '';
    iSelectPage = parseInt(iSelectPage);

    if (totalPage > 1) {
        if (iSelectPage > 1) {
            strPage += '<a onclick="' + funcDrawPage + (iSelectPage - 1) + ');"><img alt="" src="http://ask14.vn/images/emotion-previos.png"/>';
            strPage += '</a>';
        } else {
            strPage += '<a><img alt="" src="http://ask14.vn/images/emotion-previos.png"/></a>';            
        }

        if (iSelectPage < totalPage) {
            strPage += '<a onclick="' + funcDrawPage + (iSelectPage + 1) + ');"><img alt="" src="http://ask14.vn/images/emotion-next.png"/></a>';
        }
        else {
            strPage += '<a><img alt="" src="http://ask14.vn/images/emotion-next.png"/></a>';
        }
    }
    return strPage;
}

