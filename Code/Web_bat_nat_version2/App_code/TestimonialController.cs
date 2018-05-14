using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for TestimonialController
/// </summary>
public class TestimonialController
{
    ConnectSQL cnts = new ConnectSQL();
    public TestimonialController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(string NAME, string IMAGE, string SUMMURY, string DESCRIPTION, DateTime CREATED_DATE, int STATUS)
    {
        string[] para = new string[] { "@NAME", "@IMAGE", "@SUMMURY", "@DESCRIPTION", "@CREATED_DATE", "@STATUS" };
        object[] obj = new object[] { NAME, IMAGE, SUMMURY, DESCRIPTION, CREATED_DATE, STATUS };
        return cnts.insert("tblTestimonialInsert", para, obj);
    }
    public bool Update(int ID, string NAME, string IMAGE, string SUMMURY, string DESCRIPTION, DateTime CREATED_DATE, int STATUS)
    {
        string[] parameter = new string[] { "@ID", "@NAME", "@IMAGE", "@SUMMURY", "@DESCRIPTION", "@CREATED_DATE", "@STATUS" };
        object[] obj = new object[] { ID, NAME, IMAGE, SUMMURY, DESCRIPTION, CREATED_DATE, STATUS };
        return cnts.Update("tblTestimonialUpdate", parameter, obj);
    }
    public DataTable GetDataByID(string id)
    {
        return cnts.TableWithParameter("tblTestimonialGetbyID", new string[] { "@ID" }, new object[] { id });
    }
    public DataTable GetAllData()
    {
        return cnts.TableWithoutParameter("tblTestimonial_GetAll");
    }

    public void Delete(int ID)
    {
        string[] parameter = new string[]{"@ID"
};
        object[] obj = new object[] { ID };
        cnts.ExcuteStored("tblTestimonialDelete", parameter, obj);
    }
}