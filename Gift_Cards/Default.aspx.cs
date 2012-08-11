using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// this button will redirect the user to the Wine Report form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrintWine_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/WineReportFrm.aspx");
    }
    /// <summary>
    /// this button will redirect the user to the All Giftcards form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReviewSelect_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AllGiftcardsFrm.aspx");
    }
    /// <summary>
    /// this function close web form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExit_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }
    protected void btnPrintHouseKeep_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HouseKeepingFrm.aspx");
    }
    protected void btnCreateOwnCard_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OwnGiftCard.aspx");
    }

    protected void btnMaintain_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NewAmenity.aspx");

    }
}