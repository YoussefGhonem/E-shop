using System.Collections;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace E_Commerce.API.Models
{
    public class User:IdentityUser
    {
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Bio { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Product> Products { get; set; }
        
    }
}