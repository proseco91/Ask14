using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for ConnectSQL
/// </summary>
public class ConnectSQL
{
    public ConnectSQL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string connnectionString = ConfigurationManager.ConnectionStrings["sCN"].ConnectionString;

    public SqlConnection cnn;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable db;
    public SqlConnection getConnect()
    {
        return cnn;
    }
    public void OpenConnection()
    {
        try
        {
            cnn = new SqlConnection(connnectionString);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
        }
        catch (Exception ex)
        {


            File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/log.txt"), DateTime.Now + ": ConnectSQL " + ex.Message + Environment.NewLine);

            cnn.Close();
        }

    }
    public void CloseConnection()
    {
        try
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public bool ExcutedCMD(string cmdText)
    {
        try
        {
            OpenConnection();
            cmd = new SqlCommand(cmdText, cnn);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
        catch (Exception)
        {
            return false;
        }
        return true;

    }
    public void ExcuteStored(string storedname, string[] parameter, object[] objVal)
    {
        try
        {
            OpenConnection();
            cmd = new SqlCommand(storedname, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parameter.Length; i++)
            {
                cmd.Parameters.Add(new SqlParameter(parameter[i], objVal[i]));
            }
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
        catch (Exception)
        {


        }

    }
    /*  public bool ExcuteStored(string storedname, string[] parameter, object[] objVal)
      {
          try
          {
              OpenConnection();
              cmd = new SqlCommand(storedname, cnn);
              cmd.CommandType = CommandType.StoredProcedure;
              for (int i = 0; i < parameter.Length; i++)
              {
                  cmd.Parameters.Add(new SqlParameter(parameter[i], objVal[i]));
              }
              int a = cmd.ExecuteNonQuery();
              CloseConnection();
              if (a > 0)
              {
                  return true;
              }
              else
              {
                  return false;
              }
          }
          catch
          {
              return false;

          }

      }*/
    public DataTable TableWithParameter(string storedname, string[] parameter, object[] objVal)
    {
        OpenConnection();
        cmd = new SqlCommand(storedname, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 60;
        for (int i = 0; i < parameter.Length; i++)
        {
            cmd.Parameters.Add(new SqlParameter(parameter[i], objVal[i]));
        }
        DataTable db = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        da.SelectCommand = cmd;
        da.Fill(db);
        CloseConnection(); return db;
    }
    public DataTable TableWithParameterNoClose(string storedname, string[] parameter, object[] objVal)
    {
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }
        SqlCommand cmd2 = new SqlCommand(storedname, cnn);

        cmd2.CommandType = CommandType.StoredProcedure;
        for (int i = 0; i < parameter.Length; i++)
        {
            cmd2.Parameters.Add(new SqlParameter(parameter[i], objVal[i]));
        }
        SqlDataReader productReader = cmd2.ExecuteReader();
        DataTable myTable = new DataTable();
        myTable.Load(productReader);
        productReader.Close();
        return myTable;
    }
    public DataTable TableWithoutParameter(string storedname)
    {
        OpenConnection();
        cmd = new SqlCommand(storedname, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        DataTable db = new DataTable(); SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(db);
        CloseConnection(); return db;
    }
    public object GetExcuteScalar(string sql)
    {
        object t = "";
        OpenConnection();
        cmd = new SqlCommand(sql, cnn);
        t = cmd.ExecuteScalar();
        CloseConnection();
        return t;
    }
    public DataTable GetTableWithCommandText(string sql)
    {
        OpenConnection();
        cmd = new SqlCommand(sql, cnn);

        DataTable db = new DataTable(); SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(db);
        CloseConnection(); return db;
    }

    public int insert(string storedname, string[] arrParam, object[] arrValue)
    {
        int id = 0;
        try
        {
            OpenConnection();
            cmd = new SqlCommand(storedname, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterID = new SqlParameter("@ID", 0);
            parameterID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parameterID);

            for (int i = 0; i < arrParam.Length; i++)
            {
                cmd.Parameters.Add(new SqlParameter(arrParam[i], arrValue[i]));
            }

            cmd.ExecuteNonQuery();
            id = Int32.Parse(cmd.Parameters["@ID"].Value.ToString());
            CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return id;
    }



    public bool Update(string storedname, string[] arrParam, object[] arrValue)
    {
        bool kt = false;
        try
        {
            OpenConnection();
            cmd = new SqlCommand(storedname, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < arrParam.Length; i++)
            {
                cmd.Parameters.Add(new SqlParameter(arrParam[i], arrValue[i]));
            }
            cmd.ExecuteNonQuery();
            CloseConnection();
            kt = true;
        }
        catch (Exception ex)
        {
            kt = false;
            throw ex;
        }
        return kt;
    }

    public string WriteXML(DataTable objDT)
    {
        string sNew = "";
        sNew = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        sNew += "<root>";
        if (objDT.Rows.Count > 0)
        {

            for (int i = 0; i < objDT.Rows.Count; i++)
            {
                sNew += "<Row id='" + i + "'>";
                for (int j = 0; j < objDT.Columns.Count; j++)
                {
                    sNew += "<" + objDT.Columns[j].ToString() + ">";
                    sNew += "<![CDATA[" + objDT.Rows[i][j].ToString() + " ]]>";
                    sNew += "</" + objDT.Columns[j].ToString() + ">";
                }
                sNew += "</Row>";
            }
        }
        else
        {
            sNew += "<Rows>0</Rows>";
        }
        sNew += "</root>";
        return sNew;
    }


    // cat chuoi
    public string CutString(string param, int param1)
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
    //Hàm này mục đích là trừ 2 ngày
    public int DateDiff(DateTime start_date, DateTime end_date)
    {
        TimeSpan objTime = end_date - start_date;
        int days = (int)objTime.TotalDays;
        return days;
    }

}
