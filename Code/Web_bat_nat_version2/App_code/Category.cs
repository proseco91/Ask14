using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
    public Category()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private int _ID;
    public int ID
    {
        get
        {
            return this._ID;
        }
        set
        {
            this._ID = value;
        }
    }
    private int _PARENT_ID;
    public int PARENT_ID
    {
        get { return this._PARENT_ID; }
        set { this._PARENT_ID = value; }
    }

    private string _NAME;
    public string NAME
    {
        get { return this._NAME; }
        set { this._NAME = value; }
    }
}