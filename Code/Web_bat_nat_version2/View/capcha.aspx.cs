using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text;
using System.Drawing.Drawing2D;

public partial class capcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.returnNumer();
    }
    public int RandomNumber()
    {
        Random random = new Random();
        return random.Next(0, 9);
    }
    public string RandomString()
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < 1; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
            return builder.ToString().ToUpper();
    }
    private void returnNumer()
    {

        Random random1 = new Random();
        string QString = null;
        int num1 = random1.Next(0, 9);
        string num2 = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random1.NextDouble() + 65))).ToString().ToUpper();
        int num3 = random1.Next(0, 9);
        string num4 = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random1.NextDouble() + 65))).ToString().ToUpper();
        QString = num1 + "" + num2 +""+ num3 + "" + num4;

        Session["Capcha"] = num1 + "" + num2 + "" + num3 + "" + num4;


        Bitmap bitmap = new Bitmap(60, 20);

        Graphics Grfx = Graphics.FromImage(bitmap);

        Font font = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);

        Rectangle Rect = new Rectangle(0, 0, 60, 20);
        HatchBrush brush = new HatchBrush(HatchStyle.SmallCheckerBoard, Color.Wheat, Color.White);
        Grfx.FillRegion(brush, Grfx.Clip); 

        Grfx.DrawString(QString, font, Brushes.Black, 7, 2);

        Response.ContentType = "Image/jpeg";

        bitmap.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

        bitmap.Dispose();

        Grfx.Dispose();

    } 
}