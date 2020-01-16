using Bussines.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bussines.Service
{
    internal class CategoryService : HttpRequests, ICategoryService
    {
        private readonly ISettings settings;
        public CategoryService(ISettings settings) : base(settings.UrlBaseApi)
        {
            this.settings = settings;
        }

        public IEnumerable<Categories> GetCategories(string sortBy)
        {
            var categorieViewModel = this.Get<CategoryViewModel>("categories");
            if (string.IsNullOrEmpty(sortBy))
                return categorieViewModel.Categories;
            categorieViewModel.Categories = SortCategories(categorieViewModel, sortBy);
            return categorieViewModel.Categories;
        }
        private IEnumerable<Categories> SortCategories(CategoryViewModel categorymModel, string sort)
        {
            var orderByParameter = Expression.Parameter(typeof(Categories));
            var orderByExpression = Expression.Lambda<Func<Categories, IComparable>>(Expression.PropertyOrField(orderByParameter, sort), orderByParameter).Compile();
            return categorymModel.Categories.OrderBy(orderByExpression);
        }
    }
}
