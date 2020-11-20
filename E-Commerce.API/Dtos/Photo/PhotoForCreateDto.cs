
using System;
using Microsoft.AspNetCore.Http;

namespace ZwajApp.API.Dtos
{
    public class PhotoForCreateDto
    {
        public IFormFile File { get; set; }
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public string publicId { get; set; }
        public PhotoForCreateDto()
        {
          DateAdded = DateTime.Now;  
        }

    }
}