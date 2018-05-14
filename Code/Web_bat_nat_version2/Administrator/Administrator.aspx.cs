using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using LibraryO2S;

public partial class Administrator_Administrator : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    tblAdministrators admin = new tblAdministrators();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        try
        {
            CollectionPager1.DataSource = admin.GetAllData().DefaultView;
            CollectionPager1.DataBind();
            CollectionPager1.PageSize = 20;
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
                admin.DeleteAdmin(sp_list[i]);
            }
            LoadData();
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }

    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministratorAdd.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministratorAdd.aspx");
    }
}