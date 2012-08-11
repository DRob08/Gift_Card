using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.ComponentModel;

public partial class AllGiftcardsFrm : System.Web.UI.Page
{
    List<GiftCard> allGiftcards;            //list that will hold all giftcards
    /// <summary>
    /// initialize and set values to list
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
        }//end if
        set
        {
            if (allGiftcards != value)
            {
                allGiftcards = value;
            }//end if
        }//end set
    }// end List<GiftCard> cards
    /// <summary>
    /// when page loads read file fill the list and display data in gridview
    /// retrieve voyage number and saildate and display it on labels
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        UtilityClass.getDataCards(Cards);
        this.FillGrid();
        //dynamically add border color to gridview
        Gift_Cards.VoyageService.VoyageView ship = UtilityClass.TryGetShipInfo(lblMessage);
        if (ship != null)
        {
            lblVnumber.Text = ship.voyageNumber.ToString();
            lblSdate.Text = String.Format("{0:MM/dd/yyyy}", ship.startDate);
        }
        this.gvdAllgifts.Attributes.Add("bordercolor", "Black");
        
        
    }//end page load

    /// <summary>
    /// this method fill the gril view with amenities
    /// </summary>
    public void FillGrid()
    {
        // if the list has record
        if (this.Cards.Count() != 0)
        {
            gvdAllgifts.DataSource = this.Cards;
            gvdAllgifts.DataBind();
        }
        else // if the list is empty
        {
            Cards.Add(new GiftCard());
            gvdAllgifts.DataSource = this.Cards;
            gvdAllgifts.DataBind();

            int TotalColumns = gvdAllgifts.Rows[0].Cells.Count;
            gvdAllgifts.Rows[0].Cells.Clear();
            gvdAllgifts.Rows[0].Cells.Add(new TableCell());
            gvdAllgifts.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvdAllgifts.Rows[0].Cells[0].Text = "No Record Found";
        }// end else

    }// end FillGrid  
    /// <summary>
    /// Function display pop up message box to inform the user
    /// </summary>
    /// <param name="page">page where message is going to be displayed</param>
    /// <param name="message">message to be displayed on box</param>
    private void MessageBoxShow(Page page, string message)
    {
        Literal ltr = new Literal();
        ltr.Text = @"<script type='text/javascript'> alert('" + message + "') </script>";
        page.Controls.Add(ltr);
    }//end Message
    /// <summary>
    /// function retrieves and set direction for gridview to be sorted
    /// </summary>
    public SortDirection dir
    {
        get
        {
            if (ViewState["dirState"] == null)
            {
                ViewState["dirState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["dirState"];
        }//end get
        set
        {
            ViewState["dirState"] = value;
        }//end set
    }//end dir function

    /// <summary>
    /// creates a datatable from a list
    /// </summary>
    /// <param name="data">list to converted to datatabale</param>
    /// <returns></returns>
    public DataTable ToDataTable(List<GiftCard> data)
    {
        PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(GiftCard));
        DataTable table = new DataTable();
        for (int i = 0; i < props.Count; i++)
        {
            PropertyDescriptor prop = props[i];
            table.Columns.Add(prop.Name, prop.PropertyType);
        }//end for loop
        object[] values = new object[props.Count];
        foreach (GiftCard item in data)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = props[i].GetValue(item);
            }//end for loop
            table.Rows.Add(values);
        }//end for each
        return table;
    }//to datatable function

    /// <summary>
    /// gridview sorting event that allows the data to be sorted
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvdAllgifts_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortingDirection = string.Empty;
        if (dir == SortDirection.Ascending)
        {
            dir = SortDirection.Descending;
            sortingDirection = "Desc";
        }//end if
        else
        {
            dir = SortDirection.Ascending;
            sortingDirection = "Asc";
        }//end else

        DataTable d = ToDataTable(Cards);
        DataView sortedView = new DataView(d);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        gvdAllgifts.DataSource = sortedView;
        gvdAllgifts.DataBind();
    }//end gridview sorting

    /// <summary>
    /// when button clicked goes through big list find all occurrences that
    /// match and creates a new list which will be send to next form through session variable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        if (!string.IsNullOrEmpty(txtCabinSearch.Text))
        {     
            //find all ocurrences in the big list
            if (Cards[0].Cabin == null) { MessageBoxShow(this, "No Record Found"); return; }
            
                var stRoom = Cards.FindAll((ca) => ca.Cabin.Equals(txtCabinSearch.Text.ToString()));
            

            //if the list has at least one element
            if (stRoom.Count > 0)
            {
                //save into session variable
                Session["stroomatches"] = stRoom;
                
                //and go to Reviw Giftcard form
                Response.Redirect("~/ReviewGiftcardFrm.aspx");

            }//end if
            MessageBoxShow(this, "No Record Found");

        }//end if
        else
        {
            MessageBoxShow(this, "Please Enter a Stateroom Number");
        }//end else
    }//button search click
}