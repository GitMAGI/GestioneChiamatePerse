using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IDAL
    {
        List<IDAL.VO.ChiamataVO> GetChiamateByRangeDate(DateTime begin, DateTime end);
                
        int UpdateChiamataByExtPk(IDAL.VO.ChiamataVO data, long extidid);
        int UpdateChiamataByPk(IDAL.VO.ChiamataVO data, long idid);
        int AddChiamata(IDAL.VO.ChiamataVO data);
        int DeleteChiamata(string esamidid);
    }
}
