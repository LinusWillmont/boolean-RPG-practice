using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RpgApi.Models;

namespace RpgApi.Data
{
    public class RpgContext : IdentityUserContext<Player>
    {
        public DbSet<Player> UsersDB { get; set; }

        public RpgContext(DbContextOptions<RpgContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
