using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    ConnectSQL cnts = new ConnectSQL();
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public bool DisplayCategoryStatus(string ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblCategory_UpdateStatus", arrParam, arrValue);
    }

    [WebMethod]
    public bool DisplayNews(string ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblNews_UpdateStatus", arrParam, arrValue);
    }


    [WebMethod]
    public bool DisplayAdministrator(string ID)
    {
        string[] arrParam = { "@ADMIN_ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblAdministrators_UpdateStatus", arrParam, arrValue);
    }

    [WebMethod]
    public bool DisplayStatusTags(string ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblTags_UpdateStatus", arrParam, arrValue);
    }

    [WebMethod]
    public bool DisplaySubject(string ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblSubject_UpdateStatus", arrParam, arrValue);
    }


    [WebMethod]
    public bool DisplayThueXeStatus(string ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblThueXe_UpdateStatus", arrParam, arrValue);
    }

    [WebMethod]
    public bool DisplayTourStatus(string ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblDatTour_UpdateStatus", arrParam, arrValue);
    }
    [WebMethod]
    public bool DisplayDatPhongKhachSan(string ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblDatPhongKhachSan_UpdateStatus", arrParam, arrValue);
    }
    [WebMethod]
    public bool DisplayDatVe(string ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblDatVe_UpdateStatus", arrParam, arrValue);
    }
}
