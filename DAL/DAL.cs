using System.Configuration;

namespace DataAccessLayer
{
    public partial class DAL : IDAL.IDAL
    {
        public static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string GCPConnectionString = ConfigurationManager.ConnectionStrings["GCP"].ConnectionString;

        public static readonly OperationStatusNotifier.Notifier globalNotfier = OperationStatusNotifier.Notifier.GetNotifier();
    }
}
