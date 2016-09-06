<%@ Page Title="" Language="C#" MasterPageFile="~/BoostrapMain.Master" AutoEventWireup="true" CodeBehind="PostPage.aspx.cs" Inherits="GestioneChiamatePerse.PostPage" EnableEventValidation="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid theme-showcase" role="main">
        
        <div class="jumbotron">
            <h1>Simulazione POST remota</h1>
            <!--<p>This is a template showcasing the optional theme stylesheet included in Bootstrap. Use it as a starting point to create something more unique by building on or modifying it.</p>-->
        </div>

        <div class="page-header">
            <h1>Form di Simulazione</h1>
        </div>

        <form method="post" action="~/ReceiverPage.aspx">
            <fieldset>

        <div class="page-body">

            <div class="row">
                <div class="col-xl-6 col-lg-6 col-md-6">
                    <div class="form-group">
                        <label for="ExtIDChiamata">ID Chiamata</label>
                        <input type="text" class="form-control" id="ExtIDChiamata" name="ExtIDChiamata" aria-describedby="ExtIDChiamataHelp" placeholder="ID di Chiamata">
                        <small id="ExtIDChiamataHelp" class="form-text text-muted">Inserire l'ID di chiamata del proprio DB.</small>
                    </div>
                    <div class="form-group">
                        <label for="NumeroChiamata">Numero di Telefono</label>
                        <input type="tel" class="form-control" id="NumeroChiamata" name="NumeroChiamata" aria-describedby="NumerochiamataHelp" placeholder="Telefono della Chiamata">
                        <small id="NumeroChiamataHelp" class="form-text text-muted">Inserire il numero di telefono della chiamata ricevuta.</small>
                    </div>
                    <div class="form-group">
                        <label for="NomeChiamata">Nome del Chiamante</label>
                        <input type="text" class="form-control" id="NomeChiamata" name="NomeChiamata" aria-describedby="NomeChiamataHelp" placeholder="Nome del Chiamante">
                        <small id="NomeChiamataHelp" class="form-text text-muted">Inserire il nome del chiamante.</small>
                    </div>
                    <div class="form-group">
                        <label for="CognomeChiamata">Cognome del Chiamante</label>
                        <input type="text" class="form-control" id="Cognomechiamata" name="CognomeChiamata" aria-describedby="CognomeChiamataHelp" placeholder="Cognome del Chiamante">
                        <small id="CognomeChiamataHelp" class="form-text text-muted">Inserire il cognome del chiamante.</small>
                    </div>
                    
                </div>

                <div class="col-xl-6 col-lg-6 col-md-6">
                    <div class="form-group">
                        <label for="DataOrachiamata">Data e Ora Chiamata</label>
                        <input type="datetime-local" class="form-control" id="DataOraChiamata" name="DataOraChiamata" aria-describedby="DataOraChiamataHelp" placeholder="Data e Ora Chiamata" />
                        <small id="DataOraChiamataHelp" class="form-text text-muted">Inserire data e ora della chiamata.</small>
                    </div>
                    <div class="form-group">
                        <label for="Motivochiamata">Motivo della Chiamata</label>
                        <input type="text" class="form-control" id="MotivoChiamata" name="MotivoChiamata" placeholder="Motivo Chiamata">
                    </div>
                    <div class="form-group">
                        <label for="InfoChiamata">Informazioni sulla Chiamata</label>
                        <input type="text" class="form-control" id="InfoChiamata" name="InfoChiamata" placeholder="Info Chiamata">
                        <!--<textarea style="resize: none" class="form-control" id="InfoChiamata" name="InfoChiamata" cols="30" rows="5"></textarea>-->
                    </div>
                </div>

            </div>
       
        </div>

        <div class="page-footer">
            <!-- <button type="submit" class="btn btn-primary">Invia</button> -->
            <!-- <button type="submit" class="btn btn-primary">Invia</button> -->
            <asp:Button PostBackUrl="~/ReceiverPage.aspx" class="btn btn-primary" OnClick="ExecutePost" Text="Invia" CssClass="btn btn-primary" runat="server"/>
        </div>

            </fieldset>                
        </form>

    </div>

    <!-- <div id="myDiv" runat="server"></div> -->
    
</asp:Content>
