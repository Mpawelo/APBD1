namespace APBD1.Domain.Users
{
    public class Student : User
    {
        private const int StudentMaxRentals = 2; 

        public Student(string firstName, string lastName) 
            : base(firstName, lastName, UserRole.Student, StudentMaxRentals)
        {
        }
    }
}