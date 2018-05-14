using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;

using System.Data;
public partial class Administrator_ListThread : System.Web.UI.Page
{
    ForumController objForum = new ForumController();
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
        try
        {
            CollectionPager1.DataSource = objForum.GetAllData_join_Customer_and_Subject().DefaultView;
            CollectionPager1.DataBind();
            CollectionPager1.PageSize = 50;
            CollectionPager1.BindToControl = rptData;
            rptData.DataSource = CollectionPager1.DataSourcePaged;
            rptData.DataBind();
        }
        catch
        {
            divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {
                objForum.Delete(sp_list[i]);
                objCommentForum.DeleteByForum(Convert.ToInt32(sp_list[i]));
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }

    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dr = e.Item.DataItem as DataRowView;
        Literal ltCountComment = e.Item.FindControl("ltCountComment") as Literal;

        string ForumID = dr["ID"].ToString();

        DataTable dbCountComment = objCommentForum.GetDataByForumID(Convert.ToInt32(ForumID));
        ltCountComment.Text = dbCountComment.Rows.Count.ToString();
    }
}