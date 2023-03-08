using Business.Services.Abstract;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public int Delete(Category entity)
        {
             return _categoryDal.Delete(entity);           
        }

        public IEnumerable<Category> GetAllCategories(Expression<Func<Category, bool>> expression = null, params string[] IncludeList)
        {
            return _categoryDal.GetAll(expression, IncludeList);
        }

        public Category GetById(int id, params string[] IncludeList)
        {
            return _categoryDal.Get(x=>x.ID==id, IncludeList);
        }

        public Category Insert(Category entity)
        {
            return _categoryDal.Insert(entity);           
        }

        public void SoftDelete(int Id)
        {
            var category = GetById(Id);
            category.IsDeleted = true;
            Update(category);
           
        }

        public int Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }
    }
}
