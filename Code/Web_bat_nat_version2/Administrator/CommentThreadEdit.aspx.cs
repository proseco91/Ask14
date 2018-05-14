using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_CommentThreadEdit : System.Web.UI.Page
{
    SubjectController objSubject = new SubjectController();
    CommentForum objCommentForum = new CommentForum();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData(Convert.ToInt32(Request.QueryString["ID"]));
            }
        }
    }
    void loadData(int ID)
    {
        DataTable dbForum = objCommentForum.GetDataByID(ID);
        if (dbForum.Rows.Count > 0)
        {
            txtTenBaiViet.Text = dbForum.Rows[0]["Article_Name"].ToString();
            txtArticleContent.InnerText = dbForum.Rows[0]["Content"].ToString();
            txtCustomerName.Text = dbForum.Rows[0]["CUSTOMER_NAME"].ToString();
            int _status = Convert.ToInt32(dbForum.Rows[0]["Status"].ToString());
            if (_status == 1)
                chkStatus.Checked = true;
            else
                chkStatus.Checked = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string _content = txtArticleContent.Value;
        int _id = Convert.ToInt32(Request.QueryString["ID"]);
        int _status = 0;
        if (chkStatus.Checked)
            _status = 1;
        else
            _status = 0;
        bool kt = objCommentForum.Update(_id, _content, _status);
        if (kt)
        {
            divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " thực hiện thành công");
        }
        else
        {
            divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Hệ thống", " phát sinh lỗi");
        }

    }
}