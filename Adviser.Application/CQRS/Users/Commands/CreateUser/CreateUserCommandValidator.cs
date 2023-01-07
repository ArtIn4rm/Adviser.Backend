using FluentValidation;

namespace Adviser.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.Name).NotEmpty().MaximumLength(40).Matches(@"[A-Za-z]([A-Za-z\-|_0-9])*");
            RuleFor(createUserCommand =>
                createUserCommand.Email).NotEmpty().MaximumLength(30).Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            RuleFor(createUserCommand =>
                createUserCommand.Password).NotEmpty();
        }
    }
}
