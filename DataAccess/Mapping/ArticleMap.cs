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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                ID = 1,
                Title = "AspNet Core Deneme Makalesi",
                Content = "AspNet Core Deneme Makalesi Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eget posuere " +
                "magna. Phasellus pulvinar ultrices maximus. Maecenas non porta ligula. In ac dui sollicitudin," +
                " elementum felis vitae, viverra diam. Donec ut dolor eu dolor mattis tristique. Sed commodo eu" +
                " justo rutrum condimentum. Sed dolor tellus, bibendum sit amet erat ac, auctor facilisis nulla." +
                " Mauris feugiat enim sed eros tincidunt, a finibus ex iaculis. Pellentesque habitant morbi tristique" +
                " senectus et netus et malesuada fames ac turpis egestas. Etiam mattis sit amet" +
                " tellus at placerat. Nulla sagittis condimentum tortor, tincidunt tincidunt erat dictum at. Cras" +
                " sit amet mi leo. Sed eu risus cursus, congue metus eu, convallis ante. Maecenas ac luctus tellus" +
                ", a iaculis velit. Vestibulum porta accumsan nulla, ut ultricies neque pellentesque vitae. Duis nisl tellus," +
                " interdum vel rhoncus in, condimentum quis erat.\r\n\r\nQuisque vitae porta metus. Integer laoreet porta ligula " +
                "vitae pharetra. Donec pharetra, ipsum in pellentesque auctor, urna turpis feugiat erat, non aliquam lacus odio id nunc." +
                " Curabitur porta in lacus id " +
                "blandit. Nullam lorem dolor, lacinia in varius sed, consequat sollicitudin urna. Nulla facilisi",

                CategoryId = 1,
              


                IsDeleted = false
            },
             new Article
             {
                 ID = 2,
                 Title = "Redis Deneme Makalesi",
                 Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eget posuere " +
                "magna. Phasellus pulvinar ultrices maximus. Maecenas non porta ligula. In ac dui sollicitudin," +
                " elementum felis vitae, viverra diam. Donec ut dolor eu dolor mattis tristique. Sed commodo eu" +
                " justo rutrum condimentum. Sed dolor tellus, bibendum sit amet erat ac, auctor facilisis nulla." +
                " Mauris feugiat enim sed eros tincidunt, a finibus ex iaculis. Pellentesque habitant morbi tristique" +
                " senectus et netus et malesuada fames ac turpis egestas. Etiam mattis sit amet" +
                " tellus at placerat. Nulla sagittis condimentum tortor, tincidunt tincidunt erat dictum at. Cras" +
                " sit amet mi leo. Sed eu risus cursus, congue metus eu, convallis ante. Maecenas ac luctus tellus" +
                ", a iaculis velit. Vestibulum porta accumsan nulla, ut ultricies neque pellentesque vitae. Duis nisl tellus," +
                " interdum vel rhoncus in, condimentum quis erat.\r\n\r\nQuisque vitae porta metus. Integer laoreet porta ligula " +
                "vitae pharetra. Donec pharetra, ipsum in pellentesque auctor, urna turpis feugiat erat, non aliquam lacus odio id nunc." +
                " Curabitur porta in lacus id " +
                "blandit. Nullam lorem dolor, lacinia in varius sed, consequat sollicitudin urna. Nulla facilisi",

             
                 CategoryId = 2,
                 IsDeleted = false
             },

            new Article
            {
                ID = 3,
                Title = "Docker Deneme Makalesi",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eget posuere " +
                "magna. Phasellus pulvinar ultrices maximus. Maecenas non porta ligula. In ac dui sollicitudin," +
                " elementum felis vitae, viverra diam. Donec ut dolor eu dolor mattis tristique. Sed commodo eu" +
                " justo rutrum condimentum. Sed dolor tellus, bibendum sit amet erat ac, auctor facilisis nulla." +
                " Mauris feugiat enim sed eros tincidunt, a finibus ex iaculis. Pellentesque habitant morbi tristique" +
                " senectus et netus et malesuada fames ac turpis egestas. Etiam mattis sit amet" +
                " tellus at placerat. Nulla sagittis condimentum tortor, tincidunt tincidunt erat dictum at. Cras" +
                " sit amet mi leo. Sed eu risus cursus, congue metus eu, convallis ante. Maecenas ac luctus tellus" +
                ", a iaculis velit. Vestibulum porta accumsan nulla, ut ultricies neque pellentesque vitae. Duis nisl tellus," +
                " interdum vel rhoncus in, condimentum quis erat.\r\n\r\nQuisque vitae porta metus. Integer laoreet porta ligula " +
                "vitae pharetra. Donec pharetra, ipsum in pellentesque auctor, urna turpis feugiat erat, non aliquam lacus odio id nunc." +
                " Curabitur porta in lacus id " +
                "blandit. Nullam lorem dolor, lacinia in varius sed, consequat sollicitudin urna. Nulla facilisi",

          
                CategoryId = 3,
                IsDeleted = false
            }

            );


        }
    }
}
