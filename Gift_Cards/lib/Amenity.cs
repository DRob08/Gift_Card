using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Amenity
/// </summary>
public class Amenity
{
    public string amenity { get; set; }
    public string type { get; set; }
    public Amenity() {}

    public bool myEquals(System.Object obj)
    {
        // If parameter is null return false.
        if (obj == null)        
            return false;        

        // If parameter cannot be cast to Point return false.
        Amenity target = obj as Amenity;
        if ((System.Object)target == null)       
            return false;        

        int amenity = String.Compare(this.amenity.Trim(), target.amenity.Trim());
        int type = String.Compare(this.type.Trim(), target.type.Trim());

        return amenity == 0 && type == 0 ;
        // Return true if the fields match.
        //return (this.amenity.Equals(target.amenity)) && (this.type.Equals(target.type));
    }// end Equals

    public string myTostring()
    {
        string str = "";
        return str + "" + this.amenity + "|" + this.type + "|";
    }
}// end Class Amenity


