using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Dynamic;
using System.Net;
public partial class administrator_Quiz : System.Web.UI.Page
{
    public string strucdata = "[]";
    public string contentnews = "";
    public string struc_load = "{}";
    LinqDataContext sql = new LinqDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || String.IsNullOrEmpty(Session["username"].ToString()))
        {
            Response.Redirect("Login.aspx",true);
        }
        else
        {
            int ID = string.IsNullOrEmpty(Request.QueryString["ID"]) ? -1 : Convert.ToInt32(Request.QueryString["ID"]);
            if (ID > 0)
            {
                tblQuiz _quiz = (from p in sql.tblQuizs where p.ID == ID && p.Status != -1 select p).FirstOrDefault();
                if (_quiz == null)
                    Response.Redirect("Quiz.aspx", true);
                dynamic struc_load_obj = new ExpandoObject();
                struc_load_obj.setting_title = _quiz.Title;
                struc_load_obj.setting_min = _quiz.Min;
                struc_load_obj.setting_des = _quiz.Des;
                struc_load_obj.setting_status = _quiz.Status;
                strucdata = _quiz.Question;
                try
                {
                    struc_load_obj.setting_img = "data:image/png;base64," + Convert.ToBase64String(new WebClient().DownloadData(Lib.urlhome + "/images/news/" + _quiz.Img));
                }
                catch (Exception)
                {

                    struc_load_obj.setting_img = "";
                }
                struc_load = JsonConvert.SerializeObject(struc_load_obj);
                this.Title = "Chỉnh sửa " + _quiz.Title;
            }
            else
            {
                this.Title = "Thêm mới bài trắc nghiệm";
            }
        }
    }
    
}