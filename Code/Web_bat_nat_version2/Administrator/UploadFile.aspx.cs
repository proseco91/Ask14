using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_UploadFile : System.Web.UI.Page
{
    UploadFileController objUpload = new UploadFileController();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string filename;
        if (FileUpload1.HasFile)
        {
            filename = GetRandom() + "" + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/upload/") + filename);
            int a = objUpload.Insert(filename, DateTime.Now, 1);
            Literal1.Text = "http://ask14.vn/upload/" + filename;
            Literal2.Text = "http://ask14.vn/read-pdf-p" + a + ".htm";
        }
    }

    public int GetRandom()
    {
        Random rd = new Random();
        int a = rd.Next(1, 10000);
        return a;
    }
}