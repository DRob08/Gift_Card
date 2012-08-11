using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class OwnGiftCard : System.Web.UI.Page
{
    private List<GiftCard> _cards;
    private List<Amenity> _amenity;   

    public List<GiftCard> Cards
    {
        get
        {
            if (_cards == null) { _cards = new List<GiftCard>(); }
            return _cards;
        }
        set
        {
            if (_cards != value) { _cards = value; }
        }
    }// end List<GiftCard>

    public List<Amenity> Amenities
    {
        get
        {
            if (_amenity == null) { _amenity = new List<Amenity>(); }
            return _amenity;
        }
        set
        {
            if (_amenity != value) { _amenity = value; }
        }
    }// end List<String> 

    protected void Page_Load(object sender, EventArgs e)
    {
        // read the file GIFTCDS.TXT to generate the list of GiftCards and Amenities.
        UtilityClass.getDataCards(Cards);
        Amenities = UtilityClass.AmenityDeserializeFromXML();

        Gift_Cards.VoyageService.VoyageView ship = UtilityClass.TryGetShipInfo(lblCreated);
        if (ship != null)
        {
            txtVoyage.Text = ship.voyageNumber.ToString();
            txtSilingDate.Text = String.Format("{0:MM/dd/yyyy}", ship.startDate);

        }

        // if deliverytype diferent to dinning room hide dinning room, seating and table.
        if (ddlDeliverTo.SelectedItem.Text.CompareTo("Dinning room") != 0)
            this.toUnvisible();

        // Sort the amenity list
        this._amenity = Amenities.OrderBy((a) => a.amenity).ToList();
        if (!IsPostBack)
        {
            // load the amenities Dropdownlist
            loadAmenities();
            // load the delivery Dropdownlist
            loadDeliveryTo();
            // Set to unvisible Dinning Room, Table, and Seating.
            this.toUnvisible();

        }// end if (!IsPostBack)

    }// end Page_Load

    // Helpers methods
    /// <summary>
    /// This method update the amentity Dropdownlist 
    /// </summary>
    public void loadAmenities()
    {
        foreach (Amenity amenity in this.Amenities)
            ddlAmenity.Items.Add(amenity.amenity);
    }// end loadAmenities()

    /// <summary>
    /// This method update the delivery typt Dropdownlist
    /// </summary>
    public void loadDeliveryTo()
    {
        ddlDeliverTo.Items.Add("Cabin");
        ddlDeliverTo.Items.Add("Dinning room");
        ddlDeliverTo.Items.Add("Passenger Discretion");
        ddlDeliverTo.Items.Add("Stateroom");
    }// end loadDeliveryTo()
    
    /// <summary>
    /// This method validate the data imput, create a new gift card, 
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Validate data input
        Boolean Voyage = UtilityClass.isValidInt(txtVoyage, lblVoyage, "*", "Insert digits!");
        Boolean Saildate = UtilityClass.isValidDate(txtSilingDate, lblSailingDate, "*", "Format (MM/DD/YYYY)!");
        Boolean Deliverydate = UtilityClass.isValidDate(txtDeliveryDate, lblDeliveryDate, "*", "Format (MM/DD/YYYY)!");
        
        Boolean DeliverydateChronolog = false;
        if (Saildate && Deliverydate)
            DeliverydateChronolog = UtilityClass.isChronologicalDate(txtSilingDate, txtDeliveryDate, lblDeliveryDate, "Chronological error!");
       
        Boolean Cabin = UtilityClass.isValidInt(txtStateroom, lblStateroom, "*", "Insert digits!");
        Boolean Amenity = UtilityClass.isValidText(ddlAmenity, lblAmenity, "*");
        Boolean Qty = UtilityClass.isValidInt(txtQuantity, lblQuantity, "*", "Insert digits greater than zero!");
        Boolean DeliveryType = UtilityClass.isValidText(ddlDeliverTo, lblDelivery, "*");


        Boolean dinning = false;
        Boolean seating = false;
        Boolean table = false;
        if (DeliveryType && ddlDeliverTo.SelectedItem.Text == "Dinning room")
        {
            dinning = UtilityClass.isValidText(txtDiningRoom, lblDiningRoom, "*", null);
            seating = UtilityClass.isValidText(txtSeating, lblSeating, "*", null);
            table = UtilityClass.isValidText(txtTable, lblTable, "*", null);
        }// end if

        Boolean typeflag = false;
        if((DeliveryType && ddlDeliverTo.SelectedItem.Text.CompareTo("Dinning room")!=0) || (dinning && seating && table ))
        {
            typeflag = true;
        }// end if

        Boolean Compliments = UtilityClass.isValidText(txtCompliments, lblCompliments, "*", "Insert leters or digits!");
        Boolean Message = UtilityClass.isValidText(txtMessage, lblMessage, "*", "Insert leters or digits!");

        // if all the input are correct create a new GiftCard and add it to the list.
        if (Voyage && Saildate && Deliverydate && DeliverydateChronolog && Cabin && Amenity && Qty && typeflag && Compliments && Message)
        {
            GiftCard newBe = new GiftCard(); // create a new object GiftCard

            int stateroom = int.Parse(txtStateroom.Text.Trim());

            List<Gift_Cards.GuestService.GuestView> passenger = UtilityClass.TryGetGuestInfo(stateroom, lblCreated);  // 9219, 

            if (passenger == null)
            {
                lblStateroom.Text = "The stateroom does not exist!";
            }
            else
            {
                newBe.Ship = UtilityClass.shipName.Trim();
                newBe.Voyage = txtVoyage.Text.Trim();
                newBe.Saildate = txtSilingDate.Text.Trim();
                newBe.Deliverydate = txtDeliveryDate.Text.Trim();
                newBe.Amenity = ddlAmenity.SelectedItem.Text.Trim();
                newBe.Cabin = txtStateroom.Text.Trim();
                //find the amenity type and update it in the GiftCard
                newBe.Type = Amenities.Find((t) => t.amenity == newBe.Amenity).type;

                newBe.Qty = int.Parse(txtQuantity.Text);
                newBe.Compliments = txtCompliments.Text;
                newBe.Message = txtMessage.Text;
                newBe.DeliveryType = ddlDeliverTo.SelectedItem.Text;
                newBe.Cabin = txtStateroom.Text;

                if (dinning && seating && table)
                {
                    newBe.DRoom = txtDiningRoom.Text;
                    newBe.Table = txtTable.Text;
                    newBe.Seating = txtSeating.Text;
                }// end if

                // set the names of the passengers
                newBe.setNamens(passenger);

                this.Cards.Add(newBe);// add the new GiftCard to the list

                //Apend the new gift card to the end of the file
                if (this.Cards.Count == 1)
                {
                    UtilityClass.overrideGiftCardFile(this.Cards);
                }
                else
                {
                    try
                    {
                        //Apend the new gift card to the end of the file
                        var filePath = UtilityClass.GetFilePath(UtilityClass.giftcardFile);
                        using (StreamWriter sw = File.AppendText(filePath))
                        {
                            sw.WriteLine(newBe.toStringToFile()); sw.Close(); sw.Dispose();
                        }// end using
                    }
                    catch (Exception ex) { UtilityClass.ReportLog(ex.Message); }//end catch
                }

                //Create a list with the new GiftCard and send it to print.
                List<GiftCard> toPrint = new List<GiftCard>();
                toPrint.Add(this.Cards[this.Cards.Count - 1]);
                Session["newGiftCard"] = toPrint;
                lblCreated.Text = "Gift Card succesfully created!";

                //Set to unvisible Dinning Room, Table, and Seating.
                this.toUnvisible();

            } // end if (newBe != null)

        }// end if(Voyage && Saildate && ------ ) 

    }// end btnSubmit_Click

    /// <summary>
    /// this method clears all the texbox and label on the screen 
    /// </summary>
    public void reset()
    {
        lblVoyage.Text = "";
        lblSailingDate.Text = "";
        txtDeliveryDate.Text = "";
        lblDeliveryDate.Text = "";
        txtStateroom.Text = "";
        lblStateroom.Text = "";
        ddlAmenity.Text = "--- select item ---";
        lblAmenity.Text = "";
        txtQuantity.Text = "";
        lblQuantity.Text = "";
        ddlDeliverTo.Text = "--- select item ---";
        lblDelivery.Text = "";
        txtCompliments.Text = "";
        lblCompliments.Text = "";
        txtMessage.Text = "";
        lblMessage.Text = "";
        lblCreated.Text = "";
    }// end reset

    /// <summary>
    /// Redirect to PrintNewGiftCard.aspx web form
    /// </summary>  
    protected void ImBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["newGiftCard"] != null)
        {
            if (txtDiningRoom.Text.CompareTo("")!=0)
            {
                Response.Redirect("PrintNewGiftCardDinning.aspx");                
            }
            else
            {
                Response.Redirect("PrintNewGiftCard.aspx");
            }
        }// end if
    }// ImBtnPrint_Click

    /// <summary>
    /// Redirect to MenuFrm.aspx web form
    /// </summary>    
    protected void ImBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }// end ImBtnBack_Click

    /// <summary>
    /// This method calls reset() and clear the screen
    /// </summary>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.reset();
    }// end btnCancel_Click

    /// <summary>
    /// This mathod set to visible Dinning Room, Table, and Seating if delivery type is Dinning room.
    /// </summary>
    protected void ddlDeliverTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDeliverTo.SelectedItem.Text == "Dinning room")
        {
            lvDiningRoom.Visible = true;
            txtDiningRoom.Visible = true;
            lblDiningRoom.Visible = true;

            lvSeating.Visible = true;
            txtSeating.Visible = true;
            lblSeating.Visible = true;

            lvTable.Visible = true;
            txtTable.Visible = true;
            lblTable.Visible = true;
        }

    }// end ddlDeliverTo_SelectedIndexChanged

    /// <summary>
    /// Set Dinning Room, Table and table to unvisible
    /// </summary>
    public void toUnvisible()
    {
        lvDiningRoom.Visible = false;
        txtDiningRoom.Visible = false;
        lblDiningRoom.Visible = false;

        lvSeating.Visible = false;
        txtSeating.Visible = false;
        lblSeating.Visible = false;

        lvTable.Visible = false;
        txtTable.Visible = false;
        lblTable.Visible = false;
    }// end toUnvisible
    protected void btnClearScreen_Click(object sender, EventArgs e)
    {
        this.reset();
    }//end btnClearScreen
}// end class