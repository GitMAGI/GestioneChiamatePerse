using System;

namespace WSChiamatePerse.ServiceObjects
{
    public class ChiamataSO
    {
        public long? IDChiamata { get { return this.IDChiamata; } }
        public long? ExtIDChiamata { get; set; }
        public string NumeroChiamata { get; set; }
        public string NomeChiamata { get; set; }
        public string CognomeChiamata { get; set; }
        public string MotivoChiamata { get; set; }
        public DateTime? DataOraInizioChiamata { get; set; }
        public DateTime? DataOraFineChiamata { get; set; }
        public int? Priorita { get; set; }
        public int? Stato { get { return this.Stato; } }
        public string InfoChiamata { get; set; }
        public long? IDExtSollecitoChiamata { get; set; }
        public DateTime? DataOraOperazione { get { return this.DataOraOperazione; } }
        public string IPOperazione { get { return this.IPOperazione; } }
        public long? ExtIDOperatore { get; set; }
    }
}