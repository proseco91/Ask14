using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    private FunctionController objFunction = new FunctionController();
    ConnectSQL cnts = new ConnectSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check cookie
        Lib.CheckCookieAdmin();
        if (!IsPostBack)
        {
            if (Session["username"] == null || String.IsNullOrEmpty(Session["username"].ToString()))
            {
                Response.Redirect("Login.aspx");
            }
            CheckRole();
            if (Session["Role"] == null || String.IsNullOrEmpty(Session["Role"].ToString()))
            {
                Response.Redirect("Login.aspx");
            }
            litMenu.Text = objFunction.loadmenu(0, 0, Session["username"].ToString());
        }
    }
    void CheckRole()
    {
        string userName = Session["username"].ToString();
        DataTable dbRole = cnts.GetTableWithCommandText("select * from tblAdministrators A join tblRole R ON A.ROLL = R.ROLEID where username='" + userName + "'");
        int roleID = 3;
        if (dbRole.Rows.Count > 0)
        {
            roleID = Convert.ToInt32(dbRole.Rows[0]["ROLEID"].ToString());
        }
        Session["Role"] = roleID;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["username"] = "";
        Response.Cookies["username"].Expires = DateTime.Now.AddYears(-30);
        Response.Redirect("Login.aspx");
    }
}
