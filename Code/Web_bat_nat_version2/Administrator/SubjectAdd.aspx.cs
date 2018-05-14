using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

public partial class Administrator_SubjectAdd : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    SubjectController objSubject = new SubjectController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData();
                btnSubmit.Text = "Cập nhật";
            }
        }
    }
    public int GetRandom()
    {
        Random rd = new Random();
        int a = rd.Next(1, 100);
        return a;
    }
    void loadData()
    {
        DataTable db = objSubject.GetDataByID(Convert.ToInt32(Request.QueryString["ID"].ToString()));
        if (db.Rows.Count > 0)
        {
            txtSubjectName.Text = db.Rows[0]["NAME"].ToString();
            txtSummury.Text = db.Rows[0]["SUMMURY"].ToString();
            imgDes.ImageUrl = "../images/subject/" + db.Rows[0]["IMAGE"].ToString();
            string _status = db.Rows[0]["STATUS"].ToString();
            if (_status == "1")
            {
                chkStatus.Checked = true;
            }
            else
            {
                chkStatus.Checked = false;
            }

            int _isHot = Convert.ToInt32(db.Rows[0]["isHot"].ToString());
            if (_isHot == 1)
                chkIsHot.Checked = true;
            else
                chkIsHot.Checked = false;

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string _name = txtSubjectName.Text;
        string _summury = txtSummury.Text;

        int _status = 0;
        if (chkStatus.Checked)
        {
            _status = 1;
        }
        else
        {
            _status = 0;
        }

        int _isHot = 0;
        if (chkIsHot.Checked)
            _isHot = 1;
        else
            _isHot = 0;

        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            string _image = "";
            if (fuImage.HasFile)
            {
                _image = Lib.LocDauFileName(GetRandom() + "_" + fuImage.FileName);
                fuImage.SaveAs(Server.MapPath("~/Images/subject/") + _image);
                //resize ảnh
                //Bitmap images = Lib.ResizeImage(fuImage.PostedFile.InputStream, 182, 125);
                //images.Save(Server.MapPath("~/Images/subject/") + _image);
            }
            else
            {
                DataTable db = objSubject.GetDataByID(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                _image = db.Rows[0]["IMAGE"].ToString();
            }

            bool kt = objSubject.Update(Convert.ToInt32(Request.QueryString["ID"].ToString()), _name, _image, _summury, _status, _isHot);
            if (kt)
            {
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " thực hiện thành công.");
            }
            else
            {
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " phát sinh lỗi.");
            }

        }
        else
        {
            string _image = "";
            if (fuImage.HasFile)
            {
                _image = Lib.LocDauFileName(GetRandom() + "_" + fuImage.FileName);
                fuImage.SaveAs(Server.MapPath("~/Images/subject/") + _image);
                //resize ảnh
                //Bitmap images = Lib.ResizeImage(fuImage.PostedFile.InputStream, 182, 125);
                //images.Save(Server.MapPath("~/Images/subject/") + _image);
            }
            int a = objSubject.Insert(_name, _image, _summury, DateTime.Now, _status, _isHot);
            if (a > 0)
            {
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " thực hiện thành công.");
            }
            else
            {
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " phát sinh lỗi.");
            }
        }
    }
}