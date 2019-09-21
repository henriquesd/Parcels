using System;

namespace Parcels.Models
{
    public class Department
    {
        public void Handler(Parcel parcel)
        {
            var message = "The parcel was handled by " + parcel.Department.ToString() + " Department";

            if (parcel.Signed)
                message += ", and it was signedd off by the Insurance department";

            message += " - Weight: " + parcel.Weight.ToString() + " Value: " + parcel.Value.ToString();

            Console.WriteLine(message);
        }
    }
}
