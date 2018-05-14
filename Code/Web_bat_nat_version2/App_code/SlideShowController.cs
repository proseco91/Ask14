using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SlideShowController
/// </summary>
public class SlideShowController
{
    ConnectSQL objCon = new ConnectSQL();
    public SlideShowController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAll()
    {
        return objCon.TableWithoutParameter("tblSlideShow_GetAll");
    }
    public DataTable GetAllWithStatus()
    {
        return objCon.TableWithoutParameter("tblSlideShow_GetAll_With_Status");
    }
    public DataTable GetAllWithStatus_GioiThieu()
    {
        return objCon.TableWithoutParameter("tblSlideShow_GetAll_With_Status_GioiThieu");
    }
    public int Insert(string NAME, string IMAGE, string LINK, int SORT_DISPLAY, DateTime CREATED_DATE, int STATUS, string DESCRIPTION, int TYPE)
    {
        string[] arrParam = { "@NAME", "@IMAGE", "@LINK", "@SORT_DISPLAY", "@CREATED_DATE", "@STATUS", "@DESCRIPTION", "@TYPE" };
        object[] arrValue = { NAME, IMAGE, LINK, SORT_DISPLAY, CREATED_DATE, STATUS, DESCRIPTION, TYPE };
        return objCon.insert("tblSlideShow_Insert", arrParam, arrValue);
    }
    public bool Update(int ID, string NAME, string IMAGE, string LINK, int SORT_DISPLAY, int STATUS, string DESCRIPTION, int TYPE)
    {
        string[] arrParam = { "@ID", "@NAME", "@IMAGE", "@LINK", "@SORT_DISPLAY", "@STATUS", "@DESCRIPTION", "@TYPE" };
        object[] arrValue = { ID, NAME, IMAGE, LINK, SORT_DISPLAY, STATUS, DESCRIPTION, TYPE };
        return objCon.Update("tblSlideShow_Update", arrParam, arrValue);
    }
    public DataTable GetDataByID(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return objCon.TableWithParameter("tblSlideShow_GetDataByID", arrParam, arrValue);
    }
    public bool Delete(string id)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { id };
        return objCon.Update("tblSlideShow_Delete", arrParam, arrValue);
    }
}