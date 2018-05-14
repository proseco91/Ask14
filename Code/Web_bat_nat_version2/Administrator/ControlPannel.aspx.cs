using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using LibraryO2S;
using System.Collections;

public partial class Administrator_ControlPannel : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();    
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{            
        //    try
        //    {
        //        string id = objEncrypt.Decrypt(Request.QueryString["ID"].ToString());
        //        if (id == "8" || id == "9")
        //        {
        //            boxMess.Visible = false;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        Response.Redirect("~/Administrator/Login.aspx");
        //    }
        //}
    }



}