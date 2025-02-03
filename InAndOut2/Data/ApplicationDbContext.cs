using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InAndOut2.Models;

namespace InAndOut2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InAndOut2.Models.Item> Item { get; set; } = default!;
        public DbSet<InAndOut2.Models.expense> expense { get; set; } = default!;
        public DbSet<InAndOut2.Models.ExpenseType> ExpenseType { get; set; } = default!;
    }
}
