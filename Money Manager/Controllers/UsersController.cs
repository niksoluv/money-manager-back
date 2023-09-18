﻿using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Money_Manager.Models;
using Money_Manager.Services;

namespace Money_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IRepositoryWrapper _wrapper;
        UserService userService;
        public UsersController(IRepositoryWrapper wrapper, 
            ILogger<UsersController> logger)
        {
            this.userService = new UserService(wrapper, logger);
            this._wrapper = wrapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var currentUser = await _wrapper.User.GetByUsername(User.Identity.Name);
            if (currentUser.Role == "Admin")
            {
                var users = _wrapper.User.FindAll();
                return Ok(users);
            }
            return Forbid("You don't have acces for this resource");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            User user = await _wrapper.User.FindByCondition(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
                return Ok("User Id: " + id.ToString());
            return NotFound("Such user does not exists");
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var existingUser = await _wrapper.User.FindByCondition(u => u.UserName == user.UserName).FirstOrDefaultAsync();
            if (existingUser==null)
            {
                await _wrapper.User.Create(user);
                await _wrapper.SaveAsync();
                UserModel userModel = new UserModel() { Username= user.UserName, Password=user.Password };
                var token = await userService.GetToken(userModel);
                return Ok(new { token, user });
            }
            return Ok("User with this username already exists");
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var token = await this.userService.GetToken(login);
            var user = _wrapper.User.FindByCondition(u => u.UserName == login.Username);

            if (token != null)
            {
                response = Ok(new {token, user});
            }

            return response;
        }
        [HttpPost("info")]
        public async Task<IActionResult> Info()
        {
            string username = User.Identity.Name;
            User user = await _wrapper.User.FindByCondition(x => x.UserName == username).FirstOrDefaultAsync();
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound("There is no info");
        }
    }
}
