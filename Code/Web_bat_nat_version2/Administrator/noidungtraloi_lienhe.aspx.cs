using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_noidungtraloi_lienhe : System.Web.UI.Page
{
    private LienHeController objAsk = new LienHeController();
    private ConnectSQL objConnect = new ConnectSQL();
    private MailController objMail = new MailController();
    public static string id = "";
    public static string name = "";
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
            id = Int32.Parse(Request.QueryString["id"].ToString()).ToString();
            DataTable dtAsk = objConnect.GetTableWithCommandText("select * From tblLienHe where ID=" + id);
            Repeater1.DataSource = dtAsk;
            Repeater1.DataBind();
        }
        catch
        {
        }
    }
}