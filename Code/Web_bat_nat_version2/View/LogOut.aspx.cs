using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class View_LogOut : System.Web.UI.Page
{
    public string _home = "";
    CustomerController objCustomer = new CustomerController();
    protected void Page_Load(object sender, EventArgs e)
    {
        string _email = Session["email"].ToString();
        DataTable dbCheckEmail = objCustomer.GetDataByEmail(_email);
        if (dbCheckEmail.Rows.Count > 0)
        {
            int ID = Convert.ToInt32(dbCheckEmail.Rows[0]["ID"].ToString());
            objCustomer.Update_Online(ID, 0);
        }
        Session["email"] = "";
        _home = Lib.urlHome();
    }
}