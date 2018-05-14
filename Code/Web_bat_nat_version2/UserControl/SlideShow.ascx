<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SlideShow.ascx.cs" Inherits="UserControl_SlideShow" %>
<div class="panelSilder">
    <div class="panelHomeFixed" style="position: relative;">
        <div class="listSlider">
            <% 
                System.Data.DataTable dbSlide = dbGetSlideShow();
                for (int i = 0; i < dbSlide.Rows.Count; i++)
                {
                    string link = dbSlide.Rows[i]["LINK"].ToString();
                    string image = dbSlide.Rows[i]["IMAGE"].ToString();
                        
            %>
            <a href="<%=link %>">
                <div class="itemSilder" style="background-image: url('images/SlideShow/<%=image %>')">
                </div>
            </a>
            <%}%>
        </div>
        <div class="listSliderBtn">
            <%for (int i = 0; i < dbSlide.Rows.Count; i++)
              {%>
            <span class="btnSlider"></span>
            <%}%>
        </div>
    </div>
</div>
<script runat="server">
    SlideShowController objSlide = new SlideShowController();
    public System.Data.DataTable dbGetSlideShow()
    {
        return objSlide.GetAllWithStatus();
    }
</script>
