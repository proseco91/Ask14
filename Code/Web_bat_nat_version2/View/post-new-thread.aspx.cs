using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class View_post_new_thread : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    SubjectController objSubject = new SubjectController();
    ForumController objForum = new ForumController();
    CustomerController objCust = new CustomerController();
    public string scttttt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (string.IsNullOrEmpty(Session["email"].ToString()))
            //{
            //    Response.Redirect(Lib.urlHome());
            //}
            //else
            //{
            loadSubject();
            loadData();
            //}
        }
    }
    void loadSubject()
    {
        DataTable db = objSubject.GetAll();
        drvSubject.DataSource = db;
        drvSubject.DataTextField = "NAME";
        drvSubject.DataValueField = "ID";
        drvSubject.DataBind();
    }
    void loadData()
    {
        if (!string.IsNullOrEmpty(Session["subjectID"].ToString()))
        {
            drvSubject.SelectedValue = Session["subjectID"].ToString();
        }
        if (!string.IsNullOrEmpty(Session["chuDeKhac"].ToString()))
        {
            txtChuDeKhac.Text = Session["chuDeKhac"].ToString();
        }
        if (!string.IsNullOrEmpty(Session["tenBaiViet"].ToString()))
        {
            txtArticleName.Text = Session["tenBaiViet"].ToString();
        }
        if (!string.IsNullOrEmpty(Session["content"].ToString()))
        {
            txtContent.Value = Session["content"].ToString();
        }
    }
    protected void drvSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drvSubject.SelectedValue == "6")
        {
            otherSubject.Visible = true;
            txtChuDeKhac.CssClass = "required";
        }
        else
        {
            otherSubject.Visible = false;
            txtChuDeKhac.CssClass = "";
        }
    }
    protected void btnChiaSeCauChuyenCuaBan_Click(object sender, EventArgs e)
    {
        int _subjectID = Convert.ToInt32(drvSubject.SelectedValue);
        string _chuDeKhac = txtChuDeKhac.Text;
        string _tenBaiViet = txtArticleName.Text;
        string _content = txtContent.Value;
        string _email = Session["email"].ToString();
        int _custID = 0;

        Session["subjectID"] = _subjectID.ToString();
        Session["chuDeKhac"] = _chuDeKhac;
        Session["tenBaiViet"] = _tenBaiViet;
        Session["content"] = _content;

        if (_email == "")
        {
            scttttt = "return false;";
        }
        else
        {
            DataTable dbCust = objCust.GetDataByEmail(_email);
            if (dbCust.Rows.Count > 0)
            {
                _custID = Convert.ToInt32(dbCust.Rows[0]["ID"].ToString());
            }

            int fourmID = 0;
            //Kiểm tra xem _tenChuDe khác có khác rỗng hay không và _subjectID có bằng 6 hay không?
            if (_subjectID == 6)
            {
                int subjectNewID = objSubject.Insert(_chuDeKhac, "", "Đây là chủ đề được thêm từ các học viên " + _custID + "", DateTime.Now, 0,0);
                //insert forum
                fourmID = objForum.Insert(subjectNewID, _custID, _tenBaiViet, _content, DateTime.Now, 1);
            }
            else
            {
                fourmID = objForum.Insert(_subjectID, _custID, _tenBaiViet, _content, DateTime.Now, 1);
            }
            scttttt = "alert('Post bài thành công.')";
            txtContent.Value = "";
            txtArticleName.Text = "";
            txtChuDeKhac.Text = "";
            Session["subjectID"] = "";
            Session["chuDeKhac"] = "";
            Session["tenBaiViet"] = "";
            Session["content"] = "";
        }
    }
}