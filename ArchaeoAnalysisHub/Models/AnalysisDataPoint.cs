using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class AnalysisDataPoint
    {
        [Key]
        public int Id { get; set; }
        public string Symbol { get; set; }
        public double ResultInPercentage { get; set; }
        [Required]
        public int AnalysisId { get; set; }
        public Analysis Analysis { get; set; }
    }
}