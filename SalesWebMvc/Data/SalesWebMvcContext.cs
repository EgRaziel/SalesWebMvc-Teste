using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o relacionamento entre SalesRecord e Seller
            modelBuilder.Entity<SalesRecord>()
                .HasOne(s => s.Seller)
                .WithMany(s => s.Sales)
                .OnDelete(DeleteBehavior.Restrict); // Isso impede a exclusão se houver vendas
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}