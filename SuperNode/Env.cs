using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode
{
    internal class Env
    {
        public static bool IsMoiblePlatform
        {
            get
            {
#if WINDOWS
                return false;
#else
                return true;
#endif
            }
        }
    }
}
