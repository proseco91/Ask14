using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;

public partial class View_OpenFilePdf : System.Web.UI.Page
{
    UploadFileController objUpload = new UploadFileController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData();
            }
        }
    }
    void loadData()
    {

        DataTable db = objUpload.GetDataByID(Convert.ToInt32(Request.QueryString["ID"].ToString()));

        if (db.Rows.Count > 0)
        {
            string file = db.Rows[0]["FILE_NAME"].ToString();

            string FilePath = Server.MapPath("upload/" + file + "");

            WebClient User = new WebClient();

            Byte[] FileBuffer = User.DownloadData(FilePath);

            if (FileBuffer != null)
            {

                Response.ContentType = "application/pdf";

                Response.AddHeader("content-length", FileBuffer.Length.ToString());

                Response.BinaryWrite(FileBuffer);

            }
        }
    }
}