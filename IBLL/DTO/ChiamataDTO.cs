using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL.DTO
{
    public class ChiamataDTO
    {
        public long? IDChiamata { get; set; }
        public long ExtIDChiamata { get; set; }
        public string NumeroChiamata { get; set; } //MAX Length 255
        public string NomeChiamata { get; set; } //MAX Length 255
        public string CognomeChiamata { get; set; } //MAX Length 255
        public string MotivoChiamata { get; set; }
        public DateTime DataOraInizioChiamata { get; set; }
        public DateTime DataOraFineChiamata { get; set; }
        public int Priorita { get; set; }
        public int? Stato { get; set; }
        public string InfoChiamata { get; set; }
        public long IDExtSollecitoChiamata { get; set; }
        public DateTime? DataOraOperazione { get; set; }
        public string IPOperazione { get; set; } //MAX Length 50
        public long? ExtIDOperatore { get; set; }
    }
}
