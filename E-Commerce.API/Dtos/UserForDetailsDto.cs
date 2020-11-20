using System;
using System.Collections.Generic;

namespace E_Commerce.API.Dtos
{
    public class UserForDetailsDto
    {
       public string Email { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Bio { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
         public ICollection<ProductDetailsDto> Products { get; set; }
  

    }
}