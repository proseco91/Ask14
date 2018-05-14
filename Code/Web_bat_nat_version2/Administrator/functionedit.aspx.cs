using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.IO;
using System.Data;

public partial class Administrator_functionedit : System.Web.UI.Page
{
    private FunctionController objFunction = new FunctionController();
    private ConnectSQL objConnect = new ConnectSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadParentFunction();
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                bind();
                btnSubmit.Text = "Cập nhật";
                this.Title = "Cập nhật thông tin module";
            }
            else
            {
                btnSubmit.Text = "Thêm mới";
                this.Title = "Thêm mới module";
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

    void insert()
    {
        string parentid = ddlParent.SelectedValue;
        string functionname = txtFunctionName.Text;
        string url = txtUrl.Text;
        string index = txtIndex.Text.Trim();
        string isDisplay = "";
        if (chkDisplay.Checked == true)
        {
            isDisplay = "1";
        }
        else
        {
            isDisplay = "0";
        }

        int a = objFunction.Insert(parentid, functionname, url, "1", isDisplay, index, Session["username"].ToString());
        if (a > 0)
        {
            divMessage.InnerHtml = O2S_Message.Success("Thành công", "Cập nhật thành công.");
        }
    }

    void bind()
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
        {
            DataTable dt = objConnect.GetTableWithCommandText("select * from tblFunctions where FunctionID = " + Request.QueryString["id"].ToString());
            if (dt.Rows.Count > 0)
            {
                txtFunctionName.Text = dt.Rows[0]["FunctionName"].ToString();
                txtIndex.Text = dt.Rows[0]["Indexes"].ToString();
                txtUrl.Text = dt.Rows[0]["Url"].ToString();
                ddlParent.SelectedValue = dt.Rows[0]["ParentID"].ToString();
                if (dt.Rows[0]["isDisplay"].ToString() == "True")
                {
                    chkDisplay.Checked = true;
                }
            }
        }
    }

    void update()
    {
        string parentid = ddlParent.SelectedValue;
        string functionname = txtFunctionName.Text;
        string url = txtUrl.Text;
        string index = txtIndex.Text.Trim();
        string isDisplay = "";
        if (chkDisplay.Checked == true)
        {
            isDisplay = "1";
        }
        else
        {
            isDisplay = "0";
        }

        bool a = objFunction.Update(Request.QueryString["id"].ToString(), parentid, functionname, url, isDisplay, index, Session["username"].ToString());

        if (a == true)
        {
            divMessage.InnerHtml = O2S_Message.Success("Thành công", "Cập nhật thành công.");
        }
    }

    private void LoadParentFunction()
    {
        List<functions> list = objFunction.LoadChildNodes(0, 0);

        ListItem item1 = new ListItem("---- Root ----", "0");
        item1.Attributes.CssStyle.Add("font-weight", "bold");

        ddlParent.Items.Add(item1);

        foreach (functions f in list)
        {
            ListItem item = new ListItem();
            item.Text = f.FunctionName;
            item.Value = f.FunctionID.ToString();
            if (f.ParentID == 0)
            {
                item.Attributes.CssStyle.Add("font-weight", "bold");
            }
            ddlParent.Items.Add(item);
        }

    }
}