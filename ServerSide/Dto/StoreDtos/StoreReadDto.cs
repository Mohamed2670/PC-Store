using System.ComponentModel.DataAnnotations;

namespace ServerSide.Dto.StoreDtos
{
    public class StoreReadDto
    {
        public int Id { get; set; }
        [Required , MaxLength(100)]

        public required string Name { get; set; }
    }
}