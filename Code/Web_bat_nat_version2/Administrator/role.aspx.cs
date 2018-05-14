using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Administrator_role : System.Web.UI.Page
{
    private RoleController objRole = new RoleController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        try
        {
            CollectionPager1.DataSource = objRole.GetAll().DefaultView;
            CollectionPager1.BindToControl = rptData;
            CollectionPager1.PageSize = 20;
            CollectionPager1.DataBind();
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
                objRole.Delete(sp_list[i]);
            }
            bindData();
        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }

    protected void btnDelete2_Click(object sender, EventArgs e)
    {
        btnDelete_Click(sender, e);
    }

}