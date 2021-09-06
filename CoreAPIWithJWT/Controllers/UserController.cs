using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreAPIWithJWT.IdentityAuth;
using CoreAPIWithJWT.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreAPIWithJWT.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IConfiguration configuration, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [Route("getUsers")]
        public IActionResult GetAllUsers([FromQuery] int? offset, [FromQuery] int limit = 100)
        {
            List<UserResponseModel> users = new();
            _userManager.Users
                .Skip(offset ?? 0)
                .Take(limit)
                .ToList()
                .ForEach(u =>
                    users.Add(_mapper.Map<UserResponseModel>(u)));

            return users.Any()
                ? Ok(new Response<List<UserResponseModel>>
                {
                    Message = "Authentication completed successfully.",
                    Status = "Success",
                    Data = users
                })
                : Ok(new Response<NoDataResponse>
                {
                    Message = "No user found.",
                    Status = "Error"
                });
        }

        [Authorize]
        [HttpGet]
        [Route("getUserWithId")]
        public IActionResult GetUserWithId([FromQuery] string id)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == id);

            return user != null
                ? Ok(new Response<UserResponseModel>
                {
                    Message = "Authentication completed successfully.",
                    Status = "Success",
                    Data = _mapper.Map<UserResponseModel>(user)
                })
                : Ok(new Response<NoDataResponse>
                {
                    Message = "No user found.",
                    Status = "Error"
                });
        }

        [Authorize]
        [HttpGet]
        [Route("getUserWithMail")]

        public IActionResult GetUserWithMail([FromQuery] string email)
        {
            List<UserResponseModel> users = new();

            var user = _userManager.Users.Where(u => u.Email == email).ToList();

                user.ForEach(u =>
                users.Add(_mapper.Map<UserResponseModel>(u)));

            return user != null
                ? Ok(new Response<List<UserResponseModel>>
                {
                    Message = "Authentication completed successfully.",
                    Status = "Success",
                    Data = users
                })
                : Ok(new Response<NoDataResponse>
                {
                    Message = "No user found.",
                    Status = "Error"
                });
        }
    }
}