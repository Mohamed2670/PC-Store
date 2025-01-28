using System.ComponentModel.DataAnnotations;

namespace ServerSide.Dto.ProductDtos
{
    public class ProductReadDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public required int CategoryId { get; set; }
        public required decimal CurrentPrice { get; set; }
        [Required]
        public required int StoreId { get; set; }
        public string ImageUrl { get; set; } = "";
        [Required]
        public required string ProductUrl { get; set; }
    }
}