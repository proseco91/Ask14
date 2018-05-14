using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BizNews
/// </summary>
public class BizNews
{
    ConnectSQL cnts = new ConnectSQL();
    public BizNews()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable NewsSelectAll()
    {
        return cnts.TableWithoutParameter("tblNewsSelectAll");
    }
    public DataTable NewsTop1Introduce()
    {
        return cnts.TableWithoutParameter("tblNewsTop1_Introduce");
    }
    public DataTable NewsTop1HotNews()
    {
        return cnts.TableWithoutParameter("tblNewsTop1_HotNews");
    }

    public DataTable GetDataByCategory(int CATEGORYID)
    {
        string[] para = new string[] { "@CATEGORYID" };
        object[] obj = new object[] { CATEGORYID };
        return cnts.TableWithParameter("tblNews_GetDataByCategoryID", para, obj);
    }

    public DataTable NewsTop4ByCate(int PARENT_ID)
    {
        string[] para = new string[] { "@PARENT_ID" };
        object[] obj = new object[] { PARENT_ID };
        return cnts.TableWithParameter("tblNews_GetTop4ByCate", para, obj);
    }

    public int Insert(string CATEGORYID, string TITLE, string IMAGE, string SUMMARY, string CONTENT, int SORT_DISPLAY, DateTime CREATED_DATE, int STATUS, string META_KEYWORD, string META_DESCRIPTION, int IS_HOT, int IS_HIGHTLIGHT, int SchoolId)
    {
        string[] para = new string[] { "@CATEGORYID", "@TITLE", "@IMAGE", "@SUMMARY", "@CONTENT", "@SORT_DISPLAY", "@CREATED_DATE", "@STATUS", "@META_KEYWORD", "@META_DESCRIPTION", "@IS_HOT", "@IS_HIGHTLIGHT", "@SchoolId" };
        object[] obj = new object[] { CATEGORYID, TITLE, IMAGE, SUMMARY, CONTENT, SORT_DISPLAY, CREATED_DATE, STATUS, META_KEYWORD, META_DESCRIPTION, IS_HOT, IS_HIGHTLIGHT, SchoolId };
        return cnts.insert("tblNewsInsert", para, obj);
    }

    public DataTable SelectByModuleID(int TYPE)
    {
        return cnts.TableWithParameter("tblNewsByModuleID", new string[] { "@CATEGORYID" }, new object[] { TYPE });
    }
    public bool tblNewsUpdate(int ID, string CATEGORYID, string TITLE, string IMAGE, string SUMMARY, string CONTENT, int SORT_DISPLAY, int STATUS, string META_KEYWORD, string META_DESCRIPTION, int IS_HOT, int IS_HIGHTLIGHT, int SchoolId)
    {
        string[] parameter = new string[] { "@ID", "@CATEGORYID", "@TITLE", "@IMAGE", "@SUMMARY", "@CONTENT", "@SORT_DISPLAY", "@STATUS", "@META_KEYWORD", "@META_DESCRIPTION", "@IS_HOT", "@IS_HIGHTLIGHT", "@SchoolId" };
        object[] obj = new object[] { ID, CATEGORYID, TITLE, IMAGE, SUMMARY, CONTENT, SORT_DISPLAY, STATUS, META_KEYWORD, META_DESCRIPTION, IS_HOT, IS_HIGHTLIGHT, SchoolId };
        return cnts.Update("tblNewsUpdate", parameter, obj);
    }
    public DataTable GetNewsByID(string id)
    {
        return cnts.TableWithParameter("tblNewsSelectbyID", new string[] { "@ID" }, new object[] { id });
    }
    public DataTable GetNewsByCategoryID(string CATEGORYID)
    {
        return cnts.TableWithParameter("tblNewsSelectbyCategoryID", new string[] { "@CATEGORYID" }, new object[] { CATEGORYID });
    }
    public DataTable GetNewsByCategoryID_Top5_RelatedNews(string CATEGORYID)
    {
        return cnts.TableWithParameter("tblNewsSelectbyCategoryID_Top5_RelatedNews", new string[] { "@CATEGORYID" }, new object[] { CATEGORYID });
    }
    public void tblNewsDelete(int NEWSID)
    {
        string[] parameter = new string[] { "@ID" };
        object[] obj = new object[] { NEWSID };
        cnts.ExcuteStored("tblNewsDelete", parameter, obj);
    }
    public DataTable GetAllData(string from, string to, string CATEGORYID)
    {
        string[] arrParam = { "@from", "@to", "@CATEGORYID" };
        object[] arrValue = { from, to, CATEGORYID };
        return cnts.TableWithParameter("tblNews_GetAllData", arrParam, arrValue);
    }
    public DataTable GetDataNewsSearch(string from, string to, string keySearch)
    {
        string[] arrParam = { "@from", "@to", "@keySearch" };
        object[] arrValue = { from, to, keySearch };
        return cnts.TableWithParameter("tblNews_GetDataSearch", arrParam, arrValue);
    }

    public DataTable SearchByTitle(string TITLE)
    {
        string[] arrParam = { "@TITLE" };
        object[] arrValue = { TITLE };
        return cnts.TableWithParameter("SearchByTitle", arrParam, arrValue);
    }


    public DataTable GetDataByCategory(int from, int to, int CATEGORYID)
    {
        string[] arrParam = { "@from", "@to", "@CATEGORYID" };
        object[] arrValue = { from, to, CATEGORYID };
        return cnts.TableWithParameter("tblNews_PagingDataByModule", arrParam, arrValue);
    }


    public DataTable GetDataBySchoolId(int from, int to, int SchoolId)
    {
        string[] arrParam = { "@from", "@to", "@SchoolId" };
        object[] arrValue = { from, to, SchoolId };
        return cnts.TableWithParameter("tblNews_PagingDataBySchoolId", arrParam, arrValue);
    }

    public DataTable GetTop1DataByCategory(int CATEGORYID)
    {
        string[] arrParam = { "@CATEGORYID" };
        object[] arrValue = { CATEGORYID };
        return cnts.TableWithParameter("tblNews_Top1ByCate", arrParam, arrValue);
    }
    public DataTable GetTop3_highlights()
    {
        //string[] arrParam = { "@ID" };
        //object[] arrValue = { ID };
        return cnts.TableWithoutParameter("tblNews_Top3");
    }
    public DataTable GetNewsByCategoryID_Top5_Related(int ID, int CATEGORYID)
    {
        return cnts.TableWithParameter("tblNewsTop3ByCategoryID", new string[] { "@ID", "@CATEGORYID" }, new object[] { ID, CATEGORYID });
    }


}