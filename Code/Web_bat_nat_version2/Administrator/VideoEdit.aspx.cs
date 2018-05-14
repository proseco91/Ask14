using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Administrator_VideoEdit : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    VideoController objVideo = new VideoController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData(int.Parse(Request.QueryString["ID"]));
            }
        }
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "../ckfinder/";
        _FileBrowser.SetupCKEditor(txtContent);

    }
    void loadData(int ID)
    {
        DataTable dbVideo = objVideo.GetDataByID(ID);
        if (dbVideo.Rows.Count > 0)
        {
            txtTitle.Text = dbVideo.Rows[0]["NAME"].ToString();
            txtSortDisplay.Text = dbVideo.Rows[0]["SORT_DISPLAY"].ToString();
            txtLinkYoutube.Text = dbVideo.Rows[0]["LINK_YOUTUBE"].ToString();
            txtContent.Text = dbVideo.Rows[0]["DESCRIPTION"].ToString();
            int status = Convert.ToInt32(dbVideo.Rows[0]["STATUS"].ToString());
            if (status == 1)
                chkStatus.Checked = true;
            else
                chkStatus.Checked = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtTitle.Text;
        int sort_display = Convert.ToInt32(txtSortDisplay.Text);

        string link_youtube = txtLinkYoutube.Text;
        string description = txtContent.Text;
        int status = 0;
        if (chkStatus.Checked)
            status = 1;
        else
            status = 0;
        if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            bool kt = objVideo.Update(Convert.ToInt32(Request.QueryString["ID"].ToString()), name, link_youtube, description, sort_display, DateTime.Now, status);
            if (kt == true)
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " thực hiện thành công");
            else
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " phát sinh lỗi");
        }
        else
        {

            int a = objVideo.Insert(name, link_youtube, description, sort_display, DateTime.Now, status);
            if (a > 0)
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " thực hiện thành công");
            else
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " phát sinh lỗi");
        }
    }

}