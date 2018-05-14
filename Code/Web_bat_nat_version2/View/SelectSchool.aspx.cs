using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Styles_SelectSchool : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    SchoolController objSchool = new SchoolController();
    CustomerController objCustomer = new CustomerController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadSchool();
            loadData();
        }
    }
    void loadData()
    {
        string _email = Session["email"].ToString();
        DataTable dbCus = objCustomer.GetDataByEmail(_email);
        if (dbCus.Rows.Count > 0)
        {
            try
            {
                int schooldID = Convert.ToInt32(dbCus.Rows[0]["SCHOOL_ID"].ToString());
                drvSelectSchool.SelectedValue = schooldID.ToString();
            }
            catch
            {
                drvSelectSchool.SelectedValue = "1";
            }

        }
    }
    void loadSchool()
    {

        DataTable db = objSchool.GetAll();
        drvSelectSchool.DataSource = db;
        drvSelectSchool.DataTextField = "School_Name";
        drvSelectSchool.DataValueField = "ID";
        drvSelectSchool.DataBind();
        drvSelectSchool.Items.Insert(0, new ListItem("Khác", "-99"));
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int schoolID = Convert.ToInt32(drvSelectSchool.SelectedValue);
        string _email = Session["email"].ToString();
        DataTable dbCus = objCustomer.GetDataByEmail(_email);
        if (dbCus.Rows.Count > 0)
        {
            string _CustomerID = dbCus.Rows[0]["ID"].ToString();
            bool kt = objCustomer.UpdateSchool(Convert.ToInt32(_CustomerID), schoolID);
            if (kt)
            {
                ltwarning.Text = "Cập nhật thành công!";
            }
        }
    }
}