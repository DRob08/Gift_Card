﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="WineReportFrm" Codebehind="WineReportFrm.aspx.cs" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    <div align="center" >
        <asp:Label ID="lblMessage" runat="server" Text="No Record Found!" 
            Font-Bold="True" Font-Size="Large"></asp:Label>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="60%" 
            Font-Names="Verdana" Font-Size="8pt" Height="800px" 
            InteractiveDeviceInfos="(Collection)" style="margin-left: 0px" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" 
            PageCountMode="Actual">
        <LocalReport ReportPath="WineReport.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    </div>
    <br />
    
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="WineCards" TypeName="PrintReports"></asp:ObjectDataSource>
    
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" Runat="Server">
RCCL 2012
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" Runat="Server">
</asp:Content>

