using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_TeacherUpdate : System.Web.UI.Page
{
    techerController objTeacher = new techerController();
    protected void Page_Load(object sender, EventArgs e)
    {
        Lib.CheckCookieAdmin();
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["TEACHER_ID"]))
            {
                int itemID = Convert.ToInt32(Request.QueryString["TEACHER_ID"].ToString());
                loadData(itemID);
            }
            else
            {
                return;
            }
        }

    }
    void loadData(int id)
    {
        DataTable db = objTeacher.GetByID(id);
        if (db.Rows.Count > 0)
        {
            txtName.Text = db.Rows[0]["NAME"].ToString();
            txtDescription.Text = db.Rows[0]["DESCRIPTION"].ToString();
            imgDescription.ImageUrl = "~/images/teacher/" + db.Rows[0]["IMAGE"].ToString();
            int status = Convert.ToInt32(db.Rows[0]["STATUS"].ToString());
            if (status == 1)
                cbStatus.Checked = true;
            else
                cbStatus.Checked = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string _name = txtName.Text;
        string _description = txtDescription.Text;
        int _status;
        if (cbStatus.Checked == true)
        {
            _status = 1;
        }
        else
        {
            _status = 0;
        }

        if (string.IsNullOrEmpty(Request.QueryString["TEACHER_ID"]) == false)
        {
            string _image = "";
            if (fuImage.HasFile)
            {
                _image = GetRandom() + "" + fuImage.FileName;
                Lib.ResizeImage(fuImage.PostedFile.InputStream, 300, 300).Save(Server.MapPath("~/images/teacher/") + _image);
            }
            else
            {
                DataTable db = objTeacher.GetByID(int.Parse(Request.QueryString["TEACHER_ID"].ToString()));
                if (db.Rows.Count > 0)
                {
                    _image = db.Rows[0]["IMAGE"].ToString();
                }

            }
            bool kt = objTeacher.Update(int.Parse(Request.QueryString["TEACHER_ID"].ToString()), _name, _image, _description, DateTime.Now, _status);
            if (kt == true)
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "cập nhật thành công");
            else
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Hệ thống", "phát sinh lỗi");
        }
        else
        {
            string _image = "";
            if (fuImage.HasFile)
            {
                _image = GetRandom() + "" + fuImage.FileName;
                Lib.ResizeImage(fuImage.PostedFile.InputStream, 300, 300).Save(Server.MapPath("~/images/teacher/") + _image);
            }
            objTeacher.Insert(_name, _image, _description, DateTime.Now, _status);
            divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "cập nhật thành công");
        }
    }
    public int GetRandom()
    {
        Random rd = new Random();
        int a = rd.Next(1, 100);
        return a;
    }
}