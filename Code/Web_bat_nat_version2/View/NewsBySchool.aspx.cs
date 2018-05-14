using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_NewsBySchool : System.Web.UI.Page
{
    SchoolController objSchool = new SchoolController();
    public string _schoolID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _schoolID = Request.QueryString["ID"].ToString();
            loadData();
        }
    }
    void loadData()
    {
        DataTable dbSchool = objSchool.GetDataByID(Convert.ToInt32(Request.QueryString["ID"].ToString()));
        if (dbSchool.Rows.Count > 0)
        {
            string _schoolName = dbSchool.Rows[0]["School_Name"].ToString();
            ltSchoolName.Text = _schoolName;
            string _linkFacebook = dbSchool.Rows[0]["Link_Facebook"].ToString();
            if (_linkFacebook == "")
            {
                ltFacebookSchool.Text = "Chưa cập nhật.";
            }
            else
            {
                ltFacebookSchool.Text = "<a href='" + _linkFacebook + "' target='_blank'>" + _linkFacebook + "</a>";
            }

            this.Title = _schoolName;
        }
    }
}