using Business.Services.Abstract;
using DataAccess.Abstract;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class ArticleService:IArticleService
    {
        private readonly IArticleDal _articleDal;
        public ArticleService(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public int Delete(Article entity)
        {           
           

            return _articleDal.Delete(entity);
        }

        public IEnumerable<Article> GetAllArticles(Expression<Func<Article, bool>> expression = null, params string[] IncludeList)
        {
            return _articleDal.GetAll(expression, IncludeList);
        }

        public IEnumerable<Article> GetAllArticlesNonDeleted(params string[] inclueList)
        {
            return _articleDal.GetAll(x=>x.IsDeleted==false,inclueList);
        }

        public Article GetById(int id, params string[] IncludeLists)
        {
            return _articleDal.Get(x=>x.ID==id, IncludeLists);
        }

        public Article Insert(Article entity)
        {
            return _articleDal.Insert(entity);
        }

        public void SoftDelete(int Id)
        {
            var article = GetById(Id);
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            _articleDal.Update(article);
        }

        public int Update(Article entity)
        {
            return _articleDal.Update(entity);
            
        }
    }
}
