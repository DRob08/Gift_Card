<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="AllGiftcardsFrm" Codebehind="AllGiftcardsFrm.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 541px;
        }
        .style3
        {
            width: 541px;
            height: 36px;
        }
        .style4
        {
            height: 36px;
        }
        .style5
        {
            height: 36px;
            width: 219px;
        }
        .style6
        {
            width: 219px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    
    <table class="style1" >
        <tr>
            <td class="style3">
                <asp:TextBox ID="txtCabinSearch" runat="server" Width="96px" 
                    BorderColor="#000066"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Height="29px" 
                    Text="Search by Stateroom" Width="166px" onclick="btnSearch_Click" 
                    Font-Bold="True" />
            </td>
            <td align="left" class="style5">
                <asp:Label ID="lblMessage" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
            </td>
            <td align="left" class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblVoayge" runat="server" Text="Voyage #:" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="Black"></asp:Label>
            &nbsp;<asp:Label ID="lblVnumber" runat="server"></asp:Label>
            </td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblSail" runat="server" Text="Sail date:" Font-Bold="True" 
                    Font-Size="Medium"></asp:Label>
            &nbsp;<asp:Label ID="lblSdate" runat="server"></asp:Label>
            </td>
            <td align="left" class="style6">

                &nbsp;</td>
            <td align="left">

                &nbsp;</td>
        </tr>
    </table>
    <div align="center">
     <b ><font face="Georgia, Arial, Garamond" size="6" 
                    color="#dea82a"  >All Gift Cards</font></b>
    <asp:GridView ID="gvdAllgifts" runat="server" AutoGenerateColumns="false" 
        AllowSorting="True" onsorting="gvdAllgifts_Sorting">

      <Columns>
    <asp:BoundField DataField="firstPaxFirst" HeaderText="1st Pax First Name" 
                SortExpression="firstPaxFirst" />

                <asp:BoundField DataField="firstPaxLast" HeaderText="1st Pax Last Name" 
                SortExpression="firstPaxLast" />
                <asp:BoundField DataField="Cabin" HeaderText="Stateroom" 
                SortExpression="Cabin" />
                <asp:BoundField DataField="Deliverydate" HeaderText="Delivery Date" 
                SortExpression="Deliverydate" DataFormatString="{0:MM/dd/yyyy}"/>
                <asp:BoundField DataField="Amenity" HeaderText="Amenity" 
                SortExpression="Amenity" />
                <asp:BoundField DataField="Qty" HeaderText="Quantity" 
                SortExpression="Qty" />
                <asp:BoundField DataField="Compliments" HeaderText="Compliments" 
                SortExpression="Compliments" />
                <asp:BoundField DataField="Message" HeaderText="Message" 
                SortExpression="Message" />

    </Columns>
		<AlternatingRowStyle BackColor="White" />
		
		<EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="left" BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   
                <RowStyle HorizontalAlign="left" />
    </asp:GridView>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" Runat="Server">
    RCCL 2012
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" Runat="Server">
</asp:Content>

