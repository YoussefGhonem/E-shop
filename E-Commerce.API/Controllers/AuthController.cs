using System.Linq;
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
using Microsoft.IdentityModel.Logging;
using E_Commerce.API.Data;

namespace E_Commerce.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IE_CommerceRepo _repo;

        public AuthController(UserManager<User> userManager,RoleManager<Role> roleManager ,
        SignInManager<User> signInManager, IConfiguration config,
        IMapper mapper,IE_CommerceRepo repo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = config;
            _mapper = mapper;
            _repo = repo;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            // 3- Roles
            await CreateRoles();
            await CreateAdmin();
            var user = await _userManager.FindByNameAsync(userForLoginDto.username);
            if(user == null)
                 return NotFound("Email or Password Not Found Please Try Again");
            var result = await _signInManager.CheckPasswordSignInAsync(user,userForLoginDto.password,false);
            if(result.Succeeded){
                var appUser = await _userManager.Users.FirstOrDefaultAsync(
                    u=>u.NormalizedUserName==userForLoginDto.username.ToUpper()
                );
                var userToReturn = _mapper.Map<UserForListDto>(appUser);

                 // 4- Roles
                if (await _roleManager.RoleExistsAsync("User"))
                {
                    if (!await _userManager.IsInRoleAsync(user, "User") && !await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                }
                return Ok(new
            {
                token = GenerateJwtToken(appUser).Result,
                user = userToReturn
            });
            }
            return Unauthorized();
        }
        private async Task<string> GenerateJwtToken(User user)
        {
           // IdentityModelEventSource.ShowPII = true;
            var claims = new List<Claim>{ // الحجات اللي هتتحط داخل التوكين
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

          // 1- Roles
        private async Task CreateAdmin(){
            var admin=await _userManager.FindByNameAsync("Adminn");
            if(admin==null){
                var newUser=new User{
                    Email = "admin@admin.com",
                    UserName = "Admin",
                    PhoneNumber = "0796544854",
                    EmailConfirmed = true
                };
                var createAdmin=await _userManager.CreateAsync(newUser,"123#Aa");
                if(createAdmin.Succeeded){
                    if(await _roleManager.RoleExistsAsync("Admin"))
                        await _userManager.AddToRoleAsync(newUser,"Admin");
                }
            }
        }
        // 2- Roles
        private async Task CreateRoles(){
            if(_roleManager.Roles.Count()<1){
                var role=new Role{
                    Name="Admin"
                };
                await _roleManager.CreateAsync(role);
                role=new Role{
                    Name="Useer"
                };
                await _roleManager.CreateAsync(role);
            }
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto){

            if (userForRegisterDto == null) { return NotFound(); }
            
            if(ModelState.IsValid){
                if(await _repo.EmailExists(userForRegisterDto.Email))
                    return BadRequest("email is Taken Before");
                if(await _repo.UserNameExists(userForRegisterDto.UserName))
                    return BadRequest("UserName is Taken Before");
            }
            var userToCreate=_mapper.Map<User>(userForRegisterDto);
            var result=await _userManager.CreateAsync(userToCreate,userForRegisterDto.Password);
            var userToReturn=_mapper.Map<UserForDetailsDto>(userToCreate);
            if(result.Succeeded){
                return CreatedAtRoute("GetUser",new{controller="Users",id=userToCreate.Id},userToReturn);
            }
            return BadRequest(result.Errors);
        }
    }
}
