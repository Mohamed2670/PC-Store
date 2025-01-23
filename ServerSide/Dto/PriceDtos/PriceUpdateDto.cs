using System.ComponentModel.DataAnnotations;

namespace ServerSide.Dto.PriceDtos
{
    public class PriceUpdateDto
    {
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Value { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}