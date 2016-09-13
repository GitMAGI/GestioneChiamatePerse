using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneralPurposeLib
{
    public abstract class TableStructure
    {
        public List<ColumnStructure> table = null;

        public TableStructure()
        {
            this.table = Initialization();
        }

        protected abstract List<ColumnStructure> Initialization();

        public ColumnStructure? GetStructureByColName(string colName)
        {
            if (this.table == null)
            {
                throw new NullReferenceException("Table Structure Not Initialized!");
            }

            ColumnStructure? found = null;
            foreach (ColumnStructure col in this.table)
            {
                if (col.colName == colName)
                {
                    found = col;
                }
            }

            return found;
        }

        public bool ValidationNotNullable(ColumnStructure colStruct, object data)
        {
            bool result = true;

            if (data == null)
                if (colStruct.colNotNull)                
                    result = false;

            return result;
        }
        public bool ValidationChecksConstraints(ColumnStructure colStruct, object data)
        {
            bool result = true;

            // 1. MaxLength
            if (colStruct.colMaxLength != null)
                if (data.ToString().Length > colStruct.colMaxLength)
                    result = false;       
            
            // 2. Checks Validation
            if (colStruct.colChecks != null)
            {
                foreach (string check in colStruct.colChecks)
                {

                }
            }
                
            return result;
        }
        public bool ValidationDataTypeAndParsing<TR>(string colValue, out TR converted)
        {
            bool result = true;
            converted = default(TR);

            try
            {                
                if (colValue != null)
                {
                    result = TryConvertFromString<TR>(colValue, out converted);
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public static bool TryConvertFromString<TR>(string input, out TR output)
        {
            bool result = false;
            try
            {
                output = (TR)Convert.ChangeType(input, typeof(TR));
                result = true;
            }
            catch (InvalidCastException)
            {
                output = default(TR);
                //Conversion is not unsupported
            }
            catch (FormatException)
            {
                output = default(TR);
                //string input value was in incorrect format
            }
            catch (OverflowException)
            {
                output = default(TR);
                //narrowing conversion between two numeric types results in loss of data
            }
            return result;
        }

        public bool ValidationRow(Dictionary<string, string> dataRow, ref Dictionary<string, object> dataRowConverted, ref List<string> errReport)
        {
            bool result = true;

            foreach (KeyValuePair<string, string> entry in dataRow)
            {
                //entry.Value
                //entry.Key
                ColumnStructure? colStruct = GetStructureByColName(entry.Key);
                if (colStruct == null)
                {
                    string msg = "Fatal Error! Bad dataRow index! {0} not found into TableStructure definition!";
                    if (errReport == null)
                        errReport = new List<string>();
                    errReport.Add(msg);
                    throw new KeyNotFoundException(string.Format(msg));
                }

                if (!ValidationNotNullable(colStruct.Value, entry.Value))
                {
                    result = false;
                    string msg = string.Format("Attribute {0} must be not null!", entry.Key);
                    if (errReport == null)
                        errReport = new List<string>();
                    errReport.Add(msg);
                }
                else
                {
                    object[] args = new object[2];
                    args[0] = entry.Value;

                    MethodInfo method = typeof(TableStructure).GetMethod("ValidationDataTypeAndParsing");
                    MethodInfo generic = method.MakeGenericMethod(colStruct.Value.colType);
                    object genericResult = generic.Invoke(this, args);

                    bool tmpRes = (bool)genericResult;

                    if (tmpRes)
                    {
                        if (dataRowConverted == null)
                            dataRowConverted = new Dictionary<string, object>();
                        dataRowConverted.Add(entry.Key, args[1]);
                    }
                    else
                    {
                        result = tmpRes;
                    }
                }

            }

            return result;
        }
    }

    public struct ColumnStructure
    {
        public string colName;
        public Type colType;
        public int? colMaxLength;
        public bool colNotNull;
        public List<string> colChecks;
    }
}
