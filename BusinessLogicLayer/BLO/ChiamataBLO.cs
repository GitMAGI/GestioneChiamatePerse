using IBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial class BLL
    {
        public List<ChiamataDTO> GetChiamateByRangeDate(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }
        
        public int UpdateChiamataByExtPk(ChiamataDTO data, long extidid)
        {
            throw new NotImplementedException();
        }
        public int UpdateChiamataByPk(ChiamataDTO data, long idid)
        {
            throw new NotImplementedException();
        }
        
        public int AddChiamata(ChiamataDTO data)
        {
            throw new NotImplementedException();
        }
        public int AddChiamate(List<ChiamataDTO> data)
        {
            // 1. Map each DTO to VO
            // 2. Collect Lists of DTOs chunked by 999 items each
            // 3. Call DAL's insert for each chunk
            // 4. Return result

            throw new NotImplementedException();
        }
        public int AddChiamate(ChiamataDTO[] data)
        {
            for (int i = 0; i <= data.GetUpperBound(0); i++)
            {
            }
            throw new NotImplementedException();
        }
        public int AddChiamate(string jsonData)
        {     
            // Input Data like: 
            // "data: [{obj1},{obj2}, ..., {objN}]"
            // Object is built like:
            // 
            throw new NotImplementedException();
        }

        public int DeleteChiamata(string esamidid)
        {
            throw new NotImplementedException();
        }
    }
}
