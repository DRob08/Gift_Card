<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="NewAmenity" Codebehind="NewAmenity.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
 table.table1
{
    border-collapse:collapse;
    padding:15px;
    width:100%;           
}

table.table2
{
    border-collapse:collapse;
    padding:15px;
    width:100%;         
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    <h2 align="center" 
        style="font-family: Arial, Helvetica, sans-serif; color: #dea82a"> Maintain Amenities </h2>        
       <%--Panel for create new amenity--%>

        <asp:Panel ID="PanelAmenity" runat="server" BackColor="#EFF3FB" BorderColor="#003366" BorderStyle="Solid"> 
        <table bgcolor="#EFF3FB" width="100%">
            <tr>
                <td align="center">
                    &nbsp;<asp:Label ID="lblACreated" runat="server" Font-Size="Medium" 
                        ForeColor="#000066" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>               
        <table > 
            <tr>
                <td align="right">
                    <asp:Label ID="LalAmenity" runat="server" Text="Amenity:" ForeColor="#666666"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAmenity" runat="server" Width="289px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblAmenityMessage" runat="server" ForeColor="#CC3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LblType" runat="server" Text="Type:" ForeColor="#666666"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" Height="23px" Width="294px">
                         <asp:ListItem Value="--- select item ---"> </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblTypeMessage" runat="server" ForeColor="#CC3300"></asp:Label>  
                </td>
            </tr>

           </table>
          <%-- table for submit bottons--%>
          <table>
            <tr>
                <td>
                    <asp:Button ID="btnSubmitAmenity" runat="server" Text="Submit" 
                            Width="80px" onclick="btnSubmitAmenity_Click" />
                </td>                
                <td>
                    <asp:Button ID="btnCancelAmenity" runat="server" 
                        onclick="btnCancelAmenity_Click" Text="Cancel" Width="80px" />
                 </td>
                 <td>
                     <asp:Button ID="btnAClearScreen" runat="server" Text="Clear Screen" 
                         onclick="btnAClearScreen_Click" Width="90px" />
                 </td>    
                 <td>
                    <asp:LinkButton ID="LBAddNewType" runat="server" ForeColor="#CC0000" 
                        onclick="LBAddNewType_Click">+add new type.</asp:LinkButton>
                </td>                
            </tr>
        </table>
        </asp:Panel>
        <br/>
        <%-- Panel to create new type--%>
        <asp:Panel ID="PanelNewType" runat="server" BackColor="#EFF3FB" BorderColor="#003366" BorderStyle="Solid"> 
        <table bgcolor="#EFF3FB" width="100%">
            <tr>
                <td align="center">
                    &nbsp;<asp:Label ID="lblTCreated" runat="server" Font-Size="Medium" 
                        ForeColor="#000066" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>   
        <table bgcolor="#EFF3FB">
            <tr>
                <td align="right">
                    <asp:Label ID="lblNewType" runat="server" Text="New Type:" ForeColor="#666666"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNewType" runat="server" style="margin-left: 1px" Width="294px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblNewTypeMessage" runat="server" ForeColor="#CC3300"></asp:Label>
                </td>
            </tr>

            </table>
          <%--table for submit bottons--%>
          <table>
            <tr>
                <td>
                     <asp:Button ID="btnSubmitType" runat="server" Text="Submit" Width="80px" 
                         onclick="btnSubmitType_Click" />
                </td>                
                <td>
                    <asp:Button ID="btnbtnCancelType" runat="server" Text="Cancel" Width="80px" 
                        onclick="btnCancelType_Click" />
                </td>
                <td>
                    <asp:Button ID="btnTClearScreen" runat="server" Text="Clear Screen" 
                        onclick="btnTClearScreen_Click" Width="90px" />
                </td>
                <td>
                     <asp:LinkButton ID="btnUpdateType" runat="server" ForeColor="#CC0000" onclick="btnUpdateType_Click" 
                        >+edit type</asp:LinkButton>
                </td>
                <td>                 
                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#CC0000" 
                        onclick="LinkButton1_Click">-close</asp:LinkButton>
                </td>    

            </tr>
        </table> 
        </asp:Panel> 
        <br/>  
        <%-- grilg view for amenity   --%> 
          <asp:GridView ID="GridView1" 
        style = "margin:0 auto" AutoGenerateColumns="False"
             runat="server" onrowdeleting="GridView1_RowDeleting" CellPadding="4" ForeColor="#333333" 
             GridLines="Both" onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdatabound="GridView1_RowDataBound" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" Width="833px" >

              <AlternatingRowStyle BackColor="White" />

             <Columns>
               
                <asp:TemplateField HeaderText="Amenity" HeaderStyle-HorizontalAlign="Left"> 
                    
                     <ItemTemplate> 
                        <asp:Label ID="lblamenity" runat="server" Text='<%# Bind("amenity") %>'></asp:Label> 
                   </ItemTemplate>
                    
                    <EditItemTemplate> 
                        <asp:TextBox ID="txtamenity" runat="server" width="350px" Text='<%# Bind("amenity") %>'></asp:TextBox> 
                    </EditItemTemplate> 
                   
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                   
                </asp:TemplateField>  
                
                 <asp:TemplateField HeaderText="Type" HeaderStyle-HorizontalAlign="Left"> 
                    
                    <ItemTemplate> 
                        <asp:Label ID="lbltype" runat="server" Text='<%# Bind("type") %>'></asp:Label> 
                    </ItemTemplate>                   
                   
                    <EditItemTemplate> 
                        <asp:Label ID="lbltype" runat="server" Text='<%# Bind("type") %>' Visible="false" ></asp:Label> 
                        <asp:DropDownList ID = "ddltype" runat = "server" width="200px">
                        </asp:DropDownList>
                    </EditItemTemplate>                    

              <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 </asp:TemplateField>  
                 <asp:CommandField ShowEditButton="True"/>               

                <%--This is for deleting confirmation messager--%>
                <asp:TemplateField> 
                        <ItemTemplate> 
                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" Text="Delete"               
                            OnClientClick="javascript:return confirm('Are you sure you want to Remove this Record!');"> 
                            </asp:LinkButton>        
                         </ItemTemplate>   
                </asp:TemplateField>
               
            </Columns>
              <EditRowStyle BackColor="#2461BF" />
              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#EFF3FB" />
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             
          </asp:GridView>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" Runat="Server">
    RCCL 2012
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" Runat="Server">
</asp:Content>

