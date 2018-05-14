using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_TestimonialEdit : System.Web.UI.Page
{
    TestimonialController objTestimonial = new TestimonialController();
    ConnectSQL cnts = new ConnectSQL();
    public string ten_anh = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (String.IsNullOrEmpty(Request.QueryString["ID"]) == false)
            {

                loadData();
                btnSubmit.Text = "Cập nhật";
            }
        }

    }

    private void loadData()
    {
        DataTable db = objTestimonial.GetDataByID(Request.QueryString["ID"]);
        txtTitle.Text = db.Rows[0]["NAME"].ToString();
        txtDescription.Text = db.Rows[0]["DESCRIPTION"].ToString();
        string statuts = db.Rows[0]["STATUS"].ToString();
        if (statuts == "1")
            cbStatus.Checked = true;
        else
            cbStatus.Checked = false;
        ten_anh = db.Rows[0]["IMAGE"].ToString();
        imgDescription.ImageUrl = "~/images/testimonial/" + ten_anh;
        txtIntro.Text = db.Rows[0]["SUMMURY"].ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtTitle.Text;
        string description = txtDescription.Text;

        int status = 0;
        if (cbStatus.Checked == true)
            status = 1;
        else
            status = 0;
        string summury = txtIntro.Text;
        if (String.IsNullOrEmpty(Request.QueryString["ID"]) == false)
        {

            if (fuImage.HasFile)
            {
                ten_anh = GetRandom() + "" + fuImage.FileName;
                //fuImage.SaveAs(Server.MapPath("~/images/testimonial/") + ten_anh);
                Lib.ResizeImage(fuImage.PostedFile.InputStream, 156, 154).Save(Server.MapPath("~/images/testimonial/") + ten_anh);
            }
            else
            {
                DataTable db = objTestimonial.GetDataByID(Request.QueryString["ID"]);
                ten_anh = db.Rows[0]["IMAGE"].ToString();
            }

            bool kt = objTestimonial.Update(int.Parse(Request.QueryString["ID"]), name, ten_anh, summury, description, DateTime.Now, status);
            if (kt == true)
            {
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "thực hiện thành công");
            }
            else
            {
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Hệ thống", "phát sinh lỗi");
            }
        }
        else
        {
            if (fuImage.HasFile)
            {
                ten_anh = GetRandom() + "" + fuImage.FileName;
                //fuImage.SaveAs(Server.MapPath("~/images/testimonial/") + ten_anh);
                Lib.ResizeImage(fuImage.PostedFile.InputStream, 156, 154).Save(Server.MapPath("~/images/testimonial/") + ten_anh);
            }
            int a = objTestimonial.Insert(name, ten_anh, summury, description, DateTime.Now, status);
            if (a > 0)
            {
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "thực hiện thành công");
            }
            else
            {
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Hệ thống", "phát sinh lỗi");
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