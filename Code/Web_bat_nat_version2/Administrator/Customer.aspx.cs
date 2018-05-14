using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryO2S;
public partial class Administrator_Customer : System.Web.UI.Page
{
    CustomerController objCust = new CustomerController();
    ConnectSQL cnts = new ConnectSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        DataTable db = objCust.GetAllData();
        CollectionPager1.DataSource = db.DefaultView;
        CollectionPager1.BindToControl = rptData;
        CollectionPager1.PageSize = 50;
        CollectionPager1.MaxPages = 5000000;
        CollectionPager1.DataBind();
        rptData.DataSource = CollectionPager1.DataSourcePaged;
        rptData.DataBind();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        try
        {
            string del_list = hdfCheck.Value;
            string[] sp_list = del_list.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sp_list.Length; i++)
            {

                objCust.Delete(sp_list[i]);
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            divMessage.InnerHtml = O2S_Message.Error("Cảnh Báo", "Phát hiện lỗi! " + ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Customer.aspx?search=" + txtSearch.Value);
    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Item.DataItem;
        Literal lblText = (Literal)e.Item.FindControl("litText");
        DataTable dt3 = cnts.GetTableWithCommandText("select top 1 * from tblEventComment where CUSTOMER_ID = " + dr["ID"] + " order by ID desc");
        string text = "";
        if (dt3.Rows.Count > 0)
        {
            text = dt3.Rows[0]["CONTENT"].ToString();
        }
        //lblText.Text = "<input placeholder='Nhập và kết thúc bằng enter' style='width:200px;' class='viewcomment' type='text' id='txt" + dr["ID"] + "' value='" + text + "' valID='" + dr["ID"] + "'/>";
        lblText.Text = "<textarea id='txt" + dr["ID"] + "' class='viewcomment' valid='" + dr["ID"] + "'   type='text' style='width:500px;height:50px;float:left;word-wrap:break-word;' placeholder='Mời bạn comment. Kết thúc bằng Enter.'>" + text + "</textarea>";
    }
}