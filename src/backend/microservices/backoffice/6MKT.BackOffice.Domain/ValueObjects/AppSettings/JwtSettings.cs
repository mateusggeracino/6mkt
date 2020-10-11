namespace _6MKT.BackOffice.Domain.ValueObjects.AppSettings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Origin { get; set; }
        public string ValidatedAt { get; set; }
        public int ExpireIn { get; set; }
    }
}