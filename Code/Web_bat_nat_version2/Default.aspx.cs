using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    TestimonialController objTestimonial = new TestimonialController();
    BizNews objNews = new BizNews();
    SlideShowController objSlide = new SlideShowController();
    SubjectController objSubject = new SubjectController();
    CategoryController objCate = new CategoryController();
    ForumController objForum = new ForumController();
    SchoolController objSchool = new SchoolController();
    CustomerController objCustomer = new CustomerController();
    
    public string Customer_avatar = "";
    public string _customerName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadSEO();
            Customer_avatar = Session["avatar"].ToString();
            _customerName = Session["customerName"].ToString();
        }
    }
    void loadSEO()
    {
        DataTable dbCate = objCate.GetDataByID("58");
        if (dbCate.Rows.Count > 0)
        {
            Page.Title = dbCate.Rows[0]["Meta_title"].ToString();
            Page.MetaKeywords = dbCate.Rows[0]["Meta_keywords"].ToString();
            Page.MetaDescription = dbCate.Rows[0]["Meta_description"].ToString();
        }
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

    public DataTable dbGetTestimonial()
    {
        return objTestimonial.GetAllData();
    }
    //public DataTable dbNewsDiemNoiBat()
    //{
    //    return objNews.GetNewsByCategoryID_Top3("45");
    //}
    public DataTable dbNewsHightLight()
    {
        return objNews.GetTop3_highlights();
    }


}