using API_REST_GAME_PROJECT.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST_GAME_PROJECT.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

    }
}
