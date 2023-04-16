﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs.Article
{
    public class ArticleUpdateDto
    {
        public int Id { get; set; }

        public string Title { get; set; }   

        public string Content { get; set; }

        public string? PhotoPath { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

       
    }
}
