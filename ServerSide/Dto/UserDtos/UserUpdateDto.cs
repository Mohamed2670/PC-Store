using System.ComponentModel.DataAnnotations;

namespace ServerSide.Dto.UserDtos
{
    public class UserUpdateDto
    {
        [MaxLength(100)]
        public string? Name { get; set; }

        [EmailAddress, MaxLength(100)]
        public string? Email { get; set; }

        [MinLength(8), MaxLength(255)]
        public string? Password { get; set; }
    }
}