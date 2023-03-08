using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                ID = 1,
                Name = "ASP.NET Core",                
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },

            new Category
            {
                ID = 2,
                Name = "Redis",                
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category
            {
                ID=3,
                Name="Docker",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }

            );
        }
    }
}
