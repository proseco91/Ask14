using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Search : System.Web.UI.Page
{
    public string keysearch = "";
    public string langua = "vi";
    protected void Page_Load(object sender, EventArgs e)
    {
        string lang = Convert.ToString(Session["lang"]);
        if (lang.Equals("en-US"))
        {
            langua = "en";
            this.Title = "Search";
            if (Request.Params["keysearch"] != null)
            {
                keysearch = Request.Params["keysearch"];
                this.Title = "Search - " + keysearch;
            }
        }
        else
        {
            this.Title = "Tìm kiếm";
            if (Request.Params["keysearch"] != null)
            {
                keysearch = Request.Params["keysearch"];
                this.Title = "Tìm kiếm - " + keysearch;
            }
        }
    }

}