using System.ComponentModel.DataAnnotations;

namespace ServerSide.Model
{
    public class Price : IEntity
    {
        public int Id { get; set; }
        [Required ,Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Value { get; set; } = 0;
        [Required]
        public required int ProductId { get; set; }
        public Product? Product { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}