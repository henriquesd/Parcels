namespace Parcels.Models
{
    public class Parcel
    {
        public decimal Weight { get; set; }
        public decimal Value { get; set; }
        public DepartmentEnum? Department { get; set; }
        public bool Signed { get; set; }
    }
}