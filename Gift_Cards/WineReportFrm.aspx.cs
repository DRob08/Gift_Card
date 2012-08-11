using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WineReportFrm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {  //create object from report
        PrintReports report = new PrintReports();
        //create a list from wine report
        List<GiftCard> wine = report.WineCards();
        //check if list is empty
        if (wine.Count == 0)
        { //display a message to user and hide the reportviewer
            lblMessage.Visible = true;
            ReportViewer1.Visible = false;
        }
        else
        {   //hide message and show report
            lblMessage.Visible = false;
            ReportViewer1.Visible = true;
        }
    }
}