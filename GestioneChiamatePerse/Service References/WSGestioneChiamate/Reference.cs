﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestioneChiamatePerse.WSGestioneChiamate {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Response", Namespace="http://schemas.datacontract.org/2004/07/WSChiamatePerse")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GestioneChiamatePerse.WSGestioneChiamate.ResponseData))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GestioneChiamatePerse.WSGestioneChiamate.ResponseInsert))]
    public partial class Response : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ErrorsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] InfosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] WarningsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool successField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Errors {
            get {
                return this.ErrorsField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorsField, value) != true)) {
                    this.ErrorsField = value;
                    this.RaisePropertyChanged("Errors");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Infos {
            get {
                return this.InfosField;
            }
            set {
                if ((object.ReferenceEquals(this.InfosField, value) != true)) {
                    this.InfosField = value;
                    this.RaisePropertyChanged("Infos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Warnings {
            get {
                return this.WarningsField;
            }
            set {
                if ((object.ReferenceEquals(this.WarningsField, value) != true)) {
                    this.WarningsField = value;
                    this.RaisePropertyChanged("Warnings");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool success {
            get {
                return this.successField;
            }
            set {
                if ((this.successField.Equals(value) != true)) {
                    this.successField = value;
                    this.RaisePropertyChanged("success");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseData", Namespace="http://schemas.datacontract.org/2004/07/WSChiamatePerse")]
    [System.SerializableAttribute()]
    public partial class ResponseData : GestioneChiamatePerse.WSGestioneChiamate.Response {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOo[] DataField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOo[] Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseInsert", Namespace="http://schemas.datacontract.org/2004/07/WSChiamatePerse")]
    [System.SerializableAttribute()]
    public partial class ResponseInsert : GestioneChiamatePerse.WSGestioneChiamate.Response {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AffectedRowsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AffectedRows {
            get {
                return this.AffectedRowsField;
            }
            set {
                if ((this.AffectedRowsField.Equals(value) != true)) {
                    this.AffectedRowsField = value;
                    this.RaisePropertyChanged("AffectedRows");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChiamataSOo", Namespace="http://schemas.datacontract.org/2004/07/WSChiamatePerse")]
    [System.SerializableAttribute()]
    public partial class ChiamataSOo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CognomeChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DataOraFineChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DataOraInizioChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DataOraOperazioneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> ExtIDChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> ExtIDOperatoreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> IDChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> IDExtSollecitoChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IPOperazioneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InfoChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MotivoChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumeroChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> PrioritaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> StatoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CognomeChiamata {
            get {
                return this.CognomeChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.CognomeChiamataField, value) != true)) {
                    this.CognomeChiamataField = value;
                    this.RaisePropertyChanged("CognomeChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DataOraFineChiamata {
            get {
                return this.DataOraFineChiamataField;
            }
            set {
                if ((this.DataOraFineChiamataField.Equals(value) != true)) {
                    this.DataOraFineChiamataField = value;
                    this.RaisePropertyChanged("DataOraFineChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DataOraInizioChiamata {
            get {
                return this.DataOraInizioChiamataField;
            }
            set {
                if ((this.DataOraInizioChiamataField.Equals(value) != true)) {
                    this.DataOraInizioChiamataField = value;
                    this.RaisePropertyChanged("DataOraInizioChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DataOraOperazione {
            get {
                return this.DataOraOperazioneField;
            }
            set {
                if ((this.DataOraOperazioneField.Equals(value) != true)) {
                    this.DataOraOperazioneField = value;
                    this.RaisePropertyChanged("DataOraOperazione");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> ExtIDChiamata {
            get {
                return this.ExtIDChiamataField;
            }
            set {
                if ((this.ExtIDChiamataField.Equals(value) != true)) {
                    this.ExtIDChiamataField = value;
                    this.RaisePropertyChanged("ExtIDChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> ExtIDOperatore {
            get {
                return this.ExtIDOperatoreField;
            }
            set {
                if ((this.ExtIDOperatoreField.Equals(value) != true)) {
                    this.ExtIDOperatoreField = value;
                    this.RaisePropertyChanged("ExtIDOperatore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> IDChiamata {
            get {
                return this.IDChiamataField;
            }
            set {
                if ((this.IDChiamataField.Equals(value) != true)) {
                    this.IDChiamataField = value;
                    this.RaisePropertyChanged("IDChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> IDExtSollecitoChiamata {
            get {
                return this.IDExtSollecitoChiamataField;
            }
            set {
                if ((this.IDExtSollecitoChiamataField.Equals(value) != true)) {
                    this.IDExtSollecitoChiamataField = value;
                    this.RaisePropertyChanged("IDExtSollecitoChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IPOperazione {
            get {
                return this.IPOperazioneField;
            }
            set {
                if ((object.ReferenceEquals(this.IPOperazioneField, value) != true)) {
                    this.IPOperazioneField = value;
                    this.RaisePropertyChanged("IPOperazione");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InfoChiamata {
            get {
                return this.InfoChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.InfoChiamataField, value) != true)) {
                    this.InfoChiamataField = value;
                    this.RaisePropertyChanged("InfoChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MotivoChiamata {
            get {
                return this.MotivoChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.MotivoChiamataField, value) != true)) {
                    this.MotivoChiamataField = value;
                    this.RaisePropertyChanged("MotivoChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NomeChiamata {
            get {
                return this.NomeChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeChiamataField, value) != true)) {
                    this.NomeChiamataField = value;
                    this.RaisePropertyChanged("NomeChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NumeroChiamata {
            get {
                return this.NumeroChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.NumeroChiamataField, value) != true)) {
                    this.NumeroChiamataField = value;
                    this.RaisePropertyChanged("NumeroChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Priorita {
            get {
                return this.PrioritaField;
            }
            set {
                if ((this.PrioritaField.Equals(value) != true)) {
                    this.PrioritaField = value;
                    this.RaisePropertyChanged("Priorita");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Stato {
            get {
                return this.StatoField;
            }
            set {
                if ((this.StatoField.Equals(value) != true)) {
                    this.StatoField = value;
                    this.RaisePropertyChanged("Stato");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChiamataSOi", Namespace="http://schemas.datacontract.org/2004/07/WSChiamatePerse")]
    [System.SerializableAttribute()]
    public partial class ChiamataSOi : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CognomeChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DataOraFineChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DataOraInizioChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> ExtIDChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> ExtIDOperatoreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> IDExtSollecitoChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InfoChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MotivoChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumeroChiamataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> PrioritaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CognomeChiamata {
            get {
                return this.CognomeChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.CognomeChiamataField, value) != true)) {
                    this.CognomeChiamataField = value;
                    this.RaisePropertyChanged("CognomeChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DataOraFineChiamata {
            get {
                return this.DataOraFineChiamataField;
            }
            set {
                if ((this.DataOraFineChiamataField.Equals(value) != true)) {
                    this.DataOraFineChiamataField = value;
                    this.RaisePropertyChanged("DataOraFineChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DataOraInizioChiamata {
            get {
                return this.DataOraInizioChiamataField;
            }
            set {
                if ((this.DataOraInizioChiamataField.Equals(value) != true)) {
                    this.DataOraInizioChiamataField = value;
                    this.RaisePropertyChanged("DataOraInizioChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> ExtIDChiamata {
            get {
                return this.ExtIDChiamataField;
            }
            set {
                if ((this.ExtIDChiamataField.Equals(value) != true)) {
                    this.ExtIDChiamataField = value;
                    this.RaisePropertyChanged("ExtIDChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> ExtIDOperatore {
            get {
                return this.ExtIDOperatoreField;
            }
            set {
                if ((this.ExtIDOperatoreField.Equals(value) != true)) {
                    this.ExtIDOperatoreField = value;
                    this.RaisePropertyChanged("ExtIDOperatore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> IDExtSollecitoChiamata {
            get {
                return this.IDExtSollecitoChiamataField;
            }
            set {
                if ((this.IDExtSollecitoChiamataField.Equals(value) != true)) {
                    this.IDExtSollecitoChiamataField = value;
                    this.RaisePropertyChanged("IDExtSollecitoChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InfoChiamata {
            get {
                return this.InfoChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.InfoChiamataField, value) != true)) {
                    this.InfoChiamataField = value;
                    this.RaisePropertyChanged("InfoChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MotivoChiamata {
            get {
                return this.MotivoChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.MotivoChiamataField, value) != true)) {
                    this.MotivoChiamataField = value;
                    this.RaisePropertyChanged("MotivoChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NomeChiamata {
            get {
                return this.NomeChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeChiamataField, value) != true)) {
                    this.NomeChiamataField = value;
                    this.RaisePropertyChanged("NomeChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NumeroChiamata {
            get {
                return this.NumeroChiamataField;
            }
            set {
                if ((object.ReferenceEquals(this.NumeroChiamataField, value) != true)) {
                    this.NumeroChiamataField = value;
                    this.RaisePropertyChanged("NumeroChiamata");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Priorita {
            get {
                return this.PrioritaField;
            }
            set {
                if ((this.PrioritaField.Equals(value) != true)) {
                    this.PrioritaField = value;
                    this.RaisePropertyChanged("Priorita");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WSGestioneChiamate.IGestioneChiamate")]
    public interface IGestioneChiamate {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestioneChiamate/InsertJson_obj", ReplyAction="http://tempuri.org/IGestioneChiamate/InsertJson_objResponse")]
        GestioneChiamatePerse.WSGestioneChiamate.ResponseInsert InsertJson_obj(string jsonArray);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestioneChiamate/InsertJson_obj", ReplyAction="http://tempuri.org/IGestioneChiamate/InsertJson_objResponse")]
        System.Threading.Tasks.Task<GestioneChiamatePerse.WSGestioneChiamate.ResponseInsert> InsertJson_objAsync(string jsonArray);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestioneChiamate/InsertJson_json", ReplyAction="http://tempuri.org/IGestioneChiamate/InsertJson_jsonResponse")]
        string InsertJson_json(string jsonArray);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestioneChiamate/InsertJson_json", ReplyAction="http://tempuri.org/IGestioneChiamate/InsertJson_jsonResponse")]
        System.Threading.Tasks.Task<string> InsertJson_jsonAsync(string jsonArray);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestioneChiamate/GetAll_obj", ReplyAction="http://tempuri.org/IGestioneChiamate/GetAll_objResponse")]
        GestioneChiamatePerse.WSGestioneChiamate.ResponseData GetAll_obj();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestioneChiamate/GetAll_obj", ReplyAction="http://tempuri.org/IGestioneChiamate/GetAll_objResponse")]
        System.Threading.Tasks.Task<GestioneChiamatePerse.WSGestioneChiamate.ResponseData> GetAll_objAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestioneChiamate/Exposer", ReplyAction="http://tempuri.org/IGestioneChiamate/ExposerResponse")]
        void Exposer(GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOi soi, GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOo soo, GestioneChiamatePerse.WSGestioneChiamate.ResponseData rd, GestioneChiamatePerse.WSGestioneChiamate.ResponseInsert ri);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestioneChiamate/Exposer", ReplyAction="http://tempuri.org/IGestioneChiamate/ExposerResponse")]
        System.Threading.Tasks.Task ExposerAsync(GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOi soi, GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOo soo, GestioneChiamatePerse.WSGestioneChiamate.ResponseData rd, GestioneChiamatePerse.WSGestioneChiamate.ResponseInsert ri);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGestioneChiamateChannel : GestioneChiamatePerse.WSGestioneChiamate.IGestioneChiamate, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GestioneChiamateClient : System.ServiceModel.ClientBase<GestioneChiamatePerse.WSGestioneChiamate.IGestioneChiamate>, GestioneChiamatePerse.WSGestioneChiamate.IGestioneChiamate {
        
        public GestioneChiamateClient() {
        }
        
        public GestioneChiamateClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GestioneChiamateClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestioneChiamateClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestioneChiamateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public GestioneChiamatePerse.WSGestioneChiamate.ResponseInsert InsertJson_obj(string jsonArray) {
            return base.Channel.InsertJson_obj(jsonArray);
        }
        
        public System.Threading.Tasks.Task<GestioneChiamatePerse.WSGestioneChiamate.ResponseInsert> InsertJson_objAsync(string jsonArray) {
            return base.Channel.InsertJson_objAsync(jsonArray);
        }
        
        public string InsertJson_json(string jsonArray) {
            return base.Channel.InsertJson_json(jsonArray);
        }
        
        public System.Threading.Tasks.Task<string> InsertJson_jsonAsync(string jsonArray) {
            return base.Channel.InsertJson_jsonAsync(jsonArray);
        }
        
        public GestioneChiamatePerse.WSGestioneChiamate.ResponseData GetAll_obj() {
            return base.Channel.GetAll_obj();
        }
        
        public System.Threading.Tasks.Task<GestioneChiamatePerse.WSGestioneChiamate.ResponseData> GetAll_objAsync() {
            return base.Channel.GetAll_objAsync();
        }
        
        public void Exposer(GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOi soi, GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOo soo, GestioneChiamatePerse.WSGestioneChiamate.ResponseData rd, GestioneChiamatePerse.WSGestioneChiamate.ResponseInsert ri) {
            base.Channel.Exposer(soi, soo, rd, ri);
        }
        
        public System.Threading.Tasks.Task ExposerAsync(GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOi soi, GestioneChiamatePerse.WSGestioneChiamate.ChiamataSOo soo, GestioneChiamatePerse.WSGestioneChiamate.ResponseData rd, GestioneChiamatePerse.WSGestioneChiamate.ResponseInsert ri) {
            return base.Channel.ExposerAsync(soi, soo, rd, ri);
        }
    }
}
