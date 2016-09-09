using System;
using System.Collections.Generic;
using IBLL.DTO;

namespace IBLL
{
    public interface IBLL
    {
        List<ChiamataDTO> GetChiamateByRangeDate(DateTime begin, DateTime end);
        int UpdateChiamataByExtPk(ChiamataDTO data, long extidid);
        int UpdateChiamataByPk(ChiamataDTO data, long idid);
        int AddChiamata(ChiamataDTO data);
        int AddChiamate(List<ChiamataDTO> data);
        int DeleteChiamata(long esamidid);
    }
}
