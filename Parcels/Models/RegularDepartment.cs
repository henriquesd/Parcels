namespace Parcels.Models
{
    public static class RegularDepartment
    {
        public static void HandlerRegularDepartment(this Department department, Parcel parcel)
        {
            parcel.Department = DepartmentEnum.Regular;
            department.Handler(parcel);
        }
    }
}
