using System;
using System.Collections.Generic;

namespace OperationStatusNotifier
{
    public class Notifier
    {
        private static Guid callID = Guid.Empty;
        public static List<string> errors = new List<string>();
        public static List<string> warnings = new List<string>();
        public static List<string> infos = new List<string>();

        public static Guid GetCallID()
        {
            return callID;
        }

        private static Notifier instance = null;
        private static readonly object padlock = new object();

        private Notifier(Guid callID_)
        {
            callID = callID_;
        }
        private Notifier()
        {
            callID = new Guid();
        }

        public static Notifier GetNotifier()
        {
            return instance;
        }
        public static Notifier GetNotifier(Guid callID)
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Notifier(callID);
                    }
                }
            }
            return instance;
        }

        public void AddError(string error)
        {
            errors.Add(error);
        }
        public void AddInfo(string info)
        {
            infos.Add(info);
        }
        public void AddWarning(string warning)
        {
            warnings.Add(warning);
        }
        public List<string> GetErrors()
        {
            return errors;
        }
        public List<string> GetInfos()
        {
            return infos;
        }
        public List<string> GetWarnings()
        {
            return warnings;
        }
    }
}
