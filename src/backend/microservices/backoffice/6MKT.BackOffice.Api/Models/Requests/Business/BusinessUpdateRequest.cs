namespace _6MKT.BackOffice.Api.Models.Requests.Business
{
    public class BusinessUpdateRequest
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string RegisteredNumber { get; set; }
        public string TradeName { get; set; }
    }
}