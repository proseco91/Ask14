using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;
public partial class Administrator_MailReceiverAdd : System.Web.UI.Page
{
    BizEmail email = new BizEmail();
    MailReceiverController objRc = new MailReceiverController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

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
            objRc.Insert(email, name, status);
            divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Hệ thống", "Phát hiện lỗi" + ex.Message);
        }

    }

}