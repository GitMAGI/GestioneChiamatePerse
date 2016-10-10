<%@ Page Title="" Language="C#" MasterPageFile="~/BoostrapMain.Master" AutoEventWireup="true" CodeBehind="PostPage.aspx.cs" Inherits="GestioneChiamatePerse.PostPage" EnableEventValidation="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function PostSender() {
            var url = "ReceiverPage.aspx";
            var jsonData = "";
            var jsonResp = "";

            var ExtIDChiamata = $("#ExtIDChiamata").val() != "" ? $("#ExtIDChiamata").val() : null;
            var NumeroChiamata = $("#NumeroChiamata").val() != "" ? $("#NumeroChiamata").val() : null;
            var NomeChiamata = $("#NomeChiamata").val() != "" ? $("#NomeChiamata").val() : null;
            var CognomeChiamata = $("#CognomeChiamata").val() != "" ? $("#CognomeChiamata").val() : null;
            var MotivoChiamata = $("#MotivoChiamata").val() != "" ? $("#MotivoChiamata").val() : null;
            var DataOraInizioChiamata = $("#DataOraInizioChiamata").val() != "" ? $("#DataOraInizioChiamata").val() : null;
            var DataOraFineChiamata = $("#DataOraFineChiamata").val() != "" ? $("#DataOraFineChiamata").val() : null;
            var Priorita = $("#PrioritaChiamata").find(":selected").val();
            var InfoChiamata = $("#InfoChiamata").val() != "" ? $("#InfoChiamata").val() : null;
            var IDExtSollecitoChiamata = $("#IDExtSollecitoChiamata").val() != "" ? $("#IDExtSollecitoChiamata").val() : null;
            var ExtIDOperatore = $("#ExtIDOperatore").val() != "" ? $("#ExtIDOperatore").val() : null;
            var Azienda = $("#Azienda").val() != "" ? $("#Azienda").val() : null;

            jsonData = [{
                ExtIDChiamata: ExtIDChiamata,
                NumeroChiamata: NumeroChiamata,
                NomeChiamata: NomeChiamata,
                CognomeChiamata: CognomeChiamata,
                MotivoChiamata: MotivoChiamata,
                DataOraInizioChiamata: DataOraInizioChiamata,
                DataOraFineChiamata: DataOraFineChiamata,
                Priorita: Priorita,
                InfoChiamata: InfoChiamata,
                IDExtSollecitoChiamata: IDExtSollecitoChiamata,
                ExtIDOperatore: ExtIDOperatore,
                Azienda: Azienda
            }];

            $.support.cors = true;

            console.log(jsonData);
            console.log(JSON.stringify(jsonData));

            $.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify(jsonData),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    console.log("Successo!");
                    //console.log(jsonData);
                    console.log(data);
                    alert(JSON.stringify(data) + "\n\nVisualizzare la console del browser per dettagli più leggibili!");
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log("Errore!");
                    console.log(jqXHR);
                    console.log(errorThrown);
                    console.log(textStatus);
                    alert(errorThrown);
                }

            });

            //console.log(jsonData);
            //console.log(jsonResp);            
        }
    </script>

    <div class="container-fluid theme-showcase" role="main">
        
        <div class="jumbotron">
            <h1>Simulazione POST remota</h1>
        </div>

        <div class="page-header">
            <h1>Form di Simulazione</h1>
        </div>

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
						<input type="text" class="form-control" id="CognomeChiamata" name="CognomeChiamata" aria-describedby="CognomeChiamataHelp" placeholder="Cognome del Chiamante">
						<small id="CognomeChiamataHelp" class="form-text text-muted">Inserire il cognome del chiamante.</small>
					</div>  
					<div class="form-group">
						<label for="Motivochiamata">Motivo della Chiamata</label>
						<input type="text" class="form-control" id="MotivoChiamata" name="MotivoChiamata" placeholder="Motivo Chiamata">
					</div>     
                    <div class="form-group">
						<label for="Azienda">Azienda</label>
						<input type="text" class="form-control" id="Azienda" name="Azienda" aria-describedby="AziendaHelp" placeholder="Azienda">
						<small id="AziendaHelp" class="form-text text-muted">Azienda</small>
					</div>               
				</div>

				<div class="col-xl-6 col-lg-6 col-md-6">
					<div class="form-group">
						<label for="DataOraInizioChiamata">Data e Ora Inizio Chiamata</label>
						<input type="datetime-local" class="form-control" id="DataOraInizioChiamata" name="DataOraInizioChiamata" aria-describedby="DataOraInizioChiamataHelp" placeholder="Data e Ora Inizio Chiamata" />
						<small id="DataOraInizioChiamataHelp" class="form-text text-muted">Inserire data e ora di Inizio chiamata.</small>
					</div>
					<div class="form-group">
						<label for="DataOraFineChiamata">Data e Ora Fine Chiamata</label>
						<input type="datetime-local" class="form-control" id="DataOraFineChiamata" name="DataOraFineChiamata" aria-describedby="DataOraFineChiamataHelp" placeholder="Data e Ora Fine Chiamata" />
						<small id="DataOraFineChiamataHelp" class="form-text text-muted">Inserire data e ora di Fine chiamata.</small>
					</div>
					<div class="form-group">
						<label for="PrioritaChiamata">Priorit&agrave; della Chiamata</label>
						<select class="form-control" id="PrioritaChiamata" name="PrioritaChiamata" placeholder="Priorit&agrave; Chiamata">
							<option>1</option>
							<option>2</option>
							<option>3</option>
							<option>4</option>
							<option>5</option>
						</select>
					</div>
					<div class="form-group">
						<label for="IDExtSollecitoChiamata">ID Sollecito</label>
						<input type="text" class="form-control" id="IDExtSollecitoChiamata" name="IDExtSollecitoChiamata" aria-describedby="IDExtSollecitoChiamataHelp" placeholder="ID del Sollecito della Chiamata">
						<small id="IDExtSollecitoChiamataHelp" class="form-text text-muted">L'ID della chiamata che si vuole sollecitare</small>
					</div>                      
					<div class="form-group">
						<label for="ExtIDOperatore">ID Operatore</label>
						<input type="text" class="form-control" id="ExtIDOperatore" name="ExtIDOperatore" aria-describedby="ExtIDOperatoreHelp" placeholder="ID Operatore">
						<small id="ExtIDOperatoreHelp" class="form-text text-muted">ID dell'operatore</small>
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
					<span class="btn btn-primary" onclick="PostSender();">Invia</span>
					<!-- <button type="submit" class="btn btn-primary">Invia</button> -->
					<!-- <button type="submit" class="btn btn-primary">Invia</button> -->
					<!--<asp:Button PostBackUrl="~/ReceiverPage.aspx" class="btn btn-primary" OnClick="ExecutePost" Text="Invia" CssClass="btn btn-primary" runat="server"/>-->
				</div>

    </div>

    
</asp:Content>