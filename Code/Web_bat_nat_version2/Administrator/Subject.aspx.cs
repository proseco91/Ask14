using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;
using System.IO;
public partial class Administrator_Subject : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    SubjectController objSubject = new SubjectController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        DataTable db = objSubject.GetAll();
        CollectionPager1.DataSource = db.DefaultView;
        CollectionPager1.DataBind();
        CollectionPager1.PageSize = int.MaxValue;
        CollectionPager1.BindToControl = rptData;
        rptData.DataSource = CollectionPager1.DataSourcePaged;
        rptData.DataBind();
        if (rptData.Items.Count == 0)
        {
            divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
        }
    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubjectAdd.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {
                try
                {
                    DataTable db = objSubject.GetDataByID(Convert.ToInt32(sp_list[i]));
                    bool kt = File.Exists(Server.MapPath("~/Images/subject/") + db.Rows[0]["IMAGE"]);
                    if (kt)
                        File.Delete(Server.MapPath("~/Images/subject/") + db.Rows[0]["IMAGE"]);
                }
                catch (Exception)
                {

                    throw;
                }

                objSubject.Delete(sp_list[i]);
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
}