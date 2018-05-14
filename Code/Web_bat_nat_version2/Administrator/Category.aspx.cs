using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;

public partial class Administrator_Category : System.Web.UI.Page
{
    CategoryController objCate = new CategoryController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        DataTable db = objCate.GetAllData();
        rptData.DataSource = db;
        rptData.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {
                objCate.Delete(int.Parse(sp_list[i]));
            }
            loadData();
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CategoryEdit.aspx");
    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dr = e.Item.DataItem as DataRowView;
        Literal a = e.Item.FindControl("ltParent") as Literal;
        int id = Convert.ToInt32(dr["PARENT_ID"].ToString());
        if (id == 0)
        {
            a.Text = "Danh mục gốc";
        }
        else
        {
            DataTable db = objCate.GetDataByID(id.ToString());
            if (db.Rows.Count > 0)
            {
                a.Text = db.Rows[0]["NAME"].ToString();
            }

        }
    }
}