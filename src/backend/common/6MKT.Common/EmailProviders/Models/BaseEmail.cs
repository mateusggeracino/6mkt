namespace _6MKT.Common.EmailProviders.Models
{
    public abstract class BaseEmail
    {
        public string ToEmail { get; set; }
        public string ToName { get; set; }
    }
}