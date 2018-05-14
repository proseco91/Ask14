using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_AdministratorEdit : System.Web.UI.Page
{
    RoleController objRole = new RoleController();
    ConnectSQL cnts = new ConnectSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlRoll.DataSource = objRole.GetAll();
            ddlRoll.DataTextField = "ROLENAME";
            ddlRoll.DataValueField = "ROLEID";
            ddlRoll.DataBind();
            SearchData();
        }

    }
    tblAdministrators admin = new tblAdministrators();
    public string admin_ID
    {
        get
        {
            return Request.QueryString["ADMIN_ID"].ToString();
        }
    }
    public DataTable GetAdmin
    {
        get
        {
            return admin.SearchAdMin(admin_ID);
        }
    }



    public void SearchData()
    {
        DataTable db = GetAdmin;
        txtAdminName.Text = db.Rows[0]["FULL_NAME"].ToString();
        ddlRoll.SelectedValue = db.Rows[0]["ROLL"].ToString();
        txtUserName.Text = db.Rows[0]["USERNAME"].ToString();
        txtAddress.Text = db.Rows[0]["ADDRESS"].ToString();
        txtPhoneNumber.Text = db.Rows[0]["PHONE_NUMBER"].ToString();
        txtEmail.Text = db.Rows[0]["EMAIL"].ToString();
        txtSortDisplay.Text = db.Rows[0]["SORT_DISPLAY"].ToString();
        txtPass.Text = db.Rows[0]["PASSWORD"].ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string password = txtPass.Text;
            string modfied_by = Session["USERNAME"].ToString();
            string createdby = GetAdmin.Rows[0]["CREATED_BY"].ToString();
            admin.UpdateAdministrators(admin_ID, txtAdminName.Text, txtUserName.Text, password, txtAddress.Text, txtPhoneNumber.Text,
           txtEmail.Text, int.Parse(txtSortDisplay.Text), DateTime.Now, createdby, DateTime.Now, modfied_by, 1, ddlRoll.SelectedValue);

            divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "Thực hiện thành công");
        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Lỗi", "Cập nhật không thành công phát hiện lỗi " + ex.Message);
        }

    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administrator/Administrator.aspx");

    }
}