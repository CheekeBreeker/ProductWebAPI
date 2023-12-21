using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCore.Models;
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private ProductAppContext _context;

        public CategoryController(ProductAppContext context) 
        {
            _context = context;
        }

        [HttpPut]
        public void Put([FromBody] Category group)
        {
            _context.Categories.Add(group);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Post(Category category)
        {
            var existGroup = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == category.Id);

            if(existGroup != null)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetOne")]
        public Category? Get(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("GetAll")]
        public List<Category> GetAll([FromBody] CategoryFilterDto categoryFilt)
        {
            var query = _context.Categories.AsQueryable();

            if(categoryFilt.Id != null)
            {
                query = query.Where(x => x.Id == categoryFilt.Id);
            }

            if(categoryFilt.Name != null)
            {
                query = query.Where(x => x.Name.Contains(categoryFilt.Name));
            }

            return query.ToList();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var group = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (group != null)
            {
                _context.Categories.Remove(group);
                _context.SaveChanges();
            }
        }
    }
}