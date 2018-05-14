using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using LibraryO2S;
using System.IO;

public partial class Administrator_ListQuiz : System.Web.UI.Page
{


    BizNews news = new BizNews();
    ConnectSQL cnts = new ConnectSQL();
    CategoryController objCate = new CategoryController();
    LinqDataContext sql = new LinqDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        try
        {
            CollectionPager1.DataSource = Lib.ConvertToDataTable((from p in sql.tblQuizs where p.Status != -1 orderby p.CreateDate descending select p).ToList()).DefaultView;
            CollectionPager1.DataBind();
            CollectionPager1.PageSize = 50;
            CollectionPager1.BindToControl = rptData;
            rptData.DataSource = CollectionPager1.DataSourcePaged;
            rptData.DataBind();
            if (rptData.Items.Count == 0)
            {
                divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
            }
        }
        catch
        {
            divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
        }
    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Quiz.aspx");
    }




    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        try
        {
            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<tblQuiz> arrDe = new List<tblQuiz>();
            for (int i = 0; i < sp_list.Length; i++)
            {
                tblQuiz _quiz = (from p in sql.tblQuizs where p.ID == Convert.ToInt32(sp_list[i]) select p).FirstOrDefault();
                _quiz.Status = -1;
                //try
                //{
                //    DataTable db = news.GetNewsByID(sp_list[i]);
                //    bool kt = File.Exists(Server.MapPath("~/Images/news/") + db.Rows[0]["IMAGE"]);
                //    if (kt)
                //        File.Delete(Server.MapPath("~/Images/news/") + db.Rows[0]["IMAGE"]);
                //}
                //catch (Exception)
                //{

                //    throw;
                //}

                //news.tblNewsDelete(int.Parse(sp_list[i]));
            }
            sql.SubmitChanges();
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {

            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dbSearch = Lib.ConvertToDataTable((from p in sql.tblQuizs where p.Status != -1 && (p.Title.IndexOf(txtSearch.Value.Trim())>-1 || p.Des.IndexOf(txtSearch.Value.Trim())>-1) orderby p.CreateDate descending select p).ToList());
        rptData.DataSource = dbSearch;
        rptData.DataBind();
    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //DataRowView dr = e.Item.DataItem as DataRowView;
        //Literal ltName = e.Item.FindControl("ltName") as Literal;

        //string _cate = dr["CATEGORYID"].ToString();

        //string[] sp_list = _cate.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        //for (int i = 0; i < sp_list.Length; i++)
        //{
        //    DataTable db = objCate.GetDataByID(sp_list[i].ToString());
        //    try
        //    {
        //        ltName.Text += "<span class='itemCate'>" + db.Rows[0]["NAME"].ToString() + "</span>";
        //    }
        //    catch
        //    {
        //        ltName.Text += "";
        //    }

        //}


    }
}
