using System;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }  // Cloudinary Settings
        public Product Product { get; set; }
        public int ProductId { get; set; }
        //public bool IsApproved { get; set; }
    }
}