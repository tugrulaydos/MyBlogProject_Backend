using AutoMapper;
using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Model.DTOs.Category;
using Model.Entities;
using System.Net.Http.Headers;

namespace MyBlogProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public List<Category> GetAllCategories() 
        {        

            var CategoryList = _categoryService.GetAllCategories().ToList();            
                          
            return CategoryList;

        }

        [HttpGet("NonDeleted")]
        public List<Category> GetAllCategoriesNonDeleted()
        {
            var CategoryList = _categoryService.GetAllCategoriesNonDeleted().ToList();

            return CategoryList;
        }


        [ProducesResponseType(typeof(Category),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public ActionResult<CategoryGetDto> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Sıfır ve Sıfırdan küçük Id Olamaz");
            }

            var category = _categoryService.GetById(id);

            if (category == null)
            {
                return NoContent();
            }           

            var categoryGetDto = new CategoryGetDto();

            _mapper.Map(category, categoryGetDto); //Source, Destination

            //categoryGetDto.CategoryName = category.Name;
            //categoryGetDto.ID = category.ID;
            //categoryGetDto.IsDeleted = category.IsDeleted;

            return categoryGetDto;

        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryGetDto),200)]
        public ActionResult<CategoryGetDto> AddCategory(CategoryForCreationDto Dto)
        {
            Category category = new();
            
            category.Name = Dto.Name;
            
            _categoryService.Insert(category);

            var categoryGetDto = new CategoryGetDto();
            _mapper.Map(category,categoryGetDto);

            //categoryGetDto.CategoryName=category.Name;
            //categoryGetDto.ID = category.ID;

            return Ok(categoryGetDto);

        }


        [HttpPut]
        public ActionResult<CategoryGetDto> UpdateCategory(CategoryUpdateDto Dto) 
        {
            if (Dto.ID <= 0)
            {
                return BadRequest("Id Değeri Sıfır ve Sıfırdan küçük olamaz");
            }
            if (_categoryService.GetById(Dto.ID) == null)
            {
                return NoContent();
            }

            Category category = new Category();
            _mapper.Map(Dto, category);

            //category.Name=Dto.Name;
            //category.ID = Dto.ID;
            //category.ModifiedDate = Dto.ModifiedDate;
            //category.IsDeleted= Dto.IsDeleted;

            _categoryService.Update(category);

            return Ok(Dto);

        }

        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("HardDelete")]
        public ActionResult<Category> DeleteCategory(int Id) 
        {
            if (Id <= 0)
            {
                return BadRequest("Id Değeri Sıfır ve Sıfırdan küçük olamaz");
            }

            var category = _categoryService.GetById(Id);

            if(category == null)
            {
                return NoContent();
            }

            _categoryService.Delete(category);

            return Ok(category);

        }

        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("SoftDelete")]
        public ActionResult<Category> SoftDeleteCategory(int Id) 
        {
            if (Id <= 0)
            {
                return BadRequest("Id Değeri Sıfır ve Sıfırdan küçük olamaz");
            }          

            else if (_categoryService.GetById(Id) == null)
            {
                return NoContent();
            }

            _categoryService.SoftDelete(Id);           

            return Ok(_categoryService.GetById(Id));

        }

    }
}
