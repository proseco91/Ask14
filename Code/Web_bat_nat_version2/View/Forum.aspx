<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HeaderFooter.master" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="View_Forum" %>

<%@ Register src="../UserControl/forum.ascx" tagname="forum" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        var timeClearSlider = setTimeout(function () { }, 1000);
        clearTimeout(timeClearSlider);
        $(document).ready(function () {
            actionSilder(0);
            $('.btnSlider').click(function () {
                var index = $('.btnSlider').index($(this));
                actionSilder(index);
            });
        });
        function actionSilder(index) {
            if (index >= $('.rslides .itemSilder').size())
                index = 0;
            $('.rslides .itemSilder').parent().parent().removeClass('itemSilderSelect');
            $('.rslides .itemSilder').parent().parent().eq(index).addClass('itemSilderSelect');
            $('.listSliderBtn .btnSlider').removeClass('btnSliderSelect');
            $('.listSliderBtn .btnSlider').eq(index).addClass('btnSliderSelect');
            clearTimeout(timeClearSlider);
            timeClearSlider = setTimeout(function () {
                actionSilder($('.rslides .itemSilder').parent().parent().index($('.rslides').find('.itemSilderSelect')) + 1);
            }, 5000);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" runat="Server">
  
    <uc1:forum ID="forum1" runat="server" />
    <script type="text/javascript">
        var _category = "62";
        activeitem(_category);

    </script>
    
</asp:Content>

