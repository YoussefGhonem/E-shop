using System;
using E_Commerce.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Data
{
    public class DataContext : IdentityDbContext<User,Role,String>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Photo> Photos{ get; set; }
        public DbSet<Product> Products{ get; set; }
    }
}
