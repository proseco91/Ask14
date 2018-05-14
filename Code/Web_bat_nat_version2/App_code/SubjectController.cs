using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for SubjectController
/// </summary>
public class SubjectController
{
    ConnectSQL objCon = new ConnectSQL();
    public SubjectController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAll()
    {
        return objCon.TableWithoutParameter("tblSubject_GetAll");
    }

    public int Insert(string NAME, string IMAGE, string SUMMURY, DateTime CREATED_DATE, int STATUS, int isHot)
    {
        string[] arrParam = { "@NAME", "@IMAGE", "@SUMMURY", "@CREATED_DATE", "@STATUS", "@isHot" };
        object[] arrValue = { NAME, IMAGE, SUMMURY, CREATED_DATE, STATUS, isHot };
        return objCon.insert("tblSubject_Insert", arrParam, arrValue);
    }
    public bool Update(int ID, string NAME, string IMAGE, string SUMMURY, int STATUS, int isHot)
    {
        string[] arrParam = { "@ID", "@NAME", "@IMAGE", "@SUMMURY", "@STATUS", "@isHot" };
        object[] arrValue = { ID, NAME, IMAGE, SUMMURY, STATUS, isHot };
        return objCon.Update("tblSubject_Update", arrParam, arrValue);
    }
    public DataTable GetDataByID(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return objCon.TableWithParameter("tblSubject_GetDataByID", arrParam, arrValue);
    }
    public DataTable GetAllSubectRelates(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return objCon.TableWithParameter("tblSubject_GetAllDataByID_Relatest", arrParam, arrValue);
    }
    public DataTable GetDataTop5Subject()
    {
        return objCon.TableWithoutParameter("tblSubject_GetDataTop5");
    }
    public bool Delete(string id)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { id };
        return objCon.Update("tblSubject_Delete", arrParam, arrValue);
    }
}