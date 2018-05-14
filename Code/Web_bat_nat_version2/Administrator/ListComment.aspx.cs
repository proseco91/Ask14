using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class administrator_ListComment : System.Web.UI.Page
{
    EventCommentController objEvent = new EventCommentController();
    ConnectSQL cnts = new ConnectSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }

    void loadData()
    {
        DataTable db = objEvent.GetAllData();
        CollectionPager1.DataSource = db.DefaultView;
        CollectionPager1.DataBind();
        CollectionPager1.PageSize = 50;
        CollectionPager1.BindToControl = rptData;
        CollectionPager1.MaxPages = 100000;
        rptData.DataSource = CollectionPager1.DataSourcePaged;
        rptData.DataBind();
    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Item.DataItem;
      
    }
}