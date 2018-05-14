using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CategoryController
/// </summary>
public class CategoryController
{
    ConnectSQL cnts = new ConnectSQL();
    public CategoryController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAllData()
    {
        return cnts.TableWithoutParameter("tblCategory_GetAllData");
    }
    public DataTable GetAllData_WITH_PARENTID()
    {
        return cnts.TableWithoutParameter("tblCategory_GetAllData_ParentID");
    }
    public DataTable GetAllData_WITH_PARENTID_VIEWER()
    {
        return cnts.TableWithoutParameter("tblCategory_GetAllData_ParentID_Viewer");
    }
    public int Insert(int PARENT_ID, string NAME, string LINK, string SORT_DISPLAY, DateTime CREATED_DATE, int STATUS, int DISPLAY_MENU, string Meta_keywords, string Meta_title, string Meta_description)
    {
        string[] para = new string[] { "@PARENT_ID", "@NAME", "@LINK", "@SORT_DISPLAY", "@CREATED_DATE", "@STATUS", "@DISPLAY_MENU", "@Meta_keywords", "@Meta_title", "@Meta_description" };
        object[] obj = new object[] { PARENT_ID, NAME, LINK, SORT_DISPLAY, CREATED_DATE, STATUS, DISPLAY_MENU, Meta_keywords, Meta_title, Meta_description };
        return cnts.insert("tblCategory_insert", para, obj);
    }
    public bool Update(int ID, int PARENT_ID, string NAME, string LINK, string SORT_DISPLAY, DateTime CREATED_DATE, int STATUS, int DISPLAY_MENU, string Meta_keywords, string Meta_title, string Meta_description)
    {
        string[] parameter = new string[] { "@ID", "@PARENT_ID", "@NAME", "@LINK", "@SORT_DISPLAY", "@CREATED_DATE", "@STATUS", "@DISPLAY_MENU", "@Meta_keywords", "@Meta_title", "@Meta_description" };
        object[] obj = new object[] { ID, PARENT_ID, NAME, LINK, SORT_DISPLAY, CREATED_DATE, STATUS, DISPLAY_MENU, Meta_keywords, Meta_title, Meta_description };
        return cnts.Update("tblCategory_Update", parameter, obj);
    }
    public DataTable GetDataByID(string id)
    {
        return cnts.TableWithParameter("tblCategory_GetByID", new string[] { "@ID" }, new object[] { id });
    }
    public bool Delete(int ID)
    {
        string[] parameter = new string[] { "@ID" };
        object[] obj = new object[] { ID };
        return cnts.Update("tblCategory_Delete", parameter, obj);
    }
    public List<Category> LoadChildNodes(int ParentId, int level)
    {
        List<Category> parent = new List<Category>();
        DataTable dtParent = GetByParentID(ParentId);
        if (dtParent.Rows.Count > 0)
        {
            foreach (DataRow dr in dtParent.Rows)
            {
                string str = "";
                Category func = new Category();

                for (int i = 0; i < level; i++)
                {
                    str += "\\__";
                }

                func.ID = Int32.Parse(dr["ID"].ToString());
                func.PARENT_ID = Int32.Parse(dr["PARENT_ID"].ToString());
                func.NAME = str + dr["NAME"].ToString();
                parent.Add(func);
                LoadChildNodes(func.ID, level + 1);
            }
        }
        return parent;
    }
    public DataTable GetByParentID(int id)
    {
        return cnts.TableWithParameter("tblCategory_GetByParentID", new string[] { "@PARENT_ID" }, new object[] { id });
    }
    public DataTable GetByParentID_Viewer(int id)
    {
        return cnts.TableWithParameter("tblCategory_GetByParentID_Viewer", new string[] { "@PARENT_ID" }, new object[] { id });
    }



}