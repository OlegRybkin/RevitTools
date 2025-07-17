using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitTools
{
    public enum RebarClass
    {
        A240,
        A500,
        A500C
    }

    public class StructConstants
    {
        static public List<int> RebarDiameters = new List<int>()
        {
            6, 8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 32, 36, 40
        };

        
    }
}
