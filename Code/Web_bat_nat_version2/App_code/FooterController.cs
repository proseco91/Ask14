using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for FooterController
/// </summary>
public class FooterController
{
    private ConnectSQL objCon = new ConnectSQL();
	public FooterController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetData()
    {
        string[] arrParam = { };
        object[] arrValue = { };
        return objCon.TableWithParameter("tblFooter_GetData", arrParam, arrValue);
    }
    
    public bool Update(string content)
    {
        string[] arrParam = { "@Content"};
        object[] arrValue = { content};
        return objCon.Update("tblFooter_Update", arrParam, arrValue);
    }
}