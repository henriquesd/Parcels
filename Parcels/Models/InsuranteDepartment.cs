namespace Parcels.Models
{
    public static class InsuranteDepartment
    {
        public static void HandlerInsuranteDepartment(this Department department, Parcel parcel)
        {
            parcel.Signed = true;
        }
    }
}
