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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                ID = 1,
                FileName = "ASP.NET Core Image",
                FileType = "Jpg",
                IsDeleted=false                                         

            },

             new Image
             {
                 ID = 2,
                 FileName = "Redis Deneme Makalesi",
                 FileType = "png",
                 IsDeleted = false
             },

            new Image
            {
                ID = 3,
                FileName = "Docker Deneme Makalesi",
                FileType="png",
                IsDeleted=false
            });

            
            
        }
    }
}
