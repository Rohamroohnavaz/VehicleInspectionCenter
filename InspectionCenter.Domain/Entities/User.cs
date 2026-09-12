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

        public User(string firstName, string lastName, string phoneNumber, string email, string password, int age)
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

        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetRole(Role role)
        {
            UserRole = role;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void SetAge(int age)
        {
            Age = age;
        }

        public void UpdateUserInfo(string email, string password, string phoneNumber, Role role)
        {
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            UserRole = role;
            Validate();
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
