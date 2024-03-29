﻿using AutoMapper;
using Business.Services.Abstract;
using Business.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.DTOs.Article;
using Model.Entities;

namespace MyBlogProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Article>> GetAllArticles()
        {
            //List<Article> articles = _articleService.GetAllArticles().ToList();

            //List<ArticleGetDto> articleGetDto = new List<ArticleGetDto>();
            
            //_mapper.Map(articles, articleGetDto);

            var articles = _articleService.GetAllArticles(null,"Category").ToList();

            return Ok(articles);
            
        }

        [HttpGet("NonDeleted")]
        public ActionResult<Article> GetAllArticlesNonDeleted()
        {
            var articles = _articleService.GetAllArticlesNonDeleted("Category").ToList();
            return Ok(articles);
        }        



        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public ActionResult<ArticleGetDto> GetById(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("ID 0'dan küçük olamaz");
            }
            var article = _articleService.GetById(Id,"Category");

            if (article == null)
            {
                return NoContent();               
            }


            var articleGetDto = new ArticleGetDto();

            _mapper.Map(article, articleGetDto);

            return Ok(articleGetDto);

        }

        [HttpPost]
        public ActionResult<ArticleGetDto> AddArticle(ArticleForCreationDto AddDto)
        {
            var article = new Article();
            _mapper.Map(AddDto,article);
            _articleService.Insert(article);
            var articleGetDto = new ArticleGetDto();
            _mapper.Map(article, articleGetDto);
            return Ok(articleGetDto);
        }

        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public ActionResult<ArticleUpdateDto> UpdateArticle(ArticleUpdateDto UpdateDto)
        {
            if (UpdateDto.Id <= 0)
            {
                return BadRequest("ID 0'dan küçük olamaz");
            }

            var article = _articleService.GetById(UpdateDto.Id);

            if (article == null)
            {
                return NoContent();
            }
            _mapper.Map(UpdateDto, article);
            _articleService.Update(article);
            return Ok(UpdateDto);
        }

		[ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpPatch("Save")]
        public ActionResult<ArticleUpdateDto> SaveArticle(int id, JsonPatchDocument<Article> patchDocument) 
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            if(id <= 0)
            {
                return BadRequest("Böyle Bir ID Değeri Olamaz");
            }

            var SavedArticle = _articleService.GetById(id);

            if (SavedArticle == null)
            {
                return NoContent();
            }

			patchDocument.ApplyTo(SavedArticle, ModelState);

			_articleService.Update(SavedArticle);

			if (ModelState.IsValid)
				return Ok(SavedArticle);

			return BadRequest();

		}



        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("HardDelete")]
        public ActionResult<ArticleGetDto> HardDelete(int id)
        {
            if(id <= 0)
            {
                return BadRequest("ID 0'dan küçük olamaz");
            }
            var article = _articleService.GetById(id);
            if (article == null)
            {
                return NoContent();
            }

            _articleService.Delete(article);

            ArticleGetDto articleGetDto = new();

            _mapper.Map(_articleService.GetById(id), articleGetDto);

            return Ok(articleGetDto);
        }


		[ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpPatch("SoftDelete")]
        public IActionResult SoftDeletePatch(int id,JsonPatchDocument<Article> patchDocument) 
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }
			if (id <= 0)
			{
				return BadRequest("ID 0'dan küçük olamaz");
			}

			var DeletedArticle = _articleService.GetById(id);
            
            if(DeletedArticle == null)
            {
                return NoContent();
            }
            DeletedArticle.DeletedDate = DateTime.Now;

            patchDocument.ApplyTo(DeletedArticle, ModelState);

            _articleService.Update(DeletedArticle);            

            if (ModelState.IsValid)
                return Ok(DeletedArticle);

            return BadRequest();
        }

       

       



    }
}
