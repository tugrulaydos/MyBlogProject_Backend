using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Article:Entity
    {

       
        public string Title { get; set; }

        public string Content { get; set; }

        public int? ViewCount { get; set; } = 0;

        public int CategoryId { get; set; }

      
       
        public string? PhotoPath { get; set; }

        [JsonIgnore]
		[IgnoreDataMember]
        public Category Category { get; set; }

    }
}
