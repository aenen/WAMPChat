using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WampSharp.V2.Rpc;

namespace WAMPChat.Wamp
{
    public class WampTestCallee
    {
        private static int count = 0;
        public static event Action<int> CountChanged;

        [WampProcedure("wamp.test.click")]
        public void Click()
        {
            count++;
            CountChanged?.Invoke(count);
        }

        [WampProcedure("wamp.test.get.count")]
        public int GetCount()
        {
            return count;
        }
    }
}