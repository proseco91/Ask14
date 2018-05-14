<%@ WebHandler Language="C#" Class="GetDataNewsByTags" %>

using System;
using System.Web;
using System.Data;

public class GetDataNewsByTags : IHttpHandler
{

    ConnectSQL cnts = new ConnectSQL();
    NewsTagsController objNewsTags = new NewsTagsController();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";
        int from = 1;
        int to = 6;
        int ID = 43;
        try
        {
            from = Int32.Parse(context.Request.QueryString["from"].ToString());
            to = Int32.Parse(context.Request.QueryString["to"].ToString());
            ID = Int32.Parse(context.Request.QueryString["TagID"].ToString());
        }
        catch
        {
            from = 1;
            to = 10;
            ID = 43;
        }

        string sXml = cnts.WriteXML(GetData(from, to, ID));
        context.Response.Write(sXml);
    }
    private DataTable GetData(int from, int to, int ID)
    {
        return objNewsTags.GetDataByTagID(from, to, ID);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}