using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for FunctionController
/// </summary>
public class FunctionController
{
    private ConnectSQL objCon = new ConnectSQL();
    private string temp = "";
    List<functions> parent = new List<functions>();
    TreeView trv = new TreeView();
    public FunctionController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAll()
    {
        string[] arrParam = { };
        object[] arrValue = { };
        return objCon.TableWithParameter("tblAsk_GetAll", arrParam, arrValue);
    }

    public DataTable LoadRoot()
    {
        DataTable dt = objCon.GetTableWithCommandText("select * from tblFunctions where ParentID = 0 order by Indexes");
        return dt;
    }

    public List<functions> LoadChildNodes(int ParentId, int level)
    {
        DataTable dtParent = GetByParentID(ParentId);
        if (dtParent.Rows.Count > 0)
        {
            foreach (DataRow dr in dtParent.Rows)
            {
                string str = "";
                functions func = new functions();

                for (int i = 0; i < level; i++)
                {
                    str += "\\__";
                }

                func.FunctionID = Int32.Parse(dr["FunctionID"].ToString());
                func.ParentID = Int32.Parse(dr["ParentID"].ToString());
                func.FunctionName = str + dr["FunctionName"].ToString();
                func.Url = dr["Url"].ToString();
                func.Indexes = Int32.Parse(dr["Indexes"].ToString());
                parent.Add(func);
                LoadChildNodes(func.FunctionID, level + 1);
            }
        }
        return parent;
    }

    public void LoadTreeNode(TreeNode childnode, int ParentId)
    {
        DataTable dtParent = GetByParentID2(ParentId);
        if (dtParent.Rows.Count > 0)
        {
            foreach (DataRow dr in dtParent.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = dr["FunctionName"].ToString();
                node.Value = dr["FunctionID"].ToString();
                node.NavigateUrl = "functionedit.aspx?id=" + dr["FunctionID"].ToString();
                node.Expanded = false;
                childnode.ChildNodes.Add(node);
                LoadTreeNode(node, Int32.Parse(dr["FunctionID"].ToString()));
            }
        }
    }

    public DataTable GetByParentID(int id)
    {
        return objCon.GetTableWithCommandText("select * from tblFunctions where ParentID = " + id + " and isDisplay = 1 and isActivate = 1 order by Indexes");
    }

    public DataTable GetByParentIDByUser(string id, string username)
    {
        string[] arrParam = { "@ParentID", "@USERNAME" };
        string[] arrValue = { id, username };
        return objCon.TableWithParameter("tblFunctions_GetByUserName", arrParam, arrValue);
    }

    public DataTable GetByParentID2(int id)
    {
        return objCon.GetTableWithCommandText("select * from tblFunctions where ParentID = " + id + " and isActivate = 1 order by Indexes");
    }

    public int Insert(string parentid, string functionname, string url, string isActivate, string isDisplay, string indexes, string createdby)
    {
        string[] arrParam = { "@ParentID", "@FunctionName", "@Url", "@isActivate", "@isDisplay", "@Indexes", "@CreatedBy" };
        object[] arrValue = { parentid, functionname, url, isActivate, isDisplay, indexes, createdby };
        return objCon.insert("tblFunction_insert", arrParam, arrValue);
    }

    public bool Update(string id, string parentid, string functionname, string url, string isDisplay, string indexes, string updateby)
    {
        string[] arrParam = { "@ID", "@ParentID", "@FunctionName", "@Url", "@isDisplay", "@Indexes", "@UpdateBy" };
        object[] arrValue = { id, parentid, functionname, url, isDisplay, indexes, updateby };
        return objCon.Update("tblFunction_Update", arrParam, arrValue);
    }

    public string loadmenu(int ParentId, int level, string name)
    {
        if (ParentId > 0)
        {
            temp = "<ul>";
        }
        DataTable lisFunc = GetByParentIDByUser(ParentId.ToString(), name);
        if (lisFunc.Rows.Count > 0)
        {
            foreach (DataRow f in lisFunc.Rows)
            {
                string _url = f["Url"].ToString();
                if (f["isDisplay"].ToString() == "True")
                {
                    if (ParentId == 0)
                    {
                        string icon = f["Icon"].ToString();
                        temp += "<li><a><span class='icon'><img src='./Admin_files/" + icon + "'/></span><span>" + f["FunctionName"].ToString() + "</span></a>";
                    }
                    else
                    {
                        if (GetByParentIDByUser(f["FunctionID"].ToString(), name).Rows.Count > 0)
                        {
                            temp += "<li><a class='childs' href=" + _url + ">" + f["FunctionName"].ToString() + "</a>";
                        }
                        else
                        {
                            temp += "<li><a href=" + _url + ">" + f["FunctionName"].ToString() + "</a>";
                        }
                    }
                    temp += loadmenu(Int32.Parse(f["FunctionID"].ToString()), level + 1, name);
                }
            }

            if (ParentId > 0)
            {
                temp += "</li></ul>";
            }
            return temp;
        }
        else
        {
            return "";
        }
    }
}