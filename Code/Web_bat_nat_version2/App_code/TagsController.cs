using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for TagsController
/// </summary>
public class TagsController
{
    ConnectSQL cnts = new ConnectSQL();
    public TagsController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAllTags()
    {
        string[] arrParam = { };
        object[] arrValue = { };
        return cnts.TableWithParameter("tblTags_GetAll", arrParam, arrValue);
    }
    public int Insert(string NAME, DateTime CREATED_DATE, int STATUS)
    {
        string[] arrParam = { "@NAME", "@CREATED_DATE", "@STATUS" };
        object[] arrValue = { NAME, CREATED_DATE, STATUS };
        return cnts.insert("tblTags_Insert", arrParam, arrValue);
    }

    public bool Update(int ID, string NAME)
    {
        string[] arrParam = { "@ID", "@NAME" };
        object[] arrValue = { ID, NAME };
        return cnts.Update("tblTags_update", arrParam, arrValue);
    }

    public bool Delete(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.Update("tblTags_delete", arrParam, arrValue);
    }

    public DataTable CheckData(string NAME)
    {
        string[] arrParam = { "@NAME" };
        object[] arrValue = { NAME };
        return cnts.TableWithParameter("tblTags_CheckData", arrParam, arrValue);
    }

    public DataTable GetDataById(int ID)
    {
        string[] arrParam = { "@ID" };
        object[] arrValue = { ID };
        return cnts.TableWithParameter("tblTags_GetDataByID", arrParam, arrValue);
    }

    public DataTable GetTagsPresent()
    {
        return cnts.TableWithoutParameter("tblTags_GetDataPresent");
    }
}