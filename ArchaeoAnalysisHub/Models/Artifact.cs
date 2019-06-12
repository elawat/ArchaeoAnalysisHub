using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class Artifact
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Artifact name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int ArtifactTypeId { get; set; }
        public ArtifactType ArtifactType { get; set; }
        public ApplicationUser Owner { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public bool IsPublic { get; set; }
        public string Country { get; set; }
        public string Site { get; set; }
        public IEnumerable<Sample> Samples { get; set; }
    }
}