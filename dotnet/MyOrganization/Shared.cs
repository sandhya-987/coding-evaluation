using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrganization
{
    public static class Counter
    {
        private static int _currentNum = 1;
        public static int NextNumber => _currentNum++;
    }
}
