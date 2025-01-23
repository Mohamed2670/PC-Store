using System.ComponentModel.DataAnnotations;

namespace ServerSide.Dto.UserDtos
{
    public class UserReadDto
    {
        [Required, MaxLength(100)]
        public required string Name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public required string Email { get; set; }

        [Required, MinLength(8), MaxLength(255)]
        public required string Password { get; set; }
    }
}