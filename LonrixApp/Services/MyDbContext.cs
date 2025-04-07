using LonrixApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LonrixApp.Services
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; } = null!;
    }
}
