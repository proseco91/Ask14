using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_News : System.Web.UI.Page
{
    public string _category = "";
    CategoryController objCate = new CategoryController();
    TagsController objTags = new TagsController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _category = Request.QueryString["CategoryID"].ToString();
            loadSEO();
        }
    }
    void loadSEO()
    {

        DataTable dbCate = objCate.GetDataByID(_category);
        if (dbCate.Rows.Count > 0)
        {
            Page.Title = dbCate.Rows[0]["Meta_title"].ToString();
            Page.MetaKeywords = dbCate.Rows[0]["Meta_keywords"].ToString();
            Page.MetaDescription = dbCate.Rows[0]["Meta_description"].ToString();
        }
    }
    public DataTable dbTagsPresent()
    {
        return objTags.GetTagsPresent();
    }
}