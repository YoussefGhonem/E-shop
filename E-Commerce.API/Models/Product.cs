using System;
using System.Collections.Generic;

namespace E_Commerce.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        //public bool IsApproved { get; set; }
    }
}