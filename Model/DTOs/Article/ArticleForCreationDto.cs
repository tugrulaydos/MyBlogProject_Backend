using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs.Article
{
    public class ArticleForCreationDto
    {        
        public string Title { get; set;}
        public string Content { get; set;}  
        
        public int CategoryId { get; set;}

        public string? PhotoPath { get; set; }

       
    }
}
