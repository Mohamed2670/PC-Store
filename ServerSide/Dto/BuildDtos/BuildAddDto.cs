using System.ComponentModel.DataAnnotations;

namespace ServerSide.Dto.BuildDtos
{
    public class BuildAddDto
    {
        [Required ,MaxLength(100)]
        public required  string Name { get; set; }
        [Required]
        public required int UserId { get; set; }
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