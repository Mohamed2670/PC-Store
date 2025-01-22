using System.ComponentModel.DataAnnotations;

namespace ServerSide.Model
{
    public class Store
    {
        public int Id { get; set; }
        [Required , MaxLength(100)]

        public required string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}