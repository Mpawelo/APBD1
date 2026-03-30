namespace APBD1.Domain.Users
{
    public class Employee : User
    {
        private const int EmployeeMaxRentals = 5;

        public Employee(string firstName, string lastName) 
            : base(firstName, lastName, UserRole.Employee, EmployeeMaxRentals)
        {
        }
    }
}