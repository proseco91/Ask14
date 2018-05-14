using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using LibraryO2S;

public partial class Administrator_EmailTemplate : System.Web.UI.Page
{


    BizEmail email = new BizEmail();

    protected void Page_Load(object sender, EventArgs e)
    {
        Lib.CheckCookieAdmin();
        if (!IsPostBack)
        {
            LoadData();
            //LoadToCombobox();
        }
    }


    private void LoadData()
    {
        //try
        //{
            CollectionPager1.DataSource = email.tblEmailTemplateSelectAll().DefaultView;
            CollectionPager1.DataBind();
            CollectionPager1.PageSize = 20;
            CollectionPager1.BindToControl = rptData;
            rptData.DataSource = CollectionPager1.DataSourcePaged;
            rptData.DataBind();
            if (rptData.Items.Count == 0)
            {
                divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
            }
        //}
        //catch
        //{
        //    divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
        //}
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {
                email.tblEmailTemplateDelete(int.Parse(sp_list[i]));
                // news.tblNewsDelete(int.Parse(sp_list[i]));
            }
            divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công!");
            LoadData();
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }

    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmailTemplateAdd.aspx");
    }

    protected void btnDelete2_Click(object sender, EventArgs e)
    {
        btnDelete_Click(sender, e);
    }
}