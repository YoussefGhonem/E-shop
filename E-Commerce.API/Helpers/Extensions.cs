using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace E_Commerce.API.Helpers
{
   //2- setting Production Mood
   
    public static class Extensions
    {
         //التعامل مع الاخطاء الجزء 5
       public static void AddApplicationError(this HttpResponse response,string message){

           response.Headers.Add("Application-Error",message);
           response.Headers.Add("Access-Control-Expose-Headers","Application-Error");
           response.Headers.Add("Access-Control-Allow-Origin","*");

       } 

    }
}