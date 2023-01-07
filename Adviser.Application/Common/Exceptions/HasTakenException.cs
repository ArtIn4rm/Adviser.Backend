
namespace Adviser.Application.Common.Exceptions
{
    public class HasTakenException : Exception
    {
        public HasTakenException(string name) 
            : base($"{name} has been taken") { }
    }
}
