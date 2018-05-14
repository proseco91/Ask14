<%@ WebHandler Language="C#" Class="calldetail" %>

using System;
using System.Web;
using Newtonsoft.Json;
public class calldetail : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    private CustomerController objCustomer = new CustomerController();
    private ConnectSQL objConnect = new ConnectSQL();
    EventCommentController objComment = new EventCommentController();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string id = context.Request.QueryString["id"].ToString();
        string desc = context.Request.QueryString["desc"].ToString();
        string sender = context.Session["username"].ToString();
        //string IDClass = context.Session["ID_Class"].ToString();
        string serviceType = "";


        int a = InsertDescription(id, desc, serviceType, id, sender, 1);
        if (a > 0)
        {
            context.Response.Write(JsonConvert.SerializeObject(new object[] { true, a }));
        }
        else
        {
            context.Response.Write("false");
        }

    }
    public int InsertDescription(string id, string desc, string serviceType, string customerID, string sender, int CO_SO)
    {
        return objComment.InsertEventComment(id, desc, sender, serviceType, customerID, CO_SO);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}