using AutoMapper;
using Model.DTOs.Article;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleGetDto>();
            CreateMap<ArticleForCreationDto, Article>();
            CreateMap<ArticleUpdateDto,Article>();
        }
       

    }
}
