namespace WebApiDemo.Common
{
    /// <summary>
    /// jwt配置对象
    /// </summary>
    public class JwtSetting
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireSeconds { get; set; }
    }
}