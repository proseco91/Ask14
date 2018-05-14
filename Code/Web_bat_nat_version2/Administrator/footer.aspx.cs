using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;

public partial class Administrator_footer : System.Web.UI.Page
{
    private FooterController objFooter = new FooterController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();
        }
    }

    private void getdata()
    {
        try
        {
            DataTable dt = objFooter.GetData();
            txtContent.Text = dt.Rows[0]["content"].ToString();
        }
        catch
        {

            txtContent.Text = "";
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string content = txtContent.Text;
        if (objFooter.Update(content) == true)
        {
            divMessage.InnerHtml = O2S_Message.Success("Thông báo", "Cập nhật dữ liệu thành công!");
        }
        else
        {
            divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Lỗi xảy ra khi cập nhật dữ liệu!");
        }
    }
}