using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RoleController
/// </summary>
public class RoleController
{
    private ConnectSQL objCon = new ConnectSQL();
    public RoleController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAll()
    {
        string[] arrParam = { };
        object[] arrValue = { };
        return objCon.TableWithParameter("tblRole_GetAll", arrParam, arrValue);
    }

    public DataTable GetAll_C()
    {
        string[] arrParam = { };
        object[] arrValue = { };
        return objCon.TableWithParameter("tblRole_GetAll_C", arrParam, arrValue);
    }

    public int Insert(string title, string status)
    {
        string[] arrParam = { "@ROLENAME", "@STATUS", "@isActive" };
        object[] arrValue = { title, status, 1 };
        return objCon.insert("tblRole_Insert", arrParam, arrValue);
    }

    public bool Update(string id, string title, string status)
    {
        string[] arrParam = { "@ID", "@ROLENAME", "@STATUS" };
        object[] arrValue = { id, title, status };
        return objCon.Update("tblRole_Update", arrParam, arrValue);
    }

    public bool Delete(string id)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { id };
        return objCon.Update("tblRole_Delete", arrParam, arrValue);
    }   
}