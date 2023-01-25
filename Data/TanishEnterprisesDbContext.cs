using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TanishEnterprisesBackend.Models;

namespace tanish_enterprises_backend.Data
{
    public class TanishEnterprisesDbContext : DbContext
    {
        public TanishEnterprisesDbContext(DbContextOptions<TanishEnterprisesDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}