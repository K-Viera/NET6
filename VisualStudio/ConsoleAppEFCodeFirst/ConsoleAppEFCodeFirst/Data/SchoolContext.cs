using ConsoleAppEFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleAppEFCodeFirst.Data
{
    public class SchoolContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COMEDLAP0003\\SQLEXPRESS;Initial Catalog=newDatabase;Integrated Security=true;MultipleActiveResultSets=true;");
        }

        public DbSet<Course>? courses { get; set; }
        public DbSet<Student>? students { get; set; }
    }
}
