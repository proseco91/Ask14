using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class View_BaiVietTheoTruongHoc : System.Web.UI.Page
{
    ForumController objForum = new ForumController();
    SchoolController objSchool = new SchoolController();
    public string SchoolID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        SchoolID = Request.QueryString["SchoolID"].ToString();
        //DataTable dbGetDataBySchoolID = objForum.GetDataBySchoolID(Convert.ToInt32(SchoolID));
        //if (dbGetDataBySchoolID.Rows.Count > 0)
        //{
        DataTable dbSchoolName = objSchool.GetDataByID(Convert.ToInt32(SchoolID));
        if (dbSchoolName.Rows.Count > 0)
        {
            string SchoolName = dbSchoolName.Rows[0]["School_Name"].ToString();
            ltContent.Text = SchoolName;
            Page.Title = SchoolName;
        }
        //}
    }
}