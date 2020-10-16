namespace _6MKT.Identity.Domain.ValueObjects.Tokens
{
    public class Token
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public string TypeUser { get; set; }
    }
}