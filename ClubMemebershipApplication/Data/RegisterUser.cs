using ClubMemebershipApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMemebershipApplication.FieldValidators;

namespace ClubMemebershipApplication.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExists(string emailAdress)
        {
            bool emailExists = false;

            using (var dbContext = new ClubMembershipDbContext())
            {
                emailExists = dbContext.Users.Any( u => u.EmailAddress.ToLower().Trim() == emailAdress.ToLower().Trim());
            }
            
            return emailExists;
        }

        public bool Register(string[] fields)
        {
            using (var dbContext = new ClubMembershipDbContext())
            {
                User user = new User
                {
                    EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                    AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine],
                    AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine],
                    AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode],

                };

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            return true;

        }
    }
}
