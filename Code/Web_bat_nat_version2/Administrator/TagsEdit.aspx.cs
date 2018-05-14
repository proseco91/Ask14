using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;
public partial class Administrator_TagsEdit : System.Web.UI.Page
{
    TagsController objTags = new TagsController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
            {
                loadData(Convert.ToInt32(Request.QueryString["ID"]));
            }
        }
    }
    void loadData(int ID)
    {
        DataTable dbCheckTags = objTags.GetDataById(ID);
        if (dbCheckTags.Rows.Count > 0)
        {
            txtTags.Text = dbCheckTags.Rows[0]["NAME"].ToString();
            int _status = Convert.ToInt32(dbCheckTags.Rows[0]["STATUS"].ToString());
            if (_status == 1)
                chkStatus.Checked = true;
            else
                chkStatus.Checked = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string _tags = txtTags.Text;
        int _status = 0;
        if (chkStatus.Checked)
            _status = 1;
        else
            _status = 0;
        bool kt = false;
        if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
        {
            kt = objTags.Update(Convert.ToInt32(Request.QueryString["ID"]), _tags);
        }
        else
        {
            int _tagID = objTags.Insert(_tags, DateTime.Now, _status);
            if (_tagID > 0)
                kt = true;
        }
        if (kt)
        {
            divMessage.InnerHtml = O2S_Message.Success("Hệ thống", " thực hiện thành công");
        }
        else
        {
            divMessage.InnerHtml = O2S_Message.Error("Hệ thống", " phát sinh lỗi");
        }


    }
}