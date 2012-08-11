<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="ReviewGiftcardFrm" Codebehind="ReviewGiftcardFrm.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
        table.table1
          {
          
          height:100px;
          width:35%;
          
           border-top:1px solid #003366;
           border-left:1px solid #003366;
           border-right:1px solid #003366;
          background-color: #EFF3FB;
         
         
          }
          table.tablemiddle
          {
            
           padding:15px;
           width:35%;
           border-top:1px solid #003366;
           border-left:1px solid #003366;
           border-right:1px solid #003366;
           background-color:#EFF3FB;
          
          }
          table.buttons
          {
           padding:15px;
           width:35%;
             border-bottom:1px solid #003366;
           border-left:1px solid #003366;
           border-right:1px solid #003366;
           background-color: #EFF3FB;
          }
        .style1
        {
            height: 30px;
            width: 98px;
        }
        .style2
        {
            height: 30px;
            width: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
   
    <form id="form1" runat="server">
    <%--<table style = "margin:0 auto" class="table1">
            <tr>
                <td  align = "center">
                   <b><font face="Georgia, Arial, Garamond" size="6" color="#dea82a"  > 
                    Review Gift Cards</font></b></td>
                
            </tr>
            </table>--%>
            <div align="center">
            <b><font face="Georgia, Arial, Garamond" size="6" color="#dea82a"  > 
                    Review Gift Cards</font></b></div>
            <table style = "margin:0 auto"  class="tablemiddle" >
        <tr>
            <td align="right" >
                <asp:Label ID="lblVoyage" runat="server" Text="Voyage" BorderStyle="None" 
                    Font-Bold="False" ForeColor="#666666"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtVoyage" runat="server" ReadOnly="True" Width="79px"></asp:TextBox>
            </td>
            <td class="style1" >

                </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="lblSailingDate" runat="server" Text="Sailing Date" 
                    Font-Bold="False" ForeColor="#666666"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtSailingDate" runat="server" ReadOnly="True" Width="226px"></asp:TextBox>
            </td>
            <td class="style1" >
            </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="lblFirstPaxCabin" runat="server" Text="1st Pax in Cabin" 
                    Font-Bold="False" ForeColor="#666666"></asp:Label>

            </td>
            <td >
                <asp:TextBox ID="txtFirstName" runat="server" Width="226px" ReadOnly="True"></asp:TextBox>
            </td>
            <td  align="center" class="style1">
                </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="lblStateroom" runat="server" Text="StateRoom" Font-Bold="False" 
                    ForeColor="#666666"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtStRoom" runat="server" Width="69px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style1" >
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="lblDeliveryDate" runat="server" Text="Delivery Date" 
                    Font-Bold="False" ForeColor="#666666"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtDeliveryDate" runat="server" Width="227px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style1" >
                </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="lblAmenity" runat="server" Text="Amenity" Font-Bold="False" 
                    ForeColor="#666666"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtAmenity" runat="server" Width="225px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style1" >
               </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="lblQuantity" runat="server" Text="Quantity" Font-Bold="False" 
                    ForeColor="#666666"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtQuantity" runat="server" Width="63px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style1" >
                </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="lblCompliments" runat="server" Text="Compliments" 
                    Font-Bold="False" ForeColor="#666666"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtComp" runat="server" Width="266px" Height="36px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
           <td class="style1" >
                </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="lblMessage" runat="server" Text="Message" Font-Bold="False" 
                    ForeColor="#666666"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtMessage" runat="server" Height="36px" Width="265px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style1" >
                </td>
        </tr>
    </table>

    <table style = "margin:0 auto" class="buttons">
            <tr>
                <td  align="center">
                    <asp:ImageButton ID="imgBtnReturn" runat="server" Height="32px" 
                        ImageUrl="~/images/returns-icon.jpg" Width="40px" onclick="imgBtnReturn_Click" 
                         />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="All Gift Cards" Font-Bold="False" 
                        ForeColor="#666666"></asp:Label>
                    <br />
                    </td>
                <td  align="center" class="style2">
                    <asp:ImageButton ID="imgBtnPrev0" runat="server" Height="32px" 
                        ImageUrl="~/images/Button Previous-01.png" onclick="imgBtnPrev0_Click" Width="36px"  
                         />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnNext" runat="server" Height="32px" 
                        ImageUrl="~/images/Button Next-01.png" onclick="imgBtnNext_Click" 
                        Width="36px"   />
                    <br />
                    <asp:Label ID="Prev0" runat="server" Text="Prev" Font-Bold="False" 
                        ForeColor="#666666"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Next" ForeColor="#666666" 
                        Font-Bold="False"></asp:Label>
                </td>
                <td align="center" style="height: 30px">
                    <asp:ImageButton ID="imgBtnPrint" runat="server" Height="34px" 
                        ImageUrl="~/images/print-printer.png"  
                        Width="44px"  style="margin-left: 0px" onclick="imgBtnPrint_Click"  />
                    <br />
                    <asp:Label ID="lblPrint" runat="server" Text="Print Current" ForeColor="#666666" 
                        Font-Bold="False"></asp:Label>
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

