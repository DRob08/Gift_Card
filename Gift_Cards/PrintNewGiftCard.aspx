<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="_Default" Codebehind="PrintNewGiftCard.aspx.cs" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    <div align="center">
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Medium" 
            ForeColor="Red" onclick="LinkButton1_Click">-back</asp:LinkButton>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="60%" 
        Height="604px">
        <LocalReport ReportPath="PrintNewGiftCard.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="printNewGiftCard" TypeName="PrintReports">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="list" SessionField="newGiftCard" 
                Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" Runat="Server">
RCCL 2012
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" Runat="Server">
</asp:Content>

