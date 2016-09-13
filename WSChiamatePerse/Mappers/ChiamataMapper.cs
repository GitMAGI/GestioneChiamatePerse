using IBLL.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace WSChiamatePerse.Mappers
{
    public class ChiamataMapper
    {     
        public static ChiamataSOi JTokenToSO(JToken jObject)
        {
            var exceptions = new List<Exception>();
            ChiamataSOi so = new ChiamataSOi();

            so.CognomeChiamata = jObject["CognomeChiamata"] != null ? (string)jObject["CognomeChiamata"] : null;
            try{
                so.DataOraInizioChiamata = jObject["DataOraInizioChiamata"] != null ? DateTime.Parse((string)jObject["DataOraInizioChiamata"]) : (DateTime?)null;
            }catch (Exception ex){
                string msg = "Error During Parsing of \"DataOraInizioChiamata\"";
                exceptions.Add(new Exception(msg, ex));
            }
            try{
                so.DataOraFineChiamata = jObject["DataOraFineChiamata"] != null ? DateTime.Parse((string)jObject["DataOraFineChiamata"]) : (DateTime?)null;
            }catch (Exception ex){
                string msg = "Error During Parsing of \"DataOraFineChiamata\"";
                exceptions.Add(new Exception(msg, ex));
            }
            try{
                so.ExtIDChiamata = jObject["ExtIDChiamata"] != null ? long.Parse((string)jObject["ExtIDChiamata"]) : (long?)null;
            }catch (Exception ex){
                string msg = "Error During Parsing of \"ExtIDChiamata\"";
                exceptions.Add(new Exception(msg, ex));
            }
            try{
                so.ExtIDOperatore = jObject["ExtIDOperatore"] != null ? long.Parse((string)jObject["ExtIDOperatore"]) : (long?)null;
            }catch (Exception ex){
                string msg = "Error During Parsing of \"ExtIDOperatore\"";
                exceptions.Add(new Exception(msg, ex));
            }
            try{
                so.IDExtSollecitoChiamata = jObject["IDExtSollecitoChiamata"] != null ? long.Parse((string)jObject["IDExtSollecitoChiamata"]) : (long?)null;
            }catch (Exception ex){
                string msg = "Error During Parsing of \"IDExtSollecitoChiamata\"";
                exceptions.Add(new Exception(msg, ex));
            }
            so.InfoChiamata = jObject["InfoChiamata"] != null ? (string)jObject["InfoChiamata"] : null;
            so.MotivoChiamata = jObject["MotivoChiamata"] != null ? (string)jObject["MotivoChiamata"] : null;
            so.NomeChiamata = jObject["NomeChiamata"] != null ? (string)jObject["NomeChiamata"] : null;
            so.NumeroChiamata = jObject["NumeroChiamata"] != null ? (string)jObject["NumeroChiamata"] : null;
            try{
                so.Priorita = jObject["Priorita"] != null ? int.Parse((string)jObject["Priorita"]) : (int?)null;}
            catch (Exception ex){
                string msg = "Error During Parsing of \"IDExtSollecitoChiamata\"";
                exceptions.Add(new Exception(msg, ex));
            }

            if (exceptions.Count > 0)
                throw new AggregateException("Encountered errors during SO mapping!", exceptions);

            return so;
        }
        public static ChiamataSOi JsonObjToSO(string jsonObj)
        {
            ChiamataSOi so = null;

            JObject jObject = JObject.Parse(jsonObj);
            JToken jToken = jObject.First;

            so = JTokenToSO(jToken);

            return so;
        }
        public static List<ChiamataSOi> JsonArrayToSOList(string jsonArray)
        {
            List<AggregateException> exceptions = new List<AggregateException>();
            List<ChiamataSOi> sos = new List<ChiamataSOi>();

            JArray jArray = JArray.Parse(jsonArray);

            int count = 1;
            foreach (JToken jToken in jArray)
            {
                try
                {
                    sos.Add(JTokenToSO(jToken));
                }
                catch (AggregateException exs)
                {
                    string msg = string.Format("Error During Parsing of the {0} items!", count);
                    exceptions.Add(new AggregateException(msg, exs.Flatten()));
                }   
                count ++;
            }

            if (exceptions.Count > 0)
                throw new AggregateException("Encountered errors during SO mapping!", exceptions);

            return sos;
        }
        public static string SOListToJsonArray(List<ChiamataSOo> sos)
        {
            string json = null;

            json = JsonConvert.SerializeObject(sos);

            return json;
        }
        public static string SOToJsonObject(ChiamataSOo so)
        {
            string json = null;

            json = JsonConvert.SerializeObject(so);

            return json;
        }
        public static ChiamataDTO SOToDTO(ChiamataSOi so)
        {
            ChiamataDTO dto = new ChiamataDTO();

            dto.CognomeChiamata = so.CognomeChiamata;
            dto.DataOraInizioChiamata = so.DataOraInizioChiamata;
            dto.DataOraFineChiamata = so.DataOraFineChiamata;
            dto.DataOraOperazione = so.DataOraOperazione != null ? so.DataOraOperazione : DateTime.Now;
            dto.ExtIDChiamata = so.ExtIDChiamata;
            dto.ExtIDOperatore = so.ExtIDOperatore;
            dto.IDChiamata = so.IDChiamata;
            dto.IDExtSollecitoChiamata = so.IDExtSollecitoChiamata;
            dto.InfoChiamata = so.InfoChiamata;
            dto.IPOperazione = so.IPOperazione != null ? so.IPOperazione : "MyIP";
            dto.MotivoChiamata = so.MotivoChiamata;
            dto.NomeChiamata = so.NomeChiamata;
            dto.NumeroChiamata = so.NumeroChiamata;
            dto.Priorita = so.Priorita;
            dto.Stato = so.Stato != null ? so.Stato : 1;

            return dto;
        }
        public static List<ChiamataDTO> SOListToDTOList(List<ChiamataSOi> sos)
        {
            List<ChiamataDTO> dtos = new List<ChiamataDTO>();
            foreach(ChiamataSOi so in sos){
                dtos.Add(SOToDTO(so));
            }
            return dtos;
        }
        public static List<ChiamataDTO> SOArrayToDTOList(ChiamataSOi[] sos)
        {
            List<ChiamataSOi> sos_ = new List<ChiamataSOi>(sos);
            return SOListToDTOList(sos_);
        }
        public static ChiamataSOo DTOToSO(ChiamataDTO dto)
        {
            ChiamataSOo so = new ChiamataSOo();

            so.CognomeChiamata = dto.CognomeChiamata;
            so.DataOraInizioChiamata = dto.DataOraInizioChiamata;
            so.DataOraFineChiamata = dto.DataOraFineChiamata;
            so.ExtIDChiamata = dto.ExtIDChiamata;
            so.ExtIDOperatore = dto.ExtIDOperatore;
            so.IDExtSollecitoChiamata = dto.IDExtSollecitoChiamata;
            so.InfoChiamata = dto.InfoChiamata;
            so.MotivoChiamata = dto.MotivoChiamata;
            so.NomeChiamata = dto.NomeChiamata;
            so.NumeroChiamata = dto.NumeroChiamata;
            so.Priorita = dto.Priorita;
            so.Stato = dto.Stato;
            so.IPOperazione = dto.IPOperazione;
            so.DataOraOperazione = dto.DataOraOperazione;

            return so;
        }
        public static List<ChiamataSOo> DTOListToSOList(List<ChiamataDTO> dtos)
        {
            List<ChiamataSOo> sos = new List<ChiamataSOo>();
            foreach (ChiamataDTO dto in dtos){
                sos.Add(DTOToSO(dto));
            }
            return sos;
        }
    }
}