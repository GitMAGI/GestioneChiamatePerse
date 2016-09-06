using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCPData
{
    public class GCPBLL
    {
        public static object AddChiamata(Dictionary<string, object> data)
        {
            int result = -1;

            GCPDAL dal = new GCPDAL();

            ChiamataDTO d = new ChiamataDTO();

            foreach (KeyValuePair<string, object> datum in data)
            {
                if (d.GetType().GetProperty(datum.Key) != null)
                {
                    d.GetType().GetProperty(datum.Key).SetValue(d, datum.Value, null);
                }
                else
                {

                }
            }
            
            result = dal.AddChiamata(d);

            dal = null;

            return result;
        }

        public static object[] GetChiamate()
        {
            object[] result = null;
            GCPDAL dal = new GCPDAL();

            result = dal.GetChiamataAll();

            return result;
        }

    }
}
