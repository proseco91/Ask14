using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;

public partial class Administrator_ListCommentThread : System.Web.UI.Page
{
    CommentForum objCommentForum = new CommentForum();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        CollectionPager1.DataSource = objCommentForum.GetAllData_Join_Customer_and_Forum().DefaultView;
        CollectionPager1.DataBind();
        CollectionPager1.PageSize = 50;
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
                objCommentForum.Delete(Convert.ToInt32(sp_list[i]));
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
}