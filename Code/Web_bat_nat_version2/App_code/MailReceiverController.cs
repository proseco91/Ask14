using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BizEmail
/// </summary>
public class MailReceiverController
{
    public MailReceiverController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    ConnectSQL cnts = new ConnectSQL();
    public DataTable GetAll()
    {
        return cnts.TableWithoutParameter("tblMailReceiver_GetData");
    }

    public int Insert(string email, string fullname, string status)
    {
        string[] arrParam = { "@EMAIL", "@FULLNAME", "@STATUS" };
        string[] arrValue = { email, fullname, status };
        return cnts.insert("tblMailReceiver_Insert", arrParam, arrValue);
    }

    public bool Update(string id, string email, string fullname, string status)
    {
        string[] arrParam = { "@ID", "@EMAIL", "@FULLNAME", "@STATUS" };
        string[] arrValue = { id, email, fullname, status };
        return cnts.Update("tblMailReceiver_Update", arrParam, arrValue);
    }

    public bool Delete(string id)
    {
        string[] arrParam = { "@ID" };
        string[] arrValue = { id };
        return cnts.Update("tblMailReceiver_Delete", arrParam, arrValue);
    }

    public DataTable GetById(string id)
    {
        string[] arrParam = { "@ID" };
        string[] arrValue = { id };
        return cnts.TableWithParameter("tblMailReceiver_GetByID", arrParam, arrValue);
    }

}