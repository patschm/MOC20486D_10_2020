using System;
using System.Collections.Generic;
using System.Text;

namespace Misc2
{
    static class StringExtenties
    {
        public static string SponsoredByAcme(this object s, string compName)
        {
            return $"{s} is sponsored by {compName}";
        }
    }
}
