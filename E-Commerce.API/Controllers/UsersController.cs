using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.API.Dtos;
using E_Commerce.API.Models;
using E_Commerce.API.Data;

namespace E_Commerce.API.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IE_CommerceRepo _repo;

        public UsersController(IMapper mapper,IE_CommerceRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet("{id}",Name="GetUser")]
        public async Task<IActionResult>GetUser(string id){
           // var isCurrentUser=int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)==id;
            var user=await _repo.GetUser(id);
            var userToReturn=_mapper.Map<UserForDetailsDto>(user);
            return Ok(userToReturn);
        }
        
        [HttpGet]
        public async Task<IActionResult>GetUsers(){
            var users=await _repo.GetUsers();
            var userToReturn=_mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(userToReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id,UserUpdateDto userUpdateDto){
            if(id != User.FindFirst(ClaimTypes.NameIdentifier).Value){
                return Unauthorized();
            }
            // هنا انا عايز أجلب الداتا بتاعه اليوز من الداتا بيز علشان اقدر اعدل فيها
            var UserFromDB=await _repo.GetUser(id);
            
            _mapper.Map(userUpdateDto,UserFromDB);
            if(await _repo.SaveAll())return NoContent();
          //  UserFromDB.U
            throw new Exception("Sorry Can not save Data");

        }
        


    }
}
