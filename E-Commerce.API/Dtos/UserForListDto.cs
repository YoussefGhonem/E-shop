using System;

namespace E_Commerce.API.Dtos
{
    public class UserForListDto
    {
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Bio { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
      
        public UserForListDto()
        {
            this.Created=DateTime.Now;
        }
    }
}