using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class NewAmenity : System.Web.UI.Page
{
    private List<Amenity> _amenity;
    private List<Type> _type;

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

    public List<Type> Types
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
    {   //Get the amenities from xml   
        Amenities = UtilityClass.AmenityDeserializeFromXML();
        //Get the types from xml
        Types = UtilityClass.TypeDeserializeFromXML();
        //load dropdownlist
        this.loadTypeNewAmenity();        
        this.GridView1.Attributes.Add("bordercolor", "Black");        
        if (!IsPostBack)
        {   
            this.FillGrid();
            PanelNewType.Visible = false;
        }
    }// end Page_Load
    
    protected void btnSubmitAmenity_Click(object sender, EventArgs e)
    {
        // imput validation
        Boolean Amenity = UtilityClass.isValidText(txtAmenity, lblAmenityMessage, "*", "Insert leters or digits!");
        Boolean Type = UtilityClass.isValidText(ddlType, lblTypeMessage, "*");

        // if input is valid then create new amenity object
        if (Amenity && Type)
        {
            Amenity newBee = new Amenity();
            newBee.amenity = txtAmenity.Text.Trim();
            newBee.type = ddlType.Text.Trim();

            // check if the new amenity is in the list
            if (Amenities.Exists((t) => t.myEquals(newBee)))
            {
                lblAmenityMessage.Text = "amenity Exist in the list!";
                return;
            }// end if      

            this._amenity.Add(newBee);
            lblACreated.Text = "Amenity succesfully created!";
            // Sort the amenity list
            this._amenity = Amenities.OrderBy((a) => a.amenity).ToList();
           
            
            //overwrite xml file
            UtilityClass.AmenitySerializeToXML(_amenity);
            // refresh the grild view
            GridView1.DataSourceID = null;
            GridView1.DataSource = this._amenity;
            GridView1.DataBind();

        }// end  if(amenity && type)
    }// end btnSubmitAmenity_Click

    protected void btnSubmitType_Click(object sender, EventArgs e)
    {
        
        Boolean Type = UtilityClass.isValidText(txtNewType, lblNewTypeMessage, "*", "Insert leters or digits!");

        // if input is valid then create new type object
        if (Type)
        {
            Type newBee = new Type();
            newBee.type = txtNewType.Text.Trim();

            // check if the new type is in the list
            if (Types.Exists((t) => t.myEquals(newBee)))
            {
                lblNewTypeMessage.Text = "Type Exist in the list!";
                return;
            }// end if    

            this._type.Add(newBee);
            lblTCreated.Text = "Type succesfully created!";
            // Sort the list
            this._type = Types.OrderBy((t) => t.type).ToList();
            // Update the TYPE.TXT file
            UtilityClass.TypeSerializeToXML(this._type);
            
            // Add the new type to the type dropdownlist
            ddlType.Items.Add(newBee.type);

      
        }// end  if(amenity && type)
    }// end btnSubmitType_Click
   
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    { 
        this._amenity.RemoveAt(e.RowIndex); // remove the amenity from the list
        //UtilityClass.overrideAmenityFile(this._amenity);// update AMENITY.TXT 
        //overwrite xml file
        UtilityClass.AmenitySerializeToXML(_amenity);
        // refresh the grild view
        GridView1.DataSourceID = null;
        GridView1.DataSource = this._amenity;
        GridView1.DataBind();

    }// end GridView1_RowDeleting

    // Helpers methods *********************************************************

    /// <summary>
    /// this method load the types to the DropdowList that creates the new amenity
    /// </summary> 
    protected void loadTypeNewAmenity()
    {        
        if (ddlType.Items.Count == 1)
        {
            foreach (Type type in this.Types)
                ddlType.Items.Add(type.type);
        }
    }// end loadTypeNewAmenity

    /// <summary>
    /// this method fill the gril view with amenities
    /// </summary>
    public void FillGrid()
    {        
        // if the list has record
        if (this._amenity.Count() != 0)
        {
            GridView1.DataSource = this._amenity;
            GridView1.DataBind();
        }
        else // if the list is empty
        {
            Amenities.Add(new Amenity());
            GridView1.DataSource = this._amenity;
            GridView1.DataBind();

            int TotalColumns = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            GridView1.Rows[0].Cells[0].Text = "No Record Found";
        }// end else

    }// end FillGrid  

    /// <summary>
    /// this method clears all the texbox and label on the screen 
    /// </summary>
    public void resetNewAmenity()
    {
        txtAmenity.Text = "";
        lblAmenityMessage.Text = "";
        ddlType.Text = "--- select item ---";
        lblTypeMessage.Text = "";
        lblACreated.Text = "";      
    }// end resetNewAmenity

    public void resetNewType()
    {
        txtNewType.Text = "";
        lblNewTypeMessage.Text = "";
        lblTCreated.Text = "";
    }// end resetNewAmenity

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       // UtilityClass.getAmenities(Amenities);

        int index = GridView1.EditIndex;
        GridViewRow row = GridView1.Rows[index];

        TextBox amenity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtamenity");
        DropDownList type = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddltype");

        this.Amenities[index].amenity = amenity.Text.Trim();
        this.Amenities[index].type = type.Text.Trim();

        // Sort the amenity list
        this._amenity = Amenities.OrderBy((a) => a.amenity).ToList();
       
        //overwrite xml file
        UtilityClass.AmenitySerializeToXML(_amenity);

        GridView1.EditIndex = -1; // close the row
        GridView1.DataSourceID = null;
        GridView1.DataSource = this._amenity;
        GridView1.DataBind();
    }// GridView1_RowUpdating

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.FillGrid();
    }// end GridView1_RowEditing

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
        {
            DropDownList ddlType = (DropDownList)e.Row.FindControl("ddltype");           
            ddlType.DataSource = this._type;
            ddlType.DataTextField = "type";
            ddlType.DataValueField = "type";
            ddlType.DataBind();
            ddlType.Items.FindByValue((e.Row.FindControl("lbltype") as Label).Text).Selected = true;  
        }// end if       


    }// end GridView1_RowDataBound

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.FillGrid();
    }// end GridView1_RowCancelingEdit

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.FillGrid();
    }// end GridView1_SelectedIndexChanged

    /// <summary>
    /// Open PanelNewType
    /// </summary>
    protected void LBAddNewType_Click(object sender, EventArgs e)
    {
        PanelNewType.Visible = true;
    }// end LBAddNewType_Click

    /// <summary>
    /// close panel PanelNewType
    /// </summary>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.resetNewType();
        PanelNewType.Visible = false;
    }// emd LinkButton1_Click

    /// <summary>
    /// Clear the screen.
    /// </summary>
    protected void btnCancelAmenity_Click(object sender, EventArgs e)
    {
        this.resetNewAmenity();        
    }// end btnCancelAmenity_Click

    /// <summary>
    /// Clear the screen
    /// </summary>
    protected void btnCancelType_Click(object sender, EventArgs e)
    {
        this.resetNewType();
    }// btnCancelType_Click

    protected void btnUpdateType_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Types.aspx");
    }
    protected void btnAClearScreen_Click(object sender, EventArgs e)
    {
        this.resetNewAmenity();
    }
    protected void btnTClearScreen_Click(object sender, EventArgs e)
    {
        this.resetNewType();
    }

}// end class