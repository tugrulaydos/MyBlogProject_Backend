﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs.Article
{
    public class ArticleGetDto
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; } 
        
        public int ImageId { get; set; }       


    }
}
