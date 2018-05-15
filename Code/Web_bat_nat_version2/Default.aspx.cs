using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    TestimonialController objTestimonial = new TestimonialController();
    BizNews objNews = new BizNews();
    SlideShowController objSlide = new SlideShowController();
    SubjectController objSubject = new SubjectController();
    CategoryController objCate = new CategoryController();
    ForumController objForum = new ForumController();
    SchoolController objSchool = new SchoolController();
    CustomerController objCustomer = new CustomerController();
    LinqDataContext sql = new LinqDataContext();


    public string Customer_avatar = "";
    public string _customerName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadSEO();
            Customer_avatar = Session["avatar"].ToString();
            _customerName = Session["customerName"].ToString();
        }
    }
    void loadSEO()
    {
        DataTable dbCate = objCate.GetDataByID("58");
        if (dbCate.Rows.Count > 0)
        {
            Page.Title = dbCate.Rows[0]["Meta_title"].ToString();
            Page.MetaKeywords = dbCate.Rows[0]["Meta_keywords"].ToString();
            Page.MetaDescription = dbCate.Rows[0]["Meta_description"].ToString();
        }
    }
    public List<accccc> GetTracNghiem(int page)
    {
        int pageSize = 4;
        List<accccc> arrRe = new List<accccc>();
        foreach (var _new in (from p in sql.tblQuizs where p.Status == 1  select p).OrderByDescending(d => d.CreateDate).Skip((page - 1) * pageSize).Take(pageSize))
        {
            accccc _data = new accccc();
            _data.CATEGORYNAME = "quiz";
            _data.ID = _new.ID;
            _data.TITLE = _new.Title;
            _data.IMAGE = _new.Img;
            _data.SUMMARY = _new.Des;
            _data.CREATED_DATE = _new.CreateDate;
            arrRe.Add(_data);
        }
        return arrRe;
    }
    public List<accccc> GetHoTro()
    {
        int ID = 49;
        List<accccc> arrRe = new List<accccc>();
        foreach (var _new in (from p in sql.tblNews where p.STATUS == 1 && (p.CATEGORYID.IndexOf(ID + ";") > -1 || p.CATEGORYID.Replace(";", "").Equals(ID.ToString())) select p).OrderByDescending(d => d.CREATED_DATE).Take(3))
        {
            accccc _data = new accccc();
            _data.CATEGORYNAME = "0";
            _data.ID = _new.ID;
            _data.TITLE = _new.TITLE;
            _data.IMAGE = _new.IMAGE;
            _data.SUMMARY = _new.SUMMARY;
            _data.CREATED_DATE = _new.CREATED_DATE;
            arrRe.Add(_data);
        }
        return arrRe;
    }
    public List<accccc> GetDichVu()
    {
        int from = 1;
        int to = 3;
        int ID = 61;


        List<dynamic> arr = new List<dynamic>();
        arr.AddRange((from p in sql.tblNews where p.STATUS == 1 && (p.CATEGORYID.IndexOf(ID + ";") > -1 || p.CATEGORYID.Replace(";", "").Equals(ID.ToString())) select new { id = p.ID, time = p.CREATED_DATE, type = 0 }).OrderByDescending(d=>d.time).Take(to));
        arr.AddRange((from p in sql.tblQuizs where p.Status == 1 select new { id = p.ID, time = p.CreateDate, type = 1 }).OrderByDescending(d => d.time).Take(to));
        arr = arr.OrderByDescending(d => d.time).ToList();
        List<accccc> arrRe = new List<accccc>();
        to = to > arr.Count ? arr.Count : to;
        for (int i = from - 1; i < to; i++)
        {
            dynamic nData = arr[i];
            accccc _data = new accccc();
            int nId = Convert.ToInt32(nData.id);
            if (nData.type == 0)
            {
                tblNew _new = (from p in sql.tblNews where p.ID == nId select p).FirstOrDefault();
                _data.ID = _new.ID;
                _data.CATEGORYNAME = "0";
                _data.TITLE = _new.TITLE;
                _data.IMAGE = _new.IMAGE;
                _data.SUMMARY = _new.SUMMARY;
                _data.CREATED_DATE = _new.CREATED_DATE;
                _data.RowNumber = to - (to - i);
                _data.RecordsTotal = to + 1;
                arrRe.Add(_data);
            }
            else
            {
                tblQuiz _quiz = (from p in sql.tblQuizs where p.ID == nId select p).FirstOrDefault();
                _data.ID = _quiz.ID;
                _data.CATEGORYNAME = "quiz";
                _data.TITLE = _quiz.Title;
                _data.IMAGE = _quiz.Img;
                _data.SUMMARY = _quiz.Des;
                _data.CREATED_DATE = _quiz.CreateDate;
                _data.RowNumber = to - (to - i);
                _data.RecordsTotal = to + 1;
                arrRe.Add(_data);
            }
        }
        return arrRe;
    }

    public DataTable GetAllSchool()
    {
        return objSchool.GetAll();
    }
    public DataTable dbGetSlide()
    {
        return objSlide.GetAllWithStatus();
    }
    public DataTable dbGetTop5Subject()
    {
        return objSubject.GetDataTop5Subject();
    }

    public DataTable dbGetTop3Forum()
    {
        return objForum.GetTop3Data_Latest();
    }

    public DataTable dbGetTopOnline()
    {
        return objCustomer.GetDataIsOnline();
    }

    public List<DataRow> dbGetTestimonial()
    {
        var rand = new Random();
        return objTestimonial.GetAllData().AsEnumerable().OrderBy(r => rand.Next()).AsEnumerable().Take(3).ToList();
    }
    //public DataTable dbNewsDiemNoiBat()
    //{
    //    return objNews.GetNewsByCategoryID_Top3("45");
    //}
    public DataTable dbNewsHightLight()
    {
        return objNews.GetTop3_highlights();
    }


}