﻿namespace DataAccess.BaseImplementation
{
    using DataAccess.Interfaces;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class DbDefaultUserInitializer
    {
        public static async Task InitDbUser(UserManager<User> userManager, IRepository<CarWash> carWashRepository)
        {
            if (await userManager.FindByNameAsync("Mobile") == null)
            {
                var user = new User() { UserName = "Mobile" };
                var result = await userManager.CreateAsync(user, "Moblie_0");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, UserRoles.MobileClient);
            }

            //администратор автомойки 1
            if (await userManager.FindByNameAsync("Admin") == null)
            {
                var user = new User() { UserName = "Admin" };
                var result = await userManager.CreateAsync(user, "Admin_0");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);

                CarWash carWash = new CarWash()
                {
                    Phone = "123456789",
                    Name = "CarWashName",
                    Longitude = "123.4324",
                    Latitude = "3333.213",
                    Location = "Tomsk",
                    StartWorkTime = "09-00",
                    EndWorkTime = "21-00",
                    BoxesQuantity = 5,
                    Services = null,
                    Users = new List<User>()
                };
                carWash.Users.Add(user);
                await carWashRepository.AddAsync(new List<CarWash> { carWash });
            }

            //администратор автомойки 1
            if (await userManager.FindByNameAsync("Admin1") == null)
            {
                var user = new User() { UserName = "Admin1" };
                var result = await userManager.CreateAsync(user, "Admin_1");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);

                var carWash = await carWashRepository.GetAsync(item => item.Name == "CarWashName");
                carWash.Users.Add(user);
                await carWashRepository.UpdateAsync(carWash);
            }

            //администратор автомойки 2
            if (await userManager.FindByNameAsync("Admin2") == null)
            {
                var user = new User() { UserName = "Admin2" };
                var result = await userManager.CreateAsync(user, "Admin_2");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);

                CarWash carWash = new CarWash()
                {
                    Phone = "123456789",
                    Name = "CarWashName2",
                    Longitude = "123.4324",
                    Latitude = "3333.213",
                    Location = "Tomsk",
                    StartWorkTime = "09-00",
                    EndWorkTime = "21-00",
                    BoxesQuantity = 5,
                    Services = null,
                    Users = new List<User>()
                };
                carWash.Users.Add(user);
                await carWashRepository.AddAsync(new List<CarWash> { carWash });
            }
        }
    }
}
