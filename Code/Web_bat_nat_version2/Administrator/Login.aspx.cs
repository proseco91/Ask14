using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryO2S;

public partial class Administrator_Login : System.Web.UI.Page
{
    tblAdministrators Admin = new tblAdministrators();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUser.Value;
        string password = txtPassword.Value;
        if (Admin.LoginReturn(username.Trim(), password.Trim()))
        {
            WriteCookie(username);
            Session["username"] = username;
            Response.Redirect("ControlPannel.aspx");
        }
        else
        {
            divMessages.InnerHtml = O2S_Message.Warning("Cảnh báo", "Tài khoản và tên đăng nhập không đúng");
        }

    }
    private void WriteCookie(string username)
    {
        if (cbremember.Checked)
        {
            //HttpCookie cookie = new HttpCookie("cookiename");
            //cookie.Values.Add("UserName", txtUser.Value);
            //cookie.Values.Add("Password", txtPassword.Value);
            //cookie.Expires = DateTime.Now.AddDays(30);
            //Response.Cookies.Add(cookie);
            Response.Cookies["username"].Value = Lib.Encrypt(username + "_" + DateTime.Now.Ticks, "todayenglishcenter");
            Response.Cookies["username"].Expires = DateTime.Now.AddYears(30);
            Session["username"] = username;
        }
    }
}