using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using LibraryO2S;
using System.IO;

public partial class Administrator_News : System.Web.UI.Page
{


    BizNews news = new BizNews();
    ConnectSQL cnts = new ConnectSQL();
    CategoryController objCate = new CategoryController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadParent();
            if (!String.IsNullOrEmpty(Request.QueryString["Cate"]))
            {
                int _cate = Convert.ToInt32(Request.QueryString["Cate"].ToString());
                LoadData(_cate);
            }
            else
            {
                int _cate = -999;
                LoadData(_cate);
            }


        }
    }

    void showChild(int parentID, string space)
    {
        List<Category> lst = objCate.LoadChildNodes(parentID, 0);
        foreach (Category item in lst)
        {
            ListItem obj = new ListItem(space + item.NAME, item.ID.ToString());
            ddlModule.Items.Add(obj);
            showChild(item.ID, space + "--- ---");
        }
    }
    void loadParent()
    {
        ddlModule.Items.Clear();
        showChild(0, "");
    }
    private void LoadData(int _cate)
    {
        try
        {
            CollectionPager1.DataSource = news.NewsSelectAll().DefaultView;
            CollectionPager1.DataBind();
            CollectionPager1.PageSize = 50;
            CollectionPager1.BindToControl = rptData;
            rptData.DataSource = CollectionPager1.DataSourcePaged;
            rptData.DataBind();
            if (rptData.Items.Count == 0)
            {
                divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
            }
        }
        catch
        {
            divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
        }
    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["Cate"]))
        {
            Response.Redirect("NewsAdd.aspx?Cate=" + Request.QueryString["Cate"].ToString());
        }
        else
        {
            Response.Redirect("NewsAdd.aspx");
        }
    }



    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        divMessage.InnerHtml = "";
        if (ddlModule.SelectedValue == "0")
        {
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            CollectionPager1.DataSource = news.SelectByModuleID(int.Parse(ddlModule.SelectedValue)).DefaultView;
            CollectionPager1.DataBind();
            CollectionPager1.PageSize = int.MaxValue;
            CollectionPager1.BindToControl = rptData;
            rptData.DataSource = CollectionPager1.DataSourcePaged;
            rptData.DataBind();
            if (rptData.Items.Count == 0)
            {
                divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
            }
        }
    }
    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        try
        {
            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {

                try
                {
                    DataTable db = news.GetNewsByID(sp_list[i]);
                    bool kt = File.Exists(Server.MapPath("~/Images/news/") + db.Rows[0]["IMAGE"]);
                    if (kt)
                        File.Delete(Server.MapPath("~/Images/news/") + db.Rows[0]["IMAGE"]);
                }
                catch (Exception)
                {

                    throw;
                }

                news.tblNewsDelete(int.Parse(sp_list[i]));
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dbSearch = news.SearchByTitle(txtSearch.Value.Trim());
        rptData.DataSource = dbSearch;
        rptData.DataBind();
    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dr = e.Item.DataItem as DataRowView;
        Literal ltName = e.Item.FindControl("ltName") as Literal;

        string _cate = dr["CATEGORYID"].ToString();

        string[] sp_list = _cate.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < sp_list.Length; i++)
        {
            DataTable db = objCate.GetDataByID(sp_list[i].ToString());
            try
            {
                ltName.Text += "<span class='itemCate'>" + db.Rows[0]["NAME"].ToString() + "</span>";
            }
            catch
            {
                ltName.Text += "";
            }
            
        }


    }
}
