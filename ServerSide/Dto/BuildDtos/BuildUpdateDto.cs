using System.ComponentModel.DataAnnotations;

namespace ServerSide.Dto.BuildDtos
{
    public class BuildUpdateDto
    {
        public int Id { get; set; }
        [ MaxLength(100)]
        public string? Name { get; set; }

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