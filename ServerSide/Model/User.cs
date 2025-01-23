using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerSide.Model
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [Required ,MaxLength(100)]
        public required string Name { get; set; }

        [Required,EmailAddress,MaxLength(100)]
        public required string Email { get; set; }

        [Required ,MinLength(8),MaxLength(255)]
        public required string Password { get; set; } 

        public ICollection<Build> Builds { get; set; } = new List<Build>();
    }
}
