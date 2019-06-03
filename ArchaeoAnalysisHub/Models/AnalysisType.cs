using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class AnalysisType
    {
        public int Id { get; set; }
        [Display(Name = "Analysis type")]
        public string Name { get; set; }
    }
}