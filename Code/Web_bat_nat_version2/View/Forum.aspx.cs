using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class View_Forum : System.Web.UI.Page
{
    SlideShowController objSlide = new SlideShowController();
    SubjectController objSubject = new SubjectController();
    CategoryController objCate = new CategoryController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadSEO();
        }
    }
    void loadSEO()
    {
        DataTable dbCate = objCate.GetDataByID("62");
        if (dbCate.Rows.Count > 0)
        {
            Page.Title = dbCate.Rows[0]["Meta_title"].ToString();
            Page.MetaKeywords = dbCate.Rows[0]["Meta_keywords"].ToString();
            Page.MetaDescription = dbCate.Rows[0]["Meta_description"].ToString();
        }
    }
    public DataTable dbGetSlide()
    {
        return objSlide.GetAllWithStatus();
    }
    public DataTable dbGetTop5Subject()
    {
        return objSubject.GetDataTop5Subject();
    }
}