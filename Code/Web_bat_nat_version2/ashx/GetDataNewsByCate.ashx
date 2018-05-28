<%@ WebHandler Language="C#" Class="GetDataNewsByCate" %>

using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Dynamic;
using System.Collections.Generic;

public class GetDataNewsByCate : IHttpHandler
{
    BizNews objNews = new BizNews();
    ConnectSQL cnts = new ConnectSQL();
    LinqDataContext sql = new LinqDataContext();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";
        int from = 1;
        int to = 6;
        int ID = 43;
        try
        {
            from = Int32.Parse(context.Request.QueryString["from"].ToString());
            to = Int32.Parse(context.Request.QueryString["to"].ToString());
            ID = Int32.Parse(context.Request.QueryString["CATEGORYID"].ToString());
            
        }
        catch
        {
            from = 1;
            to = 5;
            ID = 43;
        }

        if (ID == 64)
        {
            List<dynamic> arr = new List<dynamic>();
            arr.AddRange((from p in sql.tblNews where p.STATUS==1 && (p.CATEGORYID.IndexOf(ID + ";") > -1 || p.CATEGORYID.Replace(";", "").Equals(ID.ToString())) select new {id=p.ID,time=p.CREATED_DATE,type=0}).OrderByDescending(d => d.time).Take(to));
            arr.AddRange((from p in sql.tblQuizs where p.Status == 1 select new { id = p.ID, time = p.CreateDate, type = 1 }).OrderByDescending(d => d.time).Take(to));
            arr = arr.OrderByDescending(d => d.time).ToList();
            List<accccc> arrRe = new List<accccc>();
            to = to > arr.Count ? arr.Count : to;
            for (int i = from-1; i < to; i++)
            {
                dynamic nData = arr[i];
                accccc _data = new accccc();
                int nId = Convert.ToInt32(nData.id);
                if (nData.type == 0)
                {
                    tblNew _new = (from p in sql.tblNews where p.ID == nId select p).FirstOrDefault();
                    _data.ID = _new.ID;
                    _data.CATEGORYNAME = "0";
                    _data.TITLE = _new.TITLE;
                    _data.IMAGE = _new.IMAGE;
                    _data.SUMMARY = _new.SUMMARY;
                    _data.CREATED_DATE = _new.CREATED_DATE;
                    _data.RowNumber = to - (to - i);
                    _data.RecordsTotal = to + 1;
                    arrRe.Add(_data);
                }
                else {
                    tblQuiz _quiz = (from p in sql.tblQuizs where p.ID == nId select p).FirstOrDefault();
                    _data.ID = _quiz.ID;
                    _data.CATEGORYNAME = "quiz";
                    _data.TITLE = _quiz.Title;
                    _data.IMAGE = _quiz.Img;
                    _data.SUMMARY = _quiz.Des;
                    _data.CREATED_DATE = _quiz.CreateDate;
                    _data.RowNumber = to - (to - i);
                    _data.RecordsTotal = to+1;
                    arrRe.Add(_data);
                }
            }
            string sXml = cnts.WriteXML(Lib.ConvertToDataTable(arrRe));
            context.Response.Write(sXml);
        }
        else {
            string sXml = cnts.WriteXML(GetData(from, to, ID));
            context.Response.Write(sXml);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private DataTable GetData(int from, int to, int ID)
    {
        return objNews.GetDataByCategory(from, to, ID);
    }

}