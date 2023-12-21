using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCore.Models;
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private ProductAppContext _context;

        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, ProductAppContext context) 
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public void Put([FromBody] ProductAddDto model)
        {
            var product = _mapper.Map<ProductAddDto, Product>(model);

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Post(ProductEditDto product)
        {
            var existProduct = _context.Products.FirstOrDefault(x => x.Id == product.Id);

            if(existProduct != null)
            {
                _mapper.Map(product, existProduct);

                _context.Products.Update(existProduct);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetOne")]
        public ProductGetDto? Get(int id)
        {
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(x => x.Id == id);

            if (product == null) return null;
            return ProductGetDto(product);
        }

        [HttpPost]
        [Route("GetAll")]
        public ProductGetAllDto GetAll([FromBody] ProductFilterDto filter)
        {
            var query = _context.Products.AsQueryable();

            if(filter.Name != null)
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }

            if (filter.Description != null)
            {
                query = query.Where(x => x.Description.Contains(filter.Description));
            }

            if (filter.CategoryId != null)
            {
                query = query.Where(x => x.CategoryId == filter.CategoryId);
            }

            var products = query.ToList()
                .Select(product => ProductGetDto(product))
                .ToList();

            var model = new ProductGetAllDto
            {
                Products = products,
                Categories = _context.Categories.Select(x => new CategoryDto { Id = x.Id, Name = x.Name }).ToList()
            };

            return model;
        }

        private ProductGetDto ProductGetDto(Product product)
        {
            var result = _mapper.Map<ProductGetDto>(product);

            return result;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}