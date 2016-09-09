using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappers
{
    public class ChiamataMapper
    {
        private static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static IBLL.DTO.ChiamataDTO JTokenToDTO(JToken jObject)
        {
            IBLL.DTO.ChiamataDTO dto = new IBLL.DTO.ChiamataDTO();

            DateTime trash;
            long trash_;
            int trash__;

            dto.CognomeChiamata = jObject["CognomeChiamata"] != null ? (string)jObject["CognomeChiamata"] : null;
            dto.DataOraFineChiamata = DateTime.TryParse((string)jObject["DataOraFineChiamata"], out trash) ? trash : DateTime.MinValue;
            dto.DataOraInizioChiamata = DateTime.TryParse((string)jObject["DataOraInizioChiamata"], out trash) ? trash : DateTime.MinValue;
            dto.DataOraOperazione = DateTime.Now;
            dto.ExtIDChiamata = long.TryParse((string)jObject["ExtIDChiamata"], out trash_) ? trash_ : 0;
            dto.ExtIDOperatore = long.TryParse((string)jObject["ExtIDOperatore"], out trash_) ? trash_ : 0;
            dto.IDChiamata = long.TryParse((string)jObject["IDChiamata"], out trash_) ? trash_ : 0;
            dto.IDExtSollecitoChiamata = long.TryParse((string)jObject["IDExtSollecitoChiamata"], out trash_) ? trash_ : 0;
            dto.InfoChiamata = jObject["InfoChiamata"] != null ? (string)jObject["InfoChiamata"] : null;
            dto.IPOperazione = jObject["IPOperazione"] != null ? (string)jObject["IPOperazione"] : null;
            dto.MotivoChiamata = jObject["MotivoChiamata"] != null ? (string)jObject["MotivoChiamata"] : null;
            dto.NomeChiamata = jObject["NomeChiamata"] != null ? (string)jObject["NomeChiamata"] : null;
            dto.NumeroChiamata = jObject["NumeroChiamata"] != null ? (string)jObject["NumeroChiamata"] : null;
            dto.Priorita = int.TryParse((string)jObject["Priorita"], out trash__) ? trash__ : 0;
            dto.Stato = int.TryParse((string)jObject["Stato"], out trash__) ? trash__ : 0;

            return dto;
        }      
        public static IBLL.DTO.ChiamataDTO JsonObjToDTO(string jsonObj)
        {
            IBLL.DTO.ChiamataDTO dto = null;

            JObject jObject = JObject.Parse(jsonObj);
            JToken jToken = jObject.First;
            //JToken jToken = JToken.Parse(jsonObj);

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
        public static string DTOListToJsonObject(IBLL.DTO.ChiamataDTO dto)
        {
            string json = null;

            json = JsonConvert.SerializeObject(dto);

            return json;
        }

        public static IDAL.VO.ChiamataVO DTOToVO(IBLL.DTO.ChiamataDTO dto)
        {
            IDAL.VO.ChiamataVO vo = null;

            return vo;
        }
        public static List<IDAL.VO.ChiamataVO> DTOListToVOList(List<IBLL.DTO.ChiamataDTO> dtos)
        {
            List<IDAL.VO.ChiamataVO> vos = null;

            return vos;
        }
        public static IBLL.DTO.ChiamataDTO VOToDTO(IDAL.VO.ChiamataVO vo)
        {
            IBLL.DTO.ChiamataDTO dto = null;

            return dto;
        }
        public static List<IBLL.DTO.ChiamataDTO> VOListToDTOList(List<IDAL.VO.ChiamataVO> vos)
        {
            List<IBLL.DTO.ChiamataDTO> dtos = null;

            return dtos;
        }
    }
}
