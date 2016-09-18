using System;
using System.Collections.Generic;
using IBLL.DTO;

namespace IBLL
{
    public interface IBLL
    {
        List<ChiamataDTO> GetChiamateByRangeDate(DateTime begin, DateTime end);
        int UpdateChiamataByExtPk(ChiamataDTO data, long extidid, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport);
        int UpdateChiamataByPk(ChiamataDTO data, long idid, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport);
        int AddChiamata(ChiamataDTO data, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport);
        int AddChiamate(List<ChiamataDTO> data, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport);
        int DeleteChiamata(long esamidid, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport);
    }
}
