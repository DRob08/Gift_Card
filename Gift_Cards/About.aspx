<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="About" Codebehind="About.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
        table.tabhead
        {
            width:35%;
            background-color:#EFF3FB;
            border: 1px solid black;
        }
        
        table.tabAbout
        {
            
            width:35%;
             background-color:#EFF3FB;
             border: 1px solid black;
        }
       
        .style1
        {
            width: 203px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    
    <table class="tabhead"  style = "margin:0 auto">
        <tr>
            <td align="center" >
                <h3> <font face="Georgia, Arial, Garamond" size=5 color="#dea82a">Gift Card Printing</font></h3></td>
        </tr>
    </table>
    

    <table class="tabAbout"  style = "margin:0 auto">
        <tr>
            <td align="right" class="style1">
                <asp:Label ID="lblAuthor" runat="server" Text="Author:" Font-Bold="True" 
                    Font-Italic="True"></asp:Label>
            </td>
            <td class="style4">
                &nbsp;Darwin Robinson</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style1">
                <asp:Label ID="lblVersion" runat="server" Text="Version:" Font-Bold="True" 
                    Font-Italic="True"></asp:Label>
            </td>
            <td >
                &nbsp;<asp:Label ID="lblVer" runat="server" Text="4.0"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style1">
                <asp:Label ID="lblUpdated" runat="server" Text="Last Updated:" Font-Bold="True" 
                    Font-Italic="True"></asp:Label>
            </td>
            <td>
                &nbsp;<asp:Label ID="lblUp" runat="server" Text="Tuesday, July 24, 2012"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style1">
                <asp:Label ID="lblOwned" runat="server" Text="Owned by:" Font-Bold="True" 
                    Font-Italic="True"></asp:Label>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style1">
                <asp:Label ID="lblCertify" runat="server" Text="Certified by:" Font-Bold="True" 
                    Font-Italic="True"></asp:Label>
            </td>
            <td class="style4">
                &nbsp;<asp:Label ID="lblCerDes" runat="server" Text=""></asp:Label>
            </td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style1">
                <asp:Label ID="lblOn" runat="server" Text="Certified on:" Font-Bold="True" 
                    Font-Italic="True"></asp:Label>
            </td>
            <td>
                &nbsp;<asp:Label ID="lblCerOnDes" runat="server" Text=""></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    

    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" Runat="Server">
RCCL 2012
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" Runat="Server">
</asp:Content>

