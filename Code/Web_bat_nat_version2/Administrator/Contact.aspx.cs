using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;

public partial class Administrator_Contact : System.Web.UI.Page
{
    LienHeController objLienHe = new LienHeController();
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
            CollectionPager1.DataSource = objLienHe.GetAllData().DefaultView;
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
   
}