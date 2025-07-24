namespace RevitTools
{
    public class Calculator
    {
        public static double FromMmToFeet(double mm)
        {
            return mm / 304.8;
        }

        public static double FromFeetToMm(double feet)
        {
            return feet * 304.8;
        }
    }
}
