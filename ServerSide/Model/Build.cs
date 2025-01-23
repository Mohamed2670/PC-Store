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
        public int? CpuId { get; set; }
        public int? GpuId { get; set; }
        public int? MotherBoardId { get; set; }
        public int? RamId { get; set; }
        public int? CaseId { get; set; }
        public int? PowerSupplyId { get; set; }
        public int? HddId { get; set; }
        public int? SddId { get; set; }

    }

}