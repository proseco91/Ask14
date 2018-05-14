using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for SchoolController
/// </summary>
public class SchoolController
{
    ConnectSQL objCon = new ConnectSQL();
    public SchoolController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAll()
    {
        return objCon.TableWithoutParameter("tblSchool_GetAll");
    }

    public int Insert(string School_Name, string School_Image, DateTime Created_Date, int Status, string Link_Facebook)
    {
        string[] arrParam = { "@School_Name", "@School_Image", "@Created_Date", "@Status", "@Link_Facebook" };
        object[] arrValue = { School_Name, School_Image, Created_Date, Status, Link_Facebook };
        return objCon.insert("tblSchool_Insert", arrParam, arrValue);
    }
    public bool Update(int ID, string School_Name, string School_Image, int Status, string Link_Facebook)
    {
        string[] arrParam = { "@ID", "@School_Name", "@School_Image", "@Status", "@Link_Facebook" };
        object[] arrValue = { ID, School_Name, School_Image, Status, Link_Facebook };
        return objCon.Update("tblSchool_Update", arrParam, arrValue);
    }
    public DataTable GetDataByID(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return objCon.TableWithParameter("tblSchool_GetDataByID", arrParam, arrValue);
    }
    public DataTable CoutCommentSchool(int SCHOOL_ID)
    {
        string[] arrParam = { "@SCHOOL_ID" };
        object[] arrValue = { SCHOOL_ID };
        return objCon.TableWithParameter("tblSchool_CountComment", arrParam, arrValue);
    }
    public DataTable CoutNewsInSchool(int SCHOOL_ID)
    {
        string[] arrParam = { "@SCHOOL_ID" };
        object[] arrValue = { SCHOOL_ID };
        return objCon.TableWithParameter("tblSchool_CountNews", arrParam, arrValue);
    }
}