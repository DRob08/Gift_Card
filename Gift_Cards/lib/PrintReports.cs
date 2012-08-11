using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PrintReports
/// </summary>
public class PrintReports
{
    private List<GiftCard> allGiftcard;     // list that contains all giftcards
    public List<GiftCard> Cards
    {
        get
        {
            if (allGiftcard == null)
            {
                allGiftcard = new List<GiftCard>();
            }
            return allGiftcard;
        }
        set
        {
            if (allGiftcard != value)
            {
                allGiftcard = value;
            }
        }
    }// end List<GiftCard
    /// <summary>
    /// constructor immediately read file and fill list of giftcards
    /// </summary>
    public PrintReports()
    {
        UtilityClass.getDataCards(Cards);
    }
    
    /// <summary>
    /// returns a list containing giftcards that match only WINE type
    /// this method is used in the object data source
    /// </summary>
    /// <returns></returns>
    public List<GiftCard> WineCards()
    {
        if (Cards != null)
        {
            var wCard = Cards.FindAll((ca) => ca.Type.Trim().Equals("WINE"));
            return wCard;
        }

        return null;
    }//end winecards

    /// <summary>
    /// returns a list containing giftcards that match only HouseKeeping type
    /// this method is used in the object data source
    /// </summary>
    /// <returns></returns>
    public  List<GiftCard> HouseKeepingCards()
    {
        if (Cards != null)
        {
            var hCard = Cards.FindAll((ca) => !ca.Type.Trim().Equals("WINE"));
            return hCard;
        }
        return null;
    }//end housekeepingcards

    /// <summary>
    /// returns a list that contain one giftcrad which is the one to be printed currently 
    /// this method is used in the object data source
    /// </summary>
    /// <param name="index"></param>
    /// <param name="curr"></param>
    /// <returns></returns>
    public  List<GiftCard> PrintCurrent(List<GiftCard> curr)
    {
       return curr;
    }//end printcurrent

    /// <summary>
    /// This method return a list with the new gift card created in create OwnGiftCard form recived as a session
    /// </summary>
    /// <param name="list"> Session["newGiftCard"] </param>
    /// <returns> A list with one GiftCard object </returns>
    public List<GiftCard> printNewGiftCard(List<GiftCard> list)
    {
        return list;
    }// end printEewGiftCard

}