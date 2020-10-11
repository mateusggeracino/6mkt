namespace _6MKT.Identity.Domain.ValueObjects.AppSettings
{
    public class AppSettings : IAppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public JwtSettings Jwt { get; set; }
    }
}