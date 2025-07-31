using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitTools
{
    public class Geometry
    {
        static public XYZ GetMidPoint(XYZ point1, XYZ point2)
        {
            XYZ midPoint = new XYZ
                (
                    0.5 * (point1.X + point2.X),
                    0.5 * (point1.Y + point2.Y),
                    0.5 * (point1.Z + point2.Z)
                );

            return midPoint;
        }

        static public bool IsVectorsMatches (XYZ vector1, XYZ vector2)
        {
            if (Math.Round(vector1.X, 2) == Math.Round(vector2.X, 2) &&
                Math.Round(vector1.Y, 2) == Math.Round(vector2.Y, 2) &&
                Math.Round(vector1.Z, 2) == Math.Round(vector2.Z, 2))
            {
                return true;
            }
            return false;
        }
    }
}
