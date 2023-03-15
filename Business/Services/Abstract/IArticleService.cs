using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IArticleService
    {
        int Delete(Article entity);

        public Article GetById(int id, params string[] IncludeLists);

        public IEnumerable<Article> GetAllArticles(Expression<Func<Article, bool>> expression = null, params string[] IncludeList);

        public IEnumerable<Article> GetAllArticlesNonDeleted(params string[] inclueList);

        public Article Insert(Article entity);

        public int Update(Article entity);

        public void SoftDelete(int Id);

    }
}
