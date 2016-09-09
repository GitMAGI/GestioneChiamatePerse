using IBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;

namespace BusinessLogicLayer
{
    public partial class BLL : IBLL.IBLL
    {
        public static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IDAL.IDAL dal;

        public BLL(IDAL.IDAL dal)
        {
            this.dal = dal;
        }
    }
}
