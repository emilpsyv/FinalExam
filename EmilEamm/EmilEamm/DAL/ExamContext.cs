using EmilEamm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EmilEamm.DAL
{
    public class ExamContext : IdentityDbContext
    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Setting> Setting { get; set; }
    }
}
