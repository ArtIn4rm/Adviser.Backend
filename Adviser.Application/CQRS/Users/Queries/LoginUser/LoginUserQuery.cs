using MediatR;

namespace Adviser.Application.CQRS.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<Guid>
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
