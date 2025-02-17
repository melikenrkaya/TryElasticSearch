using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TryElasticSearch.Data.Entity;

namespace TryElasticSearch.Data.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } // Ürünler tablosu

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
