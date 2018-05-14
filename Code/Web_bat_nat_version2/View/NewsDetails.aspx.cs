using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class View_NewsDetails : System.Web.UI.Page
{
    BizNews objNews = new BizNews();
    NewsTagsController objNewsTags = new NewsTagsController();
    public string _listTags = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string _id = Request.QueryString["NewsID"].ToString();
            loadData(_id);
        }
    }
    void loadData(string ID)
    {
        DataTable dbNews = objNews.GetNewsByID(ID);
        if (dbNews.Rows.Count > 0)
        {
            string _title = dbNews.Rows[0]["TITLE"].ToString();
            ltTitle.Text = _title;
            ltContent.Text = Regex.Replace(dbNews.Rows[0]["CONTENT"].ToString(), "/Web_bat_nat_version2/", "../");
            ltDatetime.Text = dbNews.Rows[0]["CREATED_DATE"].ToString();
            Page.Title = _title;
            Page.MetaDescription = dbNews.Rows[0]["META_DESCRIPTION"].ToString();
            Page.MetaKeywords = dbNews.Rows[0]["META_KEYWORD"].ToString();

            //Lấy ra listTags
            DataTable dbListTags = objNewsTags.dataCheckTags(Convert.ToInt32(ID));
            if (dbListTags.Rows.Count > 0)
            {
                _listTags = dbListTags.Rows[0]["TAG_ID"].ToString();
            }

        }
    }
    public DataTable dbTop5Related()
    {
        DataTable db = new DataTable();
        try
        {
            return objNews.GetNewsByCategoryID_Top5_Related(Convert.ToInt32(Request.QueryString["NewsID"].ToString()), Convert.ToInt32(Request.QueryString["CategoryID"].ToString()));
        }
        catch
        {

            return db;
        }
    }



}