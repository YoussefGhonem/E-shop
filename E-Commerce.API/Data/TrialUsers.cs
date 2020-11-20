
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using E_Commerce.API.Models;

namespace E_Commerce.API.Data
{    public class TrialData
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public TrialData(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
           _roleManager = roleManager;
           _userManager = userManager;
        }

        public void TrialUsers()
        {
            if (!_userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserTrialData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
     
                foreach (var user in users)
                {
                    // user.Photos.ToList().ForEach(p=>p.IsApproved=true);
                    _userManager.CreateAsync(user, "123#Aa").Wait();
                   // _userManager.AddToRoleAsync(user,"User").Wait();
                }

            }

        }

    }

    }
