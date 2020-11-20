using System.Threading.Tasks;
using System;
using E_Commerce.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce.API.Data
{
    public class E_CommerceRepo : IE_CommerceRepo
    {
        private readonly DataContext _context;

        public E_CommerceRepo(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<bool> EmailExists(string email)
        {
            if(await _context.Users.AnyAsync(a=>a.Email==email))return true;
            return false;
        }

        public async Task<IEnumerable<Product>> GetMyProducts(string userId)
        {
            var MyProduct=await _context.Products.Where(i=>i.UserId==userId).ToListAsync();
            return MyProduct;
        }

        public async Task<Product> GetProduct(int id)
        {
           var Product=await _context.Products.Include(u=>u.Photos).FirstOrDefaultAsync(u=>u.Id==id);
           return Product;
        }
         public async Task<Photo> GetPhoto(int id)
        {
           var photo=await _context.Photos.FirstOrDefaultAsync(u=>u.Id==id);
           return photo;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
           var Products=await _context.Products.Include(u=>u.Photos).ToListAsync();
           return Products;
        }

        public async Task<User> GetUser(string id)
        {
             var user=await _context.Users.Include(u=>u.Products).FirstOrDefaultAsync(u=>u.Id==id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users=await _context.Users.Include(u=>u.Products).ToListAsync();
            return users;
        }

        public  async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> UserNameExists(string username)
        {
           if(await _context.Users.AnyAsync(a=>a.UserName==username))return true;
           return false;
        }
    }
}
