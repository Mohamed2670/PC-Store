using System.ComponentModel.DataAnnotations;

namespace ServerSide.Model
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public required int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required]

        public required string Name { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]

        public required decimal CurrentPrice { get; set; }
        [Required]
        public required int StoreId { get; set; }
        public Store? Store { get; set; }
        public string ImageUrl { get; set; } = "";
        [Required]
        public required string ProductUrl { get; set; }
        public ICollection<Price> Prices { get; set; } = new List<Price>();

    }
}