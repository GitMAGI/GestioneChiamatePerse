using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.VO
{
    public class ChiamataVO
    {
        public long IDChiamata { get; set; }
        public long ExtIDChiamata { get; set; }
        public string NumeroChiamata { get; set; }
        public string NomeChiamata { get; set; }
        public string CognomeChiamata { get; set; }
        public string MotivoChiamata { get; set; }
        public DateTime DataOraInizioChiamata { get; set; }
        public DateTime DataOraFineChiamata { get; set; }
        public int priorita { get; set; }
        public int Stato { get; set; }
        public string InfoChiamata { get; set; }
        public string IDExtSollecitoChiamata { get; set; }
        public DateTime DataOraOperazione { get; set; }
        public string IPOperazione { get; set; }
        public string ExtIDOperatore { get; set; }
    }
}
