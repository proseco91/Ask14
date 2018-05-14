using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;
public partial class Administrator_SchoolAdd : System.Web.UI.Page
{
    SchoolController objSchool = new SchoolController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["SchoolID"]))
            {
                loadData();
            }
        }
    }
    void loadData()
    {
        DataTable db = objSchool.GetDataByID(Convert.ToInt32(Request.QueryString["SchoolID"].ToString()));
        if (db.Rows.Count > 0)
        {
            txtTitle.Text = db.Rows[0]["School_Name"].ToString();
            imgDescription.ImageUrl = "~/images/schools/" + db.Rows[0]["School_Image"].ToString();
            int _status = Convert.ToInt32(db.Rows[0]["Status"].ToString());
            if (_status == 1)
            {
                cbStatus.Checked = true;
            }
            else
            {
                cbStatus.Checked = false;
            }
            txtLinkFacebook.Text = db.Rows[0]["Link_Facebook"].ToString();
        }
    }
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string _name = txtTitle.Text;
        int _status = 0;
        if (cbStatus.Checked)
        {
            _status = 1;
        }
        else
        {
            _status = 0;
        }


        string _linkFacebook = txtLinkFacebook.Text;

        if (!String.IsNullOrEmpty(Request.QueryString["SchoolID"]))
        {
            string _image = "";
            if (fuImage.HasFile)
            {
                _image = Lib.LocDauFileName(GetRandom() + "_" + fuImage.FileName);
                //resize ảnh
                Bitmap images = Lib.ResizeImage(fuImage.PostedFile.InputStream, 200, 200);
                images.Save(Server.MapPath("~/Images/schools/") + _image);
            }
            else
            {
                DataTable db = objSchool.GetDataByID(Convert.ToInt32(Request.QueryString["SchoolID"].ToString()));
                _image = db.Rows[0]["School_Image"].ToString();
            }
            bool kt = objSchool.Update(Convert.ToInt32(Request.QueryString["SchoolID"].ToString()), _name, _image, _status, _linkFacebook);
            if (kt)
            {
                divMessage.InnerHtml = O2S_Message.Success("Hệ thống", " thực hiện thành công");
            }
            else
            {
                divMessage.InnerHtml = O2S_Message.Error("Hệ thống", " phát hiện lỗi.");
            }
        }
        else
        {
            string _image = "";
            if (fuImage.HasFile)
            {
                _image = Lib.LocDauFileName(GetRandom() + "_" + fuImage.FileName);
                //resize ảnh
                Bitmap images = Lib.ResizeImage(fuImage.PostedFile.InputStream, 200, 200);
                images.Save(Server.MapPath("~/Images/schools/") + _image);
            }
            int schoolID = objSchool.Insert(_name, _image, DateTime.Now, _status, _linkFacebook);
            if (schoolID > 0)
            {
                divMessage.InnerHtml = O2S_Message.Success("Hệ thống", " thực hiện thành công");
            }
            else
            {
                divMessage.InnerHtml = O2S_Message.Error("Hệ thống", " phát hiện lỗi.");
            }
        }
    }
    public int GetRandom()
    {
        Random rd = new Random();
        int a = rd.Next(1, 100);
        return a;
    }
}