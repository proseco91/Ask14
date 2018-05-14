<%@ WebHandler Language="C#" Class="GetFAQ" %>

using System;
using System.Web;
using System.Data;

public class GetFAQ : IHttpHandler
{

    HoiDapController objHoiDap = new HoiDapController();
    ConnectSQL cnts = new ConnectSQL();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";
        int from = 1;
        int to = 6;
        try
        {
            from = Int32.Parse(context.Request.QueryString["from"].ToString());
            to = Int32.Parse(context.Request.QueryString["to"].ToString());
        }
        catch
        {
            from = 1;
            to = 10;
        }

        string sXml = cnts.WriteXML(GetData(from, to));
        context.Response.Write(sXml);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    private DataTable GetData(int from, int to)
    {
        return objHoiDap.GetAllDataPagging(from, to);
    }


}