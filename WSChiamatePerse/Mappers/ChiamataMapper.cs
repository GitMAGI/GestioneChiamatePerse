using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace WSChiamatePerse.Mappers
{
    public class ChiamataMapper
    {
        public static IBLL.DTO.ChiamataDTO JTokenToDTO(JToken jObject)
        {
            IBLL.DTO.ChiamataDTO dto = new IBLL.DTO.ChiamataDTO();

            dto.CognomeChiamata = jObject["CognomeChiamata"] != null ? (string)jObject["CognomeChiamata"] : null;
            dto.DataOraInizioChiamata = jObject["DataOraInizioChiamata"] != null ? DateTime.Parse((string)jObject["DataOraInizioChiamata"]) : (DateTime?)null;
            dto.DataOraFineChiamata = jObject["DataOraFineChiamata"] != null ? DateTime.Parse((string)jObject["DataOraFineChiamata"]) : (DateTime?)null;
            dto.DataOraOperazione = DateTime.Now;
            dto.ExtIDChiamata = jObject["ExtIDChiamata"] != null ? long.Parse((string)jObject["ExtIDChiamata"]) : (long?)null;
            dto.ExtIDOperatore = jObject["ExtIDOperatore"] != null ? long.Parse((string)jObject["ExtIDOperatore"]) : (long?)null;
            dto.IDChiamata = jObject["IDChiamata"] != null ? long.Parse((string)jObject["IDChiamata"]) : (long?)null;
            dto.IDExtSollecitoChiamata = jObject["IDExtSollecitoChiamata"] != null ? long.Parse((string)jObject["IDExtSollecitoChiamata"]) : (long?)null;
            dto.InfoChiamata = jObject["InfoChiamata"] != null ? (string)jObject["InfoChiamata"] : null;
            dto.IPOperazione = jObject["IPOperazione"] != null ? (string)jObject["IPOperazione"] : null;
            dto.MotivoChiamata = jObject["MotivoChiamata"] != null ? (string)jObject["MotivoChiamata"] : null;
            dto.NomeChiamata = jObject["NomeChiamata"] != null ? (string)jObject["NomeChiamata"] : null;
            dto.NumeroChiamata = jObject["NumeroChiamata"] != null ? (string)jObject["NumeroChiamata"] : null;
            dto.Priorita = jObject["Priorita"] != null ? int.Parse((string)jObject["Priorita"]) : (int?)null;
            dto.Stato = jObject["Stato"] != null ? int.Parse((string)jObject["Stato"]) : (int?)null;

            return dto;
        }
        public static IBLL.DTO.ChiamataDTO JsonObjToDTO(string jsonObj)
        {
            IBLL.DTO.ChiamataDTO dto = null;

            JObject jObject = JObject.Parse(jsonObj);
            JToken jToken = jObject.First;

            dto = JTokenToDTO(jToken);

            return dto;
        }
        public static List<IBLL.DTO.ChiamataDTO> JsonArrayToDTOList(string jsonArray)
        {
            List<IBLL.DTO.ChiamataDTO> dtos = new List<IBLL.DTO.ChiamataDTO>();

            JArray jArray = JArray.Parse(jsonArray);

            foreach (JToken jToken in jArray)
            {
                dtos.Add(JTokenToDTO(jToken));
            }

            return dtos;
        }
        public static string DTOListToJsonArray(List<IBLL.DTO.ChiamataDTO> dtos)
        {
            string json = null;

            json = JsonConvert.SerializeObject(dtos);

            return json;
        }
        public static string DTOToJsonObject(IBLL.DTO.ChiamataDTO dto)
        {
            string json = null;

            json = JsonConvert.SerializeObject(dto);

            return json;
        }
    }
}