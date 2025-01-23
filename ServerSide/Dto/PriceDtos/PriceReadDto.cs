using System.ComponentModel.DataAnnotations;

namespace ServerSide.Dto.PriceDtos
{
    public class PriceReadDto
    {
        [Required, Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Value { get; set; } = 0;
        [Required]
        public required int ProductId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}