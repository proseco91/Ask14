using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for techerController
/// </summary>
public class techerController
{
    ConnectSQL cnts = new ConnectSQL();
    public techerController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAll()
    {
        string[] arrParam = { };
        object[] arrValue = { };
        return cnts.TableWithParameter("tblTeacher_GetData", arrParam, arrValue);
    }
    public DataTable GetByID(int TEACHER_ID)
    {
        string[] arrParam = { "@TEACHER_ID" };
        object[] arrValue = { TEACHER_ID };
        return cnts.TableWithParameter("tblTeacher_getByID", arrParam, arrValue);
    }
    public void Insert(string NAME, string IMAGE, string DESCRIPTION, DateTime CREATED_DATE, int STATUS)
    {
        string[] arrParam = { "@NAME", "@IMAGE", "@DESCRIPTION", "@CREATED_DATE", "@STATUS" };
        object[] arrValue = { NAME, IMAGE, DESCRIPTION, CREATED_DATE, STATUS };
        cnts.ExcuteStored("tblTeacher_Insert", arrParam, arrValue);
    }

    public bool Update(int TEACHER_ID, string NAME, string IMAGE, string DESCRIPTION, DateTime CREATED_DATE, int STATUS)
    {
        string[] arrParam = { "@TEACHER_ID", "@NAME", "@IMAGE", "@DESCRIPTION", "@CREATED_DATE", "@STATUS" };
        object[] arrValue = { TEACHER_ID, NAME, IMAGE, DESCRIPTION, CREATED_DATE, STATUS };
        return cnts.Update("tblTeacher_Update", arrParam, arrValue);
    }

    public bool Delete(string id)
    {
        string[] arrParam = { "@TEACHER_ID" };
        object[] arrValue = { id };
        return cnts.Update("tblTeacher_Delete", arrParam, arrValue);
    }
}