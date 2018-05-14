using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_DetailCustomer : System.Web.UI.Page
{
    CustomerController objCustomer = new CustomerController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                loadData(Request.QueryString["ID"].ToString());
                btnSubmit.Text = "Cập nhật";
            }
            else
            {
                btnSubmit.Text = "Thêm mới";
            }
        }
    }
    void loadData(string ID)
    {
        DataTable db = objCustomer.GetDataByID(ID);
        if (db.Rows.Count > 0)
        {
            txtCustomerName.Text = db.Rows[0]["CUSTOMER_NAME"].ToString();
            txtEmail.Text = db.Rows[0]["EMAIl"].ToString();
            txtPhoneNumber.Text = db.Rows[0]["PHONENUMBER"].ToString();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string _CustomerName = txtCustomerName.Text;
        string _Email = txtEmail.Text;
        string _PhoneNumber = txtPhoneNumber.Text;
        if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            //bool kt = objCustomer.Update(Convert.ToInt32(Request.QueryString["ID"].ToString()), _CustomerName, _Email, _PhoneNumber);
            //if (kt)
            //{
            //    divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " thực hiện thành công");
            //}
            //else
            //{
            //    divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Hệ thống", " phát sinh lỗi. Liên hệ: 0973.75.8666");
            //}
        }
        else
        {
            //int a = objCustomer.Insert(_CustomerName, _Email, _PhoneNumber,0, "", "", DateTime.Now, 1);
            //if (a > 0)
            //{
            //    divMessage.InnerHtml = LibraryO2S.O2S_Message.Success("Hệ thống", " thực hiện thành công");
            //}
            //else
            //{
            //    divMessage.InnerHtml = LibraryO2S.O2S_Message.Error("Hệ thống", " phát sinh lỗi. Liên hệ: 0973.75.8666");
            //}
        }
    }
}