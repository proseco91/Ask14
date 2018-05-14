<%@ WebHandler Language="C#" Class="GetDataNewsBySchool" %>

using System;
using System.Web;
using System.Data;

public class GetDataNewsBySchool : IHttpHandler
{

    ConnectSQL cnts = new ConnectSQL();
    BizNews objNews = new BizNews();
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
            ID = Int32.Parse(context.Request.QueryString["SchoolId"].ToString());
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
        return objNews.GetDataBySchoolId(from, to, ID);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}