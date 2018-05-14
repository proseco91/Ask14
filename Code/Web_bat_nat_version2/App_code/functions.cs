using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for functions
/// </summary>
public class functions
{
    private int functionid;
    private int parentid;
    private string functionname;
    private string url;
    private int indexes;

	public functions()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int FunctionID
    {
        get
        {
            return this.functionid;
        }
        set
        {
            this.functionid = value;
        }
    }

    public int ParentID
    {
        get
        {
            return this.parentid;
        }
        set
        {
            this.parentid = value;
        }
    }

    public string FunctionName
    {
        get
        {
            return this.functionname;
        }
        set
        {
            this.functionname = value;
        }
    }

    public string Url
    {
        get
        {
            return this.url;
        }
        set
        {
            this.url = value;
        }
    }

    public int Indexes
    {
        get
        {
            return this.indexes;
        }
        set
        {
            this.indexes = value;
        }
    }
}