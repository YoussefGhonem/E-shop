using System.Threading.Tasks;
using System;
using E_Commerce.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_Commerce.API.Data
{
    public interface IAuthRepo
    {

        Task <bool>EmailExists(string email);
        Task <bool>UserNameExists(string username);
    } 
}
