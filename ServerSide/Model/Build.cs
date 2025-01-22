using System.ComponentModel.DataAnnotations;

namespace ServerSide.Model
{
    public class Build
    {
        public int Id { get; set; }
        [Required ,MaxLength(100)]
        public required  string Name { get; set; }
        [Required]
        public required int UserId { get; set; }
        public User? User { get; set; }
        [MaxLength(100)]
        public string? Cpu { get; set; }
        [MaxLength(100)]
        public string? Gpu { get; set; }
        [MaxLength(100)]
        public string? MotherBoard { get; set; }
        [MaxLength(100)]
        public string? Ram { get; set; }
        [MaxLength(100)]
        public string? Case { get; set; }
        [MaxLength(100)]
        public string? PowerSupply { get; set; }
        [MaxLength(100)]
        public string? Hdd { get; set; }
        [MaxLength(100)]
        public string? Sdd { get; set; }

    }

}