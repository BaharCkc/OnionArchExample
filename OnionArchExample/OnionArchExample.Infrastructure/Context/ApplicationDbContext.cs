using Microsoft.EntityFrameworkCore;
using OnionArchExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchExample.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Pen", Value = 10, Quantity = 100 },
                new Product() { Id = Guid.NewGuid(), Name = "Book", Value = 30, Quantity = 500 },
                new Product() { Id = Guid.NewGuid(), Name = "Paper", Value = 1, Quantity = 200 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
