using System.Threading.Tasks;
using System;
using E_Commerce.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_Commerce.API.Data
{
    public interface IE_CommerceRepo
    {

        void Add <T>(T entity)where T:class;// Add Any entity
        void Delete <T>(T entity)where T:class;
        Task <bool> SaveAll();

        // User
        Task<IEnumerable<User>> GetUsers();
        Task <User> GetUser(string id);
        Task <bool> EmailExists(string email);
        Task <bool> UserNameExists(string username);
        
        // Product
        Task <Product> GetProduct(int id);
        Task <IEnumerable<Product>> GetProducts();
        Task <IEnumerable<Product>> GetMyProducts(string userId);

        //Photos
        Task <Photo> GetPhoto(int id);

    } 
}
