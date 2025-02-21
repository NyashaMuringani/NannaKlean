using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NannaKlean.Models;

namespace NannaKlean.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NannaKlean.Models.Contact> ContactModel { get; set; } = default!;
        public DbSet<NannaKlean.Models.ResCleanDetail> ResCleanDetail { get; set; } = default!;
    }
}
