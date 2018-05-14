using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_function : System.Web.UI.Page
{
    private FunctionController objFunction = new FunctionController();
    private ConnectSQL objConnect = new ConnectSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TreeNode no = new TreeNode();
            no.Text = "Cây chức năng";
            no.Value = "0";
            no.ShowCheckBox = false;
            objFunction.LoadTreeNode(no, 0);
            trvFunction.Nodes.Add(no);
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
}