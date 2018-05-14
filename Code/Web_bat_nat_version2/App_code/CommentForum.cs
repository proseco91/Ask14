using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CommentForum
/// </summary>
public class CommentForum
{
    ConnectSQL cnts = new ConnectSQL();
    public CommentForum()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(int ForumID, string Content, int CustomerID, DateTime Created_date, int Status)
    {
        string[] para = new string[] { "@ForumID", "@Content", "@CustomerID", "@Created_date", "@Status" };
        object[] obj = new object[] { ForumID, Content, CustomerID, Created_date, Status };
        return cnts.insert("tblCommentForum_Insert", para, obj);
    }
    public DataTable GetAllData()
    {
        string[] para = new string[] { };
        object[] obj = new object[] { };
        return cnts.TableWithParameter("tblCommentForum_GetAllData", para, obj);
    }
    public DataTable GetDataByID(int ID)
    {
        string[] para = new string[] { "@ID" };
        object[] obj = new object[] { ID };
        return cnts.TableWithParameter("tblCommentForum_GetDataByID", para, obj);
    }
    public DataTable GetDataByForumID(int ForumID)
    {
        string[] para = new string[] { "@ForumID" };
        object[] obj = new object[] { ForumID };
        return cnts.TableWithParameter("tblCommentForum_GetDataBy_ForumID", para, obj);
    }

    //public bool Update(int ForumID)
    //{
    //    string[] para = new string[] { "@ForumID" };
    //    object[] obj = new object[] { ForumID };
    //    return cnts.Update("tblCommentForum_Delete_ForumID", para, obj);
    //}

    public bool DeleteByForum(int ForumID)
    {
        string[] para = new string[] { "@ForumID" };
        object[] obj = new object[] { ForumID };
        return cnts.Update("tblCommentForum_Delete_ForumID", para, obj);
    }

    public bool Delete(int ID)
    {
        string[] para = new string[] { "@ID" };
        object[] obj = new object[] { ID };
        return cnts.Update("tblCommentForum_Delete", para, obj);
    }

    public DataTable GetAllData_Join_Customer_and_Forum()
    {
        return cnts.TableWithoutParameter("tblCommentForum_GetAllData_join_Customer_Forum");
    }



    public bool Update(int ID, string Content, int Status)
    {
        string[] arrParam = { "@ID", "@Content", "@Status" };
        object[] arrValue = { ID, Content, Status };
        return cnts.Update("tblCommentForum_Update", arrParam, arrValue);
    }
}