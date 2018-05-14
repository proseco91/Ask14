using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;

public partial class Administrator_PictureEdit : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    PictureController objPicture = new PictureController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData(Convert.ToInt32(Request.QueryString["ID"]));
                btnSubmit.Text = "Cập nhật";
            }
            else
            {
                fuImage.CssClass = "required file";
            }
        }
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "../ckfinder/";
        //_FileBrowser.SetupCKEditor(txtSumary);
        _FileBrowser.SetupCKEditor(TextBox1);
    }
    void loadData(int ID)
    {
        DataTable dbPicture = objPicture.GetDataByID(ID);
        txtName.Text = dbPicture.Rows[0]["TITLE"].ToString();
        TextBox1.Text = dbPicture.Rows[0]["DESCRIPTION"].ToString();
        imgDescription.ImageUrl = "../images/photoView/" + dbPicture.Rows[0]["AVARTA"].ToString();
        int status = Convert.ToInt32(dbPicture.Rows[0]["STATUS"].ToString());
        if (status == 1)
            cbStatus.Checked = true;
        else
            cbStatus.Checked = false;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string title = txtName.Text;

        string description = TextBox1.Text;
        int status = 0;
        if (cbStatus.Checked)
        {
            status = 1;
        }
        else
        {
            status = 0;
        }

        if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            string fileName = "";
            if (fuImage.HasFile)
            {
                fileName = Guid.NewGuid() + fuImage.FileName;
                Bitmap image = Lib.ResizeImage(fuImage.PostedFile.InputStream, 580, 300);
                image.Save(Server.MapPath("~/images/photoView/") + fileName);
            }
            else
            {
                DataTable dvPic = objPicture.GetDataByID(Convert.ToInt32(Request.QueryString["ID"]));
                fileName = dvPic.Rows[0]["AVARTA"].ToString();
            }
            bool kt = objPicture.Update(Convert.ToInt32(Request.QueryString["ID"]), title, fileName, description, status);
            if (kt == true)
            {
                string a = "";
                if (uploadPhoTo.HasFile)
                {
                    HttpFileCollection hfc = Request.Files;
                    for (int i = 0; i < hfc.Count; i++)
                    {
                        HttpPostedFile hpf = hfc[i];
                        if (!hpf.FileName.Equals(fileName))
                        {

                            try
                            {
                                string fileNameNew = DateTime.Now.Ticks + hpf.FileName;
                                //Lib.ResizeImage(hpf.InputStream, 586, 170).Save(Server.MapPath("~/images/photoView/") + fileNameNew);
                                Lib.ResizeByWidth(hpf.InputStream, 800).Save(Server.MapPath("~/images/photoView/") + fileNameNew);
                                InsertPhtoView(Convert.ToInt32(Request.QueryString["ID"]), fileNameNew, DateTime.Now, 1);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
                foreach (DataRow item in getPhoto().Rows)
                {
                    try
                    {
                        if (Request.Form["imgOld" + item["ID"]].Equals("0"))
                        {
                            string _file = Server.MapPath("~/images/photoView/") + item["FILENAME"];
                            cnts.ExcutedCMD("delete from tblPhotoView where ID = " + item["ID"]);
                            if (File.Exists(_file))
                            {
                                File.Delete(_file);
                            }

                        }
                    }
                    catch (Exception ex) { }
                }
                loadData(Convert.ToInt32(Request.QueryString["ID"]));
                btnSubmit.Text = "Cập nhật";
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "thực hiện thành công");
            }
        }
        else
        {
            string fileName = "";
            if (fuImage.HasFile)
            {
                fileName = Guid.NewGuid() + fuImage.FileName;
                Bitmap image = Lib.ResizeImage(fuImage.PostedFile.InputStream, 580, 300);
                image.Save(Server.MapPath("~/images/photoView/") + fileName);
            }


            int a = objPicture.Insert(title, fileName, description, DateTime.Now, status);
            if (a > 0)
            {
                if (uploadPhoTo.HasFile)
                {
                    HttpFileCollection hfc = Request.Files;
                    for (int i = 0; i < hfc.Count; i++)
                    {
                        HttpPostedFile hpf = hfc[i];
                        if (!hpf.FileName.Equals(fileName))
                        {
                            try
                            {
                                string fileNameNew = DateTime.Now.Ticks + hpf.FileName;
                                Lib.ResizeByWidth(hpf.InputStream, 800).Save(Server.MapPath("~/images/photoView/") + fileNameNew);

                                InsertPhtoView(a, fileNameNew, DateTime.Now, 1);
                            }
                            catch (Exception ex) { }
                        }
                    }
                }
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "thực hiện thành công");
            }
            else
            {
                divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", "phát sinh lỗi");
            }
        }
    }
    public DataTable getPhoto()
    {
        return cnts.GetTableWithCommandText("select * from tblPhotoView where PICTURE_ID=" + Request.QueryString["ID"].ToString() + " order by CREATED_DATE ASC");
    }
    public int InsertPhtoView(int PICTURE_ID, string FILENAME, DateTime CREATED_DATE, int STATUS)
    {
        string[] para = new string[] { "@PICTURE_ID", "@FILENAME", "@CREATED_DATE", "@STATUS" };
        object[] obj = new object[] { PICTURE_ID, FILENAME, CREATED_DATE, STATUS };
        return cnts.insert("tblPhotoView_Insert", para, obj);
    }
}