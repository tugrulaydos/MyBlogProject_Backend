using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Article:Entity
    {

       
        public string Title { get; set; }

        public string Content { get; set; }

        public int? ViewCount { get; set; } = 0;

        public int CategoryId { get; set; }

        public int ImageId { get; set; }
       
        public string? PhotoPath { get; set; }

        public Category Category { get; set; }

    }
}
