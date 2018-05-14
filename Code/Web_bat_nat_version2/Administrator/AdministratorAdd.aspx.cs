using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
public partial class Administrator_AdministratorAdd : System.Web.UI.Page
{
    RoleController objRole = new RoleController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlRoll.DataSource = objRole.GetAll();
            ddlRoll.DataTextField = "ROLENAME";
            ddlRoll.DataValueField = "ROLEID";
            ddlRoll.DataBind();
        }
    }
    tblAdministrators admin = new tblAdministrators();
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string createdby = Session["USERNAME"].ToString();
            admin.InsertAdministrators(txtAdminName.Text, txtUserName.Text, txtPassWord.Text, txtAddress.Text, txtPhoneNumber.Text,
                txtEmail.Text, int.Parse(txtSortDisplay.Text), DateTime.Now, createdby, DateTime.Now, "", 1, ddlRoll.SelectedValue);
            divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
            MailController controller = new MailController();
            string body = "Tên đăng nhập:<br/>" + txtUserName.Text + "<br/>Mật khẩu:" + txtPassWord.Text;
            controller.SendMail(txtEmail.Text, "TÀI KHOẢN QUẢN TRỊ MONEYLOVE", body);
        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Hệ thống", "Phát hiện lỗi" + ex.Message);
        }

    }
}