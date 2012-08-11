using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Type
/// </summary>
public class Type
{
    public string type { get; set; }
	public Type(){ }

    public bool myEquals(System.Object obj)
    {
        // If parameter is null return false.
        if (obj == null)
            return false;

        // If parameter cannot be cast to Point return false.
        Type target = obj as Type;
        if ((System.Object)target == null)
            return false;
        
        int type = String.Compare(this.type.Trim(), target.type.Trim());

        return type == 0;        
    }// end myEquals

    public string myTostring()
    {
        string str = "";
        return str + "" + this.type + "|";
    }// end myTostring

}