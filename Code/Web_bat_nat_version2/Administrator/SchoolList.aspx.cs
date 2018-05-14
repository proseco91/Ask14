using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Administrator_SchoolList : System.Web.UI.Page
{
    ConnectSQL cnts = new ConnectSQL();
    SchoolController objSchool = new SchoolController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        DataTable dbSchool = objSchool.GetAll();
        CollectionPager1.DataSource = dbSchool.DefaultView;
        CollectionPager1.DataBind();
        CollectionPager1.PageSize = int.MaxValue;
        CollectionPager1.BindToControl = rptData;
        rptData.DataSource = CollectionPager1.DataSourcePaged;
        rptData.DataBind();
    }
    protected void btnAdnew1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SchoolAdd.aspx");
    }
    protected void btnDelete_Click1(object sender, EventArgs e)
    {

    }
}