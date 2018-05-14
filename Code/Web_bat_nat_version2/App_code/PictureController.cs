using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PictureController
/// </summary>
public class PictureController
{
    ConnectSQL cnts = new ConnectSQL();
    public PictureController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(string TITLE, string AVARTA, string DESCRIPTION, DateTime CREATED_DATE, int STATUS)
    {
        string[] arrParam = { "@TITLE", "@AVARTA", "@DESCRIPTION", "@CREATED_DATE", "@STATUS" };
        object[] arrValue = { TITLE, AVARTA, DESCRIPTION, CREATED_DATE, STATUS };
        return cnts.insert("tblPicture_Insert", arrParam, arrValue);
    }

    public bool Update(int ID, string TITLE, string AVARTA, string DESCRIPTION, int STATUS)
    {
        string[] arrParam = { "@ID", "@TITLE", "@AVARTA", "@DESCRIPTION", "@STATUS" };
        object[] arrValue = { ID, TITLE, AVARTA, DESCRIPTION, STATUS };
        return cnts.Update("tblPicture_Edit", arrParam, arrValue);
    }

    public bool Delete(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblPicture_Delete", arrParam, arrValue);
    }
    public DataTable GetDataByID(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.TableWithParameter("tblPicture_GetDataByID", arrParam, arrValue);
    }
    public DataTable GetAllData_Pagging(int from, int to)
    {
        string[] arrParam = { "@from", "@to" };
        object[] arrValue = { from, to };
        return cnts.TableWithParameter("tblPicture_PagingData", arrParam, arrValue);
    }
    public DataTable GetTop5Album(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.TableWithParameter("tblPicture_GetTop5Album", arrParam, arrValue);
    }
}