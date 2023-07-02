namespace EMS.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime? DateJoined { get; set; }
    }
}