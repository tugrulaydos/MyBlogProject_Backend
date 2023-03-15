using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface ICategoryService
    {
        int Delete(Category entity);

        public Category GetById(int id,params string[] IncludeLists);

        public IEnumerable<Category> GetAllCategories(Expression<Func<Category,bool>> expression=null, params string[] IncludeList);

        public Category Insert(Category entity);

        public int Update(Category entity);

        public void SoftDelete(int Id);

        public IEnumerable<Category> GetAllCategoriesNonDeleted();

    }
}
