using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;

public partial class Administrator_roleedit : System.Web.UI.Page
{
    RoleController objRole = new RoleController();
    ConnectSQL objConnect = new ConnectSQL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                bind();
                btnSubmit.Text = "Cập nhật";
            }
            else
            {
                btnSubmit.Text = "Thêm mới";
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
        {
            update();
        }
        else
        {
            insert();
        }
    }

    void bind()
    {

        DataTable dt = objConnect.GetTableWithCommandText("select * from tblRole where ROLEID = " + Request.QueryString["id"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtTitle.Text = dt.Rows[0]["ROLENAME"].ToString();
            if (dt.Rows[0]["STATUS"].ToString() == "1")
            {
                chkStatus.Checked = true;
            }
        }
    }

    void insert()
    {
        string rolename = txtTitle.Text;
        string isDisplay = "";
        if (chkStatus.Checked == true)
        {
            isDisplay = "1";
        }
        else
        {
            isDisplay = "0";
        }

        int a = objRole.Insert(rolename, isDisplay);
        if (a > 0)
        {
            divMessage.InnerHtml = O2S_Message.Success("Thành công", "Cập nhật thành công.");
        }

    }

    void update()
    {
        string rolename = txtTitle.Text;
        string isDisplay = "";
        if (chkStatus.Checked == true)
        {
            isDisplay = "1";
        }
        else
        {
            isDisplay = "0";
        }

        bool a = objRole.Update(Request.QueryString["ID"].ToString(), rolename, isDisplay);
        if (a == true)
        {
            divMessage.InnerHtml = O2S_Message.Success("Thành công", "Cập nhật thành công.");
        }

    }
}