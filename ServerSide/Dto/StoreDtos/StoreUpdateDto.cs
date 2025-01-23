using System.ComponentModel.DataAnnotations;

namespace ServerSide.Dto.StoreDtos
{
    public class StoreUpdateDto
    {
        [Required , MaxLength(100)]

        public required string Name { get; set; }
    }
}