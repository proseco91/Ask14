using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_CategoryNews : System.Web.UI.Page
{
    public int _category = 0;
    public string _categoryParent = "0";
    CategoryController objCate = new CategoryController();
    protected void Page_Load(object sender, EventArgs e)
    {
        _category = Convert.ToInt32(Request.QueryString["CategoryID"]);
        if (!IsPostBack)
        {
            loadParentID();
        }
    }
    void loadParentID()
    {
        try
        {
            DataTable dbCate = objCate.GetDataByID(_category.ToString());
            if (dbCate.Rows.Count > 0)
            {


                _categoryParent = dbCate.Rows[0]["PARENT_ID"].ToString();
                if (_categoryParent == "0")
                {
                    _categoryParent = _category.ToString();
                }

                string _title = dbCate.Rows[0]["Meta_title"].ToString();
                string _description = dbCate.Rows[0]["Meta_description"].ToString();
                string _keywords = dbCate.Rows[0]["Meta_keywords"].ToString();

                Page.Title = _title;
                Page.MetaDescription = _description;
                Page.MetaKeywords = _keywords;
            }
        }
        catch
        {
        }
    }
   
}