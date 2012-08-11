<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="OwnGiftCard" Codebehind="OwnGiftCard.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 108px;
        }
    </style>

    <%--for datetimepeaker--%>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        });
	</script>

    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <%-- end fro datetimepeaker--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    <h2 align="center" style="font-family: Arial, Helvetica, sans-serif; color: #dea82a">Create Own Gift Card</h2>
   
   <asp:Panel ID="Panel1" runat="server" BackColor="#EFF3FB" BorderColor="#003366" BorderStyle="Solid">
   <br/>
   <table bgcolor="#EFF3FB" width="100%">
        <tr>
        <td align="center">
            &nbsp;<asp:Label ID="lblCreated" runat="server" Font-Size="Medium" 
                ForeColor="#000066" Font-Bold="True"></asp:Label>
        </td>
        </tr>
    </table>
    <table bgcolor="#EFF3FB" width="100%">
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lvoyage" runat="server" ForeColor="#666666" Text="Voyage:"></asp:Label>
                &nbsp;</td>
            <td class="style4">
                <asp:TextBox ID="txtVoyage" runat="server" Width="190px" ReadOnly="True"></asp:TextBox>                
            &nbsp;
                <asp:Label ID="lblVoyage"  runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lvSailingDate" runat="server" ForeColor="#666666" 
                    Text="Sailing Date:"></asp:Label>
            </td>
            <td class="style4">
           
                <asp:TextBox ID="txtSilingDate"  runat="server" 
                    Width="190px" ReadOnly="True"></asp:TextBox>                
            &nbsp;
                <asp:Label ID="lblSailingDate"  runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lvDeliveryDate" runat="server" ForeColor="#666666" 
                    Text="Delivery Date:"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtDeliveryDate" CssClass="datepicker" runat="server" Width="191px"></asp:TextBox>                
            &nbsp;
                <asp:Label ID="lblDeliveryDate" runat="server" ForeColor="Red" Width="190px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lvStateroom" runat="server" ForeColor="#666666" 
                    Text="Stateroom:"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtStateroom" runat="server" Width="190px"></asp:TextBox>
            &nbsp;
                <asp:Label ID="lblStateroom" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lvAmenity" runat="server" ForeColor="#666666" Text="Amenity:"></asp:Label>
            </td>
            <td class="style4">
                <asp:DropDownList ID="ddlAmenity" runat="server" Width="304px">
                <asp:ListItem Value="--- select item ---"> </asp:ListItem>
                </asp:DropDownList>                
            &nbsp;         
                <asp:Label ID="lblAmenity" runat="server" ForeColor="Red"></asp:Label>
            </td>            
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lvQuantity" runat="server" ForeColor="#666666" Text="Quantity:"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtQuantity" runat="server" Width="114px"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:Label ID="lblQuantity" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lvDeliveryTo" runat="server" ForeColor="#666666" 
                    Text="Deliver to:"></asp:Label>
            </td>
            <td class="style4">
                <asp:DropDownList ID="ddlDeliverTo" runat="server" Width="217px" clear="true" 
                    AutoPostBack="True" onselectedindexchanged="ddlDeliverTo_SelectedIndexChanged">
                <asp:ListItem Value="--- select item ---"> </asp:ListItem>
                </asp:DropDownList> 
            &nbsp;
                <asp:Label ID="lblDelivery" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lvDiningRoom" runat="server" ForeColor="#666666" 
                    Text="Dining Room:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDiningRoom" runat="server" Width="56px"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lblDiningRoom" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;
                <asp:Label ID="lvSeating" runat="server" ForeColor="#666666" Text="Seating:"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtSeating" runat="server" Width="52px"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lblSeating" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;
                <asp:Label ID="lvTable" runat="server" ForeColor="#666666" Text="Table:"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtTable" runat="server" Width="53px"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lblTable" runat="server" ForeColor="Red"></asp:Label>
            </td>            
        </tr>        
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lvCompliments" runat="server" ForeColor="#666666" 
                    Text="Compliments:"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtCompliments" runat="server" Height="25px" Width="280px"></asp:TextBox>
            &nbsp;
                <asp:Label ID="lblCompliments" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lvMessage" runat="server" ForeColor="#666666" Text="Message:"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtMessage" runat="server" Width="287px" Height="25px"></asp:TextBox>
            &nbsp;
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>            
        </tr>             
    </table>
    <table > <%--Table to put the bottoms--%>
        <tr>
            <td class="style8">
                <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                    Text="Submit" />
             </td>
            <td class="style5">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" />&nbsp;
            </td>
            <td > &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp
                <asp:ImageButton ID="ImBtnPrint" runat="server" Width="35px" 
                    ImageUrl="~/images/print-printer.png" 
                    onclick="ImBtnPrint_Click"/>&nbsp; 
             </td>
             <td>

                 <asp:Label ID="Label1" runat="server" Text="Print" ForeColor="#666666"></asp:Label>

             </td>
             <td>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearScreen" runat="server" onclick="btnClearScreen_Click" 
                     Text="Clear Screen" Width="108px" />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>         
    </table>    
   </asp:Panel>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" Runat="Server">
    RCCL 2012
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" Runat="Server">
</asp:Content>

