using System.Collections.Generic;

namespace BusinessLogicLayer.Mappers
{
    public class ChiamataMapper
    {
        private static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static IDAL.VO.ChiamataVO DTOToVO(IBLL.DTO.ChiamataDTO dto)
        {
            IDAL.VO.ChiamataVO vo = new IDAL.VO.ChiamataVO();

            vo.CognomeChiamata = dto.CognomeChiamata;
            vo.DataOraInizioChiamata = dto.DataOraInizioChiamata;
            vo.DataOraFineChiamata = dto.DataOraFineChiamata;
            vo.DataOraOperazione = dto.DataOraOperazione;
            vo.ExtIDChiamata = dto.ExtIDChiamata;
            vo.ExtIDOperatore = dto.ExtIDOperatore;
            vo.IDChiamata = dto.IDChiamata;
            vo.IDExtSollecitoChiamata = dto.IDExtSollecitoChiamata;
            vo.InfoChiamata = dto.InfoChiamata;
            vo.IPOperazione = dto.IPOperazione;
            vo.MotivoChiamata = dto.MotivoChiamata;
            vo.NomeChiamata = dto.NomeChiamata;
            vo.NumeroChiamata = dto.NumeroChiamata;
            vo.Priorita = dto.Priorita;
            vo.Stato = dto.Stato;

            return vo;
        }
        public static List<IDAL.VO.ChiamataVO> DTOListToVOList(List<IBLL.DTO.ChiamataDTO> dtos)
        {
            List<IDAL.VO.ChiamataVO> vos = new List<IDAL.VO.ChiamataVO>();

            foreach (IBLL.DTO.ChiamataDTO dto in dtos)
            {
                vos.Add(DTOToVO(dto));
            }

            return vos;
        }
        public static IBLL.DTO.ChiamataDTO VOToDTO(IDAL.VO.ChiamataVO vo)
        {
            IBLL.DTO.ChiamataDTO dto = new IBLL.DTO.ChiamataDTO();

            dto.CognomeChiamata = vo.CognomeChiamata;
            dto.DataOraInizioChiamata = vo.DataOraInizioChiamata;
            dto.DataOraFineChiamata = vo.DataOraFineChiamata;
            dto.DataOraOperazione = vo.DataOraOperazione;
            dto.ExtIDChiamata = vo.ExtIDChiamata;
            dto.ExtIDOperatore = vo.ExtIDOperatore;
            dto.IDChiamata = vo.IDChiamata;
            dto.IDExtSollecitoChiamata = vo.IDExtSollecitoChiamata;
            dto.InfoChiamata = vo.InfoChiamata;
            dto.IPOperazione = vo.IPOperazione;
            dto.MotivoChiamata = vo.MotivoChiamata;
            dto.NomeChiamata = vo.NomeChiamata;
            dto.NumeroChiamata = vo.NumeroChiamata;
            dto.Priorita = vo.Priorita;
            dto.Stato = vo.Stato;
            
            return dto;
        }
        public static List<IBLL.DTO.ChiamataDTO> VOListToDTOList(List<IDAL.VO.ChiamataVO> vos)
        {
            List<IBLL.DTO.ChiamataDTO> dtos = new List<IBLL.DTO.ChiamataDTO>();

            foreach(IDAL.VO.ChiamataVO vo in vos)
            {
                dtos.Add(VOToDTO(vo));
            }

            return dtos;
        }
    }
}
