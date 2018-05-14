using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CountLikeCommentController
/// </summary>
public class CountLikeCommentController
{
    ConnectSQL cnts = new ConnectSQL();
    public CountLikeCommentController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(int CommentId, string CustomerEmail, DateTime CreatedDate, int Status)
    {
        string[] arrParam = { "@CommentId", "@CustomerEmail", "@CreatedDate", "@Status" };
        object[] arrValue = { CommentId, CustomerEmail, CreatedDate, Status };
        return cnts.insert("tblCountLikeComment_Insert", arrParam, arrValue);
    }
    public bool Delete(int CommentId, string CustomerEmail)
    {
        string[] arrParam = { "@CommentId", "@CustomerEmail" };
        object[] arrValue = { CommentId, CustomerEmail };
        return cnts.Update("tblCountLikeComment_Delete", arrParam, arrValue);
    }
    public DataTable CheckCount(int CommentId, string CustomerEmail)
    {
        string[] arrParam = { "@CommentId", "@CustomerEmail" };
        object[] arrValue = { CommentId, CustomerEmail };
        return cnts.TableWithParameter("tblCountLikeComment_CheckLike", arrParam, arrValue);
    }

    public DataTable CheckCountThread(int CommentId)
    {
        string[] arrParam = { "@CommentId" };
        object[] arrValue = { CommentId };
        return cnts.TableWithParameter("tblCountLikeComment_Thread", arrParam, arrValue);
    }

    
    

}