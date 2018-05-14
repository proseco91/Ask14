using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UploadFileController
/// </summary>
public class UploadFileController
{
    ConnectSQL cnts = new ConnectSQL();
    public UploadFileController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(string FILE_NAME, DateTime CREATED_DATE, int STATUS)
    {
        string[] arrParam = { "@FILE_NAME", "@CREATED_DATE", "@STATUS" };
        object[] arrValue = { FILE_NAME, CREATED_DATE, STATUS };
        return cnts.insert("tblUploadFile_Insert", arrParam, arrValue);
    }
    public DataTable GetDataByID(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.TableWithParameter("tblUploadFile_GetByID", arrParam, arrValue);
    }
    public DataTable GetAllData()
    {
        return cnts.TableWithoutParameter("tblUploadFile_GetAllData");
    }
}