using E4A.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace E4A.Api.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Movies> Movie { get; set; }
    }
}
