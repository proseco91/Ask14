using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Dynamic;
using Newtonsoft;
using Newtonsoft.Json;
using System.Data;
public partial class View_LoginWithSirenChat : System.Web.UI.Page
{
    CustomerController objCustomer = new CustomerController();
    protected void Page_Load(object sender, EventArgs e)
    {
        string abc = Request.QueryString["data"];
        if (abc == "null")
        {
            Session["email"] = "";
        }
        else
        {
            dynamic _data = JsonConvert.DeserializeObject<ExpandoObject>(abc);
            string email = _data.email;
            string _name = _data.name;
            string _avatar = _data.avarta;
            if (_name == null)
            {
                _name = "";
            }
            //Kiểm tra xem email đã tồn tại trong hệ thống hay chưa?
            DataTable dbCheckEmail = objCustomer.GetDataByEmail(email);
            if (dbCheckEmail.Rows.Count > 0)
            {
                int ID = Convert.ToInt32(dbCheckEmail.Rows[0]["ID"].ToString());
                Session["email"] = email;
                Session["customerName"] = _name;
                Session["avatar"] = _avatar;

                string phone = _data.phone;
                if (phone == null)
                {
                    phone = "";
                }
                DateTime dob = _data.dob;
                if (dob == null)
                {
                    dob = DateTime.Now;
                }

                if (_avatar == null)
                {
                    _avatar = "";
                }
                float _gender = 1;
                try
                {
                    _gender = _data.gender;
                }
                catch
                {
                    _gender = 1;
                }

                string _city = _data.city;
                if (_city == null)
                {
                    _city = "";
                }
                //Cập nhật thông tin cá nhân của khách hàng
                bool kt = objCustomer.Update(ID, _name, email, phone, dob, _gender, _city, _avatar);
                objCustomer.Update_Online(ID, 1);
            }
            else
            {
                string phone = _data.phone;
                if (phone == null)
                {
                    phone = "";
                }
                DateTime dob = _data.dob;
                if (dob == null)
                {
                    dob = DateTime.Now;
                }

                if (_avatar == null)
                {
                    _avatar = "";
                }
                float _gender = 1;
                try
                {
                    _gender = _data.gender;
                }
                catch
                {
                    _gender = 1;
                }

                string _city = _data.city;
                if (_city == null)
                {
                    _city = "";
                }

                int customerID = objCustomer.Insert(_name, email, phone, dob, _gender, _city, _avatar, DateTime.Now, 1);
                if (customerID > 0)
                {
                    objCustomer.Update_Online(customerID, 1);
                    Session["email"] = email;
                    Session["customerName"] = _name;
                    Session["avatar"] = _avatar;
                }
                else
                {
                    Session["email"] = "";
                }
            }
        }
    }
}