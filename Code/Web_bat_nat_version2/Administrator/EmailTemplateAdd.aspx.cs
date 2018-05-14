using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;
public partial class Administrator_EmailTemplateAdd : System.Web.UI.Page
{


    BizEmail email = new BizEmail();
    protected void Page_Load(object sender, EventArgs e)
    {
        Lib.CheckCookieAdmin();
        if (!IsPostBack)
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            //report.Update(MODULEID, txtModuleName.Text, txtDescription.Text, int.Parse(txtSortDisplay.Text), modified, status);
            email.tblEmailTemplateInsert(txtDescription.Text, txtContent.Text, 1, DateTime.Now);
            divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
            //  Response.Redirect("EmailTemplate.aspx");

        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Hệ thống", "Phát hiện lỗi" + ex.Message);
        }

    }

}