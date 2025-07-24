using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitTools
{
    public class Checker
    {
        public static bool IsParametersExist(Element element, List<string> parameterNames)
        {
            List<string> missingParameters = new List<string>();

            foreach (string parameterName in parameterNames)
            {
                if (element.LookupParameter(parameterName) == null) missingParameters.Add(parameterName);
            }
            
            if (missingParameters.Count == 0)
            {
                return true;
            }
            else
            {
                TaskDialog.Show("Ошибка", $"Параметры отсутствуют: {string.Join(", ", missingParameters)}");
                return false;
                
            }
        }
    }
}
