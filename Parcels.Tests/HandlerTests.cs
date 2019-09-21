using Parcels.Models;
using Xunit;

namespace Parcels.Tests
{
    public class HandlerTests
    {
        [Theory]
        [InlineData(0.1, 1)]
        [InlineData(0.1, 1000)]
        [InlineData(1, 1)]
        [InlineData(1, 1000)]
        public void Handler_MailDepartment_ShouldSetMailDepartment(decimal weight, decimal value)
        {
            // Arrange
            var parcel = new Parcel
            {
                Weight = weight,
                Value = value
            };
            var department = new Department();

            // Act
            department.HandlerMailDepartment(parcel);

            // Assert
            Assert.Equal(DepartmentEnum.Mail, parcel.Department);
        }

        [Theory]
        [InlineData(1.1, 1)]
        [InlineData(1.1, 1000)]
        [InlineData(10, 1)]
        [InlineData(10, 1000)]
        public void Handler_RegularDepartment_ShouldSetRegularDepartment(decimal weight, decimal value)
        {
            // Arrange
            var parcel = new Parcel
            {
                Weight = weight,
                Value = value
            };
            var department = new Department();

            // Act
            department.HandlerRegularDepartment(parcel);

            // Assert
            Assert.Equal(DepartmentEnum.Regular, parcel.Department);
        }

        [Theory]
        [InlineData(11, 1)]
        [InlineData(1000, 1000)]
        public void Handler_HeavyDepartment_ShouldSetHeavyDepartment(decimal weight, decimal value)
        {
            // Arrange
            var parcel = new Parcel
            {
                Weight = weight,
                Value = value
            };
            var department = new Department();

            // Act
            department.HandlerHeavyDepartment(parcel);

            // Assert
            Assert.Equal(DepartmentEnum.Heavy, parcel.Department);
        }

        [Theory]
        [InlineData(1000, 0.1, DepartmentEnum.Mail)]
        [InlineData(1000, 1, DepartmentEnum.Mail)]
        [InlineData(1000, 1.1, DepartmentEnum.Regular)]
        [InlineData(1000, 10, DepartmentEnum.Regular)]
        [InlineData(1000, 11, DepartmentEnum.Heavy)]
        [InlineData(1000, 1000, DepartmentEnum.Heavy)]
        public void Handler_InsuranceDepartment_ShouldBeSigned(decimal value, decimal weight, DepartmentEnum expectedDeparment)
        {
            // Arrange
            var parcel = new Parcel
            {
                Value = value,
                Weight = weight,
                Department = expectedDeparment
            };
            var department = new Department();
            var expectedObject = new Parcel
            {
                Signed = true,
                Department = expectedDeparment
            };

            // Act
            department.HandlerInsuranteDepartment(parcel);

            // Assert
            Assert.Equal(expectedObject.Department, parcel.Department);
            Assert.Equal(expectedObject.Signed, parcel.Signed);
        }

        [Theory]
        [InlineData(0.1, 1, DepartmentEnum.Mail, false)]
        [InlineData(0.1, 1000, DepartmentEnum.Mail, false)]
        [InlineData(0.1, 1001, DepartmentEnum.Mail, true)]
        [InlineData(1.1, 1, DepartmentEnum.Regular, false)]
        [InlineData(1.1, 1000, DepartmentEnum.Regular, false)]
        [InlineData(1.1, 1001, DepartmentEnum.Regular, true)]
        [InlineData(11, 1, DepartmentEnum.Heavy, false)]
        [InlineData(1000, 1000, DepartmentEnum.Heavy, false)]
        [InlineData(1000, 1001, DepartmentEnum.Heavy, true)]
        public void HandlerParcel_ShouldHandleBasedOnWeightAndValue(decimal weight, decimal value, DepartmentEnum expectedDepartment, bool expectedSigned)
        {
            // Arrange
            var parcel = new Parcel
            {
                Weight = weight,
                Value = value
            };
            var department = new Department();

            // Act
            ParcelsHandler.HandleParcel(department, parcel);

            // Assert
            Assert.Equal(expectedDepartment, parcel.Department);
            Assert.Equal(expectedSigned, parcel.Signed);
        }
    }
}
