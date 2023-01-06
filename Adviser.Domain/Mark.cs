
namespace Adviser.Domain
{
    public class Mark
    {
        public Guid UserId { get; set; }

        public Guid ReviewId { get; set; }

        public float UserMark { get; set; }

        public bool IsLiked { get; set; }
    }
}
