
using System.Linq;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.API.Dtos;
using E_Commerce.API.Data;
using E_Commerce.API.Models;
using System.Collections.Generic;
using ZwajApp.API.Dtos;
using Microsoft.Extensions.Options;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace E_Commerce.API.Controllers
{
 // this code show u how to build an image upload to cloudniary by dot net core 3.1 web api

    [Route("[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly IE_CommerceRepo _repo;
        private Cloudinary _cloudinary;   // Cloudinary setting 
        public PhotosController(IE_CommerceRepo repo,IMapper mapper,IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;
            _repo = repo;

            // Cloudinary setting
            Account acc=new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary=new Cloudinary(acc);
        }

        [HttpGet("{id}",Name="GetPhoto")]
        public async Task<IActionResult>GetPhoto(int id){
            var photoFromDB=await _repo.GetPhoto(id);
            var photoReturn=_mapper.Map<PhotoForReturnDto>(photoFromDB);
            return Ok(photoReturn);
        }

        [HttpPost("{id}")]
         public async Task<IActionResult> AddPhotoForProduct(int id,[FromForm] PhotoForCreateDto photoForCreateDto){
                var getProductFromDB=await _repo.GetProduct(id);
                if(getProductFromDB.Id!=id)return Unauthorized();

                var file=photoForCreateDto.File;
                var uploadResult =new ImageUploadResult();

                if(file != null && file.Length>0 ){

                    using (var stream=file.OpenReadStream())// بتمكنلي من اني اقرأ اي ملف جاي من استريم
                    {//  استخدمت يوزينج علشان دي بعد ما اخد الاستريم اللي انا محتاجه بيتم حذفه من الميموري علشان مايخدش مساحه ويعمل بطىء
                           
                            var uploadParams =new ImageUploadParams() // هنا بيتم رفعها على الكلاود
                            {
                                File=new FileDescription(file.Name,stream),
                                Transformation = new Transformation()
                                 .Width(500).Height(500).Crop("fill").Gravity("face") 
                            };

                           
                            uploadResult=_cloudinary.Upload(uploadParams);// دي بترجعلنا كل حاجه اللي هستقبلها ف الانجلر
                    }
                }
                    photoForCreateDto.Url = uploadResult.Uri.ToString();
                    photoForCreateDto.publicId = uploadResult.PublicId;
             var photo = _mapper.Map<Photo>(photoForCreateDto);
            getProductFromDB.Photos.Add(photo);

            if (await _repo.SaveAll())
            {
                var PhotoToReturn =_mapper.Map<PhotoForReturnDto>(photo);

                return CreatedAtRoute("GetPhoto", new { id = photo.Id },PhotoToReturn);
            }

            return BadRequest(" Uploaded Failed  ");
         }


         
         [HttpDelete("{userId}/{productId}/delete/{id}")]
            public async Task<IActionResult> DeletePhoto(string userId,int id,int productId){
                if(userId!=User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    return Unauthorized();
                var productFromBD=await _repo.GetProduct(productId);
                if(!productFromBD.Photos.Any(p=>p.Id==id))
                    return Unauthorized();
                var photo=await _repo.GetPhoto(id);

                if(photo.PublicId!=null){
                    // Delete From Cloudniary
                    var deletePhoto=new DeletionParams(photo.PublicId);
                    var result=this._cloudinary.Destroy(deletePhoto);
                    if(result.Result=="ok"){
                        _repo.Delete(photo);
                    }
                }
                if(photo.PublicId==null){
                    _repo.Delete(photo);
                }
                if(await _repo.SaveAll())
                    return Ok();
                return BadRequest("Delete Photo Fiald");
            }



    }
}
