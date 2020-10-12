namespace _6MKT.Identity.Domain.ValueObjects.AppSettings
{
    public interface IAppSettings
    {
        ConnectionStrings ConnectionStrings { get; set; }
        JwtSettings Jwt { get; set; }
    }
}