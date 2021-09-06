using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreAPIWithJWT.IdentityAuth;
using CoreAPIWithJWT.Models;
using CoreAPIWithJWT.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CoreAPIWithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public TestController(IConfiguration configuration, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        [Route("test")]
        public IActionResult TestData()
        {
            return Ok(new Response<NoDataResponse>
            {
                Message = "Authentication completed successfully.",
                Status = "Success"
            });
        }

        /// <summary>
        ///     Easy way to access id's without going to database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getIds")]
        public IActionResult EasyWaytoReachUserIds()
        {
            Dictionary<string, string> Dict = _userManager.Users.ToList()
                .ToDictionary(userManagerUser => userManagerUser.Id.ToString(),
                    userManagerUser => !_userManager.GetRolesAsync(userManagerUser).Result.Contains(UserRoles.Admin)
                    ? UserRoles.User
                    : UserRoles.Admin);

            return Ok(Dict);
        }
    }
}
