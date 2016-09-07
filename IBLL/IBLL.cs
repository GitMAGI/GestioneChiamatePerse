using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.DTO;

namespace IBLL
{
    public interface IBLL
    {
        List<ChiamataDTO> GetChiamateByRangeDate(DateTime begin, DateTime end);
        int UpdateChiamataByExtPk(ChiamataDTO data, long extidid);
        int UpdateChiamataByPk(ChiamataDTO data, long idid);
        int AddChiamata(ChiamataDTO data);
        int DeleteChiamata(string esamidid);
    }
}
