using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class SampleType
    {
        public int Id { get; set; }
        [Display(Name = "Sample type")]
        public string Name { get; set; }
    }
}