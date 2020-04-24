using Microsoft.IdentityModel.Tokens;
using WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Common
{
    public class AppHelper
    {
        public readonly static AppHelper Instance = new AppHelper();

        private AppHelper()
        {

        }

        public string GetToken(User user)
        {
            //创建用户身份标识，可按需要添加更多信息
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.ID.ToString(), ClaimValueTypes.Integer32), // 用户id
                new Claim("name", user.UserName), // 用户名
                //new Claim("admin", user.IsAdmin.ToString(),ClaimValueTypes.Boolean) // 是否是管理员
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JwtSetting.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //创建令牌
            var token = new JwtSecurityToken(
              issuer: AppSettings.JwtSetting.Issuer,
              audience: AppSettings.JwtSetting.Audience,
              signingCredentials: creds,
              claims: claims,
              notBefore: DateTime.Now,
              expires: DateTime.Now.AddSeconds(AppSettings.JwtSetting.ExpireSeconds)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

    }
}
