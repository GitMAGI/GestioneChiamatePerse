using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class ChiamataMapper
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<IDAL.VO.ChiamataVO> DataRowToVO(DataRowCollection rows)
        {
            List<IDAL.VO.ChiamataVO> chias = new List<IDAL.VO.ChiamataVO>();

            foreach (DataRow row in rows)
            {
                chias.Add(DataRowToVO(row));
            }

            return chias;
        }

        public static IDAL.VO.ChiamataVO DataRowToVO(DataRow row)
        {
            IDAL.VO.ChiamataVO chia = new IDAL.VO.ChiamataVO();
            chia.CognomeChiamata = row["CognomeChiamata"] != DBNull.Value ? (string)row["CognomeChiamata"] : null;            
            //chia.DataOraFineChiamata = DateTime.TryParse((string)row["DataOraFineChiamata"], out trash) ? trash : DateTime.MinValue;
            chia.DataOraFineChiamata = row["DataOraFineChiamata"] != DBNull.Value ? (DateTime)row["DataOraFineChiamata"] : DateTime.MinValue;
            //chia.DataOraInizioChiamata = DateTime.TryParse((string)row["DataOraInizioChiamata"], out trash) ? trash : DateTime.MinValue;
            chia.DataOraInizioChiamata = row["DataOraInizioChiamata"] != DBNull.Value ? (DateTime)row["DataOraInizioChiamata"] : DateTime.MinValue;
            //chia.DataOraOperazione = DateTime.TryParse((string)row["DataOraOperazione"], out trash) ? trash : DateTime.MinValue;
            chia.DataOraOperazione = row["DataOraOperazione"] != DBNull.Value ? (DateTime)row["DataOraOperazione"] : DateTime.MinValue;
            chia.ExtIDChiamata = row["ExtIDChiamata"] != DBNull.Value ? (long)row["ExtIDChiamata"] : 0;
            chia.ExtIDOperatore = row["ExtIDOperatore"] != DBNull.Value ? (long)row["ExtIDOperatore"] : 0;
            chia.IDChiamata = row["IDChiamata"] != DBNull.Value ? (long)row["IDChiamata"] : 0;
            chia.IDExtSollecitoChiamata = row["IDExtSollecitoChiamata"] != DBNull.Value ? (long)row["IDExtSollecitoChiamata"] : 0;
            chia.InfoChiamata = row["InfoChiamata"] != DBNull.Value ? (string)row["InfoChiamata"] : null;
            chia.IPOperazione = row["IPOperazione"] != DBNull.Value ? (string)row["IPOperazione"] : null;
            chia.MotivoChiamata = row["MotivoChiamata"] != DBNull.Value ? (string)row["MotivoChiamata"] : null;
            chia.NomeChiamata = row["NomeChiamata"] != DBNull.Value ? (string)row["NomeChiamata"] : null;
            chia.NumeroChiamata = row["NumeroChiamata"] != DBNull.Value ? (string)row["NumeroChiamata"] : null;
            chia.Priorita = row["priorita"] != DBNull.Value ? (int)row["priorita"] : 0;
            chia.Stato = row["Stato"] != DBNull.Value ? (int)row["Stato"] : 0;

            return chia;
        }
    }
}
