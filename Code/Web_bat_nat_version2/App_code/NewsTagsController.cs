using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for NewsTagsController
/// </summary>
public class NewsTagsController
{
    ConnectSQL objCon = new ConnectSQL();
    public NewsTagsController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(int News_ID, string TAG_ID, DateTime CREATED_DATE, int STATUS)
    {
        string[] arrParam = { "@News_ID", "@TAG_ID", "@CREATED_DATE", "@STATUS" };
        object[] arrValue = { News_ID, TAG_ID, CREATED_DATE, STATUS };
        return objCon.insert("tblNewsTags_Insert", arrParam, arrValue);
    }
    public bool Update(int News_ID, string TAG_ID)
    {
        string[] arrParam = { "@News_ID", "@TAG_ID" };
        object[] arrValue = { News_ID, TAG_ID };
        return objCon.Update("tblNewsTags_Update", arrParam, arrValue);
    }
    public bool removeTagsID(string TAG_ID)
    {
        string[] arrParam = { "@TAG_ID" };
        object[] arrValue = { TAG_ID };
        return objCon.Update("tblNewsTags_removeTags", arrParam, arrValue);
    }
    public DataTable dataCheckTags(int News_ID)
    {
        string[] arrParam = { "@News_ID" };
        object[] arrValue = { News_ID };
        return objCon.TableWithParameter("tblNewsTags_CheckTags", arrParam, arrValue);
    }
    public DataTable GetDataByTagID(int from, int to, int TagID)
    {
        string[] arrParam = { "@from", "@to", "@TagID" };
        object[] arrValue = { from, to, TagID };
        return objCon.TableWithParameter("tblNews_PagingDataByTags", arrParam, arrValue);
    }
}