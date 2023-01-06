
namespace Adviser.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public DateTime RegistrationDate { get; set; }

        public long NumberOfLikes { get; set; }

        public bool IsAdmin { get; set; }
    }
}
