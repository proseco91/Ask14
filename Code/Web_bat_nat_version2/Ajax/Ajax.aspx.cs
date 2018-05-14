using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft;
using Newtonsoft.Json;
using System.Data;
public partial class Ajax_Ajax : System.Web.UI.Page
{
    CommentForum objCommentForum = new CommentForum();
    CustomerController objCustomer = new CustomerController();
    protected void Page_Load(object sender, EventArgs e)
    {

        string type = Request.Params["type"] + "".Trim();
        if (type.Equals("commentForum"))
        {
            ConnectSQL cnts = new ConnectSQL();
            //CommentNewsController objCommentNews = new CommentNewsController();
            string custEmail = Request.Params["_custEmail"].ToString();
            int forumID = Convert.ToInt32(Request.Params["_threadID"]);
            string comment = Request.Params["_comment"];

            //Lấy customerID theo custEmail
            int _CustID = 0;
            string _avatar = "";
            string _name = "";
            DateTime _DatePost = new DateTime();
            DataTable dbCust = objCustomer.GetDataByEmail(custEmail);
            if (dbCust.Rows.Count > 0)
            {
                _CustID = Convert.ToInt32(dbCust.Rows[0]["ID"].ToString());
                _avatar = dbCust.Rows[0]["AVARTA"].ToString();
                _name = dbCust.Rows[0]["CUSTOMER_NAME"].ToString();
            }
            _DatePost = DateTime.Now;
            int commentID = objCommentForum.Insert(forumID, comment, _CustID, _DatePost, 2);
            if (commentID > 0)
            {
                Response.Write(JsonConvert.SerializeObject(new Object[] { true, _name, _avatar, _DatePost }));
            }
            else
            {
                Response.Write(JsonConvert.SerializeObject(new Object[] { false }));
            }
        }
        else if (type.Equals("insertLikeThread"))
        {
            ConnectSQL cnts = new ConnectSQL();
            CountLikeController objCountLike = new CountLikeController();
            int _threadID = Convert.ToInt32(Request.Params["_threadID"]);
            string _email = Request.Params["_email"].ToString();

            int _idCount = objCountLike.Insert(_threadID, _email, DateTime.Now, 1);
            if (_idCount > 0)
                Response.Write(JsonConvert.SerializeObject(true));
            else
                Response.Write(JsonConvert.SerializeObject(false));
        }

        else if (type.Equals("insertLikeCommentThread"))
        {
            ConnectSQL cnts = new ConnectSQL();
            CountLikeCommentController objCountLikeComment = new CountLikeCommentController();
            int _commentId = Convert.ToInt32(Request.Params["_commentId"]);
            string _email = Request.Params["_email"].ToString();

            int _idCount = objCountLikeComment.Insert(_commentId, _email, DateTime.Now, 1);
            if (_idCount > 0)
                Response.Write(JsonConvert.SerializeObject(true));
            else
                Response.Write(JsonConvert.SerializeObject(false));
        }
        else if (type.Equals("deleteLikeCommentThread"))
        {
            ConnectSQL cnts = new ConnectSQL();
            CountLikeCommentController objCountLikeComment = new CountLikeCommentController();
            int _commentId = Convert.ToInt32(Request.Params["_commentId"]);
            string _email = Request.Params["_email"].ToString();
            bool kt = objCountLikeComment.Delete(_commentId, _email);
            Response.Write(JsonConvert.SerializeObject(kt));

        }



        else if (type.Equals("deleteLikeThread"))
        {
            ConnectSQL cnts = new ConnectSQL();
            CountLikeController objCountLike = new CountLikeController();
            int _threadID = Convert.ToInt32(Request.Params["_threadID"]);
            string _email = Request.Params["_email"].ToString();

            bool kt = objCountLike.Delete(_threadID, _email);
            if (kt)
                Response.Write(JsonConvert.SerializeObject(true));
            else
                Response.Write(JsonConvert.SerializeObject(false));
        }
        else if (type.Equals("checkLikeThread"))
        {
            ConnectSQL cnts = new ConnectSQL();
            CountLikeController objCountLike = new CountLikeController();
            int _threadID = Convert.ToInt32(Request.Params["_threadID"]);
            string _email = Request.Params["_email"].ToString();

            DataTable _countLikeThread = objCountLike.CheckCountThread(_threadID);
            int _coutLikeThread = _countLikeThread.Rows.Count;

            DataTable _checkCount = objCountLike.CheckCount(_threadID, _email);
            int _count = _checkCount.Rows.Count;
            if (_count > 0)
                Response.Write(JsonConvert.SerializeObject(new object[] { true, _coutLikeThread }));
            else
                Response.Write(JsonConvert.SerializeObject(new object[] { false, _coutLikeThread }));
        }
        else if (type.Equals("countLikeThread"))
        {
            ConnectSQL cnts = new ConnectSQL();
            CountLikeController objCountLike = new CountLikeController();
            int _threadID = Convert.ToInt32(Request.Params["_threadID"]);

            DataTable _countLikeThread = objCountLike.CheckCountThread(_threadID);
            int _coutLikeThread = _countLikeThread.Rows.Count;


            Response.Write(JsonConvert.SerializeObject(new object[] { true, _coutLikeThread }));

        }
    }
}