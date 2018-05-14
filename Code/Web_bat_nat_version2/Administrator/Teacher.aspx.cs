using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;
public partial class Administrator_Teacher : System.Web.UI.Page
{
    techerController objTeacher = new techerController();
    protected void Page_Load(object sender, EventArgs e)
    {
        Lib.CheckCookieAdmin();
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        try
        {
            CollectionPager1.DataSource = objTeacher.GetAll().DefaultView;
            CollectionPager1.DataBind();
            CollectionPager1.PageSize = 30;
            CollectionPager1.BindToControl = rptData;
            rptData.DataSource = CollectionPager1.DataSourcePaged;
            rptData.DataBind();
            if (rptData.Items.Count == 0)
            {
                divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
            }
        }
        catch
        {
            divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
        }
    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeacherUpdate.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {

                objTeacher.Delete(sp_list[i]);
            }
            loadData();
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
}