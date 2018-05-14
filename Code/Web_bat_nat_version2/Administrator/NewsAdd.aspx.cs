using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;
using System.Drawing;

public partial class Administrator_ModuleAdd : System.Web.UI.Page
{
    BizNews objNews = new BizNews();
    ConnectSQL cnts = new ConnectSQL();
    CategoryController objCate = new CategoryController();
    TagsController objTags = new TagsController();
    NewsTagsController objNewsTags = new NewsTagsController();
    SchoolController objSchool = new SchoolController();

    public string _cate = "";
    public string _ClassRequired = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadTags();
            loadSchool();
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData(Request.QueryString["ID"].ToString());
                btnSubmit.Text = "Cập nhật";
            }
            else
            {
                _ClassRequired = "required";
            }
            loadParent();

            CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
            _FileBrowser.BasePath = "../ckfinder/";
            //_FileBrowser.SetupCKEditor(txtSumary);
            _FileBrowser.SetupCKEditor(txtContent);
        }
    }
    void loadSchool()
    {
        DataTable dbSchool = objSchool.GetAll();
        drvSchool.DataSource = dbSchool;
        drvSchool.DataTextField = "School_Name";
        drvSchool.DataValueField = "ID";
        drvSchool.DataBind();
    }
    public int GetRandom()
    {
        Random rd = new Random();
        int a = rd.Next(1, 100);
        return a;
    }
    string htmlCate = "";
    string[] listCateOld = { };
    void showChild(int parentID, string space)
    {
        List<Category> lst = objCate.LoadChildNodes(parentID, 0);
        foreach (Category item in lst)
        {
            ListItem obj = new ListItem(space + item.NAME, item.ID.ToString());
            //drvCategory.Items.Add(obj);

            string checkeds = "";
            foreach (var arrID in listCateOld)
            {
                if (!arrID.Trim().Equals(""))
                {
                    if (item.ID == Convert.ToInt32(arrID))
                    {
                        checkeds = "checked='checked'";
                        break;
                    }
                }
            }
            htmlCate += "<div class='inputtypeNew' style='" + (item.ID == 62 || item.ID == 63 || item.ID == 58 ? "display: none;" : "") + "'><span>" + space + "</span><input " + checkeds + " style='clear:left;' type='checkbox' value='" + item.ID + "'/>&nbsp;" + item.NAME + "</div>";
            showChild(item.ID, space + "--- ---");
        }
    }
    void loadParent()
    {
        showChild(0, "");
        txtCategory.Text = htmlCate;
    }
    void loadData(string ID)
    {
        DataTable dbNews = objNews.GetNewsByID(ID);
        if (dbNews.Rows.Count > 0)
        {
            txtTitle.Text = dbNews.Rows[0]["TITLE"].ToString();
            txtSumary.Text = dbNews.Rows[0]["SUMMARY"].ToString();
            txtContent.Text = dbNews.Rows[0]["CONTENT"].ToString();
            imgDescription.ImageUrl = "~/images/news/" + dbNews.Rows[0]["IMAGE"].ToString();
            txtKeywords.Text = dbNews.Rows[0]["META_KEYWORD"].ToString();
            txtDescription.Text = dbNews.Rows[0]["META_DESCRIPTION"].ToString();
            listCateOld = dbNews.Rows[0]["CATEGORYID"].ToString().Split(';');

            drvSchool.SelectedValue = dbNews.Rows[0]["SchoolId"].ToString();

            if (dbNews.Rows[0]["STATUS"].ToString().Trim() == "1")
            {
                cbStatus.Checked = true;
            }
            else
            {
                cbStatus.Checked = false;
            }

            if (dbNews.Rows[0]["IS_HOT"].ToString().Trim() == "1")
            {
                chkNewsHot.Checked = true;
            }
            else
            {
                chkNewsHot.Checked = false;
            }
        }
    }

    void loadTags()
    {
        string _htmlClass = "";
        DataTable dbTags = objTags.GetAllTags();
        //Lấy list tag_id của thành viên.
        string listTags = "";
        string[] sp_list = { };
        if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            DataTable dbListTags = cnts.GetTableWithCommandText("select * From tblNewsTags where News_ID=" + Request.QueryString["ID"]);
            if (dbListTags.Rows.Count > 0)
            {
                listTags = dbListTags.Rows[0]["TAG_ID"].ToString();
                sp_list = listTags.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }



        foreach (DataRow item in dbTags.Rows)
        {
            string _name = item["Name"].ToString();
            string _id = item["ID"].ToString();
            //Kiểm tra xem kH đã check tags nào chưa?
            string checkeds = "";

            if (_id != "")
            {
                foreach (var arrID in sp_list)
                {
                    if (Convert.ToInt32(_id) == Convert.ToInt32(arrID))
                    {
                        checkeds = "checked='checked'";
                        break;
                    }
                }


                _htmlClass += "<div class='inputtypeNewTags' style='padding: 10px;float:left; border-bottom: 1px solid #ddd;font-size:12px;'><input " + checkeds + " style='clear:left;margin-right:5px;' type='checkbox' value='" + _id + "'/>&nbsp;<strong>" + _name + "</strong></div>";
            }
        }
        ltTags.Text = _htmlClass;
    }
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        try
        {
            string title = txtTitle.Text;
            string summary = txtSumary.Text;
            string content = txtContent.Text;
            string metaKeyWord = txtKeywords.Text;
            string metaDescription = txtDescription.Text;
            string _Category = listCategory.Value;
            int _schoolID = Convert.ToInt32(drvSchool.SelectedValue);

            int status = 0;
            if (cbStatus.Checked)
            {
                status = 1;
            }
            else
                status = 0;

            int news_hot = 0;
            if (chkNewsHot.Checked)
                news_hot = 1;
            else
                news_hot = 0;
            int news_NoiBat = 0;
            //if (chkNoiBat.Checked)
            //    news_NoiBat = 1;
            //else
            //    news_NoiBat = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                int _newsID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                string filname = "";
                if (fuImage.HasFile)
                {
                    filname = Lib.LocDauFileName(GetRandom() + "_" + fuImage.FileName);
                    //resize ảnh
                    Bitmap images = Lib.ResizeImage(fuImage.PostedFile.InputStream, 800, 600);
                    images.Save(Server.MapPath("~/Images/news/") + filname);
                }
                else
                {
                    DataTable db = objNews.GetNewsByID(Request.QueryString["ID"].ToString());
                    filname = db.Rows[0]["IMAGE"].ToString();
                }

                bool kt = objNews.tblNewsUpdate(int.Parse(Request.QueryString["ID"].ToString()), _Category, title, filname, summary, content, 1, status, metaKeyWord, metaDescription, news_hot, news_NoiBat, _schoolID);
                if (kt)
                {
                    divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
                }
                else
                {
                    divMessage.InnerHtml = O2S_Message.Error("Hệ thống", " phát sinh lỗi");
                }


                //Cập nhật Newstags
                string list_tags = listTags.Value;
                //Kiểm tra xmem bài tin này đã có tags hay chưa
                DataTable dbCheckNewsTags = objNewsTags.dataCheckTags(_newsID);
                if (dbCheckNewsTags.Rows.Count > 0)
                {
                    bool kt_updateTags = objNewsTags.Update(Convert.ToInt32(Request.QueryString["ID"].ToString()), list_tags);

                }
                else
                {
                    objNewsTags.Insert(_newsID, list_tags, DateTime.Now, 1);
                }

                //Thêm tags học viên
                string _tags = txtTag.Text;
                if (_tags.Trim() == "")
                {
                    divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
                }
                else
                {
                    int abTags = objTags.Insert(_tags, DateTime.Now, 0);
                    if (abTags > 0)
                    {
                        //Kiểm tra xem KH đã có tags nào chưa? Nếu chưa có thì insert
                        DataTable dbCHeck = cnts.GetTableWithCommandText("select * From tblNewsTags where News_ID=" + Convert.ToInt32(Request.QueryString["ID"]));
                        if (dbCHeck.Rows.Count > 0)
                        {
                            cnts.ExcutedCMD("update tblNewsTags set TAG_ID=TAG_ID + ';'+'" + abTags + "' where News_ID=" + Convert.ToInt32(Request.QueryString["ID"]) + "");
                        }
                        else
                        {
                            int abc = objNewsTags.Insert(_newsID, abTags.ToString() + ";", DateTime.Now, 1);
                        }
                        divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
                    }
                }
            }
            else
            {
                string filname = "";
                if (fuImage.HasFile)
                {
                    filname = Lib.LocDauFileName(GetRandom() + "_" + fuImage.FileName);
                    //resize ảnh
                    Bitmap images = Lib.ResizeImage(fuImage.PostedFile.InputStream, 800, 600);
                    images.Save(Server.MapPath("~/Images/news/") + filname);
                }
                int a = 0;
                a = objNews.Insert(_Category, title, filname, summary, content, 1, DateTime.Now, status, metaKeyWord, metaDescription, news_hot, news_NoiBat, _schoolID);
                if (a > 0)
                {
                    divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
                }
                else
                {
                    divMessage.InnerHtml = O2S_Message.Error("Hệ thống", " phát sinh lỗi");
                }


                //Cập nhật Newstags
                string list_tags = listTags.Value;
                //Kiểm tra xmem bài tin này đã có tags hay chưa
                DataTable dbCheckNewsTags = objNewsTags.dataCheckTags(a);
                if (dbCheckNewsTags.Rows.Count > 0)
                {
                    bool kt_updateTags = objNewsTags.Update(a, list_tags);
                }
                else
                {
                    //int abTags = objTags.Insert(list_tags, DateTime.Now, 0);
                    objNewsTags.Insert(a, list_tags, DateTime.Now, 1);
                }
                //Thêm tags học viên
                string _tags = txtTag.Text;
                if (_tags.Trim() == "")
                {
                    divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
                }
                else
                {
                    int abTags = objTags.Insert(_tags, DateTime.Now, 0);
                    if (abTags > 0)
                    {
                        //Kiểm tra xem KH đã có tags nào chưa? Nếu chưa có thì insert
                        DataTable dbCHeck = cnts.GetTableWithCommandText("select * From tblNewsTags where News_ID=" + a);
                        if (dbCHeck.Rows.Count > 0)
                        {
                            cnts.ExcutedCMD("update tblNewsTags set TAG_ID=TAG_ID + ';'+'" + abTags + "' where News_ID=" + a + "");
                        }
                        else
                        {
                            int abc = objNewsTags.Insert(a, abTags.ToString() + ";", DateTime.Now, 1);
                        }
                        divMessage.InnerHtml = O2S_Message.Success("Hệ thống", "Thực hiện thành công");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Hệ thống", "Phát hiện lỗi" + ex.Message);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string _tags = txtTag.Text;
        if (_tags.Trim() == "")
        {
            ltMess.Text = "Bạn chưa nhập nội dung thẻ tags.";

        }
        else
        {
            //CheckData Tags Name in Database
            DataTable dbCheckTags = objTags.CheckData(_tags);
            if (dbCheckTags.Rows.Count > 0)
            {
                ltMess.Text = "Tags này đã có trong database. Hãy sử dụng tính năng cập nhật Tags.";

            }
            else
            {
                int a = objTags.Insert(_tags, DateTime.Now, 1);
                if (a > 0)
                {
                    //Kiểm tra xem KH đã có tags nào chưa? Nếu chưa có thì insert
                    DataTable dbCHeck = cnts.GetTableWithCommandText("select * From tblNewsTags where News_ID=" + Request.QueryString["ID"].ToString());
                    if (dbCHeck.Rows.Count > 0)
                    {
                        cnts.ExcutedCMD("update tblNewsTags set TAG_ID=TAG_ID + ';'+'" + a + "' where News_ID=" + Request.QueryString["ID"].ToString() + "");
                    }
                    else
                    {
                        int abc = objNewsTags.Insert(Convert.ToInt32(Request.QueryString["ID"].ToString()), a.ToString() + ";", DateTime.Now, 1);
                    }

                    ltMess.Text = "Thêm mới thành công.";
                    //Insert vào bảng tblCustomerTags
                    //Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
    //protected void btnCapNhatTags_Click(object sender, EventArgs e)
    //{
    //    string list_tags = listTags.Value;
    //    bool kt = objNewsTags.Update(Convert.ToInt32(Request.QueryString["ID"].ToString()), list_tags);
    //    Response.Redirect(Request.RawUrl);
    //}

}