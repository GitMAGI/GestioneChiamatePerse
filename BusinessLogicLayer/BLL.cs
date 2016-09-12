namespace BusinessLogicLayer
{
    public partial class BLL : IBLL.IBLL
    {
        public static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static readonly OperationStatusNotifier.Notifier globalNotfier = OperationStatusNotifier.Notifier.GetNotifier();

        private IDAL.IDAL dal;

        public BLL(IDAL.IDAL dal)
        {
            this.dal = dal;
        }
    }
}
