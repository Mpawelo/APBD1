using System;

namespace APBD1.Domain.Users
{
    public enum UserRole
    {
        Student,
        Employee
    }

    public abstract class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public UserRole Role { get; private set; }
        
        public int MaxConcurrentRentals { get; private set; } 

        protected User(string firstName, string lastName, UserRole role, int maxConcurrentRentals)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Imię i nazwisko użytkownika nie mogą być puste.");

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            MaxConcurrentRentals = maxConcurrentRentals;
        }
    }
}