using Business.Services.Abstract;
using Business.Services.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));

            services.AddScoped<ICategoryDal, CategoryRepository>();

            services.AddScoped<IArticleService, ArticleService>();

            services.AddScoped<IArticleDal, ArticleRepository>();

            services.AddAutoMapper(assembly);

            return services;          
           
        }

    }
}
