using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;
using System.IO;
public partial class Administrator_TestimonialList : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    TestimonialController objTestimonial = new TestimonialController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        DataTable db = cnts.GetTableWithCommandText("Select * From tblTestimonial order by CREATED_DATE desc");
        rptData.DataSource = db;
        rptData.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {
                DataTable db = objTestimonial.GetDataByID(sp_list[i]);
                try
                {
                    bool kt = File.Exists(Server.MapPath("~/images/testimonial/" + db.Rows[0]["IMAGE"].ToString()));
                    if (kt)
                    {
                        File.Delete(Server.MapPath("~/images/testimonial/") + db.Rows[0]["IMAGE"].ToString());
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                objTestimonial.Delete(int.Parse(sp_list[i]));



            }
            loadData();
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestimonialEdit.aspx");
    }
}