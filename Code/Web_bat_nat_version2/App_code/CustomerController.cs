using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CustomerController
/// </summary>
public class CustomerController
{
    ConnectSQL cnts = new ConnectSQL();
    public CustomerController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(string CUSTOMER_NAME, string EMAIL, string PHONENUMBER, DateTime DOB, float GENDER, string ADDRESS, string AVARTA, DateTime CREATED_DATE, int STATUS)
    {
        string[] para = new string[] { "@CUSTOMER_NAME", "@EMAIL", "@PHONENUMBER", "@DOB", "@GENDER", "@ADDRESS", "@AVARTA", "@CREATED_DATE", "@STATUS" };
        object[] obj = new object[] { CUSTOMER_NAME, EMAIL, PHONENUMBER, DOB, GENDER, ADDRESS, AVARTA, CREATED_DATE, STATUS };
        return cnts.insert("tblCustomer_Insert", para, obj);
    }
    public DataTable GetAllData()
    {
        string[] para = new string[] { };
        object[] obj = new object[] { };
        return cnts.TableWithParameter("tblCustomer_GetAllData", para, obj);
    }
    public DataTable GetDataByEmail(string EMAIL)
    {
        string[] para = new string[] { "@EMAIL" };
        object[] obj = new object[] { EMAIL };
        return cnts.TableWithParameter("tblCustomer_GetDataByEmail", para, obj);
    }
    public DataTable GetDataByID(string ID)
    {
        string[] para = new string[] { "@ID" };
        object[] obj = new object[] { ID };
        return cnts.TableWithParameter("tblCustomerGetDataByID", para, obj);
    }

    public DataTable GetDataIsOnline()
    {
        return cnts.TableWithoutParameter("tblCustomerGetOnline");
    }


    public bool Delete(string ID)
    {
        string[] para = new string[] { "@ID" };
        object[] obj = new object[] { ID };
        return cnts.Update("tblCustomer_Delete", para, obj);
    }

    public bool UpdateSchool(int ID, int SCHOOL_ID)
    {
        string[] para = new string[] { "@ID", "@SCHOOL_ID" };
        object[] obj = new object[] { ID, SCHOOL_ID };
        return cnts.Update("tblCustomer_UpdateSchool", para, obj);
    }

    public bool Update(int ID, string CUSTOMER_NAME, string EMAIL, string PHONENUMBER, DateTime DOB, float GENDER, string ADDRESS, string AVARTA)
    {
        string[] para = new string[] { "@ID", "@CUSTOMER_NAME", "@EMAIL", "@PHONENUMBER", "@DOB", "@GENDER", "@ADDRESS", "@AVARTA" };
        object[] obj = new object[] { ID, CUSTOMER_NAME, EMAIL, PHONENUMBER, DOB, GENDER, ADDRESS, AVARTA };
        return cnts.Update("tblCustomer_UpdateData", para, obj);
    }
    public DataTable Customer_login_with_network_social(string EMAIL)
    {
        string[] parameter = new string[] { "@EMAIL" };
        object[] obj = new object[] { EMAIL };
        return cnts.TableWithParameter("tblCustomer_Login_network_social", parameter, obj);
    }
    public bool Update_Online(int ID, int IS_ONLINE)
    {
        string[] para = new string[] { "@ID", "@IS_ONLINE" };
        object[] obj = new object[] { ID, IS_ONLINE };
        return cnts.Update("tblCustomer_Update_Is_Online", para, obj);
    }
}