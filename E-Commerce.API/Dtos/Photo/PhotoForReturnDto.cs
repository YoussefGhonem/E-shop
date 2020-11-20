
using System;

namespace ZwajApp.API.Dtos
{
    public class PhotoForReturnDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }  // Cloudinary 
        public DateTime DateAdded { get; set; }
        public int ProductId { get; set; }
        public bool IsMain { get; set; }

    }
}