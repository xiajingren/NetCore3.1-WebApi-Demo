using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Common
{
    public static class AppSettings
    {
        public static JwtSetting JwtSetting { get; set; }

        public static void Init(IConfiguration configuration)
        {
            JwtSetting = new JwtSetting();
            configuration.Bind("JwtSetting", JwtSetting);
        }
    }
}
