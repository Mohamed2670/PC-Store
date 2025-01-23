using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerSide.Model
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [Required ,MaxLength(100)]
        public required string Name { get; set; }
        public required Role Role { get; set; } = Role.User;
        public int StoreId = 0;

        [Required,EmailAddress,MaxLength(100)]
        public required string Email { get; set; }

        [Required ,MinLength(8),MaxLength(255)]
        public required string Password { get; set; } 

        public ICollection<Build> Builds { get; set; } = new List<Build>();
    }
}
