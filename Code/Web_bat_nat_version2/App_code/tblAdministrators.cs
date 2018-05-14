using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for tblAdministrators
/// </summary>
public class tblAdministrators
{
    public tblAdministrators()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //@STATUS INT,
    //    @STARTINDEX INT,
    //    @MAXRECORDS INT
    ConnectSQL cnts = new ConnectSQL();
    public DataTable tblAdministratorsSelectWithPaged(int STATUS, int STARTINDEX, int MAXRECORDS)
    {
        return cnts.TableWithParameter("tblAdministratorsSelectWithPaged", new string[] { "@STATUS", "@STARTINDEX", "@MAXRECORDS" }
            , new object[] { STATUS, STARTINDEX, MAXRECORDS });
    }
    public DataTable tblAdministratorsValidateEmailandUserName(string username, string email)
    {
        //nvarchar(200),
        // nvarchar(50)
        return cnts.TableWithParameter("tblAdministratorsValidateEmailandUserName", new string[] { "@USERNAME ", "@EMAIL" }
         , new object[] { username, email });
    }
    public bool LoginReturn(string username, string password)
    {
        DataTable db = cnts.TableWithParameter("LoginReturn", new string[] { "@USERNAME", "@PASSWORD" }, new object[] { username, password });
        if (db.Rows[0][0].ToString() == "OK")
            return true;
        else return false;
    }
    public int InsertAdministrators(string fullname, string username,
        string password, string address, string phonenumber, string email,
         int sortdisplay, DateTime createdate, string createdby, DateTime modified_date, string modified_by, int status, string roll)
    {
        string[] parameter = new string[] { "@FULL_NAME", "@USERNAME", "@PASSWORD", "@ADDRESS", "@PHONE_NUMBER",
            "@EMAIL", "@SORT_DISPLAY ", "@CREATED_DATE","@CREATED_BY", "@MODIFIED_DATE", "@MODIFIED_BY", "@STATUS","@ROLL" };
        object[] objVal = new object[] { fullname, username, password, address, phonenumber, email, sortdisplay, createdate, createdby, modified_date, modified_by, status, roll };
        return cnts.insert("tblAdministratorsInsert", parameter, objVal);


    }

    public void UpdateAdministrators(string admin_id, string fullname, string username, string PASSWORD,
        string address, string phonenumber, string email,
         int sortdisplay, DateTime createdate, string createdby, DateTime modified_date, string modified_by, int status, string roll)
    {
        string[] parameter = new string[] {"@ADMIN_ID", "@FULL_NAME", "@USERNAME", "@PASSWORD", "@ADDRESS", "@PHONE_NUMBER",
            "@EMAIL", "@SORT_DISPLAY ", "@CREATED_DATE","@CREATED_BY", "@MODIFIED_DATE", "@MODIFIED_BY", "@STATUS","@ROLL" };
        object[] objVal = new object[] { admin_id, fullname, username, PASSWORD, address, phonenumber, email, sortdisplay, createdate, createdby, modified_date, modified_by, status, roll };
        cnts.ExcuteStored("tblAdministratorsUpdate", parameter, objVal);


    }

    public DataTable SearchAdMin(string AdminID)
    {
        string[] para = new string[] { "@ADMIN_ID" };
        string[] obj = new string[] { AdminID };
        return cnts.TableWithParameter("AdminstratorsSearchByID", para, obj);
    }
    public void DeleteAdmin(string AdminID)
    {
        string[] para = new string[] { "@ADMIN_ID" };
        string[] obj = new string[] { AdminID };
        cnts.ExcuteStored("tblAdministratorsDelete", para, obj);
    }

    // xuan hau

    public DataTable GetByUserAndPass(string username, string password)
    {
        string[] para = new string[] { "@USERNAME", "@PASSWORD" };
        string[] obj = new string[] { username, password };
        return cnts.TableWithParameter("tblAdministrator_GetByUserAndPass", para, obj);
    }

    public bool UpdateByUsername(string username, string password)
    {
        string[] para = new string[] { "@USERNAME", "@PASSWORD" };
        string[] obj = new string[] { username, password };
        return cnts.Update("tblAdministrator_UpdateByUsername", para, obj);
    }


    public DataTable GetAllData()
    {
        return cnts.TableWithoutParameter("tblAdministrators_GetAllData");
    }

}