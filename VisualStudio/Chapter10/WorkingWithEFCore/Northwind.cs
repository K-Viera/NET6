using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // DbContext, DbContextOptionsBuilder
using static System.Console;

namespace Packt.Shared
{
    internal class Northwind : DbContext
    {
        protected override void OnConfiguring(
          DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=COMEDLAP0003\\SQLEXPRESS;" +
        "Initial Catalog=Northwind;" +
        "Integrated Security=true;" +
        "MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connection);
        }
        //these properties map to tables in the database
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //example of using Fluent API instead of attibutes
            //to limit the length of a category name to 15
            modelBuilder.Entity<Category>()
                .Property(category=>category.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
            // global filter to remove discontinued products
            modelBuilder.Entity<Product>()
              .HasQueryFilter(p => !p.Discontinued);
        }
    }
}
