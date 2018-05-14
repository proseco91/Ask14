using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_ThreadEdit : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    ForumController objForum = new ForumController();
    SubjectController objSubject = new SubjectController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadSubject();
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData(Convert.ToInt32(Request.QueryString["ID"]));
            }
        }
    }
    void loadData(int ID)
    {
        DataTable dbForum = objForum.GetDataByID(ID);
        if (dbForum.Rows.Count > 0)
        {
            drvSubject.SelectedValue = dbForum.Rows[0]["SubjectID"].ToString();
            txtArticleContent.InnerText = dbForum.Rows[0]["Article_Content"].ToString();
            txtArticleName.Text = dbForum.Rows[0]["Article_Name"].ToString();
            txtCustomerName.Text = dbForum.Rows[0]["CUSTOMER_NAME"].ToString();
            int _status = Convert.ToInt32(dbForum.Rows[0]["Status"].ToString());
            if (_status == 1)
                chkStatus.Checked = true;
            else
                chkStatus.Checked = false;
        }
    }
    void loadSubject()
    {
        DataTable dbSubject = objSubject.GetAll();
        drvSubject.DataSource = dbSubject;
        drvSubject.DataValueField = "ID";
        drvSubject.DataTextField = "NAME";
        drvSubject.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int _Id = Convert.ToInt32(Request.QueryString["ID"].ToString());
        int _SubjectId = Convert.ToInt32(drvSubject.SelectedValue);
        string _articleName = txtArticleName.Text;
        string _articleContent = txtArticleContent.Value;
        int _status = 0;
        if (chkStatus.Checked)
        {
            _status = 1;
        }
        else
        {
            _status = 0;
        }
        bool kt = objForum.Update(_Id, _SubjectId, _articleName, _articleContent, _status);
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