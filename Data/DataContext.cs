using Microsoft.EntityFrameworkCore;
using RPG_dotnet.Models;

namespace RPG_dotnet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters {get; set; }
    }
}