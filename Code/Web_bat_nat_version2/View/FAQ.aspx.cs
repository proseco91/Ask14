using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_FAQ : System.Web.UI.Page
{
    public string scttttt = "";
    HoiDapController objHoiDap = new HoiDapController();
    CustomerController objCust = new CustomerController();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Hỏi đáp";
    }
    //protected void btnLienHe_Click(object sender, EventArgs e)
    //{
    //    string _content = txtNoiDung.Text;
    //    string email = Session["email"].ToString();
    //    if (email == "")
    //    {
    //        scttttt = "return false;";
    //    }
    //    else
    //    {
    //        int _custID = 0;
    //        DataTable dbCust = objCust.GetDataByEmail(email);
    //        if (dbCust.Rows.Count > 0)
    //        {
    //            _custID = Convert.ToInt32(dbCust.Rows[0]["ID"].ToString());
    //        }
    //        int a = objHoiDap.Insert(_custID, _content, DateTime.Now, 0);
    //        if (a > 0)
    //        {
    //            scttttt = "alert('Gửi hỏi đáp thành công.');setInterval(location.href=location.href, 3000);";
    //        }
    //    }
    //}
}