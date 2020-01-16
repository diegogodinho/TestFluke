using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Categories> GetCategories(string sortBy);
    }
}
