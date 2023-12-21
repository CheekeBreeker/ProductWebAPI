namespace ProductCore.Models
{
    public class ProductGetAllDto
    {
        public List<ProductGetDto> Products { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
