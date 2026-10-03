using InspectionCenter.Domain.Entities;
using InspectionCenter.Domain.Enums;
using InspectionCenter.Repositories.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.SeedAdmin
{
    public static class AdminSeedData
    {
        public static async Task EnsureAdminInformation(IUserRepository userRepository)
        {
            var adminEmail = "admin@gmail.com";
            var adminPhonenumber = "09351305594";
            var adminPassword = "Ad22@88";

            var existUser = await userRepository.FindByEmailAsync(adminEmail);

            if (existUser is null)
                return;

            var existUserByPhonenumber = await userRepository.FindByPhoneNumberAsync(adminPhonenumber);

            if (existUserByPhonenumber is null)
                return;

            var admin = new User("AdminFirstName", "AdminLastName", adminPhonenumber,
                adminEmail, adminPassword, 20);

            admin.SetRole(Role.Admin);

            await userRepository.AddAsync(admin);
        }
    }
}
