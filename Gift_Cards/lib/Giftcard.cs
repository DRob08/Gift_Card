using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GiftCard
/// </summary>
[Serializable]// for sent a session
public class GiftCard
{
    public string Voyage { get; set; }
    public string Saildate { get; set; }
    public string Deliverydate { get; set; } 
    public string Amenity { get; set; }
    public int Qty { set; get; }
    public string Compliments { get; set; }
    public string Message { set; get; }
    public string Cabin { set; get; }
    public string firstPaxFirst { set; get; }
    public string firstPaxLast { set; get; }
    public string secndPaxFirst { set; get; }
    public string secndPaxLast { set; get; }
    public string thirdPaxFirst { set; get; }
    public string thirdPaxLast { set; get; }
    public string fourthPaxFirst { set; get; }
    public string fourthPaxLast { set; get; }
    public string Ship { set; get; }
    public string Type { set; get; }
    public string DeliveryType { set; get; }
    public string DRoom { set; get; }
    public string Seating { set; get; }
    public string Table { set; get; }
    
    
    //public int DRoom { set; get; }
    //public int Seating { set; get; }
    //public int Table { set; get; }

    //public string FirstName { get; set; }
    //public string LastName { get; set; }
    //public string FullName { get { return string.Format("{0},{1}",LastName,FirstName;} }

	public GiftCard() {}

    /// <summary>
    /// this function set the passengers names and last name
    /// </summary>
    /// <param name="pass"> list with passengers information</param>
    public void setNamens(List<Gift_Cards.GuestService.GuestView> pass)
    {
        switch (pass.Count)
        {
            case 1:
                this.firstPaxFirst = pass[0].firstName.ToString();
                this.firstPaxLast = pass[0].lastName.ToString();
                break;
            case 2:
                this.firstPaxFirst = pass[0].firstName.ToString();
                this.firstPaxLast = pass[0].lastName.ToString();
                this.secndPaxFirst = pass[1].firstName.ToString();
                this.secndPaxLast = pass[1].lastName.ToString();
                break;
            case 3:
                this.firstPaxFirst = pass[0].firstName.ToString();
                this.firstPaxLast = pass[0].lastName.ToString();
                this.secndPaxFirst = pass[1].firstName.ToString();
                this.secndPaxLast = pass[1].lastName.ToString();
                this.thirdPaxFirst = pass[2].firstName.ToString();
                this.thirdPaxLast = pass[2].lastName.ToString();
                break;
            case 4:
                this.firstPaxFirst = pass[0].firstName.ToString();
                this.firstPaxLast = pass[0].lastName.ToString();
                this.secndPaxFirst = pass[1].firstName.ToString();
                this.secndPaxLast = pass[1].lastName.ToString();
                this.thirdPaxFirst = pass[2].firstName.ToString();
                this.thirdPaxLast = pass[2].lastName.ToString();
                this.fourthPaxFirst = pass[3].firstName.ToString();
                this.fourthPaxLast = pass[3].lastName.ToString();
                break;
            default:
                this.firstPaxFirst = pass[0].firstName.ToString();
                this.firstPaxLast = pass[0].lastName.ToString();
                this.secndPaxFirst = pass[1].firstName.ToString();
                this.secndPaxLast = pass[1].lastName.ToString();
                this.thirdPaxFirst = pass[2].firstName.ToString();
                this.thirdPaxLast = pass[2].lastName.ToString();
                this.fourthPaxFirst = pass[3].firstName.ToString();
                this.fourthPaxLast = pass[3].lastName.ToString();
                break;
        }// end switch (pass.Count)

    }// end setNamens

    /// <summary>
    /// this method return a gift card object string to print the new GiftCard
    /// </summary>
    /// <returns></returns>
    public String toStringToReport()
    {
        string str = "";
        return str + "" + Voyage + "|" + Saildate + "|" + Deliverydate + "|" + Amenity + "|" + Qty + "|" + Compliments + "|" +
                Message + "|" + Cabin + "|" + firstPaxFirst + "|" + firstPaxLast + "|" + secndPaxFirst + "|" + secndPaxLast + "|" + 
                thirdPaxFirst + "|" + thirdPaxLast + "|" + fourthPaxFirst + "|" + fourthPaxLast + "|" + Ship + "|" + 
                Type + "|" + DeliveryType + "|" + DRoom + "|" + Seating + "|" + Table + "\n";
    }// end toStringToReport

    /// <summary>
    /// this method return a gift card object string to apend in the GIFTCDS.TXT
    /// </summary>
    /// <returns></returns>
    public String toStringToFile()
    {
        string str = "";
        string sailidate = UtilityClass.FixDateToFile(this.Saildate.ToString());
        string deliverydate = UtilityClass.FixDateToFile(this.Deliverydate.ToString());

        return str + "" + Voyage + "|" + sailidate + "|" + deliverydate + "|" + Amenity + "|" + Qty + "|" + Compliments + "|" +
                Message + "|" + Cabin + "|" + firstPaxFirst + "|" + firstPaxLast + "|" + secndPaxFirst + "|" + secndPaxLast + "|" +
                thirdPaxFirst + "|" + thirdPaxLast + "|" + fourthPaxFirst + "|" + fourthPaxLast + "|" + Ship + "|" +
                Type + "|" + DeliveryType + "|" + DRoom + "|" + Seating + "|" + Table + "|";
    }// end toStringToReport

  
}// end class GiftCard