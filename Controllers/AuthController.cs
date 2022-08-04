using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_POC.Data;
using API_POC.DTOs.User;
using Microsoft.AspNetCore.Mvc;


namespace API_POC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
           _authRepo = authRepo;
        } 
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<List<int>>>> Register(UserRegisterDto request)
        {
            var response=await _authRepo.Register(
                new User{UserName=request.UserName},request.Password
            );

            if(!response.Success)
            {
               return BadRequest(response);
            }
            
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> login(UserLoginDto request)
        {
            var response=await _authRepo.Login(
                request.UserName,request.Password
            );

            if(!response.Success)
            {
               return BadRequest(response);
            }
            
            return Ok(response);
        }
    }
}