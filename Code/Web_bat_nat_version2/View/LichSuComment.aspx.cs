using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class View_LichSuComment : System.Web.UI.Page
{
    CustomerController objCust = new CustomerController();
    public string _custID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["email"].ToString()))
        {
            Response.Redirect(Lib.urlHome());
        }
        else
        {
            DataTable dbCust = objCust.GetDataByEmail(Session["email"].ToString());
            if (dbCust.Rows.Count > 0)
            {
                _custID = dbCust.Rows[0]["ID"].ToString();
            }

        }
    }
}