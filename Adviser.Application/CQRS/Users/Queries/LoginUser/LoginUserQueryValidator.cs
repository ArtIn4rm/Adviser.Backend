using FluentValidation;

namespace Adviser.Application.CQRS.Users.Queries.LoginUser
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.Email).NotEmpty().MaximumLength(30).Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            RuleFor(createUserCommand =>
                createUserCommand.Password).NotEmpty();
        }
    }
}
