using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class ArtifactType
    {
        public int Id { get; set; }
        [Display(Name = "Artifact type")]
        public string Name { get; set; }
    }
}