using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_BaiVietTheoChuDe : System.Web.UI.Page
{
    ForumController objForum = new ForumController();
    SubjectController objSubject = new SubjectController();
    public string subjectID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        subjectID = Request.QueryString["SubjectID"].ToString();
        DataTable dbGetDataBySubjectID = objForum.GetDataBySubjectID(Convert.ToInt32(subjectID));
        if (dbGetDataBySubjectID.Rows.Count > 0)
        {
            string SubjectName = dbGetDataBySubjectID.Rows[0]["NAME"].ToString();
            ltContent.Text = SubjectName;

            Page.Title = SubjectName;

        }
    }
    public DataTable getSubject()
    {
        return objSubject.GetAllSubectRelates(Convert.ToInt32(Request.QueryString["SubjectID"].ToString()));
    }
}