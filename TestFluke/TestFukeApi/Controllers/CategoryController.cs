using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestFukeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index(string sortBy)
        {
            return Ok(categoryService.GetCategories(sortBy));
        }
    }
}