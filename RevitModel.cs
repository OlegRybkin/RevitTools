using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitTools
{
    public class RevitModel
    {
        static public void RotateAroundVerticalAxis(FamilyInstance familyInstance, XYZ point, double angle)
        /// <summary>
        /// Копирует параметры из заданного элемента
        /// </summary>
        /// <param name="hostElement">Элемент, параметры которого будут копироваться</param>
        /// <param name="currentElement">Элемент, в который будут записываться параметры</param>
        /// <param name="groupKR">Параметр "обр_ФОП_Группа КР", который будет записан в элемент</param>
        static public void CopyParameters(Element hostElement, Element currentElement, string groupKR)
        {
            Line axisLine = Line.CreateBound
                (
                    point,
                    new XYZ
                    (
                        point.X,
                        point.Y,
                        point.Z + 10
                        )
                );
            try
            {
                currentElement.LookupParameter("ФОП_Блок СМР").Set(hostElement.LookupParameter("ФОП_Блок СМР").AsString());
                currentElement.LookupParameter("ФОП_Секция СМР").Set(hostElement.LookupParameter("ФОП_Секция СМР").AsString());
                currentElement.LookupParameter("ФОП_Этаж СМР").Set(hostElement.LookupParameter("ФОП_Этаж СМР").AsString());

            familyInstance.Location.Rotate(axisLine, angle);
                currentElement.LookupParameter("обр_ФОП_Раздел проекта").Set(hostElement.LookupParameter("обр_ФОП_Раздел проекта").AsString());
                currentElement.LookupParameter("обр_ФОП_Марка ведомости расхода").Set(hostElement.LookupParameter("обр_ФОП_Марка ведомости расхода").AsString());
                currentElement.LookupParameter("обр_ФОП_Орг. уровень").Set(hostElement.LookupParameter("обр_ФОП_Орг. уровень").AsDouble());
                currentElement.LookupParameter("обр_ФОП_Группа КР").Set(groupKR);
        }

        static public IList<ElementId> MirrorElementsOnPlane(Document document, ICollection<ElementId> elementsToMirror, XYZ point, XYZ direction, bool mirrorCopies)
        {
            Plane plane = Plane.CreateByThreePoints
                (
                    point,
                    new XYZ
                    (
                        point.X + direction.X * 10,
                        point.Y + direction.Y * 10,
                        point.Z
                        ),
                    new XYZ
                    (
                        point.X,
                        point.Y,
                        point.Z + 10
                        )
                );

            IList<ElementId> elementIds = ElementTransformUtils.MirrorElements(document, elementsToMirror, plane, mirrorCopies);

            return elementIds;
            catch { }
        }

    }
}
