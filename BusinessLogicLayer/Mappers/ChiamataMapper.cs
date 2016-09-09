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
