using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;

public partial class Administrator_SlideShowedit : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    SlideShowController objSlide = new SlideShowController();
    protected void Page_Load(object sender, EventArgs e)
    {
        //check cookie
        Lib.CheckCookieAdmin();
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData(Convert.ToInt32(Request.QueryString["ID"]));
                btnSubmit.Text = "Cập nhật";
            }
        }
    }
    void loadData(int ID)
    {
        DataTable db = objSlide.GetDataByID(ID);
        if (db.Rows.Count > 0)
        {
            txtName.Text = db.Rows[0]["NAME"].ToString();
            txtLink.Text = db.Rows[0]["LINK"].ToString();
            txtSumary.Text = db.Rows[0]["DESCRIPTION"].ToString();
            drvTypeSlide.SelectedValue = db.Rows[0]["TYPE"].ToString();

            txtSortDisplay.Text = db.Rows[0]["SORT_DISPLAY"].ToString();
            if (db.Rows[0]["STATUS"].ToString() == "1")
                cbStatus.Checked = true;
            else
                cbStatus.Checked = false;

            imgFile.ImageUrl = "~/images/SlideShow/" + db.Rows[0]["IMAGE"].ToString();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string link = txtLink.Text;
        int sortDisplay = Convert.ToInt32(txtSortDisplay.Text);
        string fileName = "";
        int type = Convert.ToInt32(drvTypeSlide.SelectedValue);
        string _des = txtSumary.Text;

        int status = 0;
        if (cbStatus.Checked)
            status = 1;
        else
            status = 0;
        if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            if (fuImage.HasFile)
            {
                fileName = Lib.LocDauFileName(Guid.NewGuid() + "-" + fuImage.FileName);
                if (type == 0)
                    Lib.ResizeImage(fuImage.PostedFile.InputStream, 1285, 723).Save(Server.MapPath("~/images/SlideShow/") + fileName);
                else
                    Lib.ResizeImage(fuImage.PostedFile.InputStream, 1200, 400).Save(Server.MapPath("~/images/SlideShow/") + fileName);
            }
            else
            {
                DataTable db = objSlide.GetDataByID(Convert.ToInt32(Request.QueryString["ID"]));
                fileName = db.Rows[0]["IMAGE"].ToString();
            }

            bool kt = objSlide.Update(Convert.ToInt32(Request.QueryString["ID"].ToString()), name, fileName, link, sortDisplay, status, _des, type);
            if (kt)
                divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "thực hiện thành công");
            else
                divMessage.InnerHtml = O2S_Message.Error("Hệ thống", "phát sinh lỗi");
        }
        else
        {
            if (fuImage.HasFile)
            {
                fileName = Lib.LocDauFileName(Guid.NewGuid() + "-" + fuImage.FileName);
                fuImage.SaveAs(Server.MapPath("~/images/SlideShow/" + fileName));
                if (type == 0)
                    Lib.ResizeImage(fuImage.PostedFile.InputStream, 1285, 723).Save(Server.MapPath("~/images/SlideShow/") + fileName);
                else
                    Lib.ResizeImage(fuImage.PostedFile.InputStream, 1200, 400).Save(Server.MapPath("~/images/SlideShow/") + fileName);
            }
            int a = objSlide.Insert(name, fileName, link, sortDisplay, DateTime.Now, status, _des, type);
            if (a > 0)
                divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "thực hiện thành công");
            else
                divMessage.InnerHtml = O2S_Message.Error("Hệ thống", "phát sinh lỗi");
        }
    }
}