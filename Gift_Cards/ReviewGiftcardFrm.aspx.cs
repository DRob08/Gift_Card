using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReviewGiftcardFrm : System.Web.UI.Page
{
    List<GiftCard> allGiftcards;    //list of all giftcards in the system
    static int currIndex = 0;       //current index of giftcard
    /// <summary>
    /// initialize and set values of the list
    /// </summary>
    public List<GiftCard> Cards
    {
        get
        {
            if (allGiftcards == null)
            {
                allGiftcards = new List<GiftCard>();
            }//end if
            return allGiftcards;
        }//end get
        set
        {
            if (allGiftcards != value)
            {
                allGiftcards = value;
            }//end if
        }//end set
    }// end List<GiftCard>
    /// <summary>
    /// when page load retrieve session variable and cast to the list
    /// display the giftcard at position 0
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["stroomatches"] != null) Cards = (List<GiftCard>)Session["stroomatches"];


        if (!IsPostBack)
        {
            currIndex = 0; //this is to reset index when page load

            DisplayGiftCard(0, Cards);
        }
    }
    /// <summary>
    /// function to display gitcard properties on form
    /// </summary>
    /// <param name="index"> position in the list of the giftcard to be displayed</param>
    /// <param name="myList"> list that contains all giftcards</param>
    protected void DisplayGiftCard(int index, List<GiftCard> myList)
    {
        txtVoyage.Text = myList[index].Voyage.ToString();
        txtDeliveryDate.Text = myList[index].Deliverydate.ToString();
        txtFirstName.Text = myList[index].firstPaxFirst.ToString() + " " + myList[index].firstPaxLast.ToString();
        txtSailingDate.Text = myList[index].Saildate.ToString();
        txtAmenity.Text = myList[index].Amenity.ToString();
        txtComp.Text = myList[index].Compliments.ToString();
        txtMessage.Text = myList[index].Message.ToString();
        txtQuantity.Text = myList[index].Qty.ToString();
        txtStRoom.Text = myList[index].Cabin.ToString();

    }//end Display GiftCard

    /// <summary>
    /// will redirect user to the Menu or Default
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AllGiftcardsFrm.aspx"); //double checkk which one to use ********
    }
    /// <summary>
    /// pop up message box 
    /// </summary>
    /// <param name="page"></param>
    /// <param name="message"></param>
    private void MessageBoxShow(Page page, string message)
    {
        Literal ltr = new Literal();
        ltr.Text = @"<script type='text/javascript'> alert('" + message + "') </script>";
        page.Controls.Add(ltr);
    }//end Message
    /// <summary>
    /// go backwards through the list making sure of not going out of bounds
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnPrev0_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GiftCard gCard in Cards)
        {
             if (currIndex >= 0 || gCard == null)
            {
                currIndex = currIndex - 1;
                // if current index is -1
                if (currIndex < 0)
                {   //display the giftcard at position 0
                    DisplayGiftCard(0, Cards);
                    
                    //add 1 more and bring it back to first position in the list
                    currIndex = currIndex + 1;
                    MessageBoxShow(this, "No Prevoius Giftcards");
                    //Immediately break 
                    break;
                }//end if
               //if current index is within the size of the list then display
               //giftcard at current index
                DisplayGiftCard(currIndex, Cards);
               //immediately break
                break;
            }//end if
        }//end foreach
    }
    /// <summary>
    /// go forward through the list making sure of not going out of bounds
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnNext_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GiftCard gCard in Cards)
        {   //check that giftcard is not null and that current index is less or equal
            //to the size of the list
            if (gCard != null & (currIndex <= Cards.Count - 1))
            {   //add one more so you can move through the list
                currIndex = currIndex + 1;
                //if current index is more that the list elements
                if (currIndex > Cards.Count - 1)
                {   //display giftcard at the end of the list
                    DisplayGiftCard(Cards.Count - 1, Cards);
                   //substract one  and current index will be 
                    //the index at the end of the list
                    currIndex = currIndex - 1;
                    MessageBoxShow(this, "No More Giftcards");
                    //immediately break
                    break;
                }
                //if current index is within the size of the list then display
                //giftcard at current index
                DisplayGiftCard(currIndex, Cards);
                //immediately break
                break;
            }//end if
            else
            {
                //display card at the end
                DisplayGiftCard(Cards.Count - 1, Cards);
                break;
            }//end else

        }//end foreach
    }
    /// <summary>
    /// function that creates a report from the current giftcard to be printed
    /// store current index into session variable to remember index of the list
    /// store the list of gitcards into session variable 
    /// session variables are used in object data source to create the report of current giftcard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
         Session["pos"] = currIndex;
        Session["cards"] = Cards;
        Response.Redirect("~/CurrentGiftFrm.aspx");
    }
}