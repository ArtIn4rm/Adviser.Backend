using FluentValidation;

namespace Adviser.Application.CQRS.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
    {
        public DeleteReviewCommandValidator()
        {
            RuleFor(deleteReviewCommand => 
                deleteReviewCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
