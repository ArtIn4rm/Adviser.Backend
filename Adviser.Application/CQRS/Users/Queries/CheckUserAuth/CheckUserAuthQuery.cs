using MediatR;

namespace Adviser.Application.CQRS.Users.Queries.CheckUserAuth
{
    public class CheckUserAuthQuery : IRequest
    {
        public Guid Id { get; set; }
    }
}
