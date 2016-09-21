<%@ Page Title="" Language="C#" MasterPageFile="~/BoostrapMain.Master" AutoEventWireup="true" CodeBehind="SummaryPage.aspx.cs" Inherits="GestioneChiamatePerse.SummaryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid theme-showcase" role="main">
        
        <div class="jumbotron">
            <h1>Riepilogo POST Avvenute con Successo</h1>
            <!--<p>This is a template showcasing the optional theme stylesheet included in Bootstrap. Use it as a starting point to create something more unique by building on or modifying it.</p>-->
        </div>

        <div class="page-header">
            <h1>Riepilogo Operazioni avvenute con successo</h1>
        </div>

        <div class="page-body">
            <div class="table-responsive" id="TableContainer" runat="server"></div>
        </div>

    </div>
    
</asp:Content>
