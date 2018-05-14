using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;
public partial class Administrator_ListTags : System.Web.UI.Page
{
    TagsController objTags = new TagsController();
    NewsTagsController objNewsTags = new NewsTagsController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadTags();
        }
    }
    void loadTags()
    {
        CollectionPager1.DataSource = objTags.GetAllTags().DefaultView;
        CollectionPager1.DataBind();
        CollectionPager1.PageSize = 20;
        CollectionPager1.BindToControl = rptData;
        rptData.DataSource = CollectionPager1.DataSourcePaged;
        rptData.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {
                objTags.Delete(Convert.ToInt32(sp_list[i]));
                objNewsTags.removeTagsID(sp_list[i] + ";");
            }
            loadTags();
        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("TagsEdit.aspx");
    }
}