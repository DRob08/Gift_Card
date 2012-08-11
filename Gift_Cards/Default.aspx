<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Default" Codebehind="Default.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">

    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
          
          
      
   

    <form id="form1" runat="server">
      
    <table style = "margin:0 auto"   class="table1">
        <tr>
            <td align="center" class="style2">
                
                </td>
            <td align="center" class="style2" >
                
               <b ><font face="Georgia, Arial, Garamond" size="6" 
                    color="#dea82a"  >Gift Card Menu</font></b></td>
            <td align="center" class="style2" >
                
                </td>
        </tr>
        <tr>
            <td align="center" >
                
                </td>
            <td align="center" >
                
                <asp:Button ID="btnReviewSelect" runat="server" 
                    Text="Review/Select Cards for Reprinting" Width="239px" 
                    onclick="btnReviewSelect_Click" Font-Bold="True" 
                   />
            </td>
            <td align="center" >
                
                </td>
        </tr>
        <tr>
            <td align="center" >
                
                </td>
            <td align="center" >
                
                <asp:Button ID="btnPrintWine" runat="server" 
                    Text="Print Wine Stewards Gift Cards" Width="239px" 
                    onclick="btnPrintWine_Click" Font-Bold="True" 
                    />
            </td>
            <td align="center" >
                
                </td>
        </tr>
        <tr>
            <td align="center" >
                
                &nbsp;</td>
            <td align="center" >
                
                <asp:Button ID="btnPrintHouseKeep" runat="server" 
                    Text="Print Housekeeping Gift Cards" Width="239px" 
                    onclick="btnPrintHouseKeep_Click" Font-Bold="True" 
                   />
            </td>
            <td align="center" >
                
                </td>
        </tr>
        <tr>
            <td align="center" >
                
                </td>
            <td align="center" >
                
                <asp:Button ID="btnCreateOwnCard" runat="server" 
                    Text="Create Your Own Gift Card" Width="239px" 
                    onclick="btnCreateOwnCard_Click" Font-Bold="True" />
            </td>
            <td align="center" >
                
                </td>
        </tr>
        <tr>
            <td align="center" >
                
                &nbsp;</td>
            <td align="center" >
                
                <asp:Button ID="btnMaintain" runat="server" onclick="btnMaintain_Click" 
                    Text="Maintain Amenities" Width="239px" Font-Bold="True" />
            </td>
            <td align="center" >
                
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" >
                
                </td>
            <td align="center" >
                
                <asp:Button ID="btnExit" runat="server" Text="Exit" Width="239px" 
                    onclick="btnExit_Click" Font-Bold="True" 
                     />
                

                </td>
            <td align="center">
                
                </td>
        </tr>
    </table>

 
  </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" Runat="Server">
    RCCL 2012
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" Runat="Server">
</asp:Content>

