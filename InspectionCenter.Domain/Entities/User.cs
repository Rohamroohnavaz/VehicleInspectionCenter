using InspectionCenter.Domain.DomainExceptions;
using InspectionCenter.Domain.Entities.Abstraction;
using InspectionCenter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            
        }

        public User(string firstName ,string lastName ,string email ,string password ,int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Age = age;
            Validate();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int Age { get; private set; }
        public Role UserRole { get; private set; }
        public List<Car> Cars { get; set; } = new();

        public void SetRole(Role role)
        {
            UserRole = role;
        }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new NullNameException("Name can't be null !");

            if (string.IsNullOrWhiteSpace(LastName))
                throw new NullNameException("Name can't be null !");

            if (string.IsNullOrWhiteSpace(Email))
                throw new NullLoginDataException("Email/Password is null !!");

            if (string.IsNullOrWhiteSpace(Password))
                throw new NullLoginDataException("Email/Password is null !!");
        }
    }
}
