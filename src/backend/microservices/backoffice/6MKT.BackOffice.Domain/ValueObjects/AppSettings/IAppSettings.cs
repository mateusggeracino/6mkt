namespace _6MKT.BackOffice.Domain.ValueObjects.AppSettings
{
    public interface IAppSettings
    {
        ConnectionStrings ConnectionStrings { get; set; }
        JwtSettings Jwt { get; set; }
        EnpointsSettings Endpoints { get; set; }
    }
}