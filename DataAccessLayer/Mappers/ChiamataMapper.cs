using System;
using System.Collections.Generic;
using System.Data;

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
            chia.DataOraFineChiamata = row["DataOraFineChiamata"] != DBNull.Value ? (DateTime)row["DataOraFineChiamata"] : (DateTime?)null;
            chia.DataOraInizioChiamata = row["DataOraInizioChiamata"] != DBNull.Value ? (DateTime)row["DataOraInizioChiamata"] : (DateTime?)null;
            chia.DataOraOperazione = row["DataOraOperazione"] != DBNull.Value ? (DateTime)row["DataOraOperazione"] : (DateTime?)null;
            chia.ExtIDChiamata = row["ExtIDChiamata"] != DBNull.Value ? (long)row["ExtIDChiamata"] : (long?)null;
            chia.ExtIDOperatore = row["ExtIDOperatore"] != DBNull.Value ? (long)row["ExtIDOperatore"] : (long?)null;
            chia.IDChiamata = row["IDChiamata"] != DBNull.Value ? (long)row["IDChiamata"] : (long?)null;
            chia.IDExtSollecitoChiamata = row["IDExtSollecitoChiamata"] != DBNull.Value ? (long)row["IDExtSollecitoChiamata"] : (long?)null;
            chia.InfoChiamata = row["InfoChiamata"] != DBNull.Value ? (string)row["InfoChiamata"] : null;
            chia.IPOperazione = row["IPOperazione"] != DBNull.Value ? (string)row["IPOperazione"] : null;
            chia.MotivoChiamata = row["MotivoChiamata"] != DBNull.Value ? (string)row["MotivoChiamata"] : null;
            chia.NomeChiamata = row["NomeChiamata"] != DBNull.Value ? (string)row["NomeChiamata"] : null;
            chia.NumeroChiamata = row["NumeroChiamata"] != DBNull.Value ? (string)row["NumeroChiamata"] : null;
            chia.Priorita = row["priorita"] != DBNull.Value ? (int)row["priorita"] : (int?)null;
            chia.Stato = row["Stato"] != DBNull.Value ? (int)row["Stato"] : (int?)null;
            chia.Azienda = row["Azienda"] != DBNull.Value ? (string)row["Azienda"] : null;

            return chia;
        }
    }
}
