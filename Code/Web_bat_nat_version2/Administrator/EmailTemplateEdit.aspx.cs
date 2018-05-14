using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;
public partial class Administrator_EmailTemplateEdit : System.Web.UI.Page
{


    BizEmail email = new BizEmail();
    protected void Page_Load(object sender, EventArgs e)
    {
        Lib.CheckCookieAdmin();
        if (!IsPostBack)
        {
            LoadData();
        }

    }
    public DataTable tblEmail
    {
        get
        {
            return email.tblEmailTemplateSearch(EMAILID);
        }
    }
    private void LoadData()
    {
        txtContent.Text = tblEmail.Rows[0]["CONTENT"].ToString();
        txtDescription.Text = tblEmail.Rows[0]["DESCRIPTION"].ToString();
        //txtDescription.Text

    }
    public string EMAILID
    {
        get
        {
            return Request.QueryString["EMAILID"].ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            string modified = Session["USERNAME"].ToString();
            //report.Update(MODULEID, txtModuleName.Text, txtDescription.Text, int.Parse(txtSortDisplay.Text), modified, status);
            email.tblEmailTemplateUpdate(int.Parse(EMAILID), txtDescription.Text, txtContent.Text, DateTime.Now);
            divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
            Response.Redirect("EmailTemplate.aspx");

        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Hệ thống", "Phát hiện lỗi" + ex.Message);
        }

    }


}