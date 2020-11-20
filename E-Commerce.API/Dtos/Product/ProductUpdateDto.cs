using System;
using System.Collections.Generic;
using ZwajApp.API.Dtos;

namespace E_Commerce.API.Dtos
{
    public class ProductUpdateDto
    {
    
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Address { get; set; }

        // public string PhotoURL { get; set; }
        // public ICollection<PhotoForDetailsDto> Photos { get; set; }
    }
}