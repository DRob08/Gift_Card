using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Types : System.Web.UI.Page
{
    private List<Type> _type;    
    public List<Type> Typess
    {
        get
        {
            if (_type == null) { _type = new List<Type>(); }
            return _type;
        }
        set
        {
            if (_type != value) { _type = value; }
        }
    }// end List<String>    
    protected void Page_Load(object sender, EventArgs e)
    {
        Typess = UtilityClass.TypeDeserializeFromXML();
        this.GridView1.Attributes.Add("bordercolor", "Black");
        if (!IsPostBack)
        {
            this.FillGrid();            
        }
    }

    public void FillGrid()
    {
        // if the list has record
        if (this._type.Count() != 0)
        {
            GridView1.DataSource = this._type;
            GridView1.DataBind();
        }
        else // if the list is empty
        {
            Typess.Add(new Type());
            GridView1.DataSource = this._type;
            GridView1.DataBind();

            int TotalColumns = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            GridView1.Rows[0].Cells[0].Text = "No Record Found";
        }// end else

    }// end FillGrid
  
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this._type.RemoveAt(e.RowIndex); // remove the type from the list
        UtilityClass.TypeSerializeToXML(this._type);       
        // refresh the grild view
        GridView1.DataSourceID = null;
        GridView1.DataSource = this._type;
        GridView1.DataBind();

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // UtilityClass.getAmenities(Amenities);

        int index = GridView1.EditIndex;
        GridViewRow row = GridView1.Rows[index];

        TextBox type = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txttype");
        this.Typess[index].type= type.Text.Trim();       

        // Sort the amenity list
        this._type = Typess.OrderBy((a) => a.type).ToList();
        //Update the TYPE.xml file 
        UtilityClass.TypeSerializeToXML(this._type);

        GridView1.EditIndex = -1; // close the row
        GridView1.DataSourceID = null;
        GridView1.DataSource = this._type;
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.FillGrid();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.FillGrid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.FillGrid();
    }
    protected void lkbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NewAmenity.aspx");
    }
}