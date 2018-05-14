using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ForumController
/// </summary>
public class ForumController
{
    ConnectSQL objCon = new ConnectSQL();
    public ForumController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAll()
    {
        return objCon.TableWithoutParameter("tblForum_GetAll");
    }

    public int Insert(int SubjectID, int CustomerID, string Article_Name, string Article_Content, DateTime Created_Date, int Status)
    {
        string[] arrParam = { "@SubjectID", "@CustomerID", "@Article_Name", "@Article_Content", "@Created_Date", "@Status" };
        object[] arrValue = { SubjectID, CustomerID, Article_Name, Article_Content, Created_Date, Status };
        return objCon.insert("tblForum_Insert", arrParam, arrValue);
    }
    public bool Update(int ID, int SubjectID, string Article_Name, string Article_Content,  int Status)
    {
        string[] arrParam = { "@ID", "@SubjectID", "@Article_Name", "@Article_Content", "@Status" };
        object[] arrValue = { ID, SubjectID, Article_Name, Article_Content, Status };
        return objCon.Update("tblForum_Update", arrParam, arrValue);
    }
    public DataTable GetDataByID(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return objCon.TableWithParameter("tblForum_GetDataByID", arrParam, arrValue);
    }
    public DataTable GetTop5DataBy_SubjectID(int ID, int SubjectID)
    {
        string[] arrParam = { "@ID", "@SubjectID" };
        object[] arrValue = { ID, SubjectID };
        return objCon.TableWithParameter("tblForum_top5_GetDataBySubjectID", arrParam, arrValue);
    }


    public DataTable GetTop3Data_Latest()
    {
        return objCon.TableWithoutParameter("tblForum_top3_GetData_Latest");
    }

    public DataTable GetDataBySubjectID(int SubjectID)
    {
        string[] arrParam = { "@SubjectID" };
        object[] arrValue = { SubjectID };
        return objCon.TableWithParameter("tblForum_GetDataBySubjectID", arrParam, arrValue);
    }

    public DataTable GetDataBySchoolID(int SchoolID)
    {
        string[] arrParam = { "@SCHOOL_ID" };
        object[] arrValue = { SchoolID };
        return objCon.TableWithParameter("tblForum_GetDataBySchoolID", arrParam, arrValue);
    }

    public bool Delete(string id)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { id };
        return objCon.Update("tblForum_Delete", arrParam, arrValue);
    }

    public DataTable GetDataBySubjectPagging(int from, int to, int SubjectID)
    {
        string[] arrParam = { "@from", "@to", "@SubjectID" };
        object[] arrValue = { from, to, SubjectID };
        return objCon.TableWithParameter("tblForum_PagingDataBySubject", arrParam, arrValue);
    }

    public DataTable GetDataBySchoolPagging(int from, int to, int SCHOOL_ID)
    {
        string[] arrParam = { "@from", "@to", "@SCHOOL_ID" };
        object[] arrValue = { from, to, SCHOOL_ID };
        return objCon.TableWithParameter("tblForum_PagingDataBySchoolID", arrParam, arrValue);
    }
    public DataTable HistoryComment_PaggingData(int from, int to, int CustomerID)
    {
        string[] arrParam = { "@from", "@to", "@CustomerID" };
        object[] arrValue = { from, to, CustomerID };
        return objCon.TableWithParameter("tblHistoryComment_PagingData", arrParam, arrValue);
    }


    public DataTable GetAllData_join_Customer_and_Subject()
    {
        return objCon.TableWithoutParameter("tblForum_GetAllData");
    }

}