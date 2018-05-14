using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_VideoList : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    VideoController objVideo = new VideoController();
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
        DataTable db = cnts.GetTableWithCommandText("select * from tblVideo");
        CollectionPager1.DataSource = db.DefaultView;
        CollectionPager1.MaxPages = 10000000;
        CollectionPager1.PageSize = 30;
        CollectionPager1.BindToControl = rptData;
        rptData.DataSource = CollectionPager1.DataSource;
        rptData.DataBind();
    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("VideoEdit.aspx");
    }
    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        try
        {

            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {
                objVideo.Delete(int.Parse(sp_list[i]));
            }
            loadData();
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
}