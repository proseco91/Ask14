using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HoiDapController
/// </summary>
public class HoiDapController
{
    ConnectSQL cnts = new ConnectSQL();
    public HoiDapController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(string DESCRIPTION, string ANSWER, string ADMIN_ANSWER, DateTime CREATED_DATE, int STATUS)
    {
        string[] arrParam = { "@DESCRIPTION", "@ANSWER", "@ADMIN_ANSWER", "@CREATED_DATE", "@STATUS" };
        object[] arrValue = { DESCRIPTION, ANSWER, ADMIN_ANSWER, CREATED_DATE, STATUS };
        return cnts.insert("tblHoiDap_Insert", arrParam, arrValue);
    }

    public bool Update(int ID, string DESCRIPTION, string ANSWER, int STATUS)
    {
        string[] arrParam = { "@ID", "@DESCRIPTION", "@ANSWER", "@STATUS" };
        object[] arrValue = { ID, DESCRIPTION, ANSWER, STATUS };
        return cnts.Update("tblHoiDap_Update", arrParam, arrValue);
    }


    public DataTable GetAll()
    {
        return cnts.TableWithoutParameter("tblHoiDap_GetAllData");
    }
    public bool Delete(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblHoiDap_Delete", arrParam, arrValue);
    }
    public DataTable GetDataByID(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.TableWithParameter("tblHoiDap_GetDataByID", arrParam, arrValue);
    }
    public bool UpdateStatus(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblHoiDap_UpdateStatus", arrParam, arrValue);
    }

    public DataTable GetAllDataPagging(int from, int to)
    {
        string[] arrParam = { "@from", "@to" };
        object[] arrValue = { from, to };
        return cnts.TableWithParameter("tblHoiDap_GetAllData_Pagging", arrParam, arrValue);
    }
}