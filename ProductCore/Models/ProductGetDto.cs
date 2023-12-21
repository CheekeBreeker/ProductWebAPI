namespace ProductCore.Models
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
