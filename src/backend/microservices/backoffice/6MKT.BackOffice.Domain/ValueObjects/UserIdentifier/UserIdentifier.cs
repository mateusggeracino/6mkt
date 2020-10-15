namespace _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier
{
    public class UserIdentifier : IUserIdentifier
    {
        public long Id { get; set; }
        public string Type { get; set; }
    }
}