using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_forum : System.Web.UI.UserControl
{
    ConnectSQL cnts = new ConnectSQL();
    SlideShowController objSlide = new SlideShowController();
    SubjectController objSubject = new SubjectController();
    CategoryController objCate = new CategoryController();
    ForumController objForum = new ForumController();
    SchoolController objSchool = new SchoolController();
    CustomerController objCustomer = new CustomerController();
    LinqDataContext sql = new LinqDataContext();
    BizNews objNews = new BizNews();
    public string Customer_avatar = "";
    public string _customerName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Customer_avatar = Session["avatar"].ToString();
            _customerName = Session["customerName"].ToString();
            loadBoxIntro();
        }
    }
    void loadBoxIntro()
    {
        DataTable dbNews = objNews.NewsTop1HotNews();
        if (dbNews.Rows.Count > 0)
        {
            Literal1.Text = dbNews.Rows[0]["TITLE"].ToString();
            ltBoxIntro.Text = dbNews.Rows[0]["CONTENT"].ToString();
            ltDateTime.Text = Convert.ToDateTime(dbNews.Rows[0]["CREATED_DATE"].ToString()).ToString();
        }
    }
    public DataTable getSchool()
    {
        return cnts.GetTableWithCommandText("SELECT TOP 8 * FROM tblSchool where Status=1 order by NEWID()");
    }
    public DataTable GetAllSchool()
    {
        return objSchool.GetAll();
    }
    public DataTable dbGetSlide()
    {
        return objSlide.GetAllWithStatus();
    }
    public DataTable dbGetTop5Subject()
    {
        return objSubject.GetDataTop5Subject();
    }

    public DataTable dbGetTop3Forum()
    {
        return objForum.GetTop3Data_Latest();
    }

    public DataTable dbGetTopOnline()
    {
        return objCustomer.GetDataIsOnline();
    }
}