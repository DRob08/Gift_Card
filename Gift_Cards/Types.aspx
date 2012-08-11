<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Types" Codebehind="Types.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    <table align="center">
        <tr>
            <td>
                <asp:LinkButton ID="lkbBack" runat="server" ForeColor="#CC0000" 
                    onclick="lkbBack_Click">-back</asp:LinkButton>
            </td>
        </tr>
    </table>
    <div align="center">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">

         <Columns>               
            <asp:TemplateField HeaderText="Type" HeaderStyle-HorizontalAlign="Left">                     
                    <ItemTemplate> 
                    <asp:Label ID="lbltype" runat="server" Text='<%# Bind("type") %>'></asp:Label> 
                    </ItemTemplate>                    
                    <EditItemTemplate> 
                    <asp:TextBox ID="txttype" runat="server" width="350px" Text='<%# Bind("type") %>'></asp:TextBox> 
                    </EditItemTemplate>                    
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>                   
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            
            <%--This is for deleting confirmation messager--%>
            <asp:TemplateField> 
                    <ItemTemplate> 
                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" Text="Delete"               
                        OnClientClick="javascript:return confirm('Are you sure you want to Remove this Record!');"> 
                        </asp:LinkButton>        
                     </ItemTemplate>   
            </asp:TemplateField>
             
        </Columns>

        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
       
    </asp:GridView>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" Runat="Server">
RCCL 2012
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" Runat="Server">
</asp:Content>

