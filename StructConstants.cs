using System.Collections.Generic;

namespace RevitTools
{
    public class StructConstants
    {
        static public List<int> RebarDiameters = new List<int>()
        {
            6, 8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 32, 36, 40
        };

        static public Dictionary<string, int> RebarClasses = new Dictionary<string, int>
        {
            { "А240", 240 },
            { "А500С", 501 }
        };

        
    }
}
