using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WSChiamatePerse
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IService1" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IGestioneChiamate
    {
        [OperationContract]
        ResponseInsert InsertJson_obj(string jsonArray);

        [OperationContract]
        string InsertJson_json(string jsonArray);

        [OperationContract]
        ResponseInsert InsertObjList_obj(List<ChiamataSOi> sos);

        [OperationContract]
        ResponseData GetAll_obj();

        [OperationContract]
        void Exposer(ChiamataSOi soi, ChiamataSOo soo, ResponseData rd, ResponseInsert ri);
    }

    [DataContract]
    public class Response
    {
        [DataMember]
        public List<string> Infos { get; set; }
        [DataMember]
        public List<string> Warnings { get; set; }
        [DataMember]
        public List<string> Errors { get; set; }
        [DataMember]
        public bool success;
                
        public void AddInfos(List<string> infos)
        {
            if (infos != null && infos.Count > 0)
            {
                if (this.Infos == null)
                    this.Infos = new List<string>();
                this.Infos.AddRange(infos);
            }
        }
        public void AddWarnings(List<string> warnings)
        {
            if (warnings != null && warnings.Count > 0)
            {
                if (this.Warnings == null)
                    this.Warnings = new List<string>();
                this.Warnings.AddRange(warnings);
            }
        }
        public void AddErrors(List<string> errors)
        {
            if (errors != null && errors.Count > 0)
            {
                if (this.Errors == null)
                    this.Errors = new List<string>();
                this.Errors.AddRange(errors);
            }            
        }
        public void AddInfo(string info)
        {
            if (this.Infos == null)
                this.Infos = new List<string>();
            this.Infos.Add(info);
        }
        public void AddWarning(string warning)
        {
            if (this.Warnings == null)
                this.Warnings = new List<string>();
            this.Warnings.Add(warning);
        }
        public void AddError(string error)
        {
            if (this.Errors == null)
                this.Errors = new List<string>();
            this.Errors.Add(error);
        }
        public List<string> GetInfos()
        {
            return this.Infos;
        }
        public List<string> GetWarnings()
        {
            return this.Warnings;
        }
        public List<string> GetErrors()
        {
            return this.Errors;
        }
    }

    [DataContract]
    public class ResponseData : Response
    {
        [DataMember]
        public List<ChiamataSOo> Data { get; set; }
    }

    [DataContract]
    public class ResponseInsert : Response
    {
        [DataMember]
        public int AffectedRows { get; set; }
    }

    [DataContract]
    public class ChiamataSOi
    {
        [DefaultValue(null)]
        public long? IDChiamata { get; set; }

        [DataMember]
        [Required(ErrorMessage = "ExtIDChiamata e' un campo obbligatorio")]
        public long? ExtIDChiamata { get; set; }

        [DataMember]
        [Required(ErrorMessage = "NumeroChiamata e' un campo obbligatorio"), MaxLength(255)]
        public string NumeroChiamata { get; set; }
        
        [DataMember]
        [Required(ErrorMessage = "NomeChiamata e' un campo obbligatorio"), MaxLength(255)]
        public string NomeChiamata { get; set; }

        [DataMember]
        [Required(ErrorMessage = "CognomeChiamata e' un campo obbligatorio"), MaxLength(255)]
        public string CognomeChiamata { get; set; }

        [DataMember]
        [Required(ErrorMessage = "MotivoChiamata e' un campo obbligatorio"), MaxLength(10000)]
        public string MotivoChiamata { get; set; }

        [DataMember]
        [Required(ErrorMessage = "DataOraInizioChiamata e' un campo obbligatorio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd hh:mm:ss}")]
        public DateTime? DataOraInizioChiamata { get; set; }

        [DataMember]
        [Required(ErrorMessage = "DataOraInizioChiamata e' un campo obbligatorio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd hh:mm:ss}")]
        public DateTime? DataOraFineChiamata { get; set; }

        [DataMember]
        public int? Priorita { get; set; }

        [DefaultValue(null)]
        public int? Stato { get; set; }

        [DataMember]
        public string InfoChiamata { get; set; }

        [DataMember]
        public long? IDExtSollecitoChiamata { get; set; }

        [Required(ErrorMessage = "DataOraOperazione e' un campo obbligatorio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd hh:mm:ss}")]
        [DefaultValue(null)]
        public DateTime? DataOraOperazione { get; set; }

        [Required(ErrorMessage = "IPOperazione e' un campo obbligatorio")]
        [DefaultValue(null)]
        public string IPOperazione { get; set; }

        [DataMember]
        public long? ExtIDOperatore { get; set; }

        [DataMember]
        public string Azienda { get; set; }
    }
    
    [DataContract]
    public class ChiamataSOo
    {
        [DataMember]
        public long? IDChiamata { get; set; }
        [DataMember]
        public long? ExtIDChiamata { get; set; }
        [DataMember]
        public string NumeroChiamata { get; set; }
        [DataMember]
        public string NomeChiamata { get; set; }
        [DataMember]
        public string CognomeChiamata { get; set; }
        [DataMember]
        public string MotivoChiamata { get; set; }
        [DataMember]
        public DateTime? DataOraInizioChiamata { get; set; }
        [DataMember]
        public DateTime? DataOraFineChiamata { get; set; }
        [DataMember]
        public int? Priorita { get; set; }
        [DataMember]
        public int? Stato { get; set; }
        [DataMember]
        public string InfoChiamata { get; set; }
        [DataMember]
        public long? IDExtSollecitoChiamata { get; set; }
        [DataMember]
        public DateTime? DataOraOperazione { get; set; }
        [DataMember]
        public string IPOperazione { get; set; }
        [DataMember]
        public long? ExtIDOperatore { get; set; }
        [DataMember]
        public string Azienda { get; set; }
    }


}
