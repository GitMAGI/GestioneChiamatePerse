using System;
using System.Collections.Generic;
using GeneralPurposeLib;

namespace WSChiamatePerse.Constraints
{
    public class ChiamataContraints : TableStructure
    {
        protected override List<ColumnStructure> Initialization()
        {
            return new List<ColumnStructure>(
                new ColumnStructure[] {

                    new ColumnStructure{
                        colName = "ExtIDChiamata", colType = typeof(long), colMaxLength = null, colNotNull = true, colChecks = null
                    },
                    new ColumnStructure{
                        colName = "NumeroChiamata", colType = typeof(string), colMaxLength = 255, colNotNull = true, colChecks = null
                    },
                    new ColumnStructure{
                        colName = "NomeChiamata", colType = typeof(string), colMaxLength = 255, colNotNull = true, colChecks = null
                    },
                    new ColumnStructure{
                        colName = "CognomeChiamata", colType = typeof(string), colMaxLength = 255, colNotNull = true, colChecks = null
                    },
                    new ColumnStructure{
                        colName = "MotivoChiamata", colType = typeof(string), colMaxLength = null, colNotNull = true, colChecks = null
                    },
                    new ColumnStructure{
                        colName = "DataOraInizioChiamata", colType = typeof(DateTime), colMaxLength = null, colNotNull = true,
                        colChecks = new List<CheckValidation>()
                        {
                            new CheckValidation()
                            {
                                libName = typeof(ChiamataContraints),
                                functionName = "DataFineMaggioreDataInizio",
                                args = new List<string>() { "DataOraFineChiamata" }
                            }
                        }
                    },
                    new ColumnStructure{ 
                        colName = "DataOraFineChiamata", colType = typeof(DateTime), colMaxLength = null, colNotNull = true, colChecks = null
                    },
                    new ColumnStructure{ 
                        colName = "Priorita", colType = typeof(int), colMaxLength = null,  colNotNull = false, colChecks = null
                    },
                    new ColumnStructure{ 
                        colName = "InfoChiamata", colType = typeof(string), colMaxLength = null, colNotNull = false, colChecks = null
                    },
                    new ColumnStructure{ 
                        colName = "IDExtSollecitoChiamata", colType = typeof(long), colMaxLength = null, colNotNull = false, colChecks = null
                    },
                    new ColumnStructure{ 
                        colName = "ExtIDOperatore", colType = typeof(long), colMaxLength = null, colNotNull = false, colChecks = null
                    },
                }
            ); 
        } 
        
        public static bool DataFineMaggioreDataInizio(DateTime dataInizio, DateTime dataFine, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport)
        {
            if (dataFine > dataInizio)
                return true;
            else
            {
                string msg = "Data finale minore di quella iniziale!";
                if (errReport == null)
                    errReport = new List<string>();
                errReport.Add(msg);
                return false;
            }
        }
    }
}