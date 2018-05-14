using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;
public partial class Administrator_MailReceiverEdit : System.Web.UI.Page
{

    BizEmail email = new BizEmail();
    MailReceiverController objRc = new MailReceiverController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        DataTable dt = objRc.GetById(EMAILID);
        txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
        txtName.Text = dt.Rows[0]["FULLNAME"].ToString();
        if (dt.Rows[0]["STATUS"].ToString() == "1")
        {
            chkStatus.Checked = true;
        }
        else
        {
            chkStatus.Checked = false;
        }
    }
    public string EMAILID
    {
        get
        {
            return Request.QueryString["ID"].ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            string email = txtEmail.Text;
            string name = txtName.Text;
            string status = "0";
            if (chkStatus.Checked)
            {
                status = "1";
            }
            objRc.Update(EMAILID, email, name, status);
            Response.Redirect("MailReceiver.aspx");

        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Hệ thống", "Phát hiện lỗi" + ex.Message);
        }

    }

}