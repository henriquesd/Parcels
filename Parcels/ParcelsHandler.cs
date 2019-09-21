using Parcels.Helpers;
using Parcels.Models;

namespace Parcels
{
    public class ParcelsHandler
    {
        public static void Handler()
        {
            var listParcel = XmlFileReader.LoadXml();

            var department = new Department();

            foreach (var item in listParcel)
            {
                HandleParcel(department, item);
            }
        }

        public static void HandleParcel(Department department, Parcel item)
        {
            var weight = item.Weight;
            var value = item.Value;

            if (value > 1000)
                department.HandlerInsuranteDepartment(item);

            if (weight <= 1)
                department.HandlerMailDepartment(item);
            else if (weight > 1 && weight <= 10)
                department.HandlerRegularDepartment(item);
            else if (weight > 10)
                department.HandlerHeavyDepartment(item);
        }
    }
}
