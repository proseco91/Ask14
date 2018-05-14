using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_listeventcomment : System.Web.UI.Page
{
    private ConnectSQL objConnect = new ConnectSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();
        }
    }

    private void GetData()
    {
        try
        {
            
            DataTable dt = null;
            if (!String.IsNullOrEmpty(Request.QueryString["servicetype"]))
            {

                string serviceType = Request.QueryString["servicetype"].ToString();
                if (serviceType == "lophoc")
                {
                    dt = objConnect.GetTableWithCommandText("select * from tblEventComment where CUSTOMEREVENT = " + Request.QueryString["Id"] + " AND STATUS <>3 AND SERVICETYPE='" + serviceType + "' order by ID desc");
                }
                else
                {
                    dt = objConnect.GetTableWithCommandText("select * from tblEventComment where CUSTOMER_ID = " + Request.QueryString["Id"] + " AND STATUS <>3 AND SERVICETYPE='" + serviceType + "' order by ID desc");
                }
            }            
            else
            {
                dt = objConnect.GetTableWithCommandText("select * from tblEventComment where CUSTOMER_ID = '" + Request.QueryString["Id"] + "' AND STATUS <>3 order by ID desc");
            }
            rptData.DataSource = dt;
            rptData.DataBind();
        }
        catch
        {
        }
    }
}