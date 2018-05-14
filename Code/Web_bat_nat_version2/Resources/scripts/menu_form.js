$(function() {
    $('.error').hide();
    $('input').css({ backgroundColor: "#FFFFFF" });
    $('input').focus(function() {
        $(this).css({ backgroundColor: "#FFDDAA" });
    });
    $('input').blur(function() {
        $(this).css({ backgroundColor: "#FFFFFF" });
    });

    $(".button").click(function() {
        $('.error').hide();
        
        var modulename = $("input#txtMenuName").val();
        if (modulename == "") {
            $("span#Module_Error").show();
            $("input#txtMenuName").focus();
            return false;
        }

    });
});