using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for LienHeController
/// </summary>
public class LienHeController
{
    ConnectSQL cnts = new ConnectSQL();
    public LienHeController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAllData()
    {
        return cnts.TableWithoutParameter("tblLienHe_GetAllData");
    }
    public int Insert(int CUSTOMER_ID, string CONTENT, DateTime CREATED_DATE, int STATUS)
    {
        string[] arrParam = { "@CUSTOMER_ID", "@CONTENT", "@CREATED_DATE", "@STATUS" };
        object[] arrValue = { CUSTOMER_ID, CONTENT, CREATED_DATE, STATUS };
        return cnts.insert("tblLienHeInsert", arrParam, arrValue);
    }

}