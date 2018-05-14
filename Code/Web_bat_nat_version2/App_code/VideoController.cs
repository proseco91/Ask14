using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for VideoController
/// </summary>
public class VideoController
{
    ConnectSQL cnts = new ConnectSQL();
    public VideoController()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int Insert(string NAME, string LINK_YOUTUBE, string DESCRIPTION, int SORT_DISPLAY, DateTime CREATE_DATE, int STATUS)
    {
        string[] arrParam = { "@NAME", "@LINK_YOUTUBE", "@DESCRIPTION", "@SORT_DISPLAY", "@CREATE_DATE", "@STATUS" };
        object[] arrValue = { NAME, LINK_YOUTUBE, DESCRIPTION, SORT_DISPLAY, CREATE_DATE, STATUS };
        return cnts.insert("tblVideoInsert", arrParam, arrValue);
    }

    public bool Update(int VIDEO_ID, string NAME, string LINK_YOUTUBE, string DESCRIPTION, int SORT_DISPLAY, DateTime CREATE_DATE, int STATUS)
    {
        string[] arrParam = { "@VIDEO_ID", "@NAME", "@LINK_YOUTUBE", "@DESCRIPTION", "@SORT_DISPLAY", "@CREATE_DATE", "@STATUS" };
        object[] arrValue = { VIDEO_ID, NAME, LINK_YOUTUBE, DESCRIPTION, SORT_DISPLAY, CREATE_DATE, STATUS };
        return cnts.Update("tblVideoEdit", arrParam, arrValue);
    }

    public bool Delete(int VIDEO_ID)
    {
        string[] arrParam = { "@VIDEO_ID" };
        object[] arrValue = { VIDEO_ID };
        return cnts.Update("tblVideo_Delete", arrParam, arrValue);
    }
    public DataTable GetDataByID(int VIDEO_ID)
    {
        string[] arrParam = { "@VIDEO_ID" };
        object[] arrValue = { VIDEO_ID };
        return cnts.TableWithParameter("tblVideo_GetByID", arrParam, arrValue);
    }
    public DataTable GetAllData_Pagging(int from, int to)
    {
        string[] arrParam = { "@from", "@to" };
        object[] arrValue = { from, to };
        return cnts.TableWithParameter("tblVideo_PagingData", arrParam, arrValue);
    }
    public DataTable GetTop5VideoNew()
    {
        return cnts.TableWithoutParameter("tblVideoTop5Relate");
    }
}