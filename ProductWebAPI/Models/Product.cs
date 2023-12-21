using ProductCore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Category))]    
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
