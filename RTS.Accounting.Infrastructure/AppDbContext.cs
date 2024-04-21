using Microsoft.EntityFrameworkCore;
using RTS.Accounting.Domain.Entities;

namespace RTS.Accounting.Application
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Document> Documents { get; set; }
    }
}
