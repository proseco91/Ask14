using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BizEmail
/// </summary>
public class BizEmail
{
    public BizEmail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    ConnectSQL cnts = new ConnectSQL();
    public DataTable GetAll()
    {
        return cnts.TableWithoutParameter("tblEmailTypeSelectAll");
    }
    public DataTable tblEmailTemplateSelectAll()
    {
        return cnts.TableWithoutParameter("tblEmailTemplateSelectAll");
    }
    public DataTable tblEmailTemplateSearch(string emailid)
    {
        return cnts.TableWithParameter("tblEmailTemplateSearch", new string[] { "@EMAILID" }, new object[] { emailid });
    }
    public void tblEmailTemplateUpdate(int EMAILID, string DESCRIPTION, string CONTENT, DateTime CREATEDDATE)
    {
        string[] parameter = new string[]{"@EMAILID","@DESCRIPTION","@CONTENT","@CREATEDDATE"
};
        object[] obj = new object[] { EMAILID, DESCRIPTION, CONTENT, CREATEDDATE };
        cnts.ExcuteStored("tblEmailTemplateUpdate", parameter, obj);
    }
    public void tblEmailTemplateDelete(int EMAILID)
    {
        string[] parameter = new string[]{"@EMAILID"
};
        object[] obj = new object[] { EMAILID };
        cnts.ExcuteStored("tblEmailTemplateDelete", parameter, obj);
    }
    public void tblEmailTemplateInsert(string DESCRIPTION, string CONTENT, int STATUS, DateTime CREATEDDATE)
    {
        string[] parameter = new string[]{"@DESCRIPTION","@CONTENT","@STATUS","@CREATEDDATE"
};
        object[] obj = new object[] { DESCRIPTION, CONTENT, STATUS, CREATEDDATE };
        cnts.ExcuteStored("tblEmailTemplateInsert", parameter, obj);
    }


}