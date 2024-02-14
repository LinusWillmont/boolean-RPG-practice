using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RpgApi.Enums;
using RpgApi.Models;
using System.Collections.Generic;

namespace RpgApi.Data
{
    public class RpgContext : IdentityUserContext<Player>
    {
        public DbSet<Player> UsersDB { get; set; }
        public DbSet<Character> CharacterDB { get; set; }

        public RpgContext(DbContextOptions<RpgContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hasher = new PasswordHasher<Player>();
            modelBuilder.Entity<Player>().HasData(new Player
            {
                Id = "80c8b6b1-e2b6-45e8-b044-8f2178a90111", // primary key
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "string"),
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com".ToUpper(),
                Role = Roles.Admin
            });

        }
    }
}
