
namespace Adviser.Application.Common.Exceptions
{
    public class HasBeenReviewedException : Exception
    {
        public HasBeenReviewedException() 
            : base("This user has already reviewed this subject") { }
    }
}
