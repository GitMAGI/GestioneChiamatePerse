using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        public bool ValidationChecksConstraints(ColumnStructure colStruct, object data, Dictionary<string, object> parsedData, ref List<string> errReport)
        {
            bool result = true;

            // 1. MaxLength
            if (colStruct.colMaxLength != null && colStruct.colType == typeof(string))
            {
                if (data.ToString().Length > colStruct.colMaxLength)
                {
                    result = false;
                    string msg = string.Format("Attribute '{0}' exceeds the maximum length available. Actual length is {1} of {2}!", colStruct.colName, data.ToString().Length, colStruct.colMaxLength);
                    if (errReport == null)
                        errReport = new List<string>();
                    errReport.Add(msg);
                }
            }
            // 2. Checks Validation
            if (colStruct.colChecks != null)
            {
                foreach (CheckValidation check in colStruct.colChecks)
                {
                    Type classType = check.libName;
                    string funtionName = check.functionName;

                    // To Implement and understand how to code it! Holy Shit!
                    try
                    {
                        object[] args = new object[check.args.Count + 2];
                        args[0] = data;
                        int i = 1;
                        foreach(string arg in check.args)
                        {
                            args[i] = parsedData[arg];
                            i++;
                        }
                        args[i] = errReport;

                        MethodInfo method = classType.GetMethod(funtionName);
                        object genericResult = method.Invoke(null, args);

                        bool tmpRes = (bool)genericResult;

                        if (!tmpRes)
                        {
                            result = tmpRes;
                            
                            string msg = string.Format("Attribute '{0}' fails checks validation defined into {1}.{2}() function!", colStruct.colName, classType.ToString(), funtionName);
                            if (errReport == null)
                                errReport = new List<string>();
                            string old = errReport.Last();
                            errReport[errReport.Count - 1] = msg + " " + old;


                        }
                    }
                    catch (Exception ex)
                    {
                        string msg = string.Format("Fatal Error during checks validation. Check the function {0}.{1}() is defined as static, return a bool, has the right number of args and doesn't throw unhandled exceptions!", classType.ToString(), funtionName);
                        throw new Exception(msg, ex);
                    }
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
            catch (Exception)
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

            Dictionary<string, bool> convOk = new Dictionary<string, bool>();

            foreach (KeyValuePair<string, string> entry in dataRow)
            {
                ColumnStructure? colStruct = GetStructureByColName(entry.Key);
                if (colStruct == null)
                {
                    string msg = string.Format("Fatal Error! Bad dataRow index! '{0}' not found into TableStructure definition!", entry.Key);
                    if (errReport == null)
                        errReport = new List<string>();
                    errReport.Add(msg);
                    throw new KeyNotFoundException(string.Format(msg));
                }

                // NULLABLE VALIDATION
                if (!ValidationNotNullable(colStruct.Value, entry.Value))
                {
                    result = false;
                    string msg = string.Format("Attribute '{0}' must be not null!", entry.Key);
                    if (errReport == null)
                        errReport = new List<string>();
                    errReport.Add(msg);
                }
                else
                {
                    // PARSING VALIDATION
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
                        string msg = string.Format("Attribute '{0}' Parsing from string to {1} failed! '{2}' is not a {3} parsable string!", entry.Key, colStruct.Value.colType.ToString(), entry.Value, colStruct.Value.colType.ToString());
                        if (errReport == null)
                            errReport = new List<string>();
                        errReport.Add(msg);
                    }
                }

            }

            // CHECKS AND CONSTRAINTS VALIDATION
            if (result)
            {
                foreach (KeyValuePair<string, string> entry in dataRow)
                {
                    ColumnStructure? colStruct = GetStructureByColName(entry.Key);
                    if (!ValidationChecksConstraints((ColumnStructure)colStruct, dataRowConverted[entry.Key], dataRowConverted, ref errReport))
                    {
                        result = false;
                    }
                }
            }
           

            return result;
        } // Can Throw tons of Exception, because of fatal Errors!

        public bool Validation(List<Dictionary<string, string>> data, out List<Dictionary<string, object>> dataConverted, out List<string> errReport)
        {
            bool result = true;

            dataConverted = new List<Dictionary<string, object>>();
            errReport = new List<string>();

            int i = 0;
            foreach (Dictionary<string, string> datum in data)
            {
                Dictionary<string, object> datumConverted = new Dictionary<string, object>();
                dataConverted.Add(datumConverted);
                string msg = string.Format("Line {0} errors: ", i+1);
                errReport.Add(msg);
                bool rowRes = ValidationRow(datum, ref datumConverted, ref errReport);
                if (rowRes)      
                    errReport.Remove(msg);
                else
                    result = false;
                i++;
            }
            if (errReport.Count == 0)
                errReport = null;

            return result;
        }
    }

    public struct ColumnStructure
    {
        public string colName;
        public Type colType;
        public int? colMaxLength;
        public bool colNotNull;
        public List<CheckValidation> colChecks;
    }

    public struct CheckValidation
    {
        public Type libName;
        public string functionName; // Function must be static!!
        public List<string> args; // Other attribute Names of the same row u want to check!! Not add the self attribute
    }
}
