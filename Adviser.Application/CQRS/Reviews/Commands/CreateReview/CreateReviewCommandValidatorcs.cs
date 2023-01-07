using Adviser.Domain;
using FluentValidation;

namespace Adviser.Application.CQRS.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidatorcs : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidatorcs()
        {
            RuleFor(createReviewCommand =>
                (Group)createReviewCommand.GroupId).NotEmpty().IsInEnum();
            RuleFor(createReviewCommand =>
                createReviewCommand.AuthorMark).NotEmpty().LessThanOrEqualTo(1).GreaterThanOrEqualTo(0);
        }
    }
}
