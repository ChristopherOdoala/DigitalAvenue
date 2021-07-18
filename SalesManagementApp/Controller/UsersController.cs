using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SalesManagementApp.Core.Helpers;
using SalesManagementApp.Core.Models;
using SalesManagementApp.Core.Services.Interfaces;
using SalesManagementApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Controller
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;


        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserViewModel UserViewModel)
        {
            var user = _userService.Authenticate(UserViewModel.Username, UserViewModel.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Username),
                    new Claim("Id", user.Id.ToString())

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromForm] UserViewModel UserViewModel)
        {
            // map dto to entity
            var user = _mapper.Map<User>(UserViewModel);

            try
            {
                // save 
                _userService.Create(user, UserViewModel.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var UserViewModels = _mapper.Map<IList<UserViewModel>>(users);
            return Ok(UserViewModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var UserViewModel = _mapper.Map<UserViewModel>(user);
            return Ok(UserViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserViewModel UserViewModel)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(UserViewModel);
            user.Id = id;

            try
            {
                // save 
                _userService.Update(user, UserViewModel.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("changepassword")]
        public IActionResult ChangePassword([FromForm] UserViewModel UserViewModel, string newPassword)
        {
            if (string.IsNullOrEmpty(UserViewModel.Password))
                return Ok("Old password should be entered");
            var res = _userService.ChangePassword(UserViewModel, newPassword);
            if (res.Any())
                return Ok(res);

            return Ok("You Have updated your password");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

    }
}
