using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class View_Introduction : System.Web.UI.Page
{
    CustomerController objCus = new CustomerController();
    SlideShowController objSlide = new SlideShowController();
    LienHeController objLienHe = new LienHeController();
    MailController objMail = new MailController();
    ConnectSQL cnts = new ConnectSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Giới thiệu | ask14.vn";
        if (!IsPostBack)
        {
            imgCapcha.ImageUrl = "../capcha.aspx";
        }
    }
    public DataTable dbGetSlideGioiThieu()
    {
        return objSlide.GetAllWithStatus_GioiThieu();
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string fullname = txtFullName.Text.Trim();
        string email = txtEmail.Text.Trim();
        string phone = txtPhoneNumber.Text.Trim();
        string address = txtDiaChi.Text;
        string content = txtNoiDung.Value.Trim();


        int _customerID = 0;
        //kiểm tra xem email đã tồn tài trong hệ thống hay chưa
        DataTable dbCheckEmail = objCus.GetDataByEmail(email);
        if (dbCheckEmail.Rows.Count > 0)
        {
            _customerID = Convert.ToInt32(dbCheckEmail.Rows[0]["ID"].ToString());
        }
        else
        {
            _customerID = objCus.Insert(fullname, email, phone, DateTime.Now, 0, address, "", DateTime.Now, 0);
        }
        if (_customerID > 0)
        {
            if (txtCapcha.Text.Trim().ToLower().Equals(Session["Capcha"].ToString().ToLower()))
            {
                int a = objLienHe.Insert(_customerID, content, DateTime.Now, 0);
                if (a > 0)
                {
                    string rec = "";
                    DataTable dtRec = cnts.GetTableWithCommandText("select * from tblMailReceiver where STATUS = 1");
                    if (dtRec.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtRec.Rows)
                        {
                            rec += dr["EMAIL"].ToString() + ";";
                        }
                    }
                    else
                    {
                        rec = "chulinh@linktam.vn;";
                    }

                    DataTable db = cnts.GetTableWithCommandText("select * from tblEmailTemplate where EMAILID=1");
                    string contentSend = db.Rows[0]["CONTENT"].ToString();
                    contentSend = contentSend.Replace("$1", fullname);
                    contentSend = contentSend.Replace("$2", email);
                    contentSend = contentSend.Replace("$3", phone);
                    contentSend = contentSend.Replace("$4", content);

                    string[] _listEmail = rec.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < _listEmail.Length; i++)
                    {
                        objMail.SendMail(_listEmail[i], db.Rows[0]["DESCRIPTION"].ToString(), contentSend);
                    }
                    string str = "<script type='text/javascript'>";
                    str += "function OnRemove(){alert('Cảm ơn bạn đã đặt câu hỏi. Chúng tôi sẽ trả lời trong vòng 3 ngày làm việc!');self.parent.tb_remove();}OnRemove();";
                    str += "</script>";
                    Response.Write(str);
                }
            }
            else
            {
                labCaptcha.Text = "Nhập sai mã.";
                imgCapcha.ImageUrl = "../capcha.aspx";
            }
        }
        else
        {
            string str = "<script type='text/javascript'>";
            str += "function OnRemove(){self.parent.tb_remove();}OnRemove();";
            str += "</script>";
            Response.Write(str);
        }
    }
}