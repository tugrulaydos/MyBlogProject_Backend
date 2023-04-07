using AutoMapper;
using Business.Services.Abstract;
using Business.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
		[HttpPatch("Save")]
		public IActionResult SavePatch(int id, JsonPatchDocument<Category> patchDocument)
		{
			if (patchDocument == null)
			{
				return BadRequest();
			}
			if (id <= 0)
			{
				return BadRequest("ID 0'dan küçük olamaz");
			}

			var SavedCategory = _categoryService.GetById(id);
			if (SavedCategory == null)
			{
				return NoContent();
			}

			patchDocument.ApplyTo(SavedCategory, ModelState);

			_categoryService.Update(SavedCategory);

			if (ModelState.IsValid)
				return Ok(SavedCategory);

			return BadRequest();
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

        //[ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpDelete("SoftDelete")]
        //public ActionResult<Category> SoftDeleteCategory(int Id) 
        //{
        //    if (Id <= 0)
        //    {
        //        return BadRequest("Id Değeri Sıfır ve Sıfırdan küçük olamaz");
        //    }          

        //    else if (_categoryService.GetById(Id) == null)
        //    {
        //        return NoContent();
        //    }

        //    _categoryService.SoftDelete(Id);           

        //    return Ok(_categoryService.GetById(Id));

        //}

		[ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpPatch("SoftDelete")]
		public IActionResult SoftDeletePatch(int id, JsonPatchDocument<Category> patchDocument)
		{
			if (patchDocument == null)
			{
				return BadRequest();
			}
			if (id <= 0)
            {
				return BadRequest("ID 0'dan küçük olamaz");
			}

			var DeletedCategory = _categoryService.GetById(id);
			if (DeletedCategory == null)
			{
				return NoContent();
            }

			patchDocument.ApplyTo(DeletedCategory, ModelState);

			_categoryService.Update(DeletedCategory);

			if (ModelState.IsValid)
				return Ok(DeletedCategory);

			return BadRequest();
		}

	}
}
