
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.API.Dtos;
using E_Commerce.API.Data;
using E_Commerce.API.Models;
using System.Collections.Generic;

namespace E_Commerce.API.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IE_CommerceRepo _repo;
        public ProductController(IE_CommerceRepo repo,IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}",Name="GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product=await _repo.GetProduct(id);
            var productReturn=_mapper.Map<ProductDetailsDto>(product);
            return Ok(productReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products=await _repo.GetProducts();
            var productsReturn= _mapper.Map<IEnumerable<ProductListDto>>(products);
            return Ok(productsReturn);
            
        } 
        [HttpGet("myproduct/{id}")] // User Id
        public async Task<IActionResult> GetMyProducts(string id)
        {
            var products=await _repo.GetMyProducts(id);
            var productsReturn= _mapper.Map<IEnumerable<ProductListDto>>(products);
            return Ok(productsReturn);
            
        } 

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,ProductUpdateDto model){
            var productFromDB=await _repo.GetProduct(id);
            
            if(productFromDB.UserId==User.FindFirst(ClaimTypes.NameIdentifier).Value){
            _mapper.Map(model,productFromDB);
            if(await _repo.SaveAll())return NoContent();
            }
            if(productFromDB.UserId!=User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {return Unauthorized();}
           
            return BadRequest("Sorry Can not Save Changes");
        }


    }
}
