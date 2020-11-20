
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.API.Models;
using ZwajApp.API.Dtos;

namespace E_Commerce.API.Dtos
{
    public class  CloudinarySettings 
    {
        public string CloudName { get; set; }
        public string ApiKey { get; set; }
        
        public string ApiSecret { get; set; }
        
        
        
    }
}