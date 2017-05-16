using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Speech.Models
{
    public class SpeechDbContext : IdentityDbContext<ApplicationUser>
    {
        public SpeechDbContext()
        {
        }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Speech;integrated security=True");
        }
        public SpeechDbContext(DbContextOptions<SpeechDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}