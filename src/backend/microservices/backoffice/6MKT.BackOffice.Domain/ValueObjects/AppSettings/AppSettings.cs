namespace _6MKT.BackOffice.Domain.ValueObjects.AppSettings
{
    public class AppSettings : IAppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public JwtSettings Jwt { get; set; }
        public EnpointsSettings Endpoints { get; set; }
    }
}