using System;
using System.Collections.Generic;
using ZwajApp.API.Dtos;

namespace E_Commerce.API.Dtos
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhotoURL { get; set; }
        public ICollection<PhotoForDetailsDto> Photos { get; set; }
    }
}