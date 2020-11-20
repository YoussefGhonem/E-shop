using System.Threading.Tasks;
using System;
using E_Commerce.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_Commerce.API.Data
{
    public class AuthRepo : IAuthRepo
    {
        private readonly DataContext _context;

        public AuthRepo(DataContext context)
        {
            _context = context;
        }


        public async Task<bool> EmailExists(string email)
        {
            if(await _context.Users.AnyAsync(a=>a.Email==email))return true;
            return false;
        }

        public async Task<bool> UserNameExists(string username)
        {
           if(await _context.Users.AnyAsync(a=>a.UserName==username))return true;
           return false;
        }
    }
}
