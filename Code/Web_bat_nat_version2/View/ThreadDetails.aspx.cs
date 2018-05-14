using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_ThreadDetails : System.Web.UI.Page
{
    CustomerController objCustomer = new CustomerController();
    CommentForum objCommentForum = new CommentForum();
    ConnectSQL cnts = new ConnectSQL();
    ForumController objForum = new ForumController();
    public int _threadID = 0;
    public string scttttt = "";
    public string _avatar = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        try
        {
            _threadID = Convert.ToInt32(Request.QueryString["ThreadID"].ToString());
            DataTable db = objForum.GetDataByID(_threadID);
            if (db.Rows.Count > 0)
            {
                string _title = db.Rows[0]["Article_Name"].ToString();
                ltTitle.Text = _title;
                ltContent.Text = db.Rows[0]["Article_Content"].ToString();
                ltDatetime.Text = db.Rows[0]["Created_Date"].ToString();
                Literal1.Text = db.Rows[0]["NAME"].ToString();
                Page.Title = _title;
                //Tác giả bài viết
                Literal2.Text = db.Rows[0]["CUSTOMER_NAME"].ToString();
                _avatar = db.Rows[0]["AVARTA"].ToString();
                //Số comment bài viết
                Literal3.Text = objCommentForum.GetDataByForumID(_threadID).Rows.Count.ToString();

            }
        }
        catch
        {
            Response.Redirect(Lib.urlHome());
        }
    }
    public DataTable dbTop5Related()
    {
        DataTable db = new DataTable();
        try
        {
            DataTable db2 = objForum.GetDataByID(Convert.ToInt32(Request.QueryString["ThreadID"].ToString()));

            int _subjectID = Convert.ToInt32(db2.Rows[0]["SubjectID"].ToString());
            return objForum.GetTop5DataBy_SubjectID(Convert.ToInt32(Request.QueryString["ThreadID"].ToString()), _subjectID);

        }
        catch
        {

            return db;
        }

    }
    protected void btnDang_Click(object sender, EventArgs e)
    {
        string _textComment = txtComment.Value;
        Session["commentThread"] = _textComment;
        string _email = Session["email"].ToString();
        if (_email == "")
        {
            scttttt = "return false;";
        }
        else
        {

            //Lấy customerID theo custEmail
            int _CustID = 0;
            string _avatar = "";
            string _name = "";
            int forumID = Convert.ToInt32(Request.QueryString["ThreadID"].ToString());
            DateTime _DatePost = new DateTime();
            DataTable dbCust = objCustomer.GetDataByEmail(_email);
            if (dbCust.Rows.Count > 0)
            {
                _CustID = Convert.ToInt32(dbCust.Rows[0]["ID"].ToString());
                _avatar = dbCust.Rows[0]["AVARTA"].ToString();
                _name = dbCust.Rows[0]["CUSTOMER_NAME"].ToString();
            }
            _DatePost = DateTime.Now;
            int commentID = objCommentForum.Insert(forumID, _textComment, _CustID, _DatePost, 2);
            if (commentID > 0)
            {
                scttttt = "alert('Gửi comment thành công.');setInterval(location.href=location.href, 3000);";
            }
        }
    }
    public DataTable dbLoadCommentByThread()
    {
        int _forumID = Convert.ToInt32(Request.QueryString["ThreadID"].ToString());
        DataTable db = objCommentForum.GetDataByForumID(_forumID);
        return db;
    }
}