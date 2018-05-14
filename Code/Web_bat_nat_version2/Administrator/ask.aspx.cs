using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;
using System.Data;

public partial class Administrator_ask : System.Web.UI.Page
{
    HoiDapController objHoiDap = new HoiDapController();
    private ConnectSQL objConnect = new ConnectSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        bindData();
        //}
    }

    private void bindData()
    {
        //try
        //{

        CollectionPager1.DataSource = objHoiDap.GetAll().DefaultView;
        CollectionPager1.BindToControl = rptData;
        CollectionPager1.PageSize = 20;
        CollectionPager1.DataBind();
        rptData.DataSource = CollectionPager1.DataSourcePaged;
        rptData.DataBind();
        //}
        //catch
        //{
        //    divMessage.InnerHtml = O2S_Message.Warning("Cảnh Báo", "Chưa Có dữ liệu trong mục này!");
        //}
    }
    public string getHTMlLink(object Name, object Email)
    {
        DataTable _cus = objConnect.GetTableWithCommandText("select CUSTOMER_ID from tblCustomers where EMAIL=N'" + Email + "'");
        if (_cus.Rows.Count > 0)
        {
            return "<a href='DetailCustomer.aspx?CUSTOMER_ID=" + _cus.Rows[0]["CUSTOMER_ID"] + "'>" + Name + "</a>";
        }
        else
        {
            return Name.ToString();
        }
    }
    public string getSender(string idAsk)
    {
        string sender = "";
        DataTable dtAsk = objConnect.GetTableWithCommandText("select * from tblHistorySent join tblAdministrators on tblHistorySent.IDSENDER=tblAdministrators.ADMIN_ID  where tblHistorySent.IDSENT = " + idAsk + " and tblHistorySent.EMAIL_ID = 50");
        if (dtAsk.Rows.Count > 0)
        {
            sender = dtAsk.Rows[0]["FULL_NAME"].ToString();
        }
        return sender;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {
                objHoiDap.Delete(int.Parse(sp_list[i]));
            }
            bindData();
        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
    protected void btnDelete2_Click(object sender, EventArgs e)
    {
        btnDelete_Click(sender, e);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
}