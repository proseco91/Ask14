using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_rolefunction : System.Web.UI.Page
{
    private FunctionController objFunction = new FunctionController();
    private ConnectSQL objConnect = new ConnectSQL();
    private RoleController objRole = new RoleController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            if (Request.QueryString["role"] != null && Request.QueryString["role"] != "")
            {
                ddlRole.SelectedValue = Request.QueryString["role"].ToString();
                checkTreeNode(Request.QueryString["role"].ToString());
            }
        }
    }

    void bind()
    {
        TreeNode no = new TreeNode();
        no.Text = "Cây chức năng";
        no.Value = "0";
        no.ShowCheckBox = false;
        objFunction.LoadTreeNode(no, 0);
        trvFunction.Nodes.Add(no);
        ddlRole.DataSource = objRole.GetAll_C();
        ddlRole.DataTextField = "ROLENAME";
        ddlRole.DataValueField = "ROLEID";
        ddlRole.DataBind();
        ListItem li = new ListItem("-- Lựa chọn quyền --", "0");
        ddlRole.Items.Insert(0, li);
    }

    void checkTreeNode(string role)
    {
        DataTable dtRoleFunction = objConnect.GetTableWithCommandText("select * from tblRoleFunction where  isActive = 1 and ROLEID = " + role);
        if (dtRoleFunction.Rows.Count > 0)
        {
            foreach (DataRow dr in dtRoleFunction.Rows)
            {
                string fid = dr["FUNCTIONID"].ToString();
                for (int i = 0; i < trvFunction.Nodes.Count; i++)
                {
                    TreeNodeSelected(trvFunction.Nodes[i], fid);
                }
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < trvFunction.Nodes.Count; i++)
        {
            Deactive(trvFunction.Nodes[i]);
        }
        Response.Redirect(Request.Url.ToString());
    }

    private void Deactive(TreeNode treeNode)
    {
        if (treeNode.Checked == true)
        {
            string id = treeNode.Value;
            objConnect.ExcutedCMD("update tblFunctions set isActivate = 0 where FunctionID = " + id);
        }
        foreach (TreeNode tn in treeNode.ChildNodes)
        {
            Deactive(tn);
        }
    }

    private void TreeNodeSelected(TreeNode treeNode, string fid)
    {
        if (treeNode.Value == fid)
        {
            treeNode.Checked = true;
        }
        foreach (TreeNode tn in treeNode.ChildNodes)
        {
            TreeNodeSelected(tn, fid);
        }
    }

    private void TreeNodeInsert(TreeNode treeNode)
    {
        if (treeNode.Checked)
        {
            Insert(Request.QueryString["role"].ToString(), treeNode.Value);
        }
        foreach (TreeNode tn in treeNode.ChildNodes)
        {
            TreeNodeInsert(tn);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["role"] != null && Request.QueryString["role"] != "")
        {
            if (Request.QueryString["role"].ToString() != "0")
            {
                objConnect.ExcutedCMD("update tblRoleFunction set isActive = 0 where ROLEID = " + Request.QueryString["role"].ToString());
                for (int i = 0; i < trvFunction.Nodes.Count; i++)
                {
                    TreeNodeInsert(trvFunction.Nodes[i]);
                }
            }
        }
    }

    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("rolefunction.aspx?role=" + ddlRole.SelectedValue);
    }

    public void Insert(string roleid, string functionid)
    {
        string[] arrParam = { "@ROLEID", "@FUNCTIONID" };
        string[] arrValue = { roleid, functionid };
        objConnect.ExcuteStored("tblRoleFunction_Insert", arrParam, arrValue);
    }
}