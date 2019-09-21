namespace Parcels.Models
{
    public static class MailDepartment
    {
        public static void HandlerMailDepartment(this Department department, Parcel parcel)
        {
            parcel.Department = DepartmentEnum.Mail;
            department.Handler(parcel);
        }
    }
}
