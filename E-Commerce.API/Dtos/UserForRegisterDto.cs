
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.API.Dtos
{
    public class UserForRegisterDto
    {
        [StringLength(256), Required, EmailAddress]
        public string Email { get; set; }
        [StringLength(256), Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        //         //[Required]
        //         public string Username { get; set; }
        // //[StringLength(8,MinimumLength=4,ErrorMessage=" ")]
        //         //[Required]
        //         public string Password { get; set; }
        //         public string Email { get; set; }      
        //         public string Gender { get; set; }
        //         public DateTime DateOfBirth { get; set; }
        //         public string City { get; set; }
        //         public string Country { get; set; }
        //         public DateTime Created { get; set; }
        //         public DateTime LastActive { get; set; }
        //         public UserForRegisterDto()
        //         {
        //             Created = DateTime.Now;
        //             LastActive = DateTime.Now;

        //         }

    }
}