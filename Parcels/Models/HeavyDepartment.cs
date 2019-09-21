namespace Parcels.Models
{
    public static class HeavyDepartment
    {
        public static void HandlerHeavyDepartment(this Department department, Parcel parcel)
        {
            parcel.Department = DepartmentEnum.Heavy;
            department.Handler(parcel);
        }
    }
}
