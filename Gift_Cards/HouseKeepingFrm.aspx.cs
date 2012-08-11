using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HouseKeepingFrm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   //create object from report class
        PrintReports house = new PrintReports();
        //create a list from house keeping giftcards
        List<GiftCard> houseGift = house.HouseKeepingCards();
        //check if is empty
        if (houseGift.Count == 0)
        {   //display message and hide report
            lblHouseMessage.Visible = true;
            ReportViewer1.Visible = false;
        }
        else
        {
            //hide label and show report
            lblHouseMessage.Visible = false;
            ReportViewer1.Visible = true;
        }
    }
}