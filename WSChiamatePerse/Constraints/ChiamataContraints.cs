using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                        colName = "DataOraInizioChiamata", colType = typeof(DateTime), colMaxLength = null, colNotNull = true, colChecks = null
                    },
                    new ColumnStructure{ 
                        colName = "DataOraFineChiamata", colType = typeof(DateTime), colMaxLength = null, colNotNull = false, colChecks = null
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

        
    }
}