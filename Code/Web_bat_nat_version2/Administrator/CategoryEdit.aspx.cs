using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class Administrator_CategoryEdit : System.Web.UI.Page
{
    CategoryController objCate = new CategoryController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadParent();
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData(Request.QueryString["ID"].ToString());
                btnSubmit.Text = "Cập nhật";
            }
        }
    }
    void loadData(string ID)
    {
        DataTable db = objCate.GetDataByID(ID);
        txtName.Text = db.Rows[0]["NAME"].ToString();
        drvCategory.SelectedValue = db.Rows[0]["PARENT_ID"].ToString();
        txtLink.Text = db.Rows[0]["LINK"].ToString();
        txtSortDisplay.Text = db.Rows[0]["SORT_DISPLAY"].ToString();
        if (db.Rows[0]["STATUS"].ToString() == "1")
            cbStatus.Checked = true;
        else
            cbStatus.Checked = false;

        if (db.Rows[0]["DISPLAY_MENU"].ToString() == "1")
            chkDisplayMenu.Checked = true;
        else
            chkDisplayMenu.Checked = false;

        txtMetaKeyWords.InnerText = db.Rows[0]["Meta_keywords"].ToString();
        txtMetaTitle.InnerText = db.Rows[0]["Meta_title"].ToString();
        txtMetaDescription.InnerText = db.Rows[0]["Meta_description"].ToString();
    }
    void loadParent()
    {
        drvCategory.Items.Clear();
        drvCategory.Items.Insert(0, new ListItem("Danh mục gốc", "0"));
        showChild(0, "");
    }
    void showChild(int parentID, string space)
    {
        List<Category> lst = objCate.LoadChildNodes(parentID, 0);
        foreach (Category item in lst)
        {
            ListItem obj = new ListItem(space + item.NAME, item.ID.ToString());
            drvCategory.Items.Add(obj);
            showChild(item.ID, space + "--- ---");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        int parentID = Convert.ToInt32(drvCategory.SelectedValue);
        int status = 0;
        if (cbStatus.Checked)
            status = 1;
        else
            status = 0;
        int display_menu = 0;
        if (chkDisplayMenu.Checked)
            display_menu = 1;
        else
            display_menu = 0;
        string link = txtLink.Text;
        string sort_display = txtSortDisplay.Text;
        string meta_keywrods = txtMetaKeyWords.Value;
        string meta_title = txtMetaTitle.Value;
        string meta_description = txtMetaDescription.Value;

        if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            bool kt = objCate.Update(Convert.ToInt32(Request.QueryString["ID"].ToString()), parentID, name, link, sort_display, DateTime.Now, display_menu, status, meta_keywrods, meta_title, meta_description);
            if (kt)
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "thực hiện thành công");
            else
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Hệ thống", " phát sinh lỗi");
        }
        else
        {

            int a = objCate.Insert(parentID, name, link, sort_display, DateTime.Now, display_menu, status, meta_keywrods, meta_title, meta_description);
            if (a > 0)
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "thực hiện thành công");
            else
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Hệ thống", " phát sinh lỗi");
        }
    }
}