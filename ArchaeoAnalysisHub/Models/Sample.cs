using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class Sample
    {
        [Key]
        [Display(Name ="Sample id")]
        public int Id { get; set; }
        [Display(Name = "Analysed")]
        public bool IsAnalysed { get; set; }
        [Required]
        public int ArtifactId { get; set; }
        public Artifact Artifact { get; set; }
        [Required]
        public int SampleTypeId { get; set; }
        public SampleType SampleType { get; set; }
        public ICollection<Analysis> Analyses { get; set; }
        public ApplicationUser Owner { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public bool IsPublic { get; set; }
        public IEnumerable<Artifact> Artifacts { get; set; }
        public IEnumerable<SampleType> SampleTypes { get; set; }
    }
}