using Microsoft.EntityFrameworkCore;

namespace Adviser.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
