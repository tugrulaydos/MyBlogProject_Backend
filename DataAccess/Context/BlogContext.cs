
using DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class BlogContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-D80M3PV;Database=MyBlog;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryMap()); //Data Seed.

            modelBuilder.ApplyConfiguration(new ArticleMap());

           
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Article> Articles { get; set; }

     


    }
}
