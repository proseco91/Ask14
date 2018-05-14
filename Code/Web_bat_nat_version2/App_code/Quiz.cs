using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Quiz
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class Quiz : System.Web.Services.WebService
{
    LinqDataContext sql = new LinqDataContext();
    public Quiz()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }



    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(EnableSession = true)]
    public bool action_update_status(int ID)
    {
        if (Session["username"] != null && !string.IsNullOrEmpty(Session["username"].ToString()))
        {
            tblQuiz _quiz = (from p in sql.tblQuizs where p.ID == ID select p).FirstOrDefault();
            _quiz.Status = _quiz.Status == 0 ? 1 : 0;
            sql.SubmitChanges();
            return true;
        }
        return false;
    }
    [WebMethod(EnableSession = true)]
    public object[] actionQuiz(string txtJson, int ID, string keyguid)
    {
        List<StrucQuestionNew> _arrayOld = (List<StrucQuestionNew>)Session["listArrayStrucNew-" + ID + '-' + keyguid];
        int _couQuestion = 0;
        foreach (StrucQuestionNew item in _arrayOld)
        {
            _couQuestion += item.arrayQuestion.Count;
        }
        List<Strucsaveactionnew> _arrayNow = JsonConvert.DeserializeObject<List<Strucsaveactionnew>>(txtJson);
        List<object[]> _return = new List<object[]>();
        foreach (Strucsaveactionnew item in _arrayNow)
        {
            item.isTrue = false;
            ArrayQuestion itemCheck = _arrayOld.Where(d => d.arrayQuestion.Where(c => c.ID.Equals(item.id)).ToArray().Length > 0).FirstOrDefault().arrayQuestion.Where(d => d.ID.Equals(item.id)).FirstOrDefault();
            if (itemCheck != null)
            {
                if (Lib.checkQuestionNew(item, itemCheck))
                {
                    item.isTrue = true;
                }
            }
            _return.Add(new object[] { item.id, itemCheck.htmltrue, item.isTrue });

            //if (!item.isTrue)
            //{
            //    _return.Add(new object[] { item.id, itemCheck.htmltrue });
            //}
        }
        tblSaveQuiz _sqveQ = new tblSaveQuiz();
        _sqveQ.IDQuiz = ID;
        _sqveQ.CreateDate = DateTime.Now;
        _sqveQ.Dung = _return.Where(d => Convert.ToBoolean(d[2])).Count();
        _sqveQ.Sai = _return.Where(d => !Convert.ToBoolean(d[2])).Count();
        sql.tblSaveQuizs.InsertOnSubmit(_sqveQ);
        sql.SubmitChanges();
        return new object[] { 1, _return };
    }
    [WebMethod(EnableSession = true)]
    public object[] saveQuiz(string data)
    {
        if (Session["username"] != null && !string.IsNullOrEmpty(Session["username"].ToString()))
        {
            dynamic obj_all = JsonConvert.DeserializeObject<ExpandoObject>(data);
            if (obj_all.id == -1)
            {
                dynamic ac = obj_all.setting;

                string acv = ac.setting_title;
                tblQuiz _quiz = new tblQuiz();
                _quiz.Title = obj_all.setting.setting_title + "";
                _quiz.Des = obj_all.setting.setting_des + "";
                _quiz.Min = Convert.ToInt32(obj_all.setting.setting_min);
                _quiz.Status = Convert.ToInt32(obj_all.setting.setting_status);
                _quiz.CreateDate = DateTime.Now;
                _quiz.Question = JsonConvert.SerializeObject(obj_all.questions);
                sql.tblQuizs.InsertOnSubmit(_quiz);
                sql.SubmitChanges();
                if (_quiz.ID != null && _quiz.ID > 0)
                {
                    string fileName = _quiz.ID + "-quiz-avarta.jpg";
                    Lib.ResizeByWidth(new MemoryStream(Convert.FromBase64String(Regex.Replace((string)obj_all.setting.setting_img, "data:image/.*?;base64,", ""))), 800).Save(Server.MapPath("~/images/news/") + fileName, ImageFormat.Png);
                    _quiz.Img = fileName;
                    sql.SubmitChanges();
                    return new object[] { true, _quiz.ID };
                }
                else
                {
                    return new object[] { false, "Tạo bài trắc nghiệm thất bại" };
                }
            }
            else
            {
                int _id = Convert.ToInt32(obj_all.id);
                tblQuiz _quiz = (from p in sql.tblQuizs where p.ID == _id select p).FirstOrDefault();
                if (_quiz == null)
                    return new object[] { false, "Không tìm thấy bài trắc nghiệm cần cập nhật" };
                else
                {
                    _quiz.Title = obj_all.setting.setting_title + "";
                    _quiz.Des = obj_all.setting.setting_des + "";
                    _quiz.Min = Convert.ToInt32(obj_all.setting.setting_min);
                    _quiz.Status = Convert.ToInt32(obj_all.setting.setting_status);
                    _quiz.Question = JsonConvert.SerializeObject(obj_all.questions);
                    string fileName = _quiz.ID + "-quiz-avarta.jpg";
                    Lib.ResizeByWidth(new MemoryStream(Convert.FromBase64String(Regex.Replace((string)obj_all.setting.setting_img, "data:image/.*?;base64,", ""))), 800).Save(Server.MapPath("~/images/news/") + fileName, ImageFormat.Png);
                    _quiz.Img = fileName;
                    sql.SubmitChanges();
                    return new object[] { false, "Cập nhật thành công" };
                }
            }
        }
        else
        {
            return new object[] { false, "Đăng nhập để sử dụng" };
        }
    }
}
