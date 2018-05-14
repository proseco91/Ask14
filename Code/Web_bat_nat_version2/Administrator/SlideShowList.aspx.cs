using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;
using System.IO;

public partial class Administrator_SlideShowList : System.Web.UI.Page
{
    SlideShowController objSlide = new SlideShowController();
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
            CollectionPager1.DataSource = objSlide.GetAll().DefaultView;
            CollectionPager1.DataBind();
            CollectionPager1.PageSize = 30;
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
                try
                {
                    DataTable db = objSlide.GetDataByID(Convert.ToInt32(sp_list[i]));
                    bool FileExits = File.Exists(Server.MapPath("~/images/SlideShow/") + db.Rows[0]["IMAGE"]);
                    if (FileExits)
                        File.Delete(Server.MapPath("~/images/SlideShow/") + db.Rows[0]["IMAGE"]);
                }
                catch
                {

                }


                objSlide.Delete(sp_list[i]);
            }
            loadData();
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }

    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SlideShowedit.aspx");
    }
}
