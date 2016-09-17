using IBLL.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace WSChiamatePerse.Mappers
{
    public class ChiamataMapper
    {
        public static ChiamataSOi DictionaryToSO(Dictionary<string, object> data)
        {
            ChiamataSOi so = GeneralPurposeLib.ConversionUtlilities.DictionaryToObject<ChiamataSOi>(data);
            return so;
        }
        public static List<ChiamataSOi> DictionaryListToSOList(List<Dictionary<string, object>> data)
        {
            List<ChiamataSOi> sos = GeneralPurposeLib.ConversionUtlilities.DictionaryListToObjectList<ChiamataSOi>(data);
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

            string ip_ = "-- no ip detected --";
            if (HttpContext.Current != null)
            {
                NameValueCollection srv = HttpContext.Current.Request.ServerVariables;
                ip_ = srv["HTTP_X_FORWARDED_FOR"] != null ? srv["HTTP_X_FORWARDED_FOR"] : string.Empty;
                if (ip_ == string.Empty)
                {
                    ip_ = srv["REMOTE_ADDR"] != null ? srv["REMOTE_ADDR"] : "-- no ip discoverable --";
                }
            }
            dto.IPOperazione = so.IPOperazione != null ? so.IPOperazione : ip_;
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