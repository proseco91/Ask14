using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for EventCommentController
/// </summary>
public class EventCommentController
{
    ConnectSQL cnts = new ConnectSQL();
    public EventCommentController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertEventComment(string customerevent, string content, string sender, string servicetype, string customer_id, int CO_SO)
    {
        string[] arrParam = { "@CUSTOMEREVENT", "@CONTENT", "@SENDER", "@SERVICETYPE", "@CUSTOMER_ID", "@CO_SO" };
        object[] arrValue = { customerevent, content, sender, servicetype, customer_id, CO_SO };
        return cnts.insert("tblEventComment_Insert2", arrParam, arrValue);
    }
    public DataTable GetAllData()
    {
        string[] arrParam = { };
        object[] arrValue = { };
        return cnts.TableWithParameter("tblEventComment_GetAllData", arrParam, arrValue);
    }
}