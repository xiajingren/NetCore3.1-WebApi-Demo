namespace WebApiDemo.Common
{
    public class JwtSetting
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireSeconds { get; set; }
    }
}