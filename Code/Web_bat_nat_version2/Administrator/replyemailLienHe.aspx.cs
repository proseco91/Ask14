﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_replyemailLienHe : System.Web.UI.Page
{
    LienHeController objLIenHe = new LienHeController();
    private ConnectSQL objConnect = new ConnectSQL();
    private MailController objMail = new MailController();
    CustomerController objCus = new CustomerController();
    public static int id = 0;
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
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            DataTable dbCus = objCus.GetDataByID(id.ToString());
            txtEmail.Text = dbCus.Rows[0]["EMAIL"].ToString();
            name = dbCus.Rows[0]["CUSTOMER_NAME"].ToString();
            txtName.Text = name;
        }
        catch
        {
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dbUse = objConnect.GetTableWithCommandText("select ADMIN_ID from tblAdministrators WHERE USERNAME='" + Session["username"].ToString() + "'");
        if (dbUse.Rows.Count > 0)
        {
            string rollID = dbUse.Rows[0]["ADMIN_ID"].ToString();
            bool ktHoiDap = objConnect.ExcutedCMD("update tblLienHe set ANSWER=N'" + txtContent.Text + "', ADMIN_ANSWER='" + Session["username"].ToString() + "' where ID=" + id);

            DataTable db = objConnect.GetTableWithCommandText("select * from tblEmailTemplate where EMAILID=1");
            string content = db.Rows[0]["CONTENT"].ToString();
            string title = db.Rows[0]["DESCRIPTION"].ToString();

            string email = txtEmail.Text.Trim();
            content = content.Replace("$1", name);
            content = content.Replace("$2", txtContent.Text);
            bool kt = objMail.SendMail(email, title, content);
            //bool kt = objMail.SendMail(email, title, content);
            if (kt == true)
            {
                //objAsk.UpdateStatus(id);
                objConnect.ExcutedCMD("update tblLienHe set STATUS='1' where ID=" + id);
                string str = "<script type='text/javascript'>";
                str += "function OnRemove(){self.parent.tb_remove();}OnRemove();";
                str += "</script>";
                Response.Write(str);
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}