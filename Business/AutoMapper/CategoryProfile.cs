
using AutoMapper;
using Model.DTOs.Category;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>();               

            CreateMap<CategoryUpdateDto, Category>();
                




        }
    }
}
