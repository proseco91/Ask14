using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;

public partial class Administrator_AskUpdate : System.Web.UI.Page
{
    HoiDapController objHoiDap = new HoiDapController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData(Convert.ToInt32(Request.QueryString["ID"]));
            }
            CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
            _FileBrowser.BasePath = "../ckfinder/";
            //_FileBrowser.SetupCKEditor(txtSumary);
            _FileBrowser.SetupCKEditor(txtAnswe12312312312rytuy);
            _FileBrowser.SetupCKEditor(txtQuestion);
        }
    }
    void loadData(int Id)
    {
        DataTable db = objHoiDap.GetDataByID(Id);
        if (db.Rows.Count > 0)
        {
            txtQuestion.Text = db.Rows[0]["DESCRIPTION"].ToString();
            txtAnswe12312312312rytuy.Text = db.Rows[0]["ANSWER"].ToString();
            int _status = Convert.ToInt32(db.Rows[0]["STATUS"].ToString());
            if (_status == 1)
                chkStatus.Checked = true;
            else
                chkStatus.Checked = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string _question = txtQuestion.Text;
        string _answer = txtAnswe12312312312rytuy.Text;
        int _status = 0;
        if (chkStatus.Checked)
        {
            _status = 1;
        }
        else
        {
            _status = 0;
        }

        bool kt = false;

        if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            kt = objHoiDap.Update(Convert.ToInt32(Request.QueryString["ID"]), _question, _answer, _status);
        }
        else
        {
            int a = objHoiDap.Insert(_question, _answer, Session["username"].ToString(), DateTime.Now, _status);
            if (a > 0)
            {
                kt = true;
            }
        }


        if (kt)
        {
            divMessage.InnerHtml = O2S_Message.Success("Hệ thống", " thực hiện thành công.");
        }
        else
        {
            divMessage.InnerHtml = O2S_Message.Error("Hệ thống", " phát sinh lỗi.");
        }
    }
}