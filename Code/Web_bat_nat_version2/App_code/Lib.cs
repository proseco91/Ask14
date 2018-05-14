using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Lib
/// </summary>
public static class Lib
{
    public static string urlhome;

    static Lib()
    {
        //
        // TODO: Add constructor logic here
        //
        HttpRequest req = HttpContext.Current.Request;
        urlhome = req.Url.GetLeftPart(UriPartial.Authority);
        if (urlhome.IndexOf("http://localhost") > -1)
            urlhome += req.ApplicationPath;
    }
    public static bool checkQuestionNew(Strucsaveactionnew _lam, ArrayQuestion itemQ)
    {
        if (_lam.type == 0)
        {
            List<string> arayIDSai = new List<string>();
            foreach (ItemPanelKeoThaItem item in itemQ.itemPanelKeoTha.item)
            {
                bool isTrueFalse = false;
                Arrayitem _check = _lam.arrayitem.Where(d => d.id.Equals(item.ID)).FirstOrDefault();
                if (_check != null)
                {
                    if (item.B != null)
                    {
                        if (item.A.ToLower().Equals(_check.a.ToLower()) && item.B.ToLower().Equals(_check.b.ToLower()))
                            isTrueFalse = true;
                    }
                    else
                    {
                        if (item.A.ToLower().Equals(_check.a.ToLower()))
                            isTrueFalse = true;
                    }

                }
                if (!isTrueFalse)
                    arayIDSai.Add(item.ID);
            }
            if (arayIDSai.Count == 0)
                return true;
        }
        else if (_lam.type == 1)
        {
            List<string> arayIDSai = new List<string>();
            foreach (ItemDienCauItem item in itemQ.itemDienCau.arrayItem)
            {
                bool isTrueFalse = false;
                Arrayitem _check = _lam.arrayitem.Where(d => d.id.Equals(item.ID)).FirstOrDefault();
                if (_check != null)
                {
                    string[] _array = item.dapan.Where(d => d.ToLower().Equals(_check.dapan.ToLower())).ToArray();
                    if (_array.Length > 0)
                        isTrueFalse = true;
                }
                if (!isTrueFalse)
                    arayIDSai.Add(item.ID);
            }
            if (arayIDSai.Count == 0)
                return true;
        }
        else if (_lam.type == 2)
        {
            List<string> arayIDSai = new List<string>();
            foreach (ItemMatchingItem item in itemQ.itemMatching.item)
            {
                bool isTrueFalse = false;
                Arrayitem _check = _lam.arrayitem.Where(d => d.id.Equals(item.ID)).FirstOrDefault();
                if (_check != null)
                {
                    if (item.dapan.ToLower().Equals(_check.dapan.ToLower()))
                        isTrueFalse = true;
                }
                if (!isTrueFalse)
                    arayIDSai.Add(item.ID);
            }
            if (arayIDSai.Count == 0)
                return true;
        }
        else if (_lam.type == 3)
        {
            bool _statusA = false, _statusB = false;
            if (itemQ.itemPhanLoai.A.Length == _lam.a.Count)
            {
                int _num = 0;
                foreach (string itemS in itemQ.itemPhanLoai.A)
                {
                    if (_lam.a.Where(d => d.ToString().ToLower().Equals(itemS.ToLower())).FirstOrDefault() != null)
                        _num++;
                }
                if (_num == itemQ.itemPhanLoai.A.Length)
                    _statusA = true;
            }
            if (itemQ.itemPhanLoai.B.Length == _lam.b.Count)
            {
                int _num = 0;
                foreach (string itemS in itemQ.itemPhanLoai.B)
                {
                    if (_lam.b.Where(d => d.ToString().ToLower().Equals(itemS.ToLower())).FirstOrDefault() != null)
                        _num++;
                }
                if (_num == itemQ.itemPhanLoai.B.Length)
                    _statusB = true;
            }
            if (_statusA && _statusB)
                return true;
        }
        else if (_lam.type == 4)
        {
            List<string> arayIDSai = new List<string>();
            foreach (ItemChonLuaDapAn item in itemQ.itemLuaChon.arrayDapAn)
            {

                bool isTrueFalse = false;
                Arrayitem _check = _lam.arrayitem.Where(d => d.id.Equals(item.ID)).FirstOrDefault();
                if (_check != null)
                {
                    if (item.item.Where(d => d.isChecked && d.title.ToLower().Equals(_check.dapan)).FirstOrDefault() != null)
                        isTrueFalse = true;
                }
                if (!isTrueFalse)
                    arayIDSai.Add(item.ID);
            }
            if (arayIDSai.Count == 0)
                return true;
        }
        else if (_lam.type == 5)
        {
            List<string> arayIDSai = new List<string>();
            foreach (ArrayPixel item in itemQ.itemImage.arrayPixel)
            {

                bool isTrueFalse = false;
                if (_lam.arrayitem.Where(d => d.id.Equals(item.ID) && d.dapan.ToLower().Equals(item.text.ToLower())).FirstOrDefault() != null)
                    isTrueFalse = true;
                if (!isTrueFalse)
                    arayIDSai.Add(item.ID);
            }
            if (arayIDSai.Count == 0)
                return true;
        }
        return false;
    }
    public static bool isNumber(object number)
    {
        return new Regex("^[0-9]+$").IsMatch(number.ToString());
    }
    public static string ReplaceOne(string txtGoc, string txtRepDel, string txtRep)
    {
        int startIndex = txtGoc.IndexOf(txtRepDel);
        txtGoc = txtGoc.Remove(startIndex, txtRepDel.Length);
        txtGoc = txtGoc.Insert(startIndex, txtRep);
        return txtGoc;
    }
    public static string removeHTMLAll(string source)
    {
        return Regex.Replace(source, "<.*?>", string.Empty);
    }
    public static Bitmap ResizeByWidth(Stream img, int width)
    {
        // lấy chiều rộng và chiều cao ban đầu của ảnh
        Bitmap imgNew = new Bitmap(img);

        int originalW = imgNew.Width;
        int originalH = imgNew.Height;

        // lấy chiều rộng và chiều cao mới tương ứng với chiều rộng truyền vào của ảnh (nó sẽ giúp ảnh của chúng ta sau khi resize vần giứ được độ cân đối của tấm ảnh
        int resizedW = width;
        int resizedH = (originalH * resizedW) / originalW;
        if (originalW < width)
        {
            resizedW = originalW;
            resizedH = (originalH * resizedW) / originalW;
        }


        // tạo một Bitmap có kích thước tương ứng với chiều rộng và chiều cao mới
        Bitmap bmp = new Bitmap(resizedW, resizedH, PixelFormat.Format32bppArgb);

        using (Graphics graphics = Graphics.FromImage(bmp))
        {
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawImage(imgNew, 0, 0, resizedW, resizedH);

        }
        return bmp;
    }
    public static Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    public static string activeLocDau(string[] pram, string content)
    {
        string txtReturn = "";
        foreach (string txt in content.Split(' '))
        {
            if (!txt.Trim().Equals(""))
            {
                bool checkRep = false;
                Match match = regex.Match(txt);
                if (match.Success)
                    checkRep = true;
                if (!checkRep)
                {
                    foreach (string item in pram)
                    {
                        if (!item.Trim().Equals(""))
                        {
                            if (txt.IndexOf(item) > -1)
                            {
                                checkRep = true;
                                break;
                            }
                        }
                    }
                }
                if (checkRep)
                {
                    for (int i = 0; i < txt.Length; i++)
                    {
                        txtReturn += "*";
                    }
                    txtReturn += " ";
                }
                else
                {
                    txtReturn += txt + " ";
                }
            }
            else
            {
                txtReturn += "  ";
            }
        }
        foreach (string item in pram)
        {
            if (!item.Trim().Equals(""))
            {
                txtReturn = txtReturn.Replace(item, "***");
            }
        }
        return txtReturn;
    }
    public static string TimeAgo(DateTime date)
    {
        TimeSpan timeSince = DateTime.Now.Subtract(date);
        if (timeSince.TotalMilliseconds < 1)
            return "không có";
        if (timeSince.TotalMinutes < 1)
            return string.Format("{0} giây trước", timeSince.Seconds);
        if (timeSince.TotalMinutes < 2)
            return "1 phút trước";
        if (timeSince.TotalMinutes < 60)
            return string.Format("{0} phút trước", timeSince.Minutes);
        if (timeSince.TotalMinutes < 120)
            return "1 giờ trước";
        if (timeSince.TotalHours < 24)
            return string.Format("{0} giờ trước", timeSince.Hours);
        if (timeSince.TotalDays == 1)
            return "hôm qua";
        if (timeSince.TotalDays < 7)
            return string.Format("{0} ngày trước", timeSince.Days);
        if (timeSince.TotalDays < 14)
            return "tuần trước";
        if (timeSince.TotalDays < 21)
            return "2 tuần trước";
        if (timeSince.TotalDays < 28)
            return "3 tuần trước";
        if (timeSince.TotalDays < 60)
            return "tháng trước";
        if (timeSince.TotalDays < 365)
            return string.Format("{0} tháng trước", Math.Round(timeSince.TotalDays / 30));
        if (timeSince.TotalDays < 730)
            return "năm ngoái";
        return string.Format("{0} năm trước", Math.Round(timeSince.TotalDays / 365));
    }
    public static string GetIpAddress()  // Get IP Address
    {
        string ip = "";
        IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
        IPAddress[] addr = ipEntry.AddressList;
        ip = addr[2].ToString();
        return ip;
    }
    public static string subString(string txtSub, int maxLeng)
    {
        txtSub = HttpUtility.HtmlDecode(txtSub);
        if (txtSub.Length > maxLeng)
        {
            string[] txtSplit = txtSub.Split(' ');
            if (txtSplit.Length > 1)
            {
                string txtReturn = "";
                for (int i = 0; i < txtSplit.Length; i++)
                {
                    if (txtReturn.Length + 4 < maxLeng)
                    {
                        txtReturn += txtSplit[i] + " ";
                        if (txtReturn.Length + 4 + txtSplit[i + 1].Length > maxLeng)
                        {
                            txtReturn += "...";
                            break;
                        }
                    }
                }
                return txtReturn;
            }
            else
            {
                return txtSub.Substring(0, maxLeng - 4) + " ...";
            }

        }
        else
        {
            return txtSub;
        }
    }
    public static string LocDau(string txt)
    {
        txt = txt.ToLower();
        txt = HttpUtility.HtmlDecode(txt);
        const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
        const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
        int index = -1;
        char[] arrChar = FindText.ToCharArray();
        while ((index = txt.IndexOfAny(arrChar)) != -1)
        {
            int index2 = FindText.IndexOf(txt[index]);
            txt = txt.Replace(txt[index], ReplText[index2]);
        }
        txt = txt.Replace(" ", "-");
        txt = txt.Replace("|", "");
        txt = txt.Replace("?", "");
        txt = txt.Replace("'", "");
        txt = txt.Replace("\"", "");
        txt = txt.Replace(":", "");
        txt = txt.Replace(";", "");
        txt = txt.Replace(",", "");
        txt = txt.Replace(".", "");
        txt = txt.Replace("“", "");
        txt = txt.Replace("!", "");
        txt = txt.Replace("’", "");
        txt = txt.Replace("&", "");
        txt = txt.Replace("=", "");
        txt = txt.Replace("/-+-/g", ""); //thay thế 2- thành 1- 
        txt = txt.Replace(@"/^\-+|\-+$/g", "");
        txt = txt.Replace(@"/ \ ?", "");
        txt = txt.Replace("(", "");
        txt = txt.Replace(")", "");
        txt = txt.Replace("%", "");
        txt = txt.Replace("\"", "");
        txt = txt.Replace(@"/", "");
        txt = txt.Replace(@"”", "");

        return txt;
    }
    public static string LocDauFileName(string txt)
    {
        txt = txt.ToLower();
        txt = HttpUtility.HtmlDecode(txt);
        const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
        const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
        int index = -1;
        char[] arrChar = FindText.ToCharArray();
        while ((index = txt.IndexOfAny(arrChar)) != -1)
        {
            int index2 = FindText.IndexOf(txt[index]);
            txt = txt.Replace(txt[index], ReplText[index2]);
        }
        txt = txt.Replace(" ", "-");
        txt = txt.Replace("|", "");
        txt = txt.Replace("?", "");
        txt = txt.Replace("'", "");
        txt = txt.Replace("\"", "");
        txt = txt.Replace(":", "");
        txt = txt.Replace(";", "");
        txt = txt.Replace(",", "");
        txt = txt.Replace("&", "");
        txt = txt.Replace("=", "");
        txt = txt.Replace("/-+-/g", "");
        txt = txt.Replace(@"/^\-+|\-+$/g", "");
        txt = txt.Replace(@"/ \ ?", "");
        txt = txt.Replace("(", "");
        txt = txt.Replace(")", "");
        txt = txt.Replace("%", "");
        txt = txt.Replace("\"", "");
        return txt;
    }
    public static string GetCompCode()  // Get Computer Name
    {
        string strHostName = "";
        strHostName = Dns.GetHostName();
        return strHostName;
    }

    public static DataTable ConvertToDataTable<T>(IList<T> data)
    {
        PropertyDescriptorCollection properties =
           TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }
        return table;

    }
    public static string encrypt(string x)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider test123 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] data = System.Text.Encoding.ASCII.GetBytes(x);
        data = test123.ComputeHash(data);
        String md5Hash = System.Text.Encoding.ASCII.GetString(data);

        return md5Hash;
    }

    public static Bitmap ResizeImage(Stream img, int maxWidth, int maxHeight)
    {
        Bitmap imgNew = new Bitmap(img);
        Bitmap imgRes = null;
        int originalWidth = imgNew.Width;
        int originalHeight = imgNew.Height;
        int widthMax = maxWidth;
        float ratioX = (float)widthMax / (float)originalWidth;

        int newWidth = (int)widthMax;
        int newHeight = (int)(originalHeight * ratioX);

        bool checkExit = false;
        do
        {
            if (widthMax >= maxWidth && newHeight >= maxHeight)
            {
                checkExit = true;
            }
            else
            {
                widthMax = widthMax + 1;
                ratioX = (float)widthMax / (float)originalWidth;
                newWidth = (int)widthMax;
                newHeight = (int)(originalHeight * ratioX);
            }
        } while (!checkExit);
        Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);
        using (Graphics graphics = Graphics.FromImage(newImage))
        {
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawImage(imgNew, 0, 0, newWidth, newHeight);

        }
        if (newImage.Height > maxHeight || newImage.Width > maxWidth)
        {
            int x = 0;
            int y = 0;
            if (newImage.Width > maxWidth)
            {
                x = (newImage.Width / 2) - (maxWidth / 2);
            }
            if (newImage.Height > maxHeight)
            {
                y = (newImage.Height / 2) - (maxHeight / 2);
            }
            System.IO.Stream stream = new MemoryStream();
            newImage.Save(stream, ImageFormat.Png);
            var bytes = ((MemoryStream)stream).ToArray();
            System.IO.Stream inputStream = new MemoryStream(bytes);
            Bitmap newImageNew = new Bitmap(maxWidth, maxHeight, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(newImageNew);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(new Bitmap(inputStream), new Rectangle(0, 0, maxWidth, maxHeight), new Rectangle(x, y, maxWidth, maxHeight), GraphicsUnit.Pixel);
            imgRes = newImageNew;
        }
        else
        {
            imgRes = newImage;
        }
        return imgRes;
    }
    private static byte[] Encrypt(byte[] clearText, byte[] Key, byte[] IV)
    {
        MemoryStream ms = new MemoryStream();
        Rijndael alg = Rijndael.Create();
        alg.Key = Key;
        alg.IV = IV;
        CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(clearText, 0, clearText.Length);
        cs.Close();
        byte[] encryptedData = ms.ToArray();
        return encryptedData;
    }

    public static string Encrypt(string clearText, string Password)
    {
        byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
        return Convert.ToBase64String(encryptedData);
    }

    private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
    {
        MemoryStream ms = new MemoryStream();
        Rijndael alg = Rijndael.Create();
        alg.Key = Key;
        alg.IV = IV;
        CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(cipherData, 0, cipherData.Length);
        cs.Close();
        byte[] decryptedData = ms.ToArray();
        return decryptedData;
    }

    public static string Decrypt(string cipherText, string Password)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
        return System.Text.Encoding.Unicode.GetString(decryptedData);
    }





    public static int CheckRole(string username)
    {
        ConnectSQL cnts = new ConnectSQL();
        int roleID = 3;
        DataTable dbRole = cnts.GetTableWithCommandText("select * from tblAdministrators A join tblRole R ON A.ROLL = R.ROLEID where username='" + username + "'");

        if (dbRole.Rows.Count > 0)
        {
            roleID = Convert.ToInt32(dbRole.Rows[0]["ROLEID"].ToString());
        }
        return roleID;
    }

    public static void CheckCookieAdmin()
    {
        if (HttpContext.Current.Session["username"] == null || String.IsNullOrEmpty(HttpContext.Current.Session["username"].ToString()))
        {
            if (HttpContext.Current.Request.Cookies["username"] != null && !String.IsNullOrEmpty(HttpContext.Current.Request.Cookies["username"].Value))
            {
                try
                {
                    string[] idCus = Lib.Decrypt(HttpContext.Current.Request.Cookies["username"].Value, "todayenglishcenter").Split('_');
                    DateTime _date = new DateTime(long.Parse(idCus[1]));
                    HttpContext.Current.Session["username"] = idCus[0];
                }
                catch
                {
                    HttpContext.Current.Session["username"] = "";
                    HttpContext.Current.Response.Cookies["username"].Expires = DateTime.Now.AddYears(-30);
                    HttpContext.Current.Response.Redirect("Login.aspx", true);
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("Login.aspx", true);
            }
        }
    }
    public static string CutString(string param, int param1)
    {
        string strCut;
        string strFinish = "";
        if (param.Length > param1)
        {
            strCut = param.Substring(0, param1);
            string[] arr = strCut.Split(new char[] { ' ' }, param1);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                strFinish += arr[i] + " ";
            }

            strFinish = strFinish + " ...";
        }
        else
        {
            strFinish = param;
        }

        return strFinish;
    }
    public static string urlHome()
    {

        HttpRequest req = HttpContext.Current.Request;
        string urlPathHome = req.Url.GetLeftPart(UriPartial.Authority);
        if (urlPathHome.IndexOf("http://localhost") > -1)
            urlPathHome += req.ApplicationPath;
        return urlPathHome;
    }
    public static Bitmap ImageDenTrang(Bitmap original)
    {
        //create a blank bitmap the same size as original
        Bitmap newBitmap = new Bitmap(original.Width, original.Height);

        //get a graphics object from the new image
        Graphics g = Graphics.FromImage(newBitmap);

        //create the grayscale ColorMatrix
        ColorMatrix colorMatrix = new ColorMatrix(
           new float[][] 
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

        //create some image attributes
        ImageAttributes attributes = new ImageAttributes();

        //set the color matrix attribute
        attributes.SetColorMatrix(colorMatrix);

        //draw the original image on the new image
        //using the grayscale color matrix
        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
           0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

        //dispose the Graphics object
        g.Dispose();
        return newBitmap;
    }
}