using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CountLikeController
/// </summary>
public class CountLikeController
{
    ConnectSQL cnts = new ConnectSQL();
    public CountLikeController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(int ThreadId, string CustomerEmail, DateTime CreatedDate, int Status)
    {
        string[] arrParam = { "@ThreadId", "@CustomerEmail", "@CreatedDate", "@Status" };
        object[] arrValue = { ThreadId, CustomerEmail, CreatedDate, Status };
        return cnts.insert("tblCountLike_Insert", arrParam, arrValue);
    }
    public bool Delete(int ThreadId, string CustomerEmail)
    {
        string[] arrParam = { "@ThreadId", "@CustomerEmail" };
        object[] arrValue = { ThreadId, CustomerEmail };
        return cnts.Update("tblCountLike_Delete", arrParam, arrValue);
    }
    public DataTable CheckCount(int ThreadId, string CustomerEmail)
    {
        string[] arrParam = { "@ThreadId", "@CustomerEmail" };
        object[] arrValue = { ThreadId, CustomerEmail };
        return cnts.TableWithParameter("tblCountLike_CheckLike", arrParam, arrValue);
    }

    public DataTable CheckCountThread(int ThreadId)
    {
        string[] arrParam = { "@ThreadId" };
        object[] arrValue = { ThreadId };
        return cnts.TableWithParameter("tblCountLike_Thread", arrParam, arrValue);
    }

}