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
    public class Category:Entity
    {
       
        public string Name { get; set; }

       
        public ICollection<Article> Articles { get; set; }


    }
}
