using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BizHistorySent
/// </summary>
public class BizHistorySent
{
    public BizHistorySent()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //@SENDER nvarchar(500),
    //       @RECIEVER nvarchar(500),
    //       @EMAIL_ID int,
    //       @DATE_SENT datetime,
    //       @CONTENT ntext,
    //       @TYPE int)
    ConnectSQL cnts = new ConnectSQL();
    public void Insert(string SENDER, string RECIEVER, int EMAIL_ID, DateTime DATE_SENT, string CONTENT, int TYPE)
    {
        string[] para = { "@SENDER", "@RECIEVER", "@EMAIL_ID", "@DATE_SENT", "@CONTENT", "@TYPE" };
        object[] obj = { SENDER, RECIEVER, EMAIL_ID, DATE_SENT, CONTENT, TYPE };
        cnts.ExcuteStored("tblHistorySent_Insert", para, obj);

    }
}