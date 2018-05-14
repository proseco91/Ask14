<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Session["email"] = "";
        Session["subjectID"] = "";
        Session["chuDeKhac"] = "";
        Session["tenBaiViet"] = "";
        Session["content"] = "";
        Session["avatar"] = "";
        Session["customerName"] = "";
        Session["commentThread"] = "";
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        if (Request.Url.Host.StartsWith("www") && !Request.Url.IsLoopback)
        {
            Response.Redirect("http://ask14.vn" + HttpContext.Current.Request.RawUrl.ToString());
        }
    }   
       
</script>
