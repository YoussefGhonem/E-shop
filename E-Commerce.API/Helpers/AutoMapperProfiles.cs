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
    public class  AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //User
            CreateMap<User,UserForListDto>();
            CreateMap<User,UserForDetailsDto>();
            CreateMap<UserForRegisterDto,User>();
            CreateMap<UserUpdateDto,User>();

            //Product
            CreateMap<Product,ProductDetailsDto>()
            .ForMember(dest=>dest.PhotoURL,opt=>{opt.MapFrom(src=>src.Photos.FirstOrDefault(p=>p.IsMain).Url);});
            CreateMap<Product,ProductListDto>()
            .ForMember(dest=>dest.PhotoURL,opt=>{opt.MapFrom(src=>src.Photos.FirstOrDefault(p=>p.IsMain).Url);});
            CreateMap<ProductUpdateDto,Product>();
            //Photos
            CreateMap<Photo,PhotoForDetailsDto>();
            CreateMap<PhotoForCreateDto,Photo>();
            CreateMap<Photo,PhotoForReturnDto>();
      
        }
    }
}