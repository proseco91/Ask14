using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_NewsPaggingByTags : System.Web.UI.Page
{
    TagsController objTags = new TagsController();
    public string _tagsID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _tagsID = Request.QueryString["TagsID"].ToString();
        }
    }
    public DataTable dbTagsPresent()
    {
        return objTags.GetDataById(Convert.ToInt32(Request.QueryString["TagsID"].ToString()));
    }
}