using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class MasterPage_HeaderFooter : System.Web.UI.MasterPage
{
    SlideShowController objSlide = new SlideShowController();
    CategoryController objCate = new CategoryController();
    FooterController objFooter = new FooterController();
    BizNews objNews = new BizNews();
    CustomerController objCus = new CustomerController();
    public string CustomerName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    public DataTable GetCate()
    {
        return objCate.GetAllData_WITH_PARENTID_VIEWER();
    }
}
