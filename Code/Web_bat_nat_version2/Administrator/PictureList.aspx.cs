using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_PictureList : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    PictureController objPicture = new PictureController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        DataTable db = cnts.GetTableWithCommandText("Select * from tblPicture order by ID desc");
        CollectionPager1.DataSource = db.DefaultView;
        CollectionPager1.BindToControl = rptData;
        CollectionPager1.PageSize = 30;
        CollectionPager1.MaxPages = 10000;
        rptData.DataSource = CollectionPager1.DataSourcePaged;
        rptData.DataBind();
    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("PictureEdit.aspx");
    }
    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        try
        {
            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {
                objPicture.Delete(int.Parse(sp_list[i]));
            }
            loadData();
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
}