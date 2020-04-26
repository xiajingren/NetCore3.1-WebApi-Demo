using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApiDemo.Common;
using WebApiDemo.Dto;
using WebApiDemo.Models;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 所有用户
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<BaseDto<IEnumerable<User>>>> Get()
        {
            var users = await userService.GetUserAsync();
            BaseDto<IEnumerable<User>> dto = new BaseDto<IEnumerable<User>>(Dto.StatusCode.Success, "", users);
            return Ok(dto);
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        /// <returns></returns>
        [Route("me")]
        [HttpGet]
        public async Task<ActionResult<BaseDto<User>>> UserInfo()
        {
            string id = User.FindFirst("id")?.Value;
            var user = await userService.GetUserAsync(Guid.Parse(id));
            BaseDto<User> dto = new BaseDto<User>(Dto.StatusCode.Success, "", user);
            return Ok(dto);
        }

        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<BaseDto<User>>> Get(Guid id)
        {
            var user = await userService.GetUserAsync(id);
            BaseDto<User> dto = new BaseDto<User>(Dto.StatusCode.Success, "", user);
            return Ok(dto);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="loginParameter"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseDto<User>>> Add(LoginParameter loginParameter)
        {
            var user = await userService.AddUserAsync(loginParameter.UserName, loginParameter.Password);
            BaseDto<User> dto = new BaseDto<User>(Dto.StatusCode.Success, "", user);
            return Ok(dto);
        }
    }

    public class LoginParameter
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

}