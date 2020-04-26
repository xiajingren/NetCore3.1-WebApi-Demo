using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Common;
using WebApiDemo.Dto;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    /// <summary>
    /// 鉴权
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService userService;

        public TokenController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="loginParameter"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost(Name = nameof(Login))]
        public async Task<ActionResult<BaseDto<object>>> Login([FromBody]LoginParameter loginParameter)
        {
            var user = await userService.GetUserAsync(loginParameter.UserName, loginParameter.Password);
            if (user != null)
            {
                var token = AppHelper.Instance.GetToken(user);
                BaseDto<object> dto = new BaseDto<object>(Dto.StatusCode.Success, "", new { token });
                return Ok(dto);
            }
            return Ok(new BaseDto<object>(Dto.StatusCode.Error, "", null));
        }
    }
}