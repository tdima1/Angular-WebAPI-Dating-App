using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      private readonly IAuthRepository _authRepository;

      public AuthController(IAuthRepository authRepository)
      {
         _authRepository = authRepository;
      }

      [HttpPost("register")]
      public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
      {
         //validate request

         userForRegisterDTO.Username = userForRegisterDTO.Username.ToLower();
         if (await _authRepository.UserExists(userForRegisterDTO.Username)) {
            return BadRequest("Username already exists");
         }

         var userToCreate = new User() {
            Username = userForRegisterDTO.Username
         };

         var createdUser = await _authRepository.Register(userToCreate, userForRegisterDTO.Password);
         return StatusCode(201);
      }

    }
}