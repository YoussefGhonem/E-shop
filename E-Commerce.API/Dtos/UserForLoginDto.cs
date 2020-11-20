using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.API.Dtos
{
    public class UserForLoginDto
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}